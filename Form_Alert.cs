﻿using clipmon.Model;
using clipmon.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomAlertBoxDemo
{
    public partial class Form_Alert : Form
    {
        public string CmdData { get; set; }
        public bool CUApp { get; set; }
        private string cmd = "";
        private string clickUpCmd = "clickup://app.clickup.com/t/";
        private string clickUpHttpCmd = "https://app.clickup.com/t/";
        private string helpdeskCmd = "https://helpdesk.itsecurity.dk/Ticket/";

        public Form_Alert()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close            
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info,
            ClickUp,
            HelpDesk
        }
        private Form_Alert.enmAction action;

        private int x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch(this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case Form_Alert.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = Form_Alert.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void Form_Alert_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process.Start(cmd);
            cmd = "";
        }

        public void showAlert(ClipAlert alert)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form_Alert frm = (Form_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            //switch(type)
            //{
            //    case enmType.Success:
            //        this.pictureBox1.Image = Resources.success;
            //        this.BackColor = Color.SeaGreen;
            //        break;
            //    case enmType.Error:
            //        this.pictureBox1.Image = Resources.error;
            //        this.BackColor = Color.DarkRed;
            //        break;
            //    case enmType.Info:
            //        this.pictureBox1.Image = Resources.info;
            //        this.BackColor = Color.RoyalBlue;
            //        break;
            //    case enmType.Warning:
            //        this.pictureBox1.Image = Resources.warning;
            //        this.BackColor = Color.DarkOrange;
            //        break;
            //    case enmType.ClickUp:
            //        this.pictureBox1.Image = Resources.clickup;
            //        this.BackColor = Color.RoyalBlue;
            //        if (!CUApp)
            //        {
            //            cmd = clickUpCmd + CmdData;
            //        } else
            //        {
            //            cmd = clickUpHttpCmd + CmdData;
            //        }
                    
            //        break;
            //    case enmType.HelpDesk:
            //        this.pictureBox1.Image = Resources.its;
            //        this.BackColor = Color.DarkRed;
            //        cmd = helpdeskCmd + CmdData;
            //        break;
            //}


            this.lblMsg.Text = alert.Text;
            this.BackColor = Color.FromArgb(int.Parse(alert.Color));
            this.pictureBox1.Image = Image.FromFile(alert.Img);
            cmd = alert.Url;


            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}