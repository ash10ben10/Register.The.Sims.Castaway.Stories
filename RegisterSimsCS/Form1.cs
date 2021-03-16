using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegisterSims3CC
{

    public partial class mainUI : Form
    {
        public mainUI()
        {
            InitializeComponent();
        }
        
        private void Reg_Click(object sender, EventArgs e)
        {
            //check if the game folder path is set first.
            //string gamefolder = gamepath.Text.Replace(@"\", @"\\");
            string gamefolder = gamepath.Text;
            if (string.IsNullOrEmpty(gamefolder))
            {
                string title = "No Folder Selected";
                string message = "Please select The Sims Castaway Stories folder.";
                MessageBox.Show(message, title);
            }
            else
            {
                /*
                string message = "The Selected folder is " + gamefolder + ".";
                MessageBox.Show(message);
                */

                RegistryKey SimsKey;

                //check the architecture of the OS
                if (Environment.Is64BitOperatingSystem)
                {
                    //check if registered keys exist
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    }

                    //register the sims castaway stories
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories\\egrc");
                    SimsKey.SetValue("", "N78QRZKW7428DB09DVTY");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey.SetValue("DisplayName", "The Sims™ Castaway Stories");
                    SimsKey.SetValue("Registration", "SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories\\ergc");
                    SimsKey.SetValue("CacheSize", "3126260736");
                    SimsKey.SetValue("SwapSize", "0");
                    SimsKey.SetValue("Language", "English UK");
                    SimsKey.SetValue("Locale", "en_uk");
                    SimsKey.SetValue("Install Dir", gamefolder);
                    SimsKey.SetValue("Product GUID", "{64EEA791-0271-4B53-00AC-2BF05F5FBEF6}");
                    SimsKey.SetValue("Region", "129397");
                    SimsKey.SetValue("Suppression Exe", "");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories\\1.0");
                    SimsKey.SetValue("Language", 00000019, RegistryValueKind.DWord);
                    SimsKey.SetValue("DisplayName", "The Sims™ Castaway Stories");
                    SimsKey.SetValue("LanguageName", "English UK");
                    SimsKey.Close();
                    
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    SimsKey.SetValue("", gamefolder + "\\TSBin\\SimsCS.exe");
                    SimsKey.SetValue("Path", gamefolder);
                    SimsKey.SetValue("Game Registry", "SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey.SetValue("Installed", 00000001, RegistryValueKind.DWord);
                    SimsKey.SetValue("Restart", 00000000, RegistryValueKind.DWord);
                    SimsKey.SetValue("DirectX Installed", 00000001, RegistryValueKind.DWord);

                    //let's display the registered pack/s via MessageBox
                    string title = "The Sims CS Registration";
                    string message = "The Sims Castaway Stories has been registered.";
                    MessageBox.Show(message, title);
                }
                else //else if architecture is 32 bit
                {
                    //check if registered keys exist
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    }

                    //register the sims castaway stories
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories\\egrc");
                    SimsKey.SetValue("", "N78QRZKW7428DB09DVTY");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey.SetValue("DisplayName", "The Sims™ Castaway Stories");
                    SimsKey.SetValue("Registration", "SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories\\ergc");
                    SimsKey.SetValue("CacheSize", "3126260736");
                    SimsKey.SetValue("SwapSize", "0");
                    SimsKey.SetValue("Language", "English UK");
                    SimsKey.SetValue("Locale", "en_uk");
                    SimsKey.SetValue("Install Dir", gamefolder);
                    SimsKey.SetValue("Product GUID", "{64EEA791-0271-4B53-00AC-2BF05F5FBEF6}");
                    SimsKey.SetValue("Region", "129397");
                    SimsKey.SetValue("Suppression Exe", "");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories\\1.0");
                    SimsKey.SetValue("Language", 00000019, RegistryValueKind.DWord);
                    SimsKey.SetValue("DisplayName", "The Sims™ Castaway Stories");
                    SimsKey.SetValue("LanguageName", "English UK");
                    SimsKey.Close();

                    SimsKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    SimsKey.SetValue("", gamefolder + "\\TSBin\\SimsCS.exe");
                    SimsKey.SetValue("Path", gamefolder);
                    SimsKey.SetValue("Game Registry", "SOFTWARE\\Electronic Arts\\The Sims Castaway Stories");
                    SimsKey.SetValue("Installed", 00000001, RegistryValueKind.DWord);
                    SimsKey.SetValue("Restart", 00000000, RegistryValueKind.DWord);
                    SimsKey.SetValue("DirectX Installed", 00000001, RegistryValueKind.DWord);

                    //let's display the registered pack/s via MessageBox
                    string title = "The Sims CS Registration";
                    string message = "The Sims Castaway Stories has been registered.";
                    MessageBox.Show(message, title);
                }
                
            }
        }
        
        private void gamepath_TextChanged(object sender, EventArgs e)
        {

        }

        private void selfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog selectpath = new FolderBrowserDialog();
            selectpath.Description = "Select the game folder of the Sims Castaway Stories:";

            if (selectpath.ShowDialog() == DialogResult.OK)
            {
                gamepath.Text = selectpath.SelectedPath;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Unreg_Click(object sender, EventArgs e)
        {
            DialogResult confirmUnregister = MessageBox.Show("This will remove the registration of The Sims Castaway Stories in this computer. Are you sure you want to proceed?", "Remove The Sims CS", MessageBoxButtons.YesNo);
            if (confirmUnregister == DialogResult.Yes)
            {
                //check the architecture of the OS
                if (Environment.Is64BitOperatingSystem)
                {
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    }
                    
                    string title = "Remove The Sims CS";
                    string message = "The Sims Castaway Stories has been removed.";
                    MessageBox.Show(message, title);
                }
                else //else if architecture is 32bit
                {
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Electronic Arts\\The Sims Castaway Stories");
                    }
                    if ((Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe")) != null)
                    {
                        Registry.LocalMachine.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\SimsCS.exe");
                    }

                    string title = "Remove The Sims CS";
                    string message = "The Sims Castaway Stories has been removed.";
                    MessageBox.Show(message, title);
                }
            }
        }
        
        private void mainUI_Load(object sender, EventArgs e)
        {

        }

        //this enables draging the window somewhere in the screen
        private void mainUI_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void mainUI_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

    }
}
