using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FortniteHUE.Connections;
using FortniteHUE.Config;
using FortniteHUE.Colors;
using static FortniteHUE.Json.Storage;
using static LoginTheme.LogInOnOffSwitch;
using FortniteHUE.GameState;
using System.Diagnostics;
using FortniteHUE.Updator;

namespace FNHue_New
{
    public partial class Form1 : Form
    {
        public static string appdata = Environment.GetEnvironmentVariable("LocalAppData");
        GameState sg = new GameState(appdata);
        public Form1()
        {
            InitializeComponent();
        }

        private void logInButton2_Click(object sender, EventArgs e)
        {
            sg.getGameState();
        }

        private void logInButton1_Click(object sender, EventArgs e)
        {
            logInLabel2.Text = "Click Button on Bridge";
            if(new Connection().ConnectPhilipsHUE() == true)
            {
                logInLabel1.Text = "Status: Connected";
                logInLabel1.ForeColor = Color.Green;
            }
            logInLabel2.Text = "Idle";
        }

        private void logInThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string udpurl = "";
            if (new Updator().CheckForUpdate(GetType().Assembly.GetName().Version.ToString(), out udpurl) == true)
            {
                MessageBox.Show("There is an update available!", "FNHue", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Process.Start(udpurl);
                Environment.Exit(0);
            }
            else
            {
                new Configs("Config//hue.json").Load();
                if (string.IsNullOrEmpty(h.username.ToString())) { logInLabel1.Text = "Status: Not Connected"; }
                else
                {
                    logInLabel1.Text = "Status: Connected";
                    logInLabel1.ForeColor = Color.Green;
                    logInButton1.Enabled = false;
                }
                panel1.BackColor = new Colors().GetColor(logInComboBox1.SelectedIndex);
                logInOnOffSwitch1.Toggled = boolToToggle(new Colors().CheckIfEnabled(logInComboBox1.SelectedIndex));
            }
        }

        private void logInComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.BackColor = new Colors().GetColor(logInComboBox1.SelectedIndex);
            logInOnOffSwitch1.Toggled = boolToToggle(new Colors().CheckIfEnabled(logInComboBox1.SelectedIndex));
        }

        private void logInButton3_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = panel1.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                Color c = MyDialog.Color;
                new Colors().SetColor(logInComboBox1.SelectedIndex, c);
                panel1.BackColor = c;
                new Configs("Config//hue.json").Load();
            }
        }
        private Toggles boolToToggle(bool b)
        {
            if (b == true)
                return Toggles.Toggled;
            else
                return Toggles.NotToggled;
        }

        private void logInOnOffSwitch1_MouseUp(object sender, MouseEventArgs e)
        {
            if (logInOnOffSwitch1.Toggled == Toggles.Toggled)
                new Colors().EnableColor(logInComboBox1.SelectedIndex, true);
            else
                new Colors().EnableColor(logInComboBox1.SelectedIndex, false);

            new Configs("Config//hue.json").Load();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://www.instagram.com/lk.preston");
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://www.twitter.com/OTSlay");
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/InsaneSlay");
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://github.com/InsaneSlay/FNHue/issues/new");
    }
}
