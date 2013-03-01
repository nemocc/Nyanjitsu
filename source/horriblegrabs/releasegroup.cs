
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Drawing;
using System.Threading;

namespace horriblegrabs
{
	
	public struct releasegroupinfo
	{
		public string rgname;
		public decimal rgid;
	}
	

	
	
	public static class releasegroup
	{
		public static List<releasegroupinfo> mygroups = new List<releasegroupinfo>();
		
		
		
		
		
		//quality functions
		//I mean, all my functions are quality. But these manage the quality detection. Hah.
		public static string qualitokens_encoded="720p|480p|1080p|360p|1920x|1280x|720x|848x|704x|480x|10bit|8bit|Complete|Vol.|Soundtrack";
		public static string[] qualitokens;
		
		public static void decodeQualities(bool force)
		{
			if(qualitokens != null && force==false) return;
			qualitokens=null;
			
			qualitokens = qualitokens_encoded.Split('|');
		}
		
		
		public static string encodeQualitokens() //for appsetting storage
		{
			string result="";
			
			foreach(string tt in qualitokens)
			{
				if(result.Length>0){result+="|";}
				result+=tt;
			}
			return result;
		}
		
		
		public static string getQuality(string inp)
		{
			decodeQualities(false);
			
			string result="unknown quality";
			
			foreach(string tt in qualitokens)
			{
				if(inp.Contains(tt))
				{
					return tt;
				}
			}
			return result;
		}
		
		
		
		public static void deleteRG(string rgname, decimal rgid)
		{
			if(rgid==0 || rgname=="")return; // stupid bastard
			
			for(int i=mygroups.Count-1;i>=0;i--)
			{
				if(mygroups[i].rgid== rgid && mygroups[i].rgname==rgname)
				{
					mygroups.RemoveAt(i);
					break;
				}
			}
		}
		
		public static void editRG(string rgname, decimal rgid)
		{
			if(rgid==0 || rgname=="")return; // fuck you, idiot!
			
			int idx=-1;
			
			for(int i=0;i<mygroups.Count;i++)
			{
				if(mygroups[i].rgid== rgid || mygroups[i].rgname==rgname)
				{
					idx=i;
					
					releasegroupinfo trgi = new releasegroupinfo();
					trgi.rgname = rgname;
					trgi.rgid = rgid;
					mygroups[i] = trgi;
					
					break;
				}
			}
			if(idx==-1)
			{
				releasegroupinfo trgi = new releasegroupinfo();
				trgi.rgname = rgname;
				trgi.rgid = rgid;
				mygroups.Add(trgi);
			}
		}
		
		public static string encodedRGdata()
		{
			string result="";
			
			foreach(releasegroupinfo rgi in mygroups)
			{
				if(result!="")
				{
					result+="||";
				}
				result+= rgi.rgname+"$$"+rgi.rgid;
			}
			
			return result;
		}
		
		public static void loadRGdata(string inp)
		{
			if(inp=="")
			{
				//have some defaults.
				inp="Commie$$76430||HorribleSubs$$64513||Hatsuyuki$$32137||FFF$$73859||GG$$9001||Evetaku$$56890||UTW$$71629";
				
			}
			
			
			string[] splitinp = inp.Split( new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries);
			
			foreach(string spstr in splitinp)
			{
				if(spstr.Contains("$$"))
				{
					try
					{
						string sname = spstr.Substring(0, spstr.IndexOf("$"));
						string sid = spstr.Substring( spstr.LastIndexOf("$")+1);
						

						
						releasegroupinfo trgi = new releasegroupinfo();
						trgi.rgname = sname;
						trgi.rgid = Convert.ToDecimal(sid);
						
						
						mygroups.Add(trgi);
					}
					catch(Exception e)
					{
						MessageBox.Show(e.ToString());
					}
				}
			}
			
		}
		
	}
	
	
	
	
	
	
	
	/* Downloading functions
	 */
	
	
	
	public partial class MainForm
	{
		
		
		
		bool isNum(char test)
		{
			string nums = "0123456789";
			return nums.Contains(test.ToString());
		}
		
		


		//This is supposed to get the series name of ANY torrent you throw at it. Will return original torrent name on failure.
		string rg_getseriesname(string inp)
		{

			//we're going to assume that every episode number looks like " 00 " or " 000 "
			//and that the name of the series ends where the episode number starts
			//aaaaand we won't use regex because we're real men ( TOFIX )
			
			//remove file extension
			if(inp[inp.Length-4]=='.')
			{
				inp = inp.Substring(0, inp.Length-4);
				inp+=" ";
			}

			
			inp = inp.Replace(" OP "," 00 ");
			inp = inp.Replace(" ED "," 00 ");
			inp = inp.Replace(" OP1 "," 00 ");
			inp = inp.Replace(" ED1 "," 00 ");
			inp = inp.Replace(" OP2 "," 00 ");
			inp = inp.Replace(" ED2 "," 00 ");
			inp = inp.Replace(" OP3 "," 00 ");
			inp = inp.Replace(" ED3 "," 00 ");
			
			inp = inp.Replace("OVA ","00 ");
			inp = inp.Replace("Vol. ","0");
			inp = inp.Replace("Vol.","0");
			inp = inp.Replace("Volume ","0");
			inp = inp.Replace("v2"," "); //fuck you
			inp = inp.Replace("v3"," "); //I hate you
			
			
			inp = inp.Replace("_"," ");
			inp = inp.Replace(" - "," ");
			inp = inp.Replace("."," ");
			

			
			//clean everything in brackets. No regex! I spit in your face!
			//But DON'T clean releasegroup names.
			string inp2 = inp;
			inp="";
			bool inbracket=false;
			
			int startat=0;
			//check for releasegroup bracket
			if(inp2[0]=='[')
			{
				int closingbracket = inp2.IndexOf(']'); //this will die on names like [[[[[.mkv, I don't care
				inp+=inp2.Substring(0,closingbracket+1);
				startat = closingbracket;
			}
			
			if(inp.Length<4)return inp;//don't bother
			
			for(int i=startat;i<inp2.Length;i++)
			{
				if(inp2[i] =='[' || inp2[i] =='(' || inp2[i] =='{')
				{
					inbracket=true;
				}
				else if(inp2[i] ==']' || inp2[i] ==')' || inp2[i] =='}')
				{
					inbracket=false;
				}
				else
				{
					if(inbracket ==false)
					{
						inp += inp2[i];
					}
				}
			}
			//	MessageBox.Show(inp+"|");
			int idx=0;
			bool foundit=false;
			try
			{
				for(int i=2;i<inp.Length-4;i++)
				{
					//find episode numbers like 00
					idx++;
					
					if(inp[i]==' ' && isNum(inp[i+1]) && isNum(inp[i+2]) && inp[i+3]==' ')
					{
						foundit=true;
						break;
					}
					
					//find episode numbers like 000
					else if(inp[i]==' ' && isNum(inp[i+1]) && isNum(inp[i+2]) && isNum(inp[i+3]) && inp[i+4]==' ')
					{
						foundit=true;
						break;
					}
				}
				
				if(foundit==false)
				{
					idx=0;
					for(int i=2;i<inp.Length-3;i++)
					{
						//find episode numbers like 0 (only if really desperate)
						idx++;
						if(inp[i]==' ' && isNum(inp[i+1]) && inp[i+2]==' ')
						{
							foundit=true;
							break;
						}
						
					}
				}
			}catch(Exception e){MessageBox.Show(e.ToString());}
			if(foundit==false)
			{
				// I give up. No episode number found, probably a movie or single release
				return inp;
				
			}
			
			
			string result=inp.Substring(0,idx+1);
			
			while(result.Contains("  ")) //remove excessive whitespace
			{
				result = result.Replace("  "," ");
			}
			
			
			
			return result.Trim();
		}
		
		
		void rg_startparse( )
		{
			decimal rgid = thread_rgid;
			
			for(int i=1;i<maxpageparse;i++)
			{
				statmsg=(i*100)+" torrents found";
				
				parsepage("http://www.nyaa.eu/?page=torrents&user="+rgid.ToString()+"&offset="+i, torlist);
				//rg_startparse(""+(i+1), rgid);
				
				if(breakparse==true)
				{
					breakparse=false;
					break;
				}
				
			}
		}
		
		void simplesearch_startparse()
		{
			string qry = thread_query;
			for(int i=1;i<maxpageparse;i++)
			{
				statmsg=(i*100)+" torrents found";
				
				parsepage("http://www.nyaa.eu/?page=search&term="+qry+"&offset="+i, torlist);
				
				if(breakparse==true)
				{
					breakparse=false;
					break;
				}
				
			}
			
			
		}
		
		
		void parsepage( string purl, List<singletor> targetlist)
		{
			List<string> thepage = getContent(purl);
			
			//basic housekeeping and cleaning
			bool dropthis=false;
			bool dropthat=true;
			for(int i=thepage.Count-1;i>=0;i--)
			{
				if(thepage[i].Contains("tlisttheight"))
				{
					dropthis=true;
				}
				if(thepage[i].Contains("tlistpages"))
				{
					dropthat=false;
				}
				
				if(dropthis==true || dropthat==true)
				{
					thepage.RemoveAt(i);
				}
			}
			

			
			singletor temptor = new singletor();
			temptor.fname="";
			temptor.episode="";
			temptor.furl="";
			temptor.leechers=0;
			temptor.seeders=0;
			temptor.quali="";
			temptor.series="";
			
			foreach(string str in thepage)
			{
				
				if(str.Contains("tlistmn"))
				{
					if(temptor.fname!="")
					{
						temptor.fname =  WebUtility.HtmlDecode(temptor.fname);
						
						//	textBox1.Text +=	 temptor.fname+" added\r\n";
						
						temptor.fullseries = rg_getseriesname(temptor.fname);

						temptor.series = toSimplestring(temptor.fullseries);
						
						
						
						temptor.quali = releasegroup.getQuality(temptor.fname);
						
						//nman.addd(temptor);
						//torlist.Add(temptor);
						targetlist.Add(temptor);
						
						temptor.fname="";
						temptor.episode="";
						temptor.furl="";
						temptor.leechers=0;
						temptor.seeders=0;
						temptor.quali="";
						temptor.series="";
					}
					
				}
				
				if(str.Contains("torrentinfo"))
				{
					string _fn = str.Substring(str.IndexOf(">")+1);
					temptor.fname= _fn;
				}
				if(str.Contains("tlistsn"))
				{
					string _fn = str.Substring(str.LastIndexOf(">")+1);
					int _num= Convert.ToInt32(_fn);
					temptor.seeders = _num;
				}
				if(str.Contains("tlistln"))
				{
					string _fn = str.Substring(str.LastIndexOf(">")+1);
					int _num= Convert.ToInt32(_fn);
					temptor.leechers = _num;
				}
				if(str.Contains("page=download"))
				{
					int ustart = str.IndexOf("http");
					int uend = str.LastIndexOf("title=")-2;
					
					string _url = str.Substring(ustart, uend-ustart);
					_url =  WebUtility.HtmlDecode(_url);
					//_url = _url.Replace("#38;","");
					temptor.furl = _url;
				}
				
			}
		}

		void prepareList(bool sortbycount)
		{
			
			foreach(singletor _tor in torlist)
			{
				toAlist(_tor);
			}
			
			
			//	clean0series(); //this will be moved to tree population
			
			
			
			//	SortedSet<string> atitles = new SortedSet<string>();
			
			
			
			foreach(aseries aser in alist)
			{
				TreeNode parent = new TreeNode(aser.title);
				
				int filescount=0;
				
				//string qlevels="";
				foreach(aqseries aq in aser.qualis)
				{
					TreeNode subparent;
					if(aser.qualis.Count>1)
					{
						subparent= new TreeNode(aq.quali+" ("+aq.tors.Count+")");
					}
					else
					{
						subparent = parent;
						subparent.Text +=" ("+aq.tors.Count+")";
					}
					if(sortbycount==true)
					{
						if(parent.Tag!=null)
						{
							parent.Tag= ((int)(parent.Tag) + aq.tors.Count);
						}
						else
						{
							parent.Tag= aq.tors.Count;
						}
					}
					
					int lowestseeders =100;
					
					bool ishealthy=true;
					
					foreach(singletor ctor in aq.tors)
					{
						
						if(ctor.seeders==0)
						{
							ishealthy=false;
						}
						
						if(no_0tors == false || ctor.seeders>0)
						{
							filescount++;
							
							TreeNode tchild = new TreeNode("( "+ctor.seeders +" S) "+ctor.fname);
							tchild.Name= ctor.furl;
							tchild.BackColor = Color.Pink;
							tchild.Tag = ctor;
							
							if(lowestseeders>ctor.seeders)
							{
								lowestseeders=ctor.seeders;
							}
							
							if(ctor.seeders>0)tchild.BackColor = Color.LightYellow;
							if(ctor.seeders>8)tchild.BackColor = Color.LightGreen;
							
							subparent.Nodes.Add(tchild);
						}
					}
					
					if(ishealthy==false && no_0series==true)
					{
						subparent.Nodes.Clear();
					}
					
					subparent.BackColor  = Color.Pink;
					if(lowestseeders>0)subparent.BackColor = Color.LightYellow;
					if(lowestseeders>8)subparent.BackColor = Color.LightGreen;
					
					if(aser.qualis.Count>1 && subparent.Nodes.Count>0)
					{
						
						parent.Nodes.Add(subparent);
					}
					
				}
				
				if(aser.qualis.Count>1)
				{
					parent.Text+=" ("+filescount+")";
				}
				
				if(aser.title!="" && aser.title!=" " && aser.title!="  ") //filter out garbage without title
				{
					if(parent.Nodes.Count>0 )
						rgtreebox.Nodes.Add(parent);
				}
				
			}
			
			rgtreebox.Sort();
		}
		
		
		
		
		
		void preparelisting()
		{
			button1.Enabled=false;
			button2.Enabled=false;
			button5.Enabled=false;
			button6.Enabled=false;
			checkBox1.Enabled=false;
			checkBox2.Enabled=false;
			
			rgtreebox.Nodes.Clear();
			torlist.Clear();
			alist.Clear();
		}
		
		void finishlisting()
		{
			button1.Enabled=true;
			button2.Enabled=true;
			button5.Enabled=true;
			button6.Enabled=true;
			checkBox1.Enabled=true;
			checkBox2.Enabled=true;
			button2.Text = "download selected";
		}
		
		
		void waitForlisting()
		{
			button2.Text = statmsg;
			Thread.Sleep(10);
			Application.DoEvents();
			
		}
		
		public Thread t1;
		public decimal thread_rgid;
		public string thread_query;
		public static volatile string statmsg;
		
		void Button1Click(object sender, EventArgs e)
		{

			preparelisting();
			
			
			thread_rgid = ((ComboboxItem)rgdrop2.SelectedItem).Value;
			
			
			
			t1 = null;
			t1 = new Thread(new ThreadStart(rg_startparse));
			t1.Start();
			
			while(t1.IsAlive)
			{
				waitForlisting();
			}
			
			prepareList(false);
			
			finishlisting();

		}
		
		
		
		
		
		
		
		
		void Button5Click(object sender, EventArgs e)
		{
			preparelisting();
			
			string myquery = textboxSearch.Text;
			if(myquery=="")return; //idiots
			
			myquery.Replace(" ","+");
			myquery = System.Uri.EscapeDataString(myquery);
			
			thread_query = myquery;

			t1 = null;
			t1 = new Thread(new ThreadStart(simplesearch_startparse));
			t1.Start();
			
			
			while(t1.IsAlive)
			{
				waitForlisting();
			}
			
			prepareList(true);
			
			finishlisting();
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			string oldtext = button2.Text;
			button2.Enabled=false;
			button2.Text = "Please wait!";
			
			Application.DoEvents();
			
			getselectedChildren();
			
			t1 = null;
			t1 = new Thread(new ThreadStart(downloadAllTorrentsInList));
			t1.Start();
			
			while(t1.IsAlive)
			{
				waitForlisting();
			}
			
			button2.Text = "Starting torrents...";
			Application.DoEvents();
			
			
			carefullypushtorrents();
			
			button2.Text = oldtext;
			button2.Enabled=true;
		}
		
		
		void RgtreeboxMouseClick(object sender, MouseEventArgs e)
		{
			
			// for watchdog functionality
			if(e.Button == MouseButtons.Right)
			{
				TreeNode anode = rgtreebox.GetNodeAt(e.X, e.Y); // anode... get it?

				try
				{
					singletor thor = (singletor)anode.Tag;
					if (MessageBox.Show("Add this to watchlist?\n"+thor.fullseries+"\nQuality: "+thor.quali,"Add to watchlist", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						
						watchlisttokens.Add(thor.fullseries+"||"+thor.quali);
						refreshWatchlistChecklist();
					}
				}
				catch
				{
				}
			}
		}
	}
	
	
	

	
	
	
	
	
	
	
	
	/* Forms functions
	 */
	
	
	public class ComboboxItem
	{
		public string Text { get; set; }
		public decimal Value { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
	
	
	
	public partial class MainForm
	{
		
		void refreshRGdrops()
		{
			rgdrop1.Items.Clear();
			rgdrop2.Items.Clear();
			
			foreach(releasegroupinfo rgi in releasegroup.mygroups)
			{
				ComboboxItem tcbi = new ComboboxItem();
				tcbi.Text=rgi.rgname;
				tcbi.Value=rgi.rgid;
				rgdrop1.Items.Add(tcbi);
				rgdrop2.Items.Add(tcbi);
				
			}
			
			ComboboxItem tempcbi = new ComboboxItem();
			tempcbi.Text="Add new release group...";
			tempcbi.Value=0;
			rgdrop1.Items.Add(tempcbi);
			
			rgdrop1.SelectedIndex=0;
			rgdrop2.SelectedIndex=0;
		}
		
		
		void Rgdrop1SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				textBoxrgname.Text = ((ComboboxItem)rgdrop1.SelectedItem).Text;
				numericRGid.Value = ((ComboboxItem)rgdrop1.SelectedItem).Value;
				
				if(textBoxrgname.Text.Contains("Add new"))
				{
					textBoxrgname.Text="";
				}
			}
			catch{}
			
		}
		
		
		void RgtreeboxAfterCheck(object sender, TreeViewEventArgs e)
		{
			if(e.Action != TreeViewAction.Unknown)
			{
				if(e.Node.Nodes.Count > 0)
				{
					CheckAllChildNodes(e.Node, e.Node.Checked);
				}
				
				checkchilds();
			}
		}
		
		
		
		void Button3Click(object sender, EventArgs e)
		{
			releasegroup.editRG(textBoxrgname.Text, numericRGid.Value);
			refreshRGdrops();
		}
		
		
		void Button4Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Shank "+textBoxrgname.Text +" fo real mate?","Ey bruv...", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				releasegroup.deleteRG(textBoxrgname.Text, numericRGid.Value);
				refreshRGdrops();
			}
			
		}
		
	}
	
	
}
