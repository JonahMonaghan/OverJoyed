using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GregsStack.InputSimulatorStandard.Native;
using Newtonsoft.Json;

namespace OverJoyedWINFORM
{
    public partial class ConfigState : Form
    {

        string name = "test";
        int[] keys = new int[6];
        bool[] buttonsRTC = new bool[2];
        int originX, originY;
        int deadzoneSize;
        int screenScaling;

        VirtualKeyCode passedValue;

        int currentInputID;


        private LowLevelKeyboardListener _listener; //Keyboard Hook, DONE

        bool isListening;

        public ConfigState()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _listener = new LowLevelKeyboardListener();

            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();


        }

        private void KeyButtonClick(Button sender, int id)
        {
            isListening = true;
            sender.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = id;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnUp, 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnDown, 2);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnLeft, 3);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnRight, 4);
        }

        private void btnLC_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnLC, 5);
        }

        private void btnRC_Click(object sender, EventArgs e)
        {
            KeyButtonClick(btnRC, 6);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            /*if (!Int32.TryParse(txtOriginX.Text, out originX))
            {
                Console.WriteLine("Origin X value is wrong.");
            }

            if (!Int32.TryParse(txtOriginY.Text, out originY))
            {
                Console.WriteLine("Origin Y value is wrong.");
            }

            if(!Int32.TryParse(txtDeadzoneSize.Text, out deadzoneSize))
            {
                Console.WriteLine("Deadzone Size is wrong");
            }

            using (StreamWriter file = new StreamWriter(new FileStream(@".\config.txt", FileMode.OpenOrCreate)))
            {
                foreach(string line in directions)
                {
                    if(!string.IsNullOrWhiteSpace(line))
                    {
                        file.WriteLine(line);
                    }
                    else
                    {
                        Console.WriteLine("Invalid value in Directions array, delete config");
                    }
                }

                foreach(string line in buttons) {
                    
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        file.WriteLine(line);
                    }
                    else
                    {
                        Console.WriteLine("Invalid value in buttons array, delete config");
                    }
                
                }

                file.WriteLine(originX);
                file.WriteLine(originY);
                file.WriteLine(deadzoneSize);
                file.WriteLine(chkReturnLC.Checked);
                file.WriteLine(chkReturnRC.Checked);
                

            }*/

            List<int> tmpLst = keys.ToList<int>();
            Config cf = new Config(name, tmpLst, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 100, true, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2, deadzoneSize, buttonsRTC[0], buttonsRTC[1]);

            using (StreamWriter file = File.CreateText(@"Configs\" + cf.Name + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, cf);
            }

        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (isListening)
            {
                ToggleForm(true);
                passedValue = (VirtualKeyCode)e.KeyPressed;
                switch (currentInputID)
                {
                    case 1:
                        keys[0] = (int)passedValue;
                        break;
                    case 2:
                        keys[1] = (int)passedValue;
                        break;
                    case 3:
                        keys[2] = (int)passedValue;
                        break;
                    case 4:
                        keys[3] = (int)passedValue;
                        break;
                    case 5:
                        keys[4] = (int)passedValue;
                        break;
                    case 6:
                        keys[5] = (int)passedValue;
                        break;

                    default:
                        Console.WriteLine("Invalid ID:" + currentInputID + " adjust as needed");
                        break;
                }
                UpdateButtonText();
                isListening = false;
            }
            
        }

        void ToggleForm(bool status)
        {
            pnlDirections.Enabled = status;
            pnlClicks.Enabled = status;
            pnlDeadzone.Enabled = status;
            pnlOrigin.Enabled = status;
            pnlProfiles.Enabled = status;
        }

        void UpdateButtonText()
        {
            btnUp.Text = keys[0].ToString();
            btnDown.Text = keys[1].ToString();
            btnLeft.Text = keys[2].ToString();
            btnRight.Text = keys[3].ToString();
            btnLC.Text = keys[4].ToString();
            btnRC.Text = keys[5].ToString();
        }

    }
}
