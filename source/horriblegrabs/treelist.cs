
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace horriblegrabs
{
	//custom nodesorter for the treeview
	public class NodeSorter : System.Collections.IComparer
	{
		public int Compare(object x, object y)
		{
			TreeNode tx = x as TreeNode;
			TreeNode ty = y as TreeNode;
			
			if(tx.Nodes.Count==0 || ty.Nodes.Count==0)return 0; //don't sort children!
			
			try
			{
				int n1 = (int)tx.Tag;
				int n2 = (int)ty.Tag;
				
				if(n1==n2)return 0;
				if(n1<n2)return 1;
				if(n1>n2)return -1;
			}
			catch{
				
			}
			return string.Compare(tx.Text, ty.Text);
			
		}
	}
	

	public partial class MainForm
	{
		

		
		
		
		bool checkIfChildChecked(TreeNode treeNode)
		{
			bool docheck=false;
			
			foreach(TreeNode node in treeNode.Nodes)
			{
				
				if(node.Nodes.Count > 0)
				{
					bool cchecked = checkIfChildChecked(node);
					docheck = (docheck ||	cchecked);
					node.Checked = cchecked;

				}
				docheck = (docheck ||	node.Checked);
				
				
			}
			
			return docheck;
		}
		
		
		void checkchilds()
		{
			foreach(TreeNode node in rgtreebox.Nodes)
			{
				if(node.Nodes.Count > 0)
				{
					node.Checked =	checkIfChildChecked(node);
				}
			}
		}
		
		
		
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach(TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				
				if(node.Nodes.Count > 0)
				{
					// If the current node has child nodes, call the CheckAllChildsNodes method recursively.
					CheckAllChildNodes(node, nodeChecked);
				}
			}
		}
		
		
		List<singletor> downloadtorlist;
		
		void downloadNode(TreeNode cnode)
		{
			try
			{
				singletor ttor = (singletor)cnode.Tag;
				downloadtorlist.Add(ttor);
//				downloadtorrentfile(ttor.furl, ttor.fname, ttor.fullseries);
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}
		
		//for 2-levels deep tree
		void getselectedChildren()
		{
			if(downloadtorlist==null)
			{
				downloadtorlist = new List<singletor>();
			}
			downloadtorlist.Clear();
			
			foreach(TreeNode node in rgtreebox.Nodes)
			{
				foreach(TreeNode node2 in node.Nodes)
				{
					if(node2.Nodes.Count>0)
					{
						foreach(TreeNode cnode in node2.Nodes)
						{
							if(cnode.Checked==true)
							{
								downloadNode(cnode);
								
								cnode.Checked=false; //reset checkboxes
							}
						}
						
					}
					else
					{
						if(node2.Checked==true)
						{
							downloadNode(node2);	
						}
						
					}
					node2.Checked=false;
				}
				
				node.Checked=false; //reset checkboxes
			}
			
		}
		
		
		
		void downloadAllTorrentsInList()
		{
			foreach(singletor ttor in downloadtorlist)
			{				
				statmsg = ttor.fname;				
				if(statmsg.Length>30)
				{
					statmsg = statmsg.Substring(statmsg.Length-30);
				}
				
				downloadtorrentfile(ttor.furl, ttor.fname, ttor.fullseries);
			}
		}
		
		
		
		void TreeView1AfterCheck(object sender, TreeViewEventArgs e)
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
		
	}
	
	
	

	
}
