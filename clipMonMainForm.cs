using clipmon.Model;
using CustomAlertBoxDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace clipmon
{
    public partial class clipMonMainForm : Form
    {
        string lastAddString { get; set; }
        public List<ClipAlert> Alerters { get; set; }


        public clipMonMainForm()
        {
            InitializeComponent();
            timbgCol.Start();
        }

        private void clipMonMain_Load(object sender, EventArgs e)
        {
            AddClipboardFormatListener(this.Handle);
            LoadAlertsFromXml();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void LoadAlertsFromXml()
        {
            Alerters = new List<ClipAlert>();
            string path = Directory.GetCurrentDirectory()+"\\Alerts.xml";
            if (File.Exists(path))
            {
                Alerters = DeserializeToObject<ClipAlert>(path);

                foreach (var alert in Alerters)
                {
                    if (alert.Img.Contains(":"))
                    {
                        alert.Img = ConvertFilePathToRelative(alert.Img);
                    }
                }
                
            } 
            else //First start. Create ClipUp and Helpdesk alerts since this is what this program is made to do.
            {
                var click = new ClipAlert();
                click.ClipRegex = "^#?[a-zA-Z0-9]{5,7}$";
                click.Title = "ClickUp";
                click.Text = "Looks like a ClickUp issue";
                click.Color = "-8388353";
                click.Url = "clickup://app.clickup.com/t/";
                if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\imgs\\"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\imgs\\");
                }
                Properties.Resources.clickup.Save(Directory.GetCurrentDirectory() + "\\imgs\\" + "clikcup.png");
                click.Img = "\\imgs\\" + "clikcup.png";
                click.Id = Guid.NewGuid();
                click.RemoveString = "#";

                Alerters.Add(click);

                var help = new ClipAlert();
                help.ClipRegex = "^1?[0-9]{7}$";
                help.Title = "Helpdesk";
                help.Text = "Looks like a helpdesk ticket";
                help.Color = "-8388608";
                help.Url = "https://helpdesk.itsecurity.dk/Ticket/";
                Properties.Resources.its.Save(Directory.GetCurrentDirectory() + "\\imgs\\" + "its.png");
                help.Img = "\\imgs\\" + "its.png";
                help.Id = Guid.NewGuid();

                Alerters.Add(help);

                SaveAlertsFromXml();
            }
            refreshData();
        }
        private void SaveAlertsFromXml()
        {
            string path = Directory.GetCurrentDirectory() + "\\Alerts.xml";
            SerializeToXml<ClipAlert>(Alerters,path);
        }

        private void refreshData()
        {
            bindingSource1.DataSource = Alerters;
            listAlerters.DataSource = bindingSource1;
            listAlerters.DisplayMember = "Title";
            bindingSource1.ResetBindings(true);
        }

        private void RefreshItemData(ClipAlert copy = null)
        {
            
            var item = (ClipAlert)listAlerters.SelectedItem;

         

            if (!string.IsNullOrEmpty(item.Color))
            {
                cpAlertBG.Color = System.Drawing.Color.FromArgb(int.Parse(item.Color));
                txtBG.BackColor = cpAlertBG.Color;
                txtBG.Refresh();
            }            
            txtRegex.Text = item.ClipRegex;
            txtTitle.Text = item.Title;
            txtText.Text = item.Text;
            txtUrl.Text = item.Url;
            txtSan.Text = item.RemoveString;
            if (!string.IsNullOrEmpty(item.Img)) { 
                pbImage.Image = Image.FromFile(Directory.GetCurrentDirectory()+ item.Img);
                pbImage.ImageLocation = Directory.GetCurrentDirectory() + item.Img;
            }


        }


        public static void SerializeToXml<T>(List<T> anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }

        public List<T> DeserializeToObject<T>(string filepath) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (List<T>)ser.Deserialize(sr);
            }
        }



        private void addToClipList(string clip)
        {
            if (clip.Length > 0 && !clip.Equals(lastAddString))
            {
                clip = clip.Trim();
                foreach (var alertCheck in Alerters)
                {
                    var regEx = new Regex(alertCheck.ClipRegex);
                    if (regEx.IsMatch(clip))
                    {
                        Alert(alertCheck, !string.IsNullOrEmpty(alertCheck.RemoveString) ? clip.Replace(alertCheck.RemoveString, "") : clip);
                    }
                }
                lastAddString = clip;
            }
        }

        private void clipMonMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveClipboardFormatListener(this.Handle);
        }

        private string ConvertFilePathToRelative(string path)
        {
            return path.Substring(path.LastIndexOf("\\imgs\\"), path.Length-path.LastIndexOf("\\imgs\\"));
        }


        public void Alert(ClipAlert clipAlert, string data)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(clipAlert, data);
        }

        /// Found on : https://www.fluxbytes.com/csharp/how-to-monitor-for-clipboard-changes-using-addclipboardformatlistener/
        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        /// Sent when the contents of the clipboard have changed.
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CLIPBOARDUPDATE:
                    IDataObject iData = Clipboard.GetDataObject();
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string data = (string)iData.GetData(DataFormats.Text);
                        addToClipList(data);
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void clipMonMainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                nfIcon.Visible = true;
            }
        }

        private void nfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            nfIcon.Visible = false;
        }

        private void txtBG_Click(object sender, EventArgs e)
        {
            cpAlertBG.ShowDialog();
            
        }

        private void pbImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ofdAlertImage.ShowDialog();
        }

        private void timbgCol_Tick(object sender, EventArgs e)
        {
            txtBG.BackColor = cpAlertBG.Color;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var alert = new ClipAlert();
            if (listAlerters.SelectedItem != null)
            {
                alert = (ClipAlert)listAlerters.SelectedItem;
            }
            alert.Text = txtText.Text;
            alert.Url = txtUrl.Text;
            alert.Title = txtTitle.Text;
            alert.Color = cpAlertBG.Color.ToArgb().ToString();
            
            alert.ClipRegex = txtRegex.Text;
            alert.Img = pbImage.ImageLocation.Replace(Directory.GetCurrentDirectory(), "");
            alert.RemoveString = txtSan.Text;           
            
            if (alert.Id != null && alert.Id != Guid.Empty)
            {
                Alerters[Alerters.FindIndex(a => a.Id.Equals(alert.Id))] = alert;
            }
            else
            {
                alert.Id = Guid.NewGuid();
                Alerters.Add(alert);
            }
            refreshData();
            SaveAlertsFromXml();
            btnNew.PerformClick();
        }

        private ClipAlert findAlertInList(Guid Id)
        {
            return Alerters.Find(a => a.Id.Equals(Id));
        }

        private void ofdAlertImage_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var f = ofdAlertImage.FileName;
            if (!string.IsNullOrEmpty(f))
            {
                string dest = MoveFile(f);
                pbImage.Image = Image.FromFile(dest);
                pbImage.ImageLocation = dest;
            }
        }

        private string MoveFile(string f)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\imgs\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\imgs\\");
            }

            var dest = Directory.GetCurrentDirectory() + "\\imgs\\" + ofdAlertImage.SafeFileName;
            if (!File.Exists(dest))
            {
                File.Copy(f, dest, true);
            }

            return dest;
        }

        private void listAlerters_DoubleClick(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnNew.Enabled = true;
            RefreshItemData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {            
            if (listAlerters.SelectedItem != null)
            {
                ClipAlert alert = (ClipAlert)listAlerters.SelectedItem;
                if(alert != null)
                {
                    Alerters.Remove(findAlertInList(alert.Id));
                    refreshData();
                    SaveAlertsFromXml();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            listAlerters.SelectedItem = null;
            txtBG.Text = "";
            txtUrl.Text = "";
            txtTitle.Text = "";
            txtText.Text = "";
            txtRegex.Text = "";
            txtSan.Text = "";
            
            cpAlertBG.Color = Color.Black;
            pbImage.Image = null;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
        }


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater up = new Updater();

            up.DownloadNewClient();
        }

        private void getSHAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater up = new Updater();
            MessageBox.Show(up.GetSha(true));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            
            if (listAlerters.SelectedItem != null)
            {
                var alert = (ClipAlert)listAlerters.SelectedItem;
                Alerters.Add(copy(alert));
                refreshData();
            }
        }

        private ClipAlert copy(ClipAlert alert)
        {
            var nAl = new ClipAlert();
            nAl.ClipRegex = alert.ClipRegex;
            nAl.Color = alert.Color;
            nAl.Id = Guid.NewGuid();
            nAl.Img = alert.Img;
            nAl.RemoveString = alert.RemoveString;
            nAl.Text = alert.Text;
            nAl.Title = alert.Title;
            return nAl;
        }
    }
}
