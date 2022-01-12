namespace UltraVncAxTest
{
    using System;
    using System.Windows.Forms;

    using Interop.UltraVncAx;

    public class UVNCaxHost : AxHost
    {
        private bool altKeyPressed;

        private bool ctrlKeyPressed;

        private bool viewOnly;

        private bool isConnected;

        public UVNCaxHost() : base("3B6D183B-F70D-43EB-A88D-21642D6F75A7")
        {
        }

        public event EventHandler ConnectionLost;

        public event EventHandler ConnectionRefused;

        public event EventHandler GotConnection;

        public bool AltKeyPressed
        {
            get => this.altKeyPressed;

            set
            {
                this.altKeyPressed = value;
                if (this.altKeyPressed)
                {
                    this.SendAltDown();
                }
                else
                {
                    this.SendAltUp();
                }
            }
        }

        public bool CtrlKeyPressed
        {
            get => this.ctrlKeyPressed;

            set
            {
                this.ctrlKeyPressed = value;
                if (this.ctrlKeyPressed)
                {
                    this.SendCtrlDown();
                }
                else
                {
                    this.SendCtrlUp();
                }
            }
        }

        public bool ViewOnly
        {
            get => this.viewOnly;

            set
            {
                this.viewOnly = value;
                this.ToggleViewOnly();
            }
        }

        public string Domain
        {
            get => this.GetOcx() != null ? ((UltraVncAxObj)this.GetOcx()).Domain : string.Empty;

            set
            {
                if (this.GetOcx() != null)
                {
                    ((UltraVncAxObj)this.GetOcx()).Domain = value;
                }
            }
        }

        public string DSM
        {
            get => this.GetOcx() != null ? ((UltraVncAxObj)this.GetOcx()).DSM : string.Empty;

            set
            {
                if (this.GetOcx() != null)
                {
                    ((UltraVncAxObj)this.GetOcx()).DSM = value;
                }
            }
        }

        public bool IsConnected
        {
            get => this.isConnected;

            private set
            {
                if (value != this.isConnected)
                {
                    this.isConnected = value;
                    if (this.isConnected)
                    {
                        if (this.GotConnection != null)
                        {
                            this.GotConnection(this, new EventArgs());
                        }
                    }
                    else if (this.ConnectionLost != null)
                    {
                        this.ConnectionLost(this, new EventArgs());
                    }
                }
            }
        }

        public string Password
        {
            get => this.GetOcx() != null ? ((UltraVncAxObj)this.GetOcx()).Password : string.Empty;

            set
            {
                if (this.GetOcx() != null)
                {
                    ((UltraVncAxObj)this.GetOcx()).Password = value;
                }
            }
        }

        public string Server
        {
            get => this.GetOcx() != null ? ((UltraVncAxObj)this.GetOcx()).Server : string.Empty;

            set
            {
                if (this.GetOcx() != null)
                {
                    ((UltraVncAxObj)this.GetOcx()).Server = value;
                }
            }
        }

        public string UserName
        {
            get => this.GetOcx() != null ? ((UltraVncAxObj)this.GetOcx()).UserName : string.Empty;

            set
            {
                if (this.GetOcx() != null)
                {
                    ((UltraVncAxObj)this.GetOcx()).UserName = value;
                }
            }
        }

        public void About()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("about");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void AutoScaling()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("autoScaling");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public bool Connect(string cmdParameters)
        {
            try
            {
                ((UltraVncAxObj)this.GetOcx()).Initialize("5D9E8691-FC72-4B7D-9E15-C552492C81A1" + cmdParameters);
                ((UltraVncAxObj)this.GetOcx()).Connect();
                this.IsConnected = true;
                return true;
            }
            catch (Exception)
            {
                if (this.ConnectionRefused != null)
                {
                    this.ConnectionRefused(this, new EventArgs());
                }

                this.IsConnected = false;
                return false;
            }
        }

        public void CustomKey()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("customkey");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void DisableRemoteIM()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("disableremoteim");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void Disconnect()
        {
            try
            {
                ((UltraVncAxObj)this.GetOcx()).Disconnect();
                this.IsConnected = false;
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void EnableRemoteIM()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("enableremoteim");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public bool ExecuteCommand(string command)
        {
            try
            {
                if (this.IsConnected)
                {
                    ((UltraVncAxObj)this.GetOcx()).ExecuteCommand(command);
                }
            }
            catch (Exception e)
            {
                this.IsConnected = false;
                this.HandleException(e);
            }

            return this.isConnected;
        }

        public void FileTransfer()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("filetransfer");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void FlushConnection()
        {
            try
            {
                if (this.GetOcx() is UltraVncAxObj ultraVncAxObj)
                {
                    ultraVncAxObj.Initialize("5D9E8691-FC72-4B7D-9E15-C552492C81A1");
                    ultraVncAxObj.Disconnect();
                }

                this.IsConnected = false;
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void InfoConnection()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("info");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void NormalScaling()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("normalScaling");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void OptionDialog()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("optiondialog");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void RequestRefresh()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("requestrefresh");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void ResizeScreen()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("resize");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void SendCtrlAltDel()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendctrlaltdel");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void SendStart()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendstart");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void TextChat()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("textchat");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void ToggleViewOnly()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("viewonlytoggle");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        public void ToogleRemoteInput()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("toggleinput");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        private void HandleException(Exception e)
        {
            this.IsConnected = false;
            throw (e);
        }

        private void SendAltDown()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendaltdown");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        private void SendAltUp()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendaltup");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        private void SendCtrlDown()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendctrldown");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        private void SendCtrlUp()
        {
            try
            {
                if (!this.IsConnected)
                {
                    return;
                }

                ((UltraVncAxObj)this.GetOcx()).ExecuteCommand("sendctrlup");
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }
    }
}