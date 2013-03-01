
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using MonoTorrent.BEncoding;
using MonoTorrent.Client.Encryption;
using MonoTorrent.Client.Tracker;
using MonoTorrent.Dht;
using MonoTorrent.Dht.Listeners;
using MonoTorrent.Common;
using MonoTorrent.Client;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;

namespace horriblegrabs
{
	
	
	
	

	public partial class MainForm : Form
	{
		
		public static int maxpageparse = 1000;
		
		public static bool no_0tors = false;
		public static bool no_0series = false;
		
		
		
		
		public string getAppSetting(string key)
		{
			string result="";
			Configuration config = ConfigurationManager.OpenExeConfiguration(
				System.Reflection.Assembly.GetExecutingAssembly().Location);
			try{
				result = config.AppSettings.Settings[key].Value;
			}
			catch
			{
			}
			return result;
		}

		public void setAppSetting(string key, string value)
		{
			Configuration config = ConfigurationManager.OpenExeConfiguration(
				System.Reflection.Assembly.GetExecutingAssembly().Location);
			if (config.AppSettings.Settings[key] != null)
			{
				config.AppSettings.Settings.Remove(key);
			}
			config.AppSettings.Settings.Add(key, value);
			config.Save(ConfigurationSaveMode.Modified);
		}

		
		public void loadSettings()
		{
			string tempst = getAppSetting("activedown");
			if(tempst!="")
				numericUpDown2.Value = Convert.ToDecimal(tempst);
			
			tempst = getAppSetting("maxdownspeed");
			if(tempst!="")
				numericUpDown3_down.Value = Convert.ToDecimal(tempst);
			
			tempst = getAppSetting("maxupspeed");
			if(tempst!="")
				numericUpDown4_up.Value = Convert.ToDecimal(tempst);
			
			tempst = getAppSetting("bitport");
			if(tempst!=""){
				MonoTorrent.maintor.listenport = Convert.ToInt32(tempst);
				numericUpDownPort.Value = Convert.ToDecimal(tempst);
			}

			
			tempst = getAppSetting("completedpath");
			if(tempst!=""){
				MonoTorrent.maintor.completedPath = tempst;
				textBox4.Text = tempst;
			}
			
			tempst = getAppSetting("keepseeding");
			if(tempst!=""){
				bool tbool = false;
				if(tempst.Contains("rue"))
				{
					tbool=true;
				}
				MonoTorrent.maintor.keepseeding = tbool;
				checkBox3.Checked = tbool;
			}
			
			
			
			tempst = getAppSetting("releasegroups");
			releasegroup.loadRGdata(tempst);
			
			tempst = getAppSetting("watchlisttokens");
			loadWatchlistTokens(tempst);
			
			
		}


		public void saveSettings()
		{
			setAppSetting("activedown", numericUpDown2.Value.ToString());
			setAppSetting("maxdownspeed", numericUpDown3_down.Value.ToString());
			setAppSetting("maxupspeed", numericUpDown4_up.Value.ToString());
			setAppSetting("bitport", numericUpDownPort.Value.ToString());
			
			setAppSetting("keepseeding", checkBox3.Checked.ToString());
			
			
			setAppSetting("completedpath", MonoTorrent.maintor.completedPath);
			setAppSetting("releasegroups", releasegroup.encodedRGdata());
			setAppSetting("watchlisttokens",getWatchlistTokens());

		}
		
		
		public Thread threadLoadtorrents;
		public Thread threadpushtorrents;
		
		
		void carefullypushtorrents()
		{
			
			if(threadpushtorrents!=null)
			{
				if(threadpushtorrents.IsAlive==true)
					return; //sorry, can't push now.
			}
			
			threadpushtorrents = null;
			threadpushtorrents = new Thread(new ThreadStart(MonoTorrent.maintor.pushTorrents)); //very, very unsafe, WILL cause problems sooner or later TOFIX
			threadpushtorrents.Start();
			
		}
		
		
		public MainForm()
		{
			
			InitializeComponent();
			loadSettings();
			
			
			
			rgtreebox.TreeViewNodeSorter = new NodeSorter();
			
			refreshRGdrops();
			refreshWatchlistChecklist();
			
			
			string oldtext = notifyIcon1.Text;
			

			
			var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			var buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan( TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
			                                                              TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)
			string date = "Alpha 7\nRevision "+version.Build.ToString()+"."+version.Revision.ToString()+"\nBuild date: "+buildDateTime.ToShortDateString()+"";
			
			label6.Text = "Debug release version\n\n"+date;
			

			
			notifyIcon1.Text ="Loading torrents, please wait...";
			
			

			tabPage2.Visible=false;
			threadLoadtorrents = null;
			threadLoadtorrents = new Thread(new ThreadStart(MonoTorrent.maintor._maintor)); //very, very unsafe, WILL cause problems sooner or later TOFIX
			threadLoadtorrents.Start();
			

			notifyIcon1.Text = oldtext;
			
		}
		
		public MemoryStream fromURL(string durl)
		{
			WebClient client = new WebClient();
			byte[] arr = client.DownloadData(durl);
			
			MemoryStream memoryStream = new MemoryStream(arr);
			
			return memoryStream;
		}
		
		public static bool breakparse = false;
		
		public List<string> getContent(string furl)
		{
			List<string> outlist = new List<string>();
			
			try{
				using (StreamReader sr = new StreamReader(fromURL(furl)))
				{
					String line;
					while ((line = sr.ReadLine()) != null)
					{
						if(line.Contains("No torrents found."))breakparse=true;
						
						string[] _lines = line.Split('<');
						
						foreach(string _spl in _lines)
						{
							if(_spl.Length > 6)
							{
								outlist.Add("<"+_spl);
							}
						}
					}
				}
			}
			catch( Exception e)
			{
				Program.handleExceptions(e);
			}
			return outlist;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		public static string toSimplestring(string inp)
		{
			string result="";
			
			inp = inp.ToLower();
			
			string validchars ="abcdefghijklmnopqrstuvwxyz";
			
			for(int i=0;i<inp.Length;i++)
			{
				if(validchars.Contains(inp[i].ToString()))
				{
					result+=inp[i];
				}
			}
			
			return result;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		

		
		
		
		public void updateViewGroups()
		{
			try
			{
				List<string[]> slist = new List<string[]>();
				HashSet<string> nowitems = new HashSet<string>();
				HashSet<string> nowlistitems = new HashSet<string>();
				
				int colnum = 7;
				
				
				
				foreach(TorrentManager manager in MonoTorrent.maintor.torrents)
				{
					string[] tstr= new string[colnum];
					//tstr[0] = manager.State.ToString();
					tstr[0] = manager.Torrent.Name;
					
					
					tstr[5]=manager.State.ToString();
					if(tstr[5].Contains("topp") == false )
					{
						
						tstr[1] = manager.Progress.ToString("0.0")+"%";
						if(tstr[1]=="0.0%" || tstr[1]=="0,0%")tstr[1]="";

						
						int fullsize= (int)(manager.Torrent.Size/(1024*1024));
						int partsize= (int)(manager.Progress*0.01 * fullsize);
						//	tstr[2] = (manager.Monitor.DataBytesDownloaded/1024).ToString()+"/"+ .ToString();
						tstr[2] = partsize+" / "+fullsize;
						
						
						
						tstr[3] = ((double)manager.Monitor.DownloadSpeed/1024).ToString("0");
						if(tstr[3]=="0")
						{
							tstr[3] = ((double)manager.Monitor.DownloadSpeed/1024).ToString("0.000");
						}
						if(tstr[3]=="0.000" || tstr[3]=="0,000")tstr[3]="";
						
						//	tstr[4] = manager.Peers.Seeds+"/"+manager.Peers.Leechs;
						//	if(tstr[4] =="0/0")tstr[4]="";
						tstr[4] = (manager.Peers.Seeds+manager.Peers.Leechs).ToString();
						if(tstr[4] =="0")tstr[4]="";
						
						tstr[6]=  manager.Torrent.TorrentPath;
					}
					else
					{
						tstr[5]="";
					}
					
					nowitems.Add(manager.Torrent.Name);
					
					//sgroups.Add(MonoTorrent.maintor.getcatname( manager.Torrent.TorrentPath));
					
					slist.Add(tstr);
				}
				
				
				//listViewG.BeginUpdate(); // what the hell. this consumes much more resources
				
				
				//remove obsolete items
				for(int i=listViewG.Items.Count-1;i>=0;i--)
				{
					if(nowitems.Contains(listViewG.Items[i].SubItems[0].Text) == false)
					{
						listViewG.Items.RemoveAt(i);
					}
					else
					{
						nowlistitems.Add(listViewG.Items[i].SubItems[0].Text);
					}
				}
				
				
				
				
				for(int i=0;i<slist.Count;i++)
				{
					string[] helper = slist[i];
					
					if(nowlistitems.Contains(helper[0])==false)
					{
						
						ListViewItem item = new ListViewItem(helper);
						item.Name = helper[0];
						string gname = MonoTorrent.maintor.getcatname( helper[6]);

						
						
						bool group_exists = false;
						foreach (ListViewGroup group in listViewG.Groups)
						{
							if (group.Header == gname)
							{
								item.Group = group;
								group_exists = true;
								break;
							}
						}
						if (!group_exists)
						{

							ListViewGroup group = new ListViewGroup(gname);
							listViewG.Groups.Add(group);
							item.Group = group;
						}
						
						
						
						
						listViewG.Items.Add(item);

					}
					
					
					else
					{
						int ix = listViewG.Items.IndexOfKey(helper[0]);
						
						
						
						for(int j=0;j<colnum;j++)
						{
							//if(listViewG.Items[ix].SubItems[j].Text != helper[j])
							
							//	{
							
							listViewG.Items[ix].SubItems[j].Text = helper[j];
							//	}
						}
					}
				}
				
			}catch
			{}
			//	listViewG.EndUpdate();
		}
		
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet=CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);
		
		
		public Bitmap bmp=null;
		int lasticonval=0;
		public void updateNotificationIcon(int pix)
		{
			if(this.WindowState == FormWindowState.Minimized )
			{
				this.ShowInTaskbar=false;
				
			}
			else
			{
				this.ShowInTaskbar=true;
			}
			
			
			if(pix==lasticonval)return;
			
			lasticonval=pix;
			
			if(bmp==null)
			{
				
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
				bmp = ( (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon")).ToBitmap();//new Bitmap(16,16); //( (System.Drawing.Icon)(resources.GetObject("trayIcon.Icon"))).ToBitmap();
				
				
			}
			
			System.Drawing.Graphics ImageGraphics;
			// Create an ImageGraphics Graphics object from bitmap Image

			ImageGraphics =       System.Drawing.Graphics.FromImage(bmp);

		
			Brush brush = new SolidBrush(Color.White);
			Brush brush2 = new SolidBrush(Color.DodgerBlue);

			
			
			ImageGraphics.FillRectangle(brush, 0,0, 6, 32);
			ImageGraphics.FillRectangle(brush2, 1, 32-pix, 4, 32);
			
			
			brush.Dispose();
			brush2.Dispose();
			ImageGraphics.Dispose();
			brush = null;
			brush2 = null;
			ImageGraphics = null;
			
			//
			
			try
			{
					
				IntPtr geth = bmp.GetHicon();
				Icon ticon =  Icon.FromHandle(geth);
				notifyIcon1.Icon = ticon;
				DestroyIcon(ticon.Handle);
				
			}
			catch
			{
				//MessageBox.Show("icon up");
			}
			
			
			
		}
		
		
		
		
		
		int alltimemaxspeed=1;
		
		public void updateView()
		{
			if(checkBox2.Checked==true) //trumps the other setting
			{
				checkBox1.Checked = true;
			}
			
			



			no_0series = checkBox2.Checked;
			no_0tors   = checkBox1.Checked;
			
			
			MonoTorrent.maintor.keepseeding = checkBox3.Checked;
			
			
			MonoTorrent.maintor.engine.Settings.GlobalMaxDownloadSpeed = (int)numericUpDown3_down.Value*1024;
			MonoTorrent.maintor.engine.Settings.GlobalMaxUploadSpeed = (int)numericUpDown4_up.Value*1024;
				
			int speednow = (int)(MonoTorrent.maintor.engine.TotalDownloadSpeed /1024);
			
			if(alltimemaxspeed< speednow)
			{
				alltimemaxspeed = speednow;
			}
			
			toolStripStatusLabel1.Text = (MonoTorrent.maintor.engine.TotalDownloadSpeed /1024)+" KByte/s down, ";
			toolStripStatusLabel1.Text += (MonoTorrent.maintor.engine.TotalUploadSpeed /1024)+" KByte/s up";
			
			toolStripProgressBar1.Maximum =alltimemaxspeed; // MonoTorrent.maintor.torrents.Count * 100;
			try
			{
				toolStripProgressBar1.Value =speednow; //(int)totalprogress;
				
				
				
			}
			catch{}
			
			
			if(tickflip%3==0)
			{
				try
				{
					updateNotificationIcon((int)(((double)speednow / (double)alltimemaxspeed)*32));
				}
				catch
				{}
				
			}
			
			
			
			
			
			
			
			
			if(listViewG.Visible==true &&  this.WindowState != FormWindowState.Minimized)
			{
				updateViewGroups();
			}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		void downloadtorrentfile(string furl, string fname, string catname)
		{
			fname.Replace("__","");
			
			if(fname.Length>80)
			{
				fname = fname.Substring(0,80);
				Random rnd = new Random();
				fname+=rnd.Next(0,10000).ToString();
				
			}
			
			if(catname.Length>50)
			{
				catname = catname.Substring(0,50);
			}
			
			fname = MonoTorrent.maintor.torrentsPath+"\\"+catname+"__"+fname+".torrent";
			
			//	MessageBox.Show(fname);
			
			try
			{
				WebClient client = new WebClient();
				client.DownloadFile(furl, fname);
				
				addTorrenttoHistory(furl);
			}
			catch(Exception e)
			{
				Program.handleExceptions(e);
			}
			
			Application.DoEvents();
		}
		
		
		
		
		
		
		int diskc = 199;
		void showdiskspace()
		{
			diskc++;
			if(diskc<200)return;
			diskc=0;
			try
			{
				DriveInfo c = new DriveInfo(MonoTorrent.maintor.completedPath.Substring(0,1));
				long cAvailableSpace = c.AvailableFreeSpace / (1024*1024*1024);
				
				toolStripStatusLabel2.Text=cAvailableSpace+" GB free";
			}
			catch
			{
				
			}
		}
		
		
		
		
		
		
		static int tickflip=0;
		
		void Timer1Tick(object sender, EventArgs e)
		{
			if(watchlisttokens!=null)
			{
				if(watchlisttokens.Count>0)
				{
					groupBox1.Visible= true;
				}
				else
				{
					groupBox1.Visible=false;
				}
			}
			else
			{
				groupBox1.Visible=false;
			}
			
	
			
			if(MonoTorrent.maintor.engine != null)
			{
			
				
				updateView();
				
				
				tickflip++;
				if(tickflip>8)
				{
					tickflip=0;
					
					MonoTorrent.maintor.maxactive = (int)numericUpDown2.Value;
					MonoTorrent.maintor.housekeepTorrents();
					showdiskspace();
				}
			}
		}
		
		
		
		void clean0tors()
		{
			
			
		}
		
		
		void clean0series()
		{
			try
			{
				
				for(int k=alist.Count-1; k>=0; k--)
				{
					
					for(int j=alist[k].qualis.Count-1;j>=0;j--)
					{
						bool killq = false;
						for(int i= alist[k].qualis[j].tors.Count -1; i>=0; i--)
						{
							if(alist[k].qualis[j].tors[i].seeders == 0)
							{
								if(no_0tors==true)
								{
									alist[k].qualis[j].tors.RemoveAt(i);
								}
								
								killq = true;
							}
							
							
						}
						
						if(killq == true && no_0series == true)
						{
							alist[k].qualis.RemoveAt(j);
						}
						
						else if(alist[k].qualis[j].tors.Count == 0)
						{
							alist[k].qualis.RemoveAt(j);
						}
					}
					
					if(alist[k].qualis.Count == 0)
					{
						alist.RemoveAt(k);
					}
				}
			}catch(Exception e)
			{
				MessageBox.Show(e.ToString());
				}
			
		}
		
		
		
		
		
		
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(t1!=null)
			{
				t1.Abort();
			}
			saveSettings();
			MonoTorrent.maintor.shutdown();
		}
		
	
		
		
		void Button9Click(object sender, EventArgs e)
		{
			
			System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
			objDialog.Description = "Folder for finished downloads";
			objDialog.SelectedPath=textBox4.Text;   
			DialogResult objResult = objDialog.ShowDialog(this);
			if (objResult == DialogResult.OK)
			{
				textBox4.Text = objDialog.SelectedPath;
				MonoTorrent.maintor.completedPath = objDialog.SelectedPath;
			}
			
		}
		
		void ListViewGMouseUp(object sender, MouseEventArgs e)
		{
			
			
			if ((e.Button == MouseButtons.Right) ) //If it's the right button.
			{
				List<string> tokill = new List<string>();
				for(int i=0;i<listViewG.SelectedItems.Count;i++)
				{
					
					tokill.Add(listViewG.SelectedItems[i].SubItems[0].Text);
				}
				
				
				
				ListViewItem lvi =	listViewG.GetItemAt(e.X, e.Y);
				if(lvi != null)
				{
					string viewtokill ="";
					foreach(string st in tokill)
					{
						viewtokill+=st+"\n";
					}
					
					if (MessageBox.Show("Kill torrents?\n\n"+viewtokill,"Confirm Kill", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						
						foreach(string st in tokill)
						{
							MonoTorrent.maintor.killtorrent(st);
						}
					}
					
					
				}
			}
			
			
		}
		
		void NotifyIcon1DoubleClick(object sender, EventArgs e)
		{
			this.BringToFront();//MainForm.BringToFront();
			this.Activate();
			this.WindowState = FormWindowState.Normal;
		}
		

		
		

		
		
		void MainFormResizeEnd(object sender, EventArgs e)
		{
			
		}
		
		void Button10Click(object sender, EventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start(MonoTorrent.maintor.completedPath);
			}
			catch{}
		}
		
		
		
		
		

		
		

		

		

		
		void Infobutton1Click(object sender, EventArgs e)
		{
			string infotext = "1. Go to nyaa.eu, click browse and search for the name of the release group\n";
			infotext+= "2. Click on a promising torrent name to bring up the torrent info\n";
			infotext+= "3. Click on the link next to \"Submitter\"\n";
			infotext+= "4. The URL should end with user=00000\n";
			infotext+= "5. The 00000 part is the UserID. \n";
			
			MessageBox.Show(infotext,"How to get a releasegroup UserID for Nyaa");
		}
		

		
		void Button8Click(object sender, EventArgs e)
		{
			int portnum = (int)numericUpDownPort.Value;
			MonoTorrent.maintor.listenport = portnum;
			MonoTorrent.maintor.changePort(portnum);
		}
	}
	
	
	
	
	
}




namespace System.Windows.Forms
{
	
	//CUSTOM TREEVIEW handles checkboxes correctly
	class MyTreeView : System.Windows.Forms.TreeView {
		protected override void WndProc(ref Message m) {
			// Filter WM_LBUTTONDBLCLK
			if (m.Msg != 0x203) base.WndProc(ref m);
		}
	}

	
	//CUSTOM LISTVIEW prevents flickering when updated
	class ListViewNF : System.Windows.Forms.ListView
	{
		public ListViewNF()
		{
			//Activate double buffering
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

			//Enable the OnNotifyMessage event so we get a chance to filter out
			// Windows messages before they get to the form's WndProc
			this.SetStyle(ControlStyles.EnableNotifyMessage, true);
		}

		protected override void OnNotifyMessage(Message m)
		{
			//Filter out the WM_ERASEBKGND message
			if(m.Msg != 0x14)
			{
				base.OnNotifyMessage(m);
			}
		}
	}
	


}
