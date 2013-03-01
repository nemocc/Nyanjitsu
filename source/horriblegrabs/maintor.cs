
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using MonoTorrent.Common;
using MonoTorrent.Client;
using System.Net;
using System.Diagnostics;
using System.Threading;
using MonoTorrent.BEncoding;
using MonoTorrent.Client.Encryption;
using MonoTorrent.Client.Tracker;
using MonoTorrent.Dht;
using MonoTorrent.Dht.Listeners;
using System.Windows.Forms;

namespace MonoTorrent
{

	public static  class maintor
	{
		
		static string dhtNodeFile;
		static string basePath;
		static string downloadsPath;
		public static string fastResumeFile;
		public static string completedPath;
		public static string torrentsPath;
		public static ClientEngine engine;				// The engine used for downloading
		public static List<TorrentManager> torrents;	// The list where all the torrentManagers will be stored that the engine gives us
	//	static MonoTorrent.Top10Listener listener;			// This is a subclass of TraceListener which remembers the last 20 statements sent to it
		
		public static bool keepseeding=false;

		public static void _maintor()
			
		{
			/* Generate the paths to the folder we will save .torrent files to and where we download files to */
			
			basePath = Environment.CurrentDirectory;						// This is the directory we are currently in
			torrentsPath = Path.Combine(basePath, "Torrents");				// This is the directory we will save .torrents to
			downloadsPath = Path.Combine(basePath, "Downloads");			// This is the directory we will save downloads to
			completedPath = Path.Combine(basePath, "Completed");
			fastResumeFile = Path.Combine(torrentsPath, "fastresume.data");
			dhtNodeFile = Path.Combine(basePath, "DhtNodes");
			torrents = new List<TorrentManager>();							// This is where we will store the torrentmanagers
		//	listener = new Top10Listener(10);

			// We need to cleanup correctly when the user closes the window by using ctrl-c
			// or an unhandled exception happens
			//	Console.CancelKeyPress += delegate { shutdown(); };
			//	AppDomain.CurrentDomain.ProcessExit += delegate { shutdown(); };
			//	AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e) { Console.WriteLine(e.ExceptionObject); shutdown(); };
			//	Thread.GetDomain().UnhandledException += delegate(object sender, UnhandledExceptionEventArgs e) { Console.WriteLine(e.ExceptionObject); shutdown(); };

			StartEngine();
		}

	//	public static TorrentManager manager;
		
		
		
		
		
		
		public static void pushTorrents()
		{
			Torrent torrent = null;
			int maxtorrents = 200;
			foreach (string file in Directory.GetFiles(torrentsPath))
			{
				if(maxtorrents>0)
				{
					maxtorrents--;
				TorrentManager manager;
				if (file.EndsWith(".torrent"))
				{
					try
					{
						// Load the .torrent from the file into a Torrent instance
						// You can use this to do preprocessing should you need to
						torrent = Torrent.Load(file);
						//	Console.WriteLine(torrent.InfoHash.ToString());
					}
					catch (Exception e)
					{
						MessageBox.Show("Couldn't load torrent "+file);
						
					}
					// When any preprocessing has been completed, you create a TorrentManager
					// which you then register with the engine.
					
					
					try
					{
						//manager is a single torrent
						manager = new TorrentManager(torrent, downloadsPath, torrentDefaults);
						if (fastResume.ContainsKey(torrent.InfoHash.ToHex ()))
							manager.LoadFastResume(new FastResume ((BEncodedDictionary)fastResume[torrent.InfoHash.ToHex ()]));
						
						engine.Register(manager);
						torrents.Add(manager);
					}catch{
						
						
					}
					// Store the torrent manager in our list so we can access it later
					
				//	manager.PeersFound += new EventHandler<PeersAddedEventArgs>(manager_PeersFound);
					
				}
			}
			}
			
			
			foreach (TorrentManager manager in torrents)
			{
			/*	// Every time a piece is hashed, this is fired.
				manager.PieceHashed += delegate(object o, PieceHashedEventArgs e) {
					lock (listener)
						listener.WriteLine(string.Format("Piece Hashed: {0} - {1}", e.PieceIndex, e.HashPassed ? "Pass" : "Fail"));
				};

				// Every time the state changes (Stopped -> Seeding -> Downloading -> Hashing) this is fired
				manager.TorrentStateChanged += delegate (object o, TorrentStateChangedEventArgs e) {
					lock (listener)
						listener.WriteLine("OldState: " + e.OldState.ToString() + " NewState: " + e.NewState.ToString());
				};

				// Every time the tracker's state changes, this is fired
				foreach (TrackerTier tier in manager.TrackerManager)
				{
					
					foreach (MonoTorrent.Client.Tracker.Tracker t in tier.Trackers)
					{
						t.AnnounceComplete += delegate(object sender, AnnounceResponseEventArgs e) {
							listener.WriteLine(string.Format("{0}: {1}", e.Successful, e.Tracker.ToString()));
						};
					}
				}*/
				// Start the torrentmanager. The file will then hash (if required) and begin downloading/seeding
				try{
					manager.Start();
					manager.Pause();
				}catch{}
			}
			
			
		}
		
		
		
		public static void endTorrentFile(string fname, string frname)
		{
			//TODO
			//implement multifile archives
			//implement move to folder
			
			string dirname = getcatname(frname);
			
			try
			{
				System.IO.Directory.CreateDirectory(completedPath+"\\"+dirname);
			}
			catch
			{
				
			}
			
			try
			{
				
				System.IO.File.Delete(torrentsPath+"\\"+frname);
				
				//System.IO.File.Move(torrentsPath+"\\"+fname+".torrent", torrentsPath+"\\"+fname+".complete");
				System.IO.File.Move( downloadsPath+"\\"+fname, completedPath+"\\"+dirname+"\\"+fname);
				
			}catch{
				try
				{
					string src = Path.Combine(downloadsPath, fname);
					string dest = Path.Combine(completedPath, dirname, fname);
					//System.IO.Directory.Move( downloadsPath+"\\"+fname, completedPath+"\\"+dirname+"\\"+fname);
				//	System.IO.Directory.Move(src, dest);
					
					DirectoryInfo dInfo = new DirectoryInfo(src);
            dInfo.MoveTo(dest);

					//	System.IO.File.Move(torrentsPath+"\\"+frname, torrentsPath+"\\"+fname+".complete");
				}
				catch(Exception e){
					string src = Path.Combine(downloadsPath, fname);
					string dest = Path.Combine(completedPath, dirname, fname);
					
					string posdest = Path.Combine(completedPath, dirname);
				//	MessageBox.Show(src+"\n\n"+dest+"\n\n"+e.ToString());
					
				}
				
			}
		}
		
		
		
		
		public static void endTorrentData(string fname, string completedpath)
		{
			//TODO
			//System.IO.File.Move(torrentsPath+"\\"+fname, torrentsPath+"\\"+fname+".complete");
			
		}
		
		
		
		public static void killtorrent(string tname)
		{
			for(int i = torrents.Count-1; i>=0;i--)
			{
				if(torrents[i].Torrent.Name == tname)
				{
					string fname = gettorrentfile( torrents[i].Torrent.TorrentPath);
					
					//torrents[i].Torrent.Name;//+".torrent";
					
					torrents[i].Stop();
					try{
						engine.Unregister(torrents[i]);
					}catch{}
					
					torrents[i].Dispose();
					
					torrents.RemoveAt(i);
					
					Thread.Sleep(100);
					try
					{
						System.IO.File.Delete(torrentsPath+"\\"+fname);
						System.IO.File.Delete(downloadsPath+"\\"+tname);
						
					}
					catch
					{
						try
						{
							System.IO.Directory.Delete(downloadsPath+"\\"+tname, true);
						}
						catch(Exception e)
						{
							MessageBox.Show("Sorry, I can't delete this torrent! "+tname+" You'll have to do it manually.\n\n"+e.ToString());
						}
					}
				}
			}
		}
		
		public static string gettorrentfile(string tsource)
		{
			string result = tsource.Substring(tsource.LastIndexOf("\\")+1);
			return result;
		}
		
		
		public static string getcatname(string nsource)
		{
			
			string result="";
			if(nsource.Contains("\\"))
			{
				nsource = nsource.Substring(nsource.LastIndexOf("\\")+1);
			}
			
			if(nsource.Contains("__"))
			{
				result = nsource.Substring(0, nsource.IndexOf("__"));
			}
			else
			{
				result="uncategorized";
			}
			
			//if(result.Length>30){result = result.Substring(0,30);}
			
			return result.Trim();
		}
		
		
		
		public static int maxactive = 1;
		
		public static void housekeepTorrents()
		{
			/// <summary>
			/// name, also torrentpath
			/// In the case of a single file torrent, this is the name of the file.
			/// In the case of a multi file torrent, it is the name of the root folder.
			/// </summary>
			
			for(int i = torrents.Count-1; i>=0;i--)
			{
				string fname = torrents[i].Torrent.Name;
				string frname = gettorrentfile( torrents[i].Torrent.TorrentPath);
				string catname = getcatname(frname);
				
				bool torexists=false;
				
				if(System.IO.File.Exists(completedPath+"\\"+catname+"\\"+fname) || System.IO.Directory.Exists(completedPath+"\\"+catname+"\\"+fname))
				{
					torexists=true;
				}
				
				if( (torrents[i].Complete == true && keepseeding==false) || torexists == true)
				{
					
					torrents[i].Stop();
					Thread.Sleep(600);
					torrents[i].Dispose();
					torrents.RemoveAt(i);
					Thread.Sleep(200);
					
					endTorrentFile(fname, frname);
				}
			}
			
			for(int i=0; i< torrents.Count; i++)
			{
				try
				{
					if(i< maxactive)
					{
						if(torrents[i].State == TorrentState.Downloading )
						{
							if(torrents[i].Monitor.DownloadSpeed == 0)
							{
								maxactive++;
							}
						}
						else if(torrents[i].State == TorrentState.Seeding)
						{
							maxactive++;
						}
						else{
							
							torrents[i].Start();
							
						}
					}
					else
					{
						if(torrents[i].State != TorrentState.Stopped &&  torrents[i].State != TorrentState.Stopping )
						{
							torrents[i].Stop();
						}
					}
				}catch{}
			}
			
		}
		
		
		static BEncodedDictionary fastResume;
		static TorrentSettings torrentDefaults;
		public static int listenport=8889;
		
		public static void changePort(int port)
		{
		engine.ChangeListenEndpoint(new IPEndPoint(IPAddress.Any, port));
		}
		
		public static void StartEngine()
		{
			int port;
			//Torrent torrent = null;
			// Ask the user what port they want to use for incoming connections
			//	MessageBox.Show(Environment.NewLine + "Choose a listen port: ");
			// while (!Int32.TryParse(Console.ReadLine(), out port)) { }
			port = listenport;


			// Create the settings which the engine will use
			// downloadsPath - this is the path where we will save all the files to
			// port - this is the port we listen for connections on
			EngineSettings engineSettings = new EngineSettings(downloadsPath, port);
			engineSettings.PreferEncryption = false;
			engineSettings.AllowedEncryption = EncryptionTypes.All;

			
			//engineSettings.GlobalMaxUploadSpeed = 30 * 1024;
			//engineSettings.GlobalMaxDownloadSpeed = 100 * 1024;
			//engineSettings.MaxReadRate = 1 * 1024 * 1024;

			//engineSettings.MaxOpenFiles = 1;

			// Create the default settings which a torrent will have.
			// 4 Upload slots - a good ratio is one slot per 5kB of upload speed
			// 50 open connections - should never really need to be changed
			// Unlimited download speed - valid range from 0 -> int.Max
			// Unlimited upload speed - valid range from 0 -> int.Max
			torrentDefaults = new TorrentSettings(4, 50, 0, 0);

			try
			{
				// Create an instance of the engine.
				engine = new ClientEngine(engineSettings);
				changePort(port);
			}
			catch
			{
				MessageBox.Show("Error: new client engine");
			}
			
			byte[] nodes = null;
			try
			{
				nodes = File.ReadAllBytes(dhtNodeFile);
			}
			catch
			{
				//MessageBox.Show("No existing dht nodes could be loaded.");
			}

			DhtListener dhtListner = new DhtListener (new IPEndPoint (IPAddress.Any, port));
			DhtEngine dht = new DhtEngine (dhtListner);
			
			try
			{
				engine.RegisterDht(dht);
				dhtListner.Start();
				engine.DhtEngine.Start(nodes);
			}
			catch
			{
				MessageBox.Show("DHT");
			}
			
			
			// If the SavePath does not exist, we want to create it.
			if (!Directory.Exists(engine.Settings.SavePath))
				Directory.CreateDirectory(engine.Settings.SavePath);

			// If the torrentsPath does not exist, we want to create it
			if (!Directory.Exists(torrentsPath))
				Directory.CreateDirectory(torrentsPath);

			if (!Directory.Exists(completedPath))
				Directory.CreateDirectory(completedPath);
			
			try
			{
				fastResume = BEncodedValue.Decode<BEncodedDictionary>(File.ReadAllBytes(fastResumeFile));
			}
			catch
			{
				fastResume = new BEncodedDictionary();
			}

			// For each file in the torrents path that is a .torrent file, load it into the engine.
			try
			{
				pushTorrents();
			}
			catch
			{
				MessageBox.Show("Error: pushtorrents");
			}
			

			/*	// If we loaded no torrents, just exist. The user can put files in the torrents directory and start
			// the client again
			if (torrents.Count == 0)
			{
				MessageBox.Show("No torrents found in the Torrents directory");
				//Console.WriteLine("Exiting...");
				//		engine.Dispose();
				//		return;
			}

			// For each torrent manager we loaded and stored in our list, hook into the events
			// in the torrent manager and start the engine.
			foreach (TorrentManager manager in torrents)
			{
				// Every time a piece is hashed, this is fired.
				manager.PieceHashed += delegate(object o, PieceHashedEventArgs e) {
					lock (listener)
						listener.WriteLine(string.Format("Piece Hashed: {0} - {1}", e.PieceIndex, e.HashPassed ? "Pass" : "Fail"));
				};

				// Every time the state changes (Stopped -> Seeding -> Downloading -> Hashing) this is fired
				manager.TorrentStateChanged += delegate (object o, TorrentStateChangedEventArgs e) {
					lock (listener)
						listener.WriteLine("OldState: " + e.OldState.ToString() + " NewState: " + e.NewState.ToString());
				};

				// Every time the tracker's state changes, this is fired
				foreach (TrackerTier tier in manager.TrackerManager)
				{
					
					foreach (MonoTorrent.Client.Tracker.Tracker t in tier.Trackers)
					{
						t.AnnounceComplete += delegate(object sender, AnnounceResponseEventArgs e) {
							listener.WriteLine(string.Format("{0}: {1}", e.Successful, e.Tracker.ToString()));
						};
					}
				}
				// Start the torrentmanager. The file will then hash (if required) and begin downloading/seeding
				manager.Start();
			}*/

			// While the torrents are still running, print out some stats to the screen.
			// Details for all the loaded torrent managers are shown.
			//int i = 0;
			//	bool running = true;
			//	StringBuilder sb = new StringBuilder(1024);
			/*	while (running)
			{
				if ((i++) % 10 == 0)
				{
					sb.Remove(0, sb.Length);
					running = torrents.Exists(delegate(TorrentManager m) { return m.State != TorrentState.Stopped; });

					AppendFormat(sb, "Total Download Rate: {0:0.00}kB/sec", engine.TotalDownloadSpeed / 1024.0);
					AppendFormat(sb, "Total Upload Rate:   {0:0.00}kB/sec", engine.TotalUploadSpeed / 1024.0);
					AppendFormat(sb, "Disk Read Rate:      {0:0.00} kB/s", engine.DiskManager.ReadRate / 1024.0);
					AppendFormat(sb, "Disk Write Rate:     {0:0.00} kB/s", engine.DiskManager.WriteRate / 1024.0);
					AppendFormat(sb, "Total Read:         {0:0.00} kB", engine.DiskManager.TotalRead / 1024.0);
					AppendFormat(sb, "Total Written:      {0:0.00} kB", engine.DiskManager.TotalWritten / 1024.0);
					AppendFormat(sb, "Open Connections:    {0}", engine.ConnectionManager.OpenConnections);
					
					foreach (TorrentManager manager in torrents)
					{
						AppendSeperator(sb);
						AppendFormat(sb, "State:           {0}", manager.State);
						AppendFormat(sb, "Name:            {0}", manager.Torrent == null ? "MetaDataMode" : manager.Torrent.Name);
						AppendFormat(sb, "Progress:           {0:0.00}", manager.Progress);
						AppendFormat(sb, "Download Speed:     {0:0.00} kB/s", manager.Monitor.DownloadSpeed / 1024.0);
						AppendFormat(sb, "Upload Speed:       {0:0.00} kB/s", manager.Monitor.UploadSpeed / 1024.0);
						AppendFormat(sb, "Total Downloaded:   {0:0.00} MB", manager.Monitor.DataBytesDownloaded / (1024.0 * 1024.0));
						AppendFormat(sb, "Total Uploaded:     {0:0.00} MB", manager.Monitor.DataBytesUploaded / (1024.0 * 1024.0));
						MonoTorrent.Client.Tracker.Tracker tracker = manager.TrackerManager.CurrentTracker;
						//AppendFormat(sb, "Tracker Status:     {0}", tracker == null ? "<no tracker>" : tracker.State.ToString());
						AppendFormat(sb, "Warning Message:    {0}", tracker == null ? "<no tracker>" : tracker.WarningMessage);
						AppendFormat(sb, "Failure Message:    {0}", tracker == null ? "<no tracker>" : tracker.FailureMessage);
						if (manager.PieceManager != null)
							AppendFormat(sb, "Current Requests:   {0}", manager.PieceManager.CurrentRequestCount());
						
						foreach (PeerId p in manager.GetPeers())
							AppendFormat(sb, "\t{2} - {1:0.00}/{3:0.00}kB/sec - {0}", p.Peer.ConnectionUri,
							             p.Monitor.DownloadSpeed / 1024.0,
							             p.AmRequestingPiecesCount,
							             p.Monitor.UploadSpeed/ 1024.0);
						
						AppendFormat(sb, "", null);
						if (manager.Torrent != null)
							foreach (TorrentFile file in manager.Torrent.Files)
								AppendFormat(sb, "{1:0.00}% - {0}", file.Path, file.BitField.PercentComplete);
					}
					//Console.Clear();
				//	Console.WriteLine(sb.ToString());
					listener.ExportTo(Console.Out);
				}

			//	System.Threading.Thread.Sleep(500);
			}*/
		}

	/*	static void manager_PeersFound(object sender, PeersAddedEventArgs e)
		{
			lock (listener)
				listener.WriteLine(string.Format("Found {0} new peers and {1} existing peers", e.NewPeers, e.ExistingPeers ));//throw new Exception("The method or operation is not implemented.");
		}

		private static void AppendSeperator(StringBuilder sb)
		{
			AppendFormat(sb, "", null);
			AppendFormat(sb, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", null);
			AppendFormat(sb, "", null);
		}
		private static void AppendFormat(StringBuilder sb, string str, params object[] formatting)
		{
			if (formatting != null)
				sb.AppendFormat(str, formatting);
			else
				sb.Append(str);
			sb.AppendLine();
		}
*/
		public static void shutdown()
		{
			BEncodedDictionary fastResume = new BEncodedDictionary();
			for (int i = 0; i < torrents.Count; i++)
			{
				torrents[i].Stop();
				/*while (torrents[i].State != TorrentState.Stopped)
				{
					//Console.WriteLine("{0} is {1}", torrents[i].Torrent.Name, torrents[i].State);
					
				}*/

			}
			Thread.Sleep(2000);
			
			for (int i = 0; i < torrents.Count; i++)
			{

				try{
					fastResume.Add(torrents[i].Torrent.InfoHash.ToHex (), torrents[i].SaveFastResume().Encode());
				}catch{}
			}

			#if !DISABLE_DHT
			File.WriteAllBytes(dhtNodeFile, engine.DhtEngine.SaveNodes());
			#endif
			File.WriteAllBytes(fastResumeFile, fastResume.Encode());
			engine.Dispose();

			foreach (TraceListener lst in Debug.Listeners)
			{
				lst.Flush();
				lst.Close();
			}

			System.Threading.Thread.Sleep(1000);
		}
	}
	
	
	
	
	
}
