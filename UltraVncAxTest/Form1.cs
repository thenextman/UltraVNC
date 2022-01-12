using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraVncAxTest
{
    public partial class Form1 : Form
    {
        private UVNCaxHost ultraVncViewer;

        public Form1()
        {
            InitializeComponent();
        }

        private void DoInitializeComponent()
        {
            this.ultraVncViewer = new UVNCaxHost(); // -=
            this.ultraVncViewer.Parent = this;
            this.ultraVncViewer.Location = new Point(0, 0);
            this.ultraVncViewer.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - this.ultraVncViewer.Location.Y);
            this.ultraVncViewer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            this.ultraVncViewer.ClientSizeChanged += UltraVncViewer_ClientSizeChanged;

            this.Shown += Form1_Shown;
        }

        private void UltraVncViewer_ClientSizeChanged(object sender, EventArgs e)
        {
            this.ultraVncViewer.ResizeScreen();

            if (true)//this.scaled)
            {
                // OFF/ON to force rescaling
                this.ultraVncViewer.AutoScaling();
                this.ultraVncViewer.AutoScaling();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ProcessArgumentBuilder argumentBuilder = new ProcessArgumentBuilder("-");
            argumentBuilder.AddSwitch("notoolbar");

            // if (!this.showStatus)
            // {
            argumentBuilder.AddSwitch("nostatus");
            //  }

            //this.ultraVncViewer.ViewOnly = this.viewOnly;
            //if (this.viewOnly)
            //{
            //    argumentBuilder.AddSwitch("viewonly");
            //    this.butViewOnly.Down = true;
            //}

            // if (this.scaled)
            // {
            argumentBuilder.AddSwitch("autoscaling");
            //  }

            //if (this.requestSharedSession)
            //{
            argumentBuilder.AddSwitch("shared");
            //}

            //if (this.swapMouseButtons)
            //{
            //    argumentBuilder.AddSwitch("swapmouse");
            //}

            //if (this.emulateThreeButton)
            //{
            //    argumentBuilder.AddSwitch("emulate3");
            //}

            //if (this.disableClipboard)
            //{
            //    argumentBuilder.AddSwitch("disableclipboard");
            //}

            //switch (this.mouseCursorMode)
            //{
            //    case VNCCursorMode.TrackLocally:
            //        argumentBuilder.AddSwitch("dotcursor");
            //        break;
            //    case VNCCursorMode.RemoteDeal:
            //        argumentBuilder.AddSwitch("normalcursor");
            //        break;
            //    case VNCCursorMode.DontShowRemote:
            //        argumentBuilder.AddSwitch("nocursor");
            //        break;
            //}

            //if (this.preferredEncoding != VNCEncoding.Auto || this.screenColorDepth != VNCColorDepth.CFull)
            //{
            //    argumentBuilder.AddSwitch("noauto");
            //}

            //switch (this.preferredEncoding)
            //{
            //    case VNCEncoding.CoRRE:
            //        argumentBuilder.AddSwitchAndValue("encoding", "corre");
            //        break;
            //    case VNCEncoding.Hextile:
            //        argumentBuilder.AddSwitchAndValue("encoding", "hextile");
            //        break;
            //    case VNCEncoding.Raw:
            //        argumentBuilder.AddSwitchAndValue("encoding", "raw");
            //        break;
            //    case VNCEncoding.RRE:
            //        argumentBuilder.AddSwitchAndValue("encoding", "rre");
            //        break;
            //    case VNCEncoding.Tight:
            //        argumentBuilder.AddSwitchAndValue("encoding", "tight");
            //        argumentBuilder.AddSwitchAndValue("compresslevel", this.customCompressionLevel);
            //        argumentBuilder.AddSwitchAndValue("quality", this.jpegCompressionLevel);
            //        break;
            //    case VNCEncoding.Ultra:
            //        argumentBuilder.AddSwitchAndValue("encoding", "ultra");
            //        break;
            //    case VNCEncoding.Zlib:
            //        argumentBuilder.AddSwitchAndValue("encoding", "zlib");
            //        argumentBuilder.AddSwitchAndValue("compresslevel", this.customCompressionLevel);
            //        break;
            //    case VNCEncoding.ZlibHEX:
            //        argumentBuilder.AddSwitchAndValue("encoding", "zlibhex");
            //        break;
            //    case VNCEncoding.Zrle:
            //        argumentBuilder.AddSwitchAndValue("encoding", "ZRLE");
            //        break;
            //}

            //switch (this.screenColorDepth)
            //{
            //    case VNCColorDepth.CFull:
            //        break;
            //    case VNCColorDepth.C256:
            //        argumentBuilder.AddSwitch("256colors");
            //        break;
            //    case VNCColorDepth.C64:
            //        argumentBuilder.AddSwitch("64colors");
            //        break;
            //    case VNCColorDepth.C8:
            //        argumentBuilder.AddSwitch("8colors");
            //        break;
            //    case VNCColorDepth.C8Bit:
            //        argumentBuilder.AddSwitch("8bit");
            //        break;
            //    case VNCColorDepth.C8Grey:
            //        argumentBuilder.AddSwitch("8greycolors");
            //        break;
            //    case VNCColorDepth.C4Grey:
            //        argumentBuilder.AddSwitch("4greycolors");
            //        break;
            //    case VNCColorDepth.C2Grey:
            //        argumentBuilder.AddSwitch("2greycolors");
            //        break;
            //}

            this.ultraVncViewer.Server = "172.30.189.20";
            this.ultraVncViewer.Password = "richard";
            bool result = this.ultraVncViewer.Connect(argumentBuilder.ToString());

            // this.ultraVncViewer.InfoConnection();
        }
    }

    public class ProcessArgumentBuilder
    {
        private readonly List<string> arguments = new List<string>();

        public ProcessArgumentBuilder(string defaultSwitch)
        {
            this.DefaultSwitch = defaultSwitch;
        }

        public ProcessArgumentBuilder()
        {
            this.DefaultSwitch = "-";
        }

        public string DefaultSwitch
        {
            get;
            set;
        }

        public static string PreparePathValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                return ExpandVariables(value);
            }

            return QuoteString(ExpandVariables(value));
        }

        public static string QuoteString(string str, string quote)
        {
            return quote + str + quote;
        }

        public static string QuoteString(string str)
        {
            return QuoteString(str, "\"");
        }

        public void AddPathValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.arguments.Add(PreparePathValue(value));
        }

        public void AddSwitch(string switchValue)
        {
            if (string.IsNullOrEmpty(switchValue))
            {
                return;
            }

            if (switchValue.StartsWith(this.DefaultSwitch))
            {
                this.AddValue(switchValue);
            }
            else
            {
                this.AddValue(this.DefaultSwitch + switchValue);
            }
        }

        public void AddSwitch(string switchValue, string value)
        {
            if (switchValue.StartsWith(this.DefaultSwitch))
            {
                this.AddValue(switchValue + value);
            }
            else
            {
                this.AddValue(this.DefaultSwitch + switchValue + value);
            }
        }

        public void AddSwitchAndPathValue(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue);
            this.AddPathValue(value);
        }

        public void AddSwitchAndValue(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue);
            this.AddValue(value);
        }

        public void AddSwitchPath(string switchValue, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.AddSwitch(switchValue + PreparePathValue(value));
        }

        public void AddValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            this.arguments.Add(value);
        }

        public void Clear()
        {
            this.arguments.Clear();
        }

        public override string ToString()
        {
            if (this.arguments.Count == 0)
            {
                return string.Empty;
            }

            return Concat(this.arguments.ToArray(), " ").Trim();
        }

        private static string Concat(Array strings, string spacer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (strings != null)
            {
                for (int i = 0; i < strings.Length; i++)
                {
                    if (strings.GetValue(i) == null)
                    {
                        stringBuilder.Append(i == 0 ? string.Empty : spacer);
                    }
                    else
                    {
                        stringBuilder.Append(i == 0 ? string.Empty : spacer);
                        stringBuilder.Append(strings.GetValue(i));
                    }
                }
            }

            return stringBuilder.ToString();
        }

        private static string ExpandVariables(string value)
        {
            return string.IsNullOrEmpty(value) ? value : Environment.ExpandEnvironmentVariables(value);
        }
    }
}