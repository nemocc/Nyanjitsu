using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.Drawing;
using System.Threading;
using System.IO;


namespace horriblegrabs
{
	
	
	public partial class MainForm
	{
		List<string> historicTorrentlist;
		string historypath;
		
		SortedSet<string> watchlisttokens;
		
		void watchlistTokenDecode(string inp, out string query, out string quali)
		{
			string[] tmp = inp.Split(new string[] {"||"}, StringSplitOptions.RemoveEmptyEntries);
			query = tmp[0];
			quali = tmp[1];
		}
		
		
		void loadWatchlistTokens(string alltokens)
		{
			string[] tmp = alltokens.Split(new string[] {"§$"}, StringSplitOptions.RemoveEmptyEntries);
			
			watchlisttokens = new SortedSet<string>();
			
			foreach(string str in tmp)
			{
				if(str!="")watchlisttokens.Add(str);
			}
		}
		
		string getWatchlistTokens()
		{
			string result="";
			
			foreach(string str in watchlisttokens)
			{
				if(result!="")result+="§$";
				
				result+=str;
			}
			
			
			return result;
		}
		
		bool isTorrentHistorical(string furl)
		{
			historypath = MonoTorrent.maintor.torrentsPath+"\\history.data";
			
			if(historicTorrentlist==null)
			{
				historicTorrentlist= new List<string>();
				string line;
				try
				{
					System.IO.StreamReader file = new System.IO.StreamReader(historypath);
					while((line = file.ReadLine()) != null)
					{
						line.Replace("\n","");
						historicTorrentlist.Add(line);
					}

					file.Close();
				}
				catch{}
			}
			
			for(int i=0;i<historicTorrentlist.Count;i++)
			{
				if(historicTorrentlist[i] == furl) return true;
			}
			
			return false;
		}
		
		
		
		void addTorrenttoHistory(string furl)
		{
			if(isTorrentHistorical(furl)==false)
			{
				historicTorrentlist.Add(furl);
				using (System.IO.StreamWriter file = new System.IO.StreamWriter(historypath, true))
				{
					file.WriteLine(furl);
					file.Close();
				}
				
				
			}
		}
		
		
		
		void checkWatchlist()
		{
			
			foreach(string wtoken in watchlisttokens)
			{
				
				string qry="";
				string qual="";
				List<singletor> temptors = new List<singletor>();
				
				watchlistTokenDecode(wtoken, out qry, out qual);
				
				
				for(int i=1;i<maxpageparse;i++)
				{
					statmsg=(i*100)+" candidates found";
					
					parsepage("http://www.nyaa.eu/?page=search&term="+qry+"&offset="+i, temptors);
					
					if(breakparse==true)
					{
						breakparse=false;
						break;
					}
					
				}

				foreach(singletor stor in temptors)
				{
					if(stor.fullseries==qry && stor.quali== qual)
					{
						if(isTorrentHistorical(stor.furl)==false)
						{
							refreshWatchlistChecklist();
							torlist.Add(stor);
						}
					}
				}
				
				
			}
		}
		
		
		void refreshWatchlistChecklist()
		{
			checkedListBoxWatchlist.Items.Clear();
			foreach(string tkn in watchlisttokens)
			{
				checkedListBoxWatchlist.Items.Add(tkn);
			}
		}
		
		
		void Button6Click(object sender, EventArgs e)
		{
			preparelisting();
			
			t1 = null;
			t1 = new Thread(new ThreadStart(checkWatchlist));
			t1.Start();
			
			while(t1.IsAlive)
			{
				waitForlisting();
			}
			
			prepareList(false);
			
			finishlisting();
		}
		
		void Button7Click(object sender, EventArgs e)
		{
			
			
			foreach(string obj in checkedListBoxWatchlist.SelectedItems)
			{
				watchlisttokens.Remove(obj);
			}
			
			refreshWatchlistChecklist();
		}
	}
}
