using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Policy;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;


namespace rndxAutoClicker
{
    public partial class Form1 : Form
    {
        private bool isStarted = false;

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOD_NONE = 0x0000;
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID = 1;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifier, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private Keys assignedKey;
        private bool isWaitingForKey = false;

        //Save Settings
        private string dirPath = "cfgs";
        private string cfgFileName = "config.json";

        public Form1()
        {
            InitializeComponent();

            RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, (int)assignedKey); // Register the key to Enable/Disable Macros.

            comboBoxMouseButton.SelectedIndex = 0; // Default "Left" on Mouse Button Dropdown Menu.

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private class AppConfig
        {
            public bool isHoldClickChecked { get; set; }
            public int comboBoxClickButton { get; set; }
            public string textBoxMiliseconds { get; set; }
            public Keys assignedKeyStored { get; set; }
        }

        private void SaveAppState()
        {
            var config = new AppConfig
            {
                isHoldClickChecked = checkBoxHold.Checked,
                comboBoxClickButton = comboBoxMouseButton.SelectedIndex,
                textBoxMiliseconds = msInput.Text,
                assignedKeyStored = assignedKey
            };

            string json = JsonSerializer.Serialize(config);

            // Save the config file
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath); // Create the directory if it doesn't exist.
                }
                File.WriteAllText(Path.Combine(dirPath, cfgFileName), json);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error saving config file: " + ex.Message); // Show an error message if the file couldn't be saved.
            }
        }

        private void LoadAppState()
        {
            if (File.Exists(Path.Combine(dirPath, cfgFileName)))
            {
                string json = File.ReadAllText(Path.Combine(dirPath, cfgFileName));
                var config = JsonSerializer.Deserialize<AppConfig>(json);

                // Load the data from the config file
                checkBoxHold.Checked = config.isHoldClickChecked;
                comboBoxMouseButton.SelectedIndex = config.comboBoxClickButton;
                msInput.Text = config.textBoxMiliseconds;
                assignedKey = config.assignedKeyStored;

                // Register the key
                RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, (int)assignedKey);
                // Assign the text to the buttons
                buttonStartMacro.Text = "Start (" + assignedKey.ToString() + ")";
                buttonStopMacro.Text = "Stop (" + assignedKey.ToString() + ")";
            }
            else
            {
                // Default settings
                checkBoxHold.Checked = false;
                comboBoxMouseButton.SelectedIndex = 0;
                msInput.Text = "1000";

                //Set some more things up:
                buttonStartMacro.Text = "Start";
                buttonStopMacro.Text = "Stop";
                buttonStartMacro.Enabled = false;
                buttonStopMacro.Enabled = false;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == HOTKEY_ID)
            {
                // Perform your action when F6 is pressed
                StartStopMacro();
            }
            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveAppState();

            UnregisterHotKey(this.Handle, HOTKEY_ID);

            base.OnFormClosing(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadAppState();

            base.OnLoad(e);
        }

        void StartStopMacro()
        {
            if (isStarted)
            {
                StopMacro();
            }
            else
            {
                StartMacro();
            }
        }

        private void StartMacro()
        {
            if (!checkBoxHold.Checked)
            {
                //Start Timer (Auto Clicker)
                timerAutoClicker.Interval = (int)(Int32.Parse(msInput.Text));
                timerAutoClicker.Start();
            }
            else
            {
                if (comboBoxMouseButton.SelectedIndex == 0) //Left Click
                {
                    mouse_event(0x0002, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 1) //Right Click
                {
                    mouse_event(0x0008, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 2) //Middle Click
                {
                    mouse_event(0x0020, 0, 0, 0, 0);
                }
            }

            //Disable the StartMacro Button, and enable the StopMacro one.
            buttonStartMacro.Enabled = false;
            buttonStopMacro.Enabled = true;
            buttonStartMacro.Cursor = Cursors.Arrow;
            buttonStopMacro.Cursor = Cursors.Hand;

            isStarted = true;
        }

        private void StopMacro()
        {
            if (!checkBoxHold.Checked)
            {
                //Stop Timer (Auto Clicker)
                timerAutoClicker.Stop();
            }
            else
            {
                if (comboBoxMouseButton.SelectedIndex == 0) //Left Click
                {
                    mouse_event(0x0004, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 1) //Right Click
                {
                    mouse_event(0x0010, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 2) //Middle Click
                {
                    mouse_event(0x0040, 0, 0, 0, 0);
                }
            }

            //Disable the StopMacro Button, and enable the StartMacro one.
            buttonStartMacro.Enabled = true;
            buttonStopMacro.Enabled = false;
            buttonStartMacro.Cursor = Cursors.Hand;
            buttonStopMacro.Cursor = Cursors.Arrow;

            isStarted = false;
        }

        private void buttonStartMacro_Click(object sender, EventArgs e)
        {
            StartMacro();
        }

        private void buttonStopMacro_Click(object sender, EventArgs e)
        {
            StopMacro();
        }

        private void AutoClicker_Tick(object sender, EventArgs e)
        {
            if (!Bounds.Contains(PointToClient(MousePosition)))
            {
                if (comboBoxMouseButton.SelectedIndex == 0) //Left Click
                {
                    mouse_event(0x0002, 0, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    mouse_event(0x0004, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 1) //Right Click
                {
                    mouse_event(0x0008, 0, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    mouse_event(0x0010, 0, 0, 0, 0);
                }
                else if (comboBoxMouseButton.SelectedIndex == 2) //Middle Click
                {
                    mouse_event(0x0020, 0, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    mouse_event(0x0040, 0, 0, 0, 0);
                }

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isWaitingForKey)
            {
                UnregisterHotKey(this.Handle, HOTKEY_ID); // Unregister the previous Key.

                assignedKey = e.KeyCode;
                buttonStartMacro.Text = "Start (" + assignedKey.ToString() + ")";
                buttonStopMacro.Text = "Stop (" + assignedKey.ToString() + ")";

                RegisterHotKey(this.Handle, HOTKEY_ID, MOD_NONE, (int)assignedKey);

                isWaitingForKey = false;
                buttonAssignKey.Enabled = true;
                buttonStartMacro.Enabled = true;
                buttonStopMacro.Enabled = false;

                if(!checkBoxHold.Checked)
                    msInput.Enabled = true;
                else 
                    msInput.Enabled = false;
            }
        }

        private void buttonAssignKey_Click(object sender, EventArgs e)
        {
            isWaitingForKey = true;
            buttonAssignKey.Enabled = false;

            StopMacro();
            buttonStartMacro.Enabled = false;
            buttonStopMacro.Enabled = false;

            msInput.Enabled = false;

        }

        private void checkBoxHold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHold.Checked)
                msInput.Enabled = false;
            else
                msInput.Enabled = true;
        }

        private void PotatoLinkToGithub(object sender, EventArgs e)
        {
            string githubUrl = "https://github.com/randexlofi";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = githubUrl,
                    UseShellExecute = true, //Ensure the link is opened in the default browser.
                });
            }catch (Exception ex)
            {
                MessageBox.Show("Failed to open the link: " + ex.Message);
            }
        }
    }
}
