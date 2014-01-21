using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace FeedTool
{
	public class RssNode : NodeInfo
	{
		public override void LoadMeta(XmlDocument doc, XmlNamespaceManager man)
		{
//			throw new NotImplementedException();
		}
		internal override Dictionary<string, string> Infos {
			get { return infos; }
		} readonly Dictionary<string,string> infos = Resource.Dic_RssFeed
			.ToStringDictionary('\n','|',new char[]{'#','['},new char[]{'\r','\n','\t'});
		
		public override string HtmlText {
			get {
				return Resource
					.Html_Master
					.Replace("@{style}",Resource.html_css)
					.Replace("@{content}",Resource.Html_Rss_Template)
					.Replace("@{title}",Title)
					.Replace("@{description}",DefaultContent)
					.Replace("@{link}",Link)
					
					.Replace("@{html-enclosure}",HtmlLinks["enclosure"])
					.Replace("@{html-enclosure-break}",HtmlLinks["enclosure-break"])
					.Replace("@{html-link}",HtmlLinks["link"])
					
					.Replace("@{enclosure}",Enclosure)
					.Replace("@{enclosure-length}",EnclosureLength)
					.Replace("@{enclosure-type}",EnclosureType)
					.Replace("@{date}",Date)
//					.Replace("@{img}",xnode.)
					;
			}
		}
		
		public override string DefaultContent {
			get { return string.IsNullOrEmpty(Content) ? Description : Content; }
		}
		
		public override string Name {
			get { return Title; }
		}
		public string Comments { get;set; }
		public string Creator { get;set; }
		public override string Description { get;set; }
		public override string Content { get;set; }
		public string Enclosure { get;set; }
		public string EnclosureType { get;set; }
		public string EnclosureLength { get;set; }
		public string Link { get ; set; }
		public string Title { get;set; }
		
		/// <summary>
		/// only to be called when OriginalDate is provided.
		/// This also sets PubDate value.
		/// </summary>
		bool CanParseDate
		{
			get {
				bool isSuccess = true;
				try { PubDate = DateTime.Parse(OriginalDate); }
				catch{ isSuccess = false; }
				return isSuccess;
			}
		}
		public string Date { get ; set; }
		public string OriginalDate { get ; set; }
		public DateTime PubDate { get;set; }
		
		/// <summary>
		/// Title, Comments, Description, Date
		/// </summary>
		/// <param name="doc"></param>
		public override void Parse(XmlDocument doc, XmlNamespaceManager man)
		{
			var node =		GetNode(doc, man,"title");
			Title =			node.InnerText;
			Comments =		TryGetText(doc, man, ref node, "comments");
			Link =			TryGetText(doc, man, ref node, "link");
			Enclosure =		TryGetText(doc, man, ref node, "enclosure");
			Description =	TryGetText(doc, man, ref node, "description");
			Content =		TryGetText(doc, man, ref node, "content");
			OriginalDate =  TryGetText(doc, man, ref node, "pubDate");
			EnclosureType =	TryGetText(doc, man, ref node, "enclosure-length");
			EnclosureLength =TryGetText(doc, man, ref node, "enclosure-type");
			Date =			CanParseDate ? PubDate.ToString(dateFmt) : OriginalDate;
			GenerateLinks();
		}
		public override void GenerateLinks()
		{
			HtmlLinks.Clear();
			// generate enclosure link
			if (!string.IsNullOrEmpty(this.Enclosure))
			{
//				int mb = int.Parse(EnclosureLength)/1024;
//				int kb = mb/1024;
				
				HtmlLinks.Add("enclosure-title",string.Format("{0} - {1}Mb - {2}", EnclosureType, EnclosureLength, Enclosure));
				HtmlLinks.Add("enclosure",string.Format(linkFormat,HtmlLinks["enclosure-title"],Enclosure,string.Empty,"enclosure"));
				HtmlLinks.Add("enclosure-break","<br />");
			} else {
				HtmlLinks.Add("enclosure-title",string.Empty);
				HtmlLinks.Add("enclosure-break",string.Empty);
				HtmlLinks.Add("enclosure",string.Empty);
			}
			if (!string.IsNullOrEmpty(this.Link)) {
				HtmlLinks.Add("link",string.Format(linkFormat,Link,Link,string.Empty,"link"));
			} else {
				HtmlLinks.Add("link",string.Empty);
			}
		}
		
	}


}
