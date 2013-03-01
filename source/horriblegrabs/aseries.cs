
using System;
using System.Collections.Generic;

namespace horriblegrabs
{

	public struct singletor
	{
		public string fname;
		public string furl;
		public int seeders;
		public int leechers;
		public string quali;
		public string series;
		public string fullseries;
		public string episode;
	}
	
	
	public class aqseries
	{
		public string quali;
		public List<singletor> tors;
		
		public aqseries(string _quali)
		{
			quali = _quali;
			tors = new List<singletor>();
		}
		
		public void addd(singletor t)
		{
			tors.Add(t);
		}
	}
	
	public class aseries
	{
		public List<aqseries> qualis;
		public string title;
		public string simpletitle;
		
		
		public aseries(string _title, string _quali)
		{
			title = _title;
			qualis = new List<aqseries>();
		}
		
		
		public string mergeseriesname(string in1)
		{
			string result="";
			
			string in2 = title;
			
			int len = in1.Length;
			if(in2.Length < len) len=in2.Length;
			
			for(int i=0;i<len;i++)
			{
				if(in1[i] == in2[i])
				{
					result+= in1[i];
				}
			}
			
			result = result.Trim();
			
			foreach(aqseries ql in qualis)
			{
				for(int i=0;i<ql.tors.Count;i++)
				{
					singletor stor = ql.tors[i];
					stor.fullseries = result;
					ql.tors[i] = stor;
				}
			}
			
			title=result;
			return result;
		}

		public void addd(singletor t)
		{
			string tqu = t.quali;
			
			int tindex =-1;
			for(int i=0;i<qualis.Count;i++)
			{
				if(qualis[i].quali == t.quali)
				{
					tindex = i;
					break;
				}
			}
			if(tindex==-1)
			{
				tindex = qualis.Count;
				qualis.Add(new aqseries(t.quali));
			}
			qualis[tindex].addd(t);
			
		}
		
	}
	
	
	
	
	
	public partial class MainForm
	{
		
		
			
		public static List<singletor> torlist = new List<singletor>();
		public static List<aseries> alist = new List<aseries>();
		
		
		

		void toAlist(singletor t)
		{
			int aindex = -1;
			for(int i=0;i<alist.Count;i++)
			{
				if(alist[i].simpletitle == t.series )
				{
					aindex = i;
					break;
				}
			}
			
			if(aindex == -1)
			{
				aindex = alist.Count;
				aseries ts = new aseries(t.fullseries, t.quali);
				ts.simpletitle = toSimplestring(t.fullseries);
				alist.Add(ts);
				
			}
			t.fullseries = alist[aindex].mergeseriesname(t.fullseries);
			alist[aindex].addd(t);
		}
		
	}
	
}
