﻿using Flash.External;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

//[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
//[assembly: System.Windows.Forms.AxHost.TypeLibraryTimeStamp("1/26/2010 7:03:00 PM")]

namespace AxShockwaveFlashObjects {
	
	[System.Windows.Forms.AxHost.ClsidAttribute("{d27cdb6e-ae6d-11cf-96b8-444553540000}")]
	[System.ComponentModel.DesignTimeVisibleAttribute(true)]
	public class AxShockwaveFlash : System.Windows.Forms.AxHost {

//		object eProxyCall(object sender, ExternalInterfaceCallEventArgs e) {
////			((IFormDockHost)Host).StatMain = e.FunctionCall.Arguments[0].ToString();
//			return e.FunctionCall.Arguments;
//		}
		ExternalInterfaceProxy proxy ;
		public ExternalInterfaceProxy Proxy {
			get { return proxy; }
			set { proxy = value; }
		}
		const string DefaultMessage = "get_flv";
		public void sendMessage(string message) { sendMessage(DefaultMessage,message); }
		public void sendMessage(string mthd, string message) {
			System.Console.WriteLine("{0}, “{1}”",mthd,message);
			Proxy.Call(mthd, message); }
		
		private ShockwaveFlashObjects.IShockwaveFlash ocx;
		
		private AxShockwaveFlashEventMulticaster eventMulticaster;
		
		private System.Windows.Forms.AxHost.ConnectionPointCookie cookie;
		
		public AxShockwaveFlash() :
			base("d27cdb6e-ae6d-11cf-96b8-444553540000") {
			
		}
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(-525)]
		public virtual int ReadyState {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ReadyState", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.ReadyState;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(124)]
		public virtual int TotalFrames {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TotalFrames", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.TotalFrames;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(125)]
		public virtual bool Playing {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Playing", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Playing;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Playing", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Playing = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(105)]
		public virtual int Quality {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Quality", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Quality;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Quality", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Quality = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(120)]
		public virtual int ScaleMode {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ScaleMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.ScaleMode;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ScaleMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.ScaleMode = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(121)]
		public virtual int AlignMode {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AlignMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.AlignMode;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AlignMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.AlignMode = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(123)]
		public virtual int BackgroundColor {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BackgroundColor", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.BackgroundColor;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BackgroundColor", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.BackgroundColor = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(106)]
		public virtual bool Loop {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Loop", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Loop;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Loop", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Loop = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(102)]
		public virtual string Movie {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Movie", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Movie;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Movie", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Movie = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(107)]
		public virtual int FrameNum {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FrameNum", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.FrameNum;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FrameNum", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.FrameNum = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(133)]
		public virtual string WMode {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("WMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.WMode;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("WMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.WMode = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(134)]
		public virtual string SAlign {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SAlign", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.SAlign;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SAlign", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.SAlign = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(135)]
		public virtual bool Menu {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Menu", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Menu;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Menu", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Menu = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(136)]
		public virtual string Base {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Base", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Base;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Base", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Base = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(137)]
		public virtual string CtlScale {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CtlScale", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Scale;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CtlScale", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Scale = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(138)]
		public virtual bool DeviceFont {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("DeviceFont", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.DeviceFont;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("DeviceFont", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.DeviceFont = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(139)]
		public virtual bool EmbedMovie {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("EmbedMovie", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.EmbedMovie;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("EmbedMovie", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.EmbedMovie = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(140)]
		public virtual string BGColor {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BGColor", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.BGColor;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BGColor", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.BGColor = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(141)]
		public virtual string Quality2 {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Quality2", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Quality2;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Quality2", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Quality2 = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(159)]
		public virtual string SWRemote {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SWRemote", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.SWRemote;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SWRemote", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.SWRemote = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(170)]
		public virtual string FlashVars {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FlashVars", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.FlashVars;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FlashVars", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.FlashVars = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(171)]
		public virtual string AllowScriptAccess {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowScriptAccess", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.AllowScriptAccess;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowScriptAccess", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.AllowScriptAccess = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(190)]
		public virtual string MovieData {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MovieData", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.MovieData;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MovieData", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.MovieData = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(191)]
		public virtual object InlineData {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("InlineData", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.InlineData;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("InlineData", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.InlineData = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(192)]
		public virtual bool SeamlessTabbing {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SeamlessTabbing", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.SeamlessTabbing;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SeamlessTabbing", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.SeamlessTabbing = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(194)]
		public virtual bool Profile {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Profile", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.Profile;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Profile", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.Profile = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(195)]
		public virtual string ProfileAddress {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ProfileAddress", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.ProfileAddress;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ProfileAddress", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.ProfileAddress = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(196)]
		public virtual int ProfilePort {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ProfilePort", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.ProfilePort;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ProfilePort", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.ProfilePort = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(201)]
		public virtual string AllowNetworking {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowNetworking", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.AllowNetworking;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowNetworking", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.AllowNetworking = value;
			}
		}
		
		[System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		[System.Runtime.InteropServices.DispIdAttribute(202)]
		public virtual string AllowFullScreen {
			get {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowFullScreen", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
				}
				return this.ocx.AllowFullScreen;
			}
			set {
				if ((this.ocx == null)) {
					throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowFullScreen", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
				}
				this.ocx.AllowFullScreen = value;
			}
		}
		
		public event _IShockwaveFlashEvents_OnReadyStateChangeEventHandler OnReadyStateChange;
		
		public event _IShockwaveFlashEvents_OnProgressEventHandler OnProgress;
		
		public event _IShockwaveFlashEvents_FSCommandEventHandler FSCommand;
		
		public event _IShockwaveFlashEvents_FlashCallEventHandler FlashCall;
		
		public virtual void TSetPropertyNum(string target, int property, double value) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TSetPropertyNum", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TSetPropertyNum(target, property, value);
		}
		
		public virtual double TGetPropertyNum(string target, int property) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TGetPropertyNum", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			double returnValue = ((double)(this.ocx.TGetPropertyNum(target, property)));
			return returnValue;
		}
		
		public virtual double TGetPropertyAsNumber(string target, int property) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TGetPropertyAsNumber", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			double returnValue = ((double)(this.ocx.TGetPropertyAsNumber(target, property)));
			return returnValue;
		}
		
		public virtual void EnforceLocalSecurity() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("EnforceLocalSecurity", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.EnforceLocalSecurity();
		}
		
		public virtual string CallFunction(string request) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CallFunction", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			string returnValue = ((string)(this.ocx.CallFunction(request)));
			return returnValue;
		}
		
		public virtual void SetReturnValue(string returnValue) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SetReturnValue", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.SetReturnValue(returnValue);
		}
		
		public virtual void DisableLocalSecurity() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("DisableLocalSecurity", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.DisableLocalSecurity();
		}
		
		public virtual int FlashVersion() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FlashVersion", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			int returnValue = ((int)(this.ocx.FlashVersion()));
			return returnValue;
		}
		
		public virtual void LoadMovie(int layer, string url) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("LoadMovie", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.LoadMovie(layer, url);
		}
		
		public virtual void TGotoFrame(string target, int frameNum) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TGotoFrame", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TGotoFrame(target, frameNum);
		}
		
		public virtual void TGotoLabel(string target, string label) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TGotoLabel", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TGotoLabel(target, label);
		}
		
		public virtual int TCurrentFrame(string target) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TCurrentFrame", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			int returnValue = ((int)(this.ocx.TCurrentFrame(target)));
			return returnValue;
		}
		
		public virtual string TCurrentLabel(string target) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TCurrentLabel", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			string returnValue = ((string)(this.ocx.TCurrentLabel(target)));
			return returnValue;
		}
		
		public virtual void TPlay(string target) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TPlay", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TPlay(target);
		}
		
		public virtual void TStopPlay(string target) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TStopPlay", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TStopPlay(target);
		}
		
		public virtual void SetVariable(string name, string value) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SetVariable", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.SetVariable(name, value);
		}
		
		public virtual string GetVariable(string name) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("GetVariable", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			string returnValue = ((string)(this.ocx.GetVariable(name)));
			return returnValue;
		}
		
		public virtual void TSetProperty(string target, int property, string value) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TSetProperty", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TSetProperty(target, property, value);
		}
		
		public virtual string TGetProperty(string target, int property) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TGetProperty", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			string returnValue = ((string)(this.ocx.TGetProperty(target, property)));
			return returnValue;
		}
		
		public virtual void TCallFrame(string target, int frameNum) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TCallFrame", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TCallFrame(target, frameNum);
		}
		
		public virtual void TCallLabel(string target, string label) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("TCallLabel", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.TCallLabel(target, label);
		}
		
		public virtual void SetZoomRect(int left, int top, int right, int bottom) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SetZoomRect", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.SetZoomRect(left, top, right, bottom);
		}
		
		public virtual void Zoom(int factor) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Zoom", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Zoom(factor);
		}
		
		public virtual void Pan(int x, int y, int mode) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Pan", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Pan(x, y, mode);
		}
		
		public virtual void Play() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Play", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Play();
		}
		
		public virtual void Stop() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Stop", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Stop();
		}
		
		public virtual void Back() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Back", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Back();
		}
		
		public virtual void Forward() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Forward", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Forward();
		}
		
		public virtual void Rewind() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Rewind", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.Rewind();
		}
		
		public virtual void StopPlay() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("StopPlay", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.StopPlay();
		}
		
		public virtual void GotoFrame(int frameNum) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("GotoFrame", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			this.ocx.GotoFrame(frameNum);
		}
		
		public virtual int CurrentFrame() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CurrentFrame", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			int returnValue = ((int)(this.ocx.CurrentFrame()));
			return returnValue;
		}
		
		public virtual bool IsPlaying() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("IsPlaying", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			bool returnValue = ((bool)(this.ocx.IsPlaying()));
			return returnValue;
		}
		
		public virtual int PercentLoaded() {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("PercentLoaded", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			int returnValue = ((int)(this.ocx.PercentLoaded()));
			return returnValue;
		}
		
		public virtual bool FrameLoaded(int frameNum) {
			if ((this.ocx == null)) {
				throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FrameLoaded", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
			}
			bool returnValue = ((bool)(this.ocx.FrameLoaded(frameNum)));
			return returnValue;
		}
		
		protected override void CreateSink() {
			try {
				this.eventMulticaster = new AxShockwaveFlashEventMulticaster(this);
				this.cookie = new System.Windows.Forms.AxHost.ConnectionPointCookie(this.ocx, this.eventMulticaster, typeof(ShockwaveFlashObjects._IShockwaveFlashEvents));
			}
			catch (System.Exception ) {
			}
		}
		
		protected override void DetachSink() {
			try {
				this.cookie.Disconnect();
			}
			catch (System.Exception ) {
			}
		}
		
		protected override void AttachInterfaces() {
			try {
				this.ocx = ((ShockwaveFlashObjects.IShockwaveFlash)(this.GetOcx()));
			}
			catch (System.Exception ) {
			}
		}
		
		internal void RaiseOnOnReadyStateChange(object sender, _IShockwaveFlashEvents_OnReadyStateChangeEvent e) {
			if ((this.OnReadyStateChange != null)) {
				this.OnReadyStateChange(sender, e);
			}
		}
		
		internal void RaiseOnOnProgress(object sender, _IShockwaveFlashEvents_OnProgressEvent e) {
			if ((this.OnProgress != null)) {
				this.OnProgress(sender, e);
			}
		}
		
		internal void RaiseOnFSCommand(object sender, _IShockwaveFlashEvents_FSCommandEvent e) {
			if ((this.FSCommand != null)) {
				this.FSCommand(sender, e);
			}
		}
		
		internal void RaiseOnFlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
			if ((this.FlashCall != null)) {
				this.FlashCall(sender, e);
			}
		}
	}
	
	public delegate void _IShockwaveFlashEvents_OnReadyStateChangeEventHandler(object sender, _IShockwaveFlashEvents_OnReadyStateChangeEvent e);
	
	public class _IShockwaveFlashEvents_OnReadyStateChangeEvent {
		
		public int newState;
		
		public _IShockwaveFlashEvents_OnReadyStateChangeEvent(int newState) {
			this.newState = newState;
		}
	}
	
	public delegate void _IShockwaveFlashEvents_OnProgressEventHandler(object sender, _IShockwaveFlashEvents_OnProgressEvent e);
	
	public class _IShockwaveFlashEvents_OnProgressEvent {
		
		public int percentDone;
		
		public _IShockwaveFlashEvents_OnProgressEvent(int percentDone) {
			this.percentDone = percentDone;
		}
	}
	
	public delegate void _IShockwaveFlashEvents_FSCommandEventHandler(object sender, _IShockwaveFlashEvents_FSCommandEvent e);
	
	public class _IShockwaveFlashEvents_FSCommandEvent {
		
		public string command;
		
		public string args;
		
		public _IShockwaveFlashEvents_FSCommandEvent(string command, string args) {
			this.command = command;
			this.args = args;
		}
	}
	
	public delegate void _IShockwaveFlashEvents_FlashCallEventHandler(object sender, _IShockwaveFlashEvents_FlashCallEvent e);
	
	public class _IShockwaveFlashEvents_FlashCallEvent {
		
		public string request;
		
		public _IShockwaveFlashEvents_FlashCallEvent(string request) {
			this.request = request;
		}
	}
	
	[System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.None)]
	public class AxShockwaveFlashEventMulticaster : ShockwaveFlashObjects._IShockwaveFlashEvents {
		
		private AxShockwaveFlash parent;
		
		public AxShockwaveFlashEventMulticaster(AxShockwaveFlash parent) {
			this.parent = parent;
		}
		
		public virtual void OnReadyStateChange(int newState) {
			_IShockwaveFlashEvents_OnReadyStateChangeEvent onreadystatechangeEvent = new _IShockwaveFlashEvents_OnReadyStateChangeEvent(newState);
			this.parent.RaiseOnOnReadyStateChange(this.parent, onreadystatechangeEvent);
		}
		
		public virtual void OnProgress(int percentDone) {
			_IShockwaveFlashEvents_OnProgressEvent onprogressEvent = new _IShockwaveFlashEvents_OnProgressEvent(percentDone);
			this.parent.RaiseOnOnProgress(this.parent, onprogressEvent);
		}
		
		public virtual void FSCommand(string command, string args) {
			_IShockwaveFlashEvents_FSCommandEvent fscommandEvent = new _IShockwaveFlashEvents_FSCommandEvent(command, args);
			this.parent.RaiseOnFSCommand(this.parent, fscommandEvent);
		}
		
		public virtual void FlashCall(string request) {
			_IShockwaveFlashEvents_FlashCallEvent flashcallEvent = new _IShockwaveFlashEvents_FlashCallEvent(request);
			this.parent.RaiseOnFlashCall(this.parent, flashcallEvent);
		}
	}
}
