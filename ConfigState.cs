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

namespace OverJoyedWINFORM
{
    public partial class ConfigState : Form
    {

        string[] directions = new string[4];
        string[] buttons = new string[2];
        string[] buttonsRTC = new string[2];
        int originX, originY;
        int deadzoneSize;

        string stellaris; //passedValue

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

        private void btnUp_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnUp.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 1;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnDown.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 2;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnLeft.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 3;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnRight.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 4;
        }

        private void btnLC_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnLC.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 5;
        }

        private void btnRC_Click(object sender, EventArgs e)
        {
            isListening = true;
            btnRC.Text = "Waiting for Input";
            ToggleForm(false);
            currentInputID = 6;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (!Int32.TryParse(txtOriginX.Text, out originX))
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

            }


        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (isListening)
            {
                ToggleForm(true);
                stellaris = e.KeyPressed.ToString();
                switch (currentInputID)
                {
                    case 1:
                        directions[0] = stellaris;
                        break;
                    case 2:
                        directions[1] = stellaris;
                        break;
                    case 3:
                        directions[2] = stellaris;
                        break;
                    case 4:
                        directions[3] = stellaris;
                        break;
                    case 5:
                        buttons[0] = stellaris;
                        break;
                    case 6:
                        buttons[1] = stellaris;
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
            btnUp.Text = directions[0];
            btnDown.Text = directions[1];
            btnLeft.Text = directions[2];
            btnRight.Text = directions[3];
            btnLC.Text = buttons[0];
            btnRC.Text = buttons[1];
        }

    }
}
