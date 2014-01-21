/*
 * Created by SharpDevelop.
 * User: oio
 * Date: 11/6/2013
 * Time: 6:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using DspAudio.Formats;

namespace FeedTool.Loaders
{
	public class Options
	{
		readonly Dictionary<string, string> Sounds = new Dictionary<string, string> { {
			OPML_LOAD,
			SND_OPML_LOAD
		} };
		
		public const string OPML_LOAD = "OPML_LOADED";
		const string SND_OPML_LOAD = "sonar.wav";
		
		public void Notify(string snd)
		{
			if (Sounds.ContainsKey(snd))
				MM_Sys.sndPlaySound(Sounds[snd], MM_Sys.sndFlags.ASYNC);
		}
	}
}
