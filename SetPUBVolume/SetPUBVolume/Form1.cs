using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using System.Configuration;

namespace SetPUBVolume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var lastKeyUsed = Properties.Settings.Default.LastKeyUsed;

            InitialiseShortcutSelector();

            // bind default hotkey
            Program.gkh.HookedKeys.Add(Keys.F1);

            // hook functions
            Program.gkh.KeyDown += new KeyEventHandler(keyDown);

            if(!Program.gkh.isHooked())
                Program.gkh.hook();

            cmbShortcut.SelectedIndex = lastKeyUsed;
            volumeA.Text = "75";
            volumeB.Text = "15";
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

        public void setVolume()
        {
            using (var sessionManager = getSession(DataFlow.Render))
            {
                using (var sessionEnumerator = sessionManager.GetSessionEnumerator())
                {
                    foreach (var session in sessionEnumerator)
                    {
                        bool setVolume = false;

                        using (var control = session.QueryInterface<AudioSessionControl2>())
                        {
                            
                            if(control.Process != null)
                            {
                                if (control.Process.ProcessName.Contains(processName.Text))
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
            Properties.Settings.Default.Save();
        }

        private void cmbShortcut_DisplayMemberChanged(object sender, EventArgs e)
        {

        }

        private void cmbShortcut_SelectedValueChanged(object sender, EventArgs e)
        {
            Program.gkh.unhook();
            Program.gkh.HookedKeys.Clear();
            Program.gkh.HookedKeys.Add((Keys)cmbShortcut.SelectedItem);

            if (!Program.gkh.isHooked())
                Program.gkh.hook();

            Properties.Settings.Default.LastKeyUsed = cmbShortcut.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
