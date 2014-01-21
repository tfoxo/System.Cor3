using System;

namespace FeedTool
{

	public enum YtMediaFormat
	{
		Unknown =				0,
		RtspMobile_H263_AMR =	1,
		HttpSwf =				5,
		RtspMpeg4Aac =			6,
		Flv240p =				17,
		Flv360p =				18,
		Flv480p =				19,
	}
	public class YtMediaContent
	{
		#region Properties
		
		#region Comment
		/*<media:content
	        url="..."
	        type="video/3gpp"
	        medium="video"
	        expression="full"
	        duration="5454"
	        yt:format="1" />*/
		#endregion
		
		public string EmbedHash { get;set; }
		public string Url { get;set; }
		public string Type { get;set; }
		public string Medium { get;set; }
		public string Expression { get;set; }
		public string Duration { get;set; }
		/// yt:format @'https://developers.google.com/youtube/2.0/reference'
		/// <para>1 - RTSP streaming URL for mobile video playback. H.263 video (up to 176x144) and AMR audio.</para>
		/// <para>5 - HTTP URL to the embeddable player (SWF) for this video. This format is not available for a video that is not embeddable.
		/// Developers commonly add format=5 to their queries to restrict results to videos that can be embedded on their sites.</para>
		/// <para>6 - RTSP streaming URL for mobile video playback. MPEG-4 SP video (up to 176x144) and AAC audio.</para>
		/// <para>In addition, the following streaming formats are valid for live videos: 19 – 480p FLV, 18 – 360p FLV, 17 – 240p FLV</para>
		public string Format { get;set; }
		public YtMediaFormat YtFormat {
			get
			{
				if (this.Type==null) return YtMediaFormat.Unknown;
				var yt = (YtMediaFormat)Enum.Parse(typeof(YtMediaFormat),this.Format);
				return yt;
			}
		}
		public string YtStrFormat { get { return ConvertEnum(YtFormat); } }
		
		#endregion
		
		static public string ConvertEnum(string value)
		{
			return ConvertEnum((YtMediaFormat)int.Parse(value));
		}
		static public string ConvertEnum(YtMediaFormat value)
		{
			switch (value)
			{
				case YtMediaFormat.RtspMobile_H263_AMR: return "video/mpeg (H.263/AMR)";
				case YtMediaFormat.HttpSwf: return "shockwave/flash";
				case YtMediaFormat.RtspMpeg4Aac: return "video/mpeg4 (MPEG-4 SP/AAC)";
				case YtMediaFormat.Flv240p: return "video/flv (240p)";
				case YtMediaFormat.Flv360p: return "video/flv (360p)";
				case YtMediaFormat.Flv480p: return "video/flv (480p)";
				default: return "Unknown Format";
			}
		}
		
		public YtMediaContent(){}
		
	}
}
