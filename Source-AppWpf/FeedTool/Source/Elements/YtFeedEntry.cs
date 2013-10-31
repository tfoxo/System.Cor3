using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace FeedTool
{
	/// <summary>
	/// represents a podcast feed (in most cases).
	/// </summary>
	public class YtFeedEntry : NodeInfo
	{
		#region Dictionary Infos

		internal override Dictionary<string, string> Infos {
			get { return infos; }
		} Dictionary<string,string> infos = Resource.Dic_YtFeed
			.ToStringDictionary('\n','|',new char[]{'#','['},new char[]{'\r','\n','\t'});
		#endregion
		
		#region Content Dictionary

		List<YtMediaContent> contentEntries = new List<YtMediaContent>();
		
		public List<YtMediaContent> ContentEntries {
			get { return contentEntries; }
		}
		
		#endregion
		
		#region Properties
		
		public override string HtmlText {
			get {
				
				#region Youtube content html helper
				
				string linkTest = string.Empty;
				
				List<string> list = new List<string>();
				
				foreach (YtMediaContent yt in ContentEntries)
					list.Add(string.Format("Url: {0}, Type: {1}, Format: {2}",yt.Url,yt.Type,yt.Format));
				
				linkTest = string.Join("<br/>",list.ToArray());
				list.Clear();
				
				string vidTest = string.Empty;
				
				int cid = 0;
				
				foreach (YtMediaContent yt in ContentEntries)
				{
					list.Add(
						string.Format(
							@"<a href=""{0}"" title=""Type: {1}, Format: {2}"">vid</a> {4}",
							yt.Url,
							yt.Type,
							yt.Format,
							++cid,
							yt.YtStrFormat
						)
					);
				}
				
				vidTest = string.Join("<br />",list.ToArray())+"<hr />";
				
				#endregion
				
				return Resource
					.Html_YouTube_Template
					
					.Replace("@{links}",vidTest)

					.Replace("@{html-link}",HtmlLinks["link"])
					
					.Replace("@{title}",Title)
					.Replace("@{description}",Content)
					.Replace("@{date}",Updated)
					.Replace("@{img}",Image)
					;
			}
		}
		
		public override string Name { get { return Title; } }
		
		public string Id { get;set; }
		public string Title { get;set; }
		public string Image { get;set; }
		/// <summary>
		/// This is never used.
		/// </summary>
		public override string Description { get;set; }
		
		public DateTime? DatePublished { get;set; }
		string OrigPublished { get;set; }
		public string Published { get;set; }
		
		public DateTime? DateUpdated { get;set; }
		string OrigUpdated { get;set; }
		public string Updated { get;set; }
		
		public string Creator { get;set; }
		public override string Content { get;set; }
		public string Enclosure { get;set; }
		public string Link { get;set; }

		#endregion
		
		/// <summary>
		/// Title, Comments, Description, Date
		/// </summary>
		/// <param name="doc"></param>
		public override void Parse(XmlDocument doc, XmlNamespaceManager man)
		{
			var node =		GetNode(doc,man,"id");
			Id =			node.InnerText;
			Image =			TryGetText(doc, man, ref node, "img");
			Title =			TryGetText(doc, man, ref node, "title");
			
			OrigPublished =	TryGetText(doc, man, ref node, "published");
			DatePublished = CheckDate(OrigPublished);
			Published =		DatePublished.HasValue ? DatePublished.Value.ToString(dateFmt) : OrigPublished;
			
			OrigUpdated =	TryGetText(doc, man, ref node, "updated");
			DateUpdated =	CheckDate(OrigUpdated);
			Updated =		DateUpdated.HasValue ? DateUpdated.Value.ToString(dateFmt) : OrigUpdated;
			
			Creator =		TryGetText(doc, man, ref node, "creator");
			Content =		TryGetText(doc, man, ref node, "content");
			Enclosure =		TryGetText(doc, man, ref node, "enclosure");
			Link =			TryGetText(doc, man, ref node, "link");
			
			XmlNodeList nodelist = doc.DocumentElement.SelectNodes(GetPath("/media:group/media:content"),man);
			List<YtMediaContent> items = new List<YtMediaContent>();
			
			contentEntries.Clear();
			foreach (XmlNode xnode in nodelist)
			{
				string ytUrl, ytType, ytFormat;
				ytUrl = xnode.Attributes["url"].Value;
				ytType = xnode.Attributes["type"].Value;
				ytFormat = xnode.Attributes["yt:format"].Value;
				YtMediaContent ytc = new YtMediaContent{ Url=ytUrl, Type=ytType, Format=ytFormat };
				contentEntries.Add(ytc);
			}
			
		}
		
		public override void GenerateLinks()
		{
			HtmlLinks.Clear();
			
			if (!string.IsNullOrEmpty(this.Link)) {
				HtmlLinks.Add("link",string.Format(linkFormat,Link,Link,string.Empty,"link"));
				HtmlLinks.Add("link-break","<br />");
			} else {
				HtmlLinks.Add("link",string.Empty);
				HtmlLinks.Add("link-break",string.Empty);
			}
		}
		
	}

}
