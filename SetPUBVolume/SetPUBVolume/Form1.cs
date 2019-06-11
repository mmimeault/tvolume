using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using System.Configuration;
using Newtonsoft.Json;

namespace SetPUBVolume
{
    public partial class Form1 : Form
    {
        private GameProfiles profiles;

        public Form1()
        {
            InitializeComponent();
            InitialiseProfile();

            var lastProcessIndex = Properties.Settings.Default.LastProcessIndex;

            InitialiseShortcutSelector();
            InitialiseProcessSelector();

            // bind default hotkey
            Program.gkh.HookedKeys.Add(Keys.F1);

            // hook functions
            Program.gkh.KeyDown += new KeyEventHandler(keyDown);

            if(!Program.gkh.isHooked())
                Program.gkh.hook();

            cmbProcessName.SelectedIndex = lastProcessIndex;
        }

        private void InitialiseShortcutSelector()
        {
            var AvailableKeys = new List<Keys>();
            var currentKey = Keys.F1;
            while (currentKey != Keys.F24)
            {
                AvailableKeys.Add(currentKey);
                
                currentKey++;
            }

            cmbShortcut.DataSource = AvailableKeys;
        }

        private void InitialiseProcessSelector()
        {
            var availableProcesses = new List<String>();

            availableProcesses.Add("Custom");
            availableProcesses.Add("TslGame");
            availableProcesses.Add("Overwatch");

            cmbProcessName.DataSource = availableProcesses;
        }

        private void InitialiseProfile()
        {
            profiles = JsonConvert.DeserializeObject<GameProfiles>(Properties.Settings.Default.Profiles);
            if (profiles == null)
            {
                profiles = new GameProfiles();
            }
            if (profiles.profiles == null)
            {
                profiles.profiles = new Dictionary<string, GameProfile>();
            }
        }

        void keyDown(object sender, KeyEventArgs e)
        {
            setVolume();
            e.Handled = true;
        }

        private AudioSessionManager2 getSession(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // unhook the hotkey
            Program.gkh.unhook();
            Properties.Settings.Default.LastProcessIndex = cmbProcessName.SelectedIndex;
            Properties.Settings.Default.Profiles = JsonConvert.SerializeObject(profiles);
            Properties.Settings.Default.Save();
        }

        private void cmbShortcut_SelectedValueChanged(object sender, EventArgs e)
        {
            Program.gkh.unhook();
            Program.gkh.HookedKeys.Clear();
            Program.gkh.HookedKeys.Add((Keys)cmbShortcut.SelectedItem);

            if (!Program.gkh.isHooked())
                Program.gkh.hook();
        }

        private void cmbProcessName_SelectedValueChanged(object sender, EventArgs e)
        {
            loadProfile();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            saveProfile();
        }

        private void loadProfile()
        {
            var processName = getProcessName();

            if (processName == null | processName.Length == 0 || !profiles.profiles.ContainsKey(processName))
            {
                cmbShortcut.SelectedIndex = 0;
                volumeA.Text = "100";
                volumeB.Text = "25";
                return;
            }

            GameProfile profile = profiles.profiles[processName];
            cmbShortcut.SelectedIndex = profile.shortcutIndex;
            volumeA.Text = profile.volumeAValue;
            volumeB.Text = profile.volumeBValue;
        }

        private void saveProfile()
        {
            var processName = getProcessName();

            if (processName == null | processName.Length == 0)
            {
                return;
            }

            GameProfile gameProfile = new GameProfile();
            gameProfile.shortcutIndex = cmbShortcut.SelectedIndex;
            gameProfile.volumeAValue = volumeA.Text;
            gameProfile.volumeBValue = volumeB.Text;

            if (profiles.profiles.ContainsKey(processName)) { 
                profiles.profiles.Remove(processName);
            }
            profiles.profiles.Add(processName, gameProfile);
        }

        private string getProcessName()
        {
            if (cmbProcessName.SelectedIndex == 0)
            {
                return processName.Text;
            }
            return (String) cmbProcessName.SelectedValue;
        }


        public void setVolume()
        {
            var processName = getProcessName();
            using (var sessionManager = getSession(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        bool setVolume = false;

                        using (var control = session.QueryInterface<AudioSessionControl2>())
                        {

                            if (control.Process != null)
                            {
                                if (control.Process.ProcessName.Contains(processName))
                                {
                                    setVolume = true;
                                }
                            }
                        }

                        if (setVolume)
                        {
                            using (var simpleVolume = session.QueryInterface<SimpleAudioVolume>())
                            {
                                float volume = simpleVolume.MasterVolume;

                                int vol1;
                                int vol2;

                                if (Int32.TryParse(volumeA.Text, out vol1) && Int32.TryParse(volumeB.Text, out vol2))
                                {
                                    float volA = Math.Min(1f, vol1 / 100f);
                                    float volB = Math.Min(1f, vol2 / 100f);

                                    if (volume == volB)
                                        simpleVolume.MasterVolume = volA;
                                    else
                                        simpleVolume.MasterVolume = volB;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
