/*
 * 
 * TODO
---------------------------------

hadena

secure threaded torrent engine bootup handling
secure pushtorrent handling

threading is a mess

Port to mono when hell has frozen over and everybody has lots of time on their hands


---------------------------------
DONE

 0series doesn't work

Needs a slightly better systems for catching small naming differences.
>Kamisama no Memochou
>Kamisama no Memo-chou

mazui 69762
evetaku 56890
fff 73859
gg 9001
utw 71629

Don't forget Mazui, FFF
you need gg and UTW
Evetaku
 UI runs in main thread, the sub-group queries run in their own threads and feed back info to the main form.


Background check to automatically download new release?
-> "watchdogs"? list of singular search terms?

---------------------------------
WONTFIX

When I minimize the program put it on the taskbar not system tray, when I hit the 'x' it should go to system tray like most torrent programs.
--> why not? Because we would need a context menu for the tray icon which would add bloat.


---------------------------------
CANTFIX
Upload/download rate limits don't work or are all over the place -> Monotorrent's fault. Can't help it.

 */
 
 
 
 
using System;
using System.Windows.Forms;
using System.Threading;

namespace horriblegrabs
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);

				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

				
				
				AppDomain.CurrentDomain.UnhandledException +=
					new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
				
				
				
				
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
			}
			catch(Exception e)
			{
				
				handleExceptions(e);
			
			}
		}
		
		
		
		
		
		
		
		
		private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
		{
			
			Exception ex = (Exception)t.Exception;
			handleExceptions(ex);
		}
		
		
		
		
		

		
		
		
		static void CurrentDomain_UnhandledException
			(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				Exception ex = (Exception)e.ExceptionObject;
				handleExceptions(ex);
				
			}
			catch{}
		}
		
		
		//error handling
		public static void handleExceptions(Exception ex)
		{
			string sttrace = ex.ToString()+ ex.StackTrace.ToString();
			if(sttrace.Length>500)sttrace = sttrace.Substring(0,500)+"...";
			
			if(sttrace.Contains("ThreadAbortException") )return; //ignore this
			
			if(sttrace.Contains("uri"))
			{
				MessageBox.Show("Sorry, the torrent engine has crashed. If this continues to happen, it is very likely that a corrupted torrent file is the reason.\n\nPlease go to the torrent directory,\nremove them and put them back in until you've found the culprit.\n\n"+sttrace);
				//Application.Exit();
			}
			else if (MessageBox.Show("Please press Ctrl+C to copy this error message, then send it to the developer: \n\n\n"+sttrace+"\n\n\nDo you want to restart?","Oh the humanity!", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				System.IO.File.Delete(MonoTorrent.maintor.fastResumeFile);
				Application.Exit();
				System.Diagnostics.Process.Start(Application.ExecutablePath, "");
			}
			

			
			Thread.Sleep(2000);

			
			
		}
		
	}
}
