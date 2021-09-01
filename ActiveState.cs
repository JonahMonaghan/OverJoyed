using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Input;
using GregsStack.InputSimulatorStandard.Native;
using GregsStack.InputSimulatorStandard;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

using static OverJoyedWINFORM.DictionaryEnums;

namespace OverJoyedWINFORM
{

    public partial class ActiveMode : Form
    {

        Config activeConfig;

        //Size values will need to be fetched from config file
        int screenWidth = 1920;
        int screenHeight = 1080;
        int screenScaling = 100;

        string configReader;

        //Settings booleans
        private bool isActive = false;

        //Zone booleans
        private bool isZone = false;

        //Vector booleans
        private bool isVector = true;

        //Vector variables
        private float xStart, xEnd, yStart, yEnd; //DONE

        //Needs config
        //private float deadZone = 100f;

        InputSimulator inputSimulator = new InputSimulator(); //Input Simulator , DONE

        List<VirtualKeyCode> keyCodes = new List<VirtualKeyCode>(); //DONE

        private LowLevelKeyboardListener _listener; //Keyboard Hook, DONE

        private MouseListener _mouse; //Mouse Hook, DONE

        //Previous mouse positions
        private int prevMouseX, prevMouseY;
        private bool posix; //was bool reset

        //Return to Center Bool
        private bool returnToCenterLC, returnToCenterRC;

        private bool mouseCalc = true;

        //Drawing Variables
        Pen penA;
        Pen penB;
        Pen penC;
        Rectangle centerRect;

        //Click Through DLL
        [DllImport("user32.dll", SetLastError = true)]
        static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, int dwFlags);

        //Top DLL - Keeps OverJoyed above other software
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        //Top DLL Constants
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public ActiveMode()
        {
            InitializeComponent();

            if (!File.Exists(@"\Configs\Default.json"))
            {
                Config cf = new Config();
                activeConfig = cf;
                using (StreamWriter file = File.CreateText(@"Configs\" + cf.Name + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, cf);
                }
            }
            else
            {
                using (StreamReader file = File.OpenText(@"\Configs\Default.json")){
                    JsonSerializer serializer = new JsonSerializer();
                    activeConfig = (Config)serializer.Deserialize(file, typeof(Config));
                }
            }



            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = 30; //Counts by ms
            timer.Enabled = true; //Ensure that the timer is enabled
            timer.Start(); //Start the timer

            this.Paint += this.pnlDraw_Paint;

            AssignKeyCodes();

        }

        private void TimerTick(object sender, EventArgs e)
        {
            
            //Debugging Position Output
            string xPos = "X: " + MousePosition.X.ToString();
            string yPos = "Y: " + MousePosition.Y.ToString();

            if (mouseCalc)
            {
                MouseCheck(MousePosition.X, MousePosition.Y);
            }

            prevMouseX = MousePosition.X;
            prevMouseY = MousePosition.Y;
            mouseCalc = !mouseCalc;

            Refresh();
        }

        /// <summary>
        /// A function that directs to the correct calculation method passing the mouse position
        /// </summary>
        /// <param name="mouseX">Mouse position on X-axis</param>
        /// <param name="mouseY">Mouse position on the Y-axis</param>
        private void MouseCheck(int mouseX, int mouseY)
        {
            
            if (activeConfig.KeyCodes.Count > 3 && isActive) //If the config is properly setup and the software is active
            { 

                if (isZone) //Zone mode is a 3x3 full screen method
                {
                    CalculateZone(mouseX, mouseY);
                }
                else if (isVector && isActive) //Vector mode is the control circle method
                {
                    CalculateVector(mouseX, mouseY);
                }
            }
        }

        /// <summary>
        /// A function that reads from the config file and converts each line to the proper mode
        /// </summary>
        private void AssignKeyCodes()
        {
            
            //NEW STUFF YAY!
            /*
            int counter = 0;
            StreamReader file = new StreamReader("config.txt");
            while ((configReader = file.ReadLine()) != null)
            {
                configReader = configReader.ToLower();
                Console.WriteLine(configReader);
                VirtualKeyCode code; 
                strToKey.TryGetValue(configReader, out code); //Replace Accept with dictionary conversion
                if (counter <= 5)
                {
                    keyCodes.Add(code);
                }else if(counter == 6)
                {
                    if (configReader == "vector")
                    {
                        isVector = true;
                        isZone = false;
                    }else if (configReader == "zone")
                    {
                        isZone = true;
                        isVector = false;
                    }
                }
                else if (counter == 7)
                {
                    screenWidth = int.Parse(configReader);
                }
                else if (counter == 8)
                {
                    screenHeight = int.Parse(configReader);
                }
                else if (counter == 9)
                {
                    screenScaling = int.Parse(configReader) / 100;
                }
                else if (counter == 10)
                {
                    activeConfig.XStart = float.Parse(configReader);
                }else if (counter == 11)
                {
                    yStart = float.Parse(configReader);
                }else if(counter == 12)
                {
                    deadZone = float.Parse(configReader);
                }else if (counter == 13)
                {
                    returnToCenterLC = bool.Parse(configReader);
                }else if (counter == 14)
                {
                    returnToCenterRC = bool.Parse(configReader);
                }
                counter++;
            } 
            
            screenWidth = screenWidth / screenScaling;
            
            screenHeight = screenHeight / screenScaling;
            */
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            int initialStyle = (int)GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);

            _listener = new LowLevelKeyboardListener();

            _mouse = new MouseListener();

            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _mouse.OnMousePressed += _mouse_OnMousePressed;

            _listener.HookKeyboard();

            _mouse.HookMouse();

            penA = new Pen(Color.FromArgb(15, 0, 0,255));
            penA.Width = 8.0f;
            penB = new Pen(Color.FromArgb(255, 0, 0, 255));
            penB.Width = 8.0f;

            penC = new Pen(Color.FromArgb(255, 255, 0, 0));
            penC.Width = 8.0f;

        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            string _keyHook = e.KeyPressed.ToString();
            //this.lblOutput.Text = _keyHook;
            if (_keyHook == "Return")
            {
                isActive = !isActive;
            }
            
        }

        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {
            //Console.WriteLine("Drawing UI"); 
            float _magnitudeX = Math.Abs(MousePosition.X - activeConfig.XStart);
            float _magnitudeY = Math.Abs(MousePosition.Y - activeConfig.YStart);
            float _mouseAngle = (float)Math.Atan2((MousePosition.Y - activeConfig.YStart), (MousePosition.X - activeConfig.XStart));
            _mouseAngle = (float)(180 / Math.PI) * _mouseAngle;

            //Console.WriteLine(_mouseAngle);

            bool markNextLine = false;

            if (_magnitudeX > activeConfig.DeadZone || _magnitudeY > activeConfig.DeadZone)
            {
                //Rectangle rect = new Rectangle(-16, -39, 120, 120);
                //e.Graphics.DrawEllipse(penA, rect);
                e.Graphics.DrawEllipse(penA, new RectangleF(activeConfig.XStart - (activeConfig.DeadZone + 16), activeConfig.YStart - (activeConfig.DeadZone + 39), activeConfig.DeadZone * 2, activeConfig.DeadZone * 2));
                
            }
            else
            {
                e.Graphics.DrawEllipse(penB, new RectangleF(activeConfig.XStart - (activeConfig.DeadZone + 16), activeConfig.YStart - (activeConfig.DeadZone + 39), activeConfig.DeadZone * 2, activeConfig.DeadZone * 2));
                
            }
            

            for (float _angle = -157.5f; _angle <= 157.5; _angle += 45f)
            {
                float _x1 = (float)Math.Sin((float)(Math.PI / 180) * (_angle + 90)) * activeConfig.DeadZone + activeConfig.XStart -16;
                float _y1 = (float)Math.Cos((float)(Math.PI / 180) * (_angle - 90)) * activeConfig.DeadZone + activeConfig.YStart - 39;
                float _x2 = ((float)Math.Cos((float)(Math.PI / 180) * _angle) * 100f) + _x1;
                float _y2 = ((float)Math.Sin((float)(Math.PI / 180) * _angle) * 100f) + _y1;

                if ((_mouseAngle > _angle && _mouseAngle <= _angle + 45f && (_magnitudeX > activeConfig.DeadZone || _magnitudeY > activeConfig.DeadZone)) || markNextLine)
                {
                    e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);

                    markNextLine = !markNextLine;
                }
                else
                {
                    e.Graphics.DrawLine(penA, _x1, _y1, _x2, _y2);
                }

                if (_angle == 157.5)
                {
                    if (_mouseAngle >= 157.5)
                    {
                        _x1 = (float)Math.Sin((float)(Math.PI / 180) * (-1 * _angle + 90)) * activeConfig.DeadZone + activeConfig.XStart - 16;
                        _y1 = (float)Math.Cos((float)(Math.PI / 180) * (-1 * _angle - 90)) * activeConfig.DeadZone + activeConfig.YStart - 39;
                        _x2 = ((float)Math.Cos((float)(Math.PI / 180) * -1 * _angle) * 100f) + _x1;
                        _y2 = ((float)Math.Sin((float)(Math.PI / 180) * -1 * _angle) * 100f) + _y1;
                        e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);
                    }
                    else if (_mouseAngle < -157.5)
                    {
                        _x1 = (float)Math.Sin((float)(Math.PI / 180) * (-1 * _angle + 90)) * activeConfig.DeadZone + activeConfig.XStart - 16;
                        _y1 = (float)Math.Cos((float)(Math.PI / 180) * (-1 * _angle - 90)) * activeConfig.DeadZone + activeConfig.YStart - 39;
                        _x2 = ((float)Math.Cos((float)(Math.PI / 180) * -1 * _angle) * 100f) + _x1;
                        _y2 = ((float)Math.Sin((float)(Math.PI / 180) * -1 * _angle) * 100f) + _y1;
                        e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);
                        _x1 = (float)Math.Sin((float)(Math.PI / 180) * (_angle + 90)) * activeConfig.DeadZone + activeConfig.XStart - 16;
                        _y1 = (float)Math.Cos((float)(Math.PI / 180) * (_angle - 90)) * activeConfig.DeadZone + activeConfig.YStart - 39;
                        _x2 = ((float)Math.Cos((float)(Math.PI / 180) * _angle) * 100f) + _x1;
                        _y2 = ((float)Math.Sin((float)(Math.PI / 180) * _angle) * 100f) + _y1;
                        e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);
                    }
                }
            }

            e.Graphics.DrawRectangle(penC, new Rectangle(new Point((int)xEnd - 16, (int)yEnd - 39), new Size(3, 3)));

            //IF - Mouse is within angles, draw that angle at full opacity, else draw with slight transparancy
            
        }

        void _mouse_OnMousePressed(object sender, MousePressedArgs e)
        {

            xEnd = System.Windows.Forms.Cursor.Position.X;
            yEnd = System.Windows.Forms.Cursor.Position.Y;

            float _magnitudeX = Math.Abs(activeConfig.XStart - xEnd);
            float _magnitudeY = Math.Abs(activeConfig.YStart - yEnd);

            if (isActive)
            {
                if (e.action == 1) //Btn A Down
                {
                    if (activeConfig.RtcLC)
                    {
                        if (_magnitudeX < activeConfig.DeadZone || _magnitudeY < activeConfig.DeadZone) {
                            inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.A]);
                        }

                    }
                    else
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.A]);
                    }
                }
                else if (e.action == 2) //Btn B Down
                {
                    if (activeConfig.RtcRC)
                    {
                        if (_magnitudeX < activeConfig.DeadZone || _magnitudeY < activeConfig.DeadZone)
                        
                            {
                            inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.B]);
                        }

                    }
                    else
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.B]);
                    }
                }
                else if (e.action == 3) //Btn A Up
                {
                    if (activeConfig.RtcLC)
                    {
                        System.Windows.Forms.Cursor.Position = new Point((int)activeConfig.XStart, (int)activeConfig.YStart);
                    }
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.A]);
                }
                else if (e.action == 4) //Btn B Up
                {
                    if (activeConfig.RtcRC)
                    {
                        System.Windows.Forms.Cursor.Position = new Point((int)activeConfig.XStart, (int)activeConfig.YStart);
                    }
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.B]);
                }
                else if (e.action == 5) //LMOUSE DBLCLK
                {
                    isActive = !isActive;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _listener.UnHookKeyboard();
            _mouse.UnHookMouse();
        }

        private bool CheckKey(GregsStack.InputSimulatorStandard.Native.VirtualKeyCode key)
        {
            return inputSimulator.InputDeviceState.IsHardwareKeyDown(key);
        }

        private void CalculateVector(int mouseX, int mouseY)
        {
            xEnd = mouseX;
            yEnd = mouseY;

            float _magnitudeX = Math.Abs(activeConfig.XStart - xEnd);
            float _magnitudeY = Math.Abs(activeConfig.YStart - yEnd);


            if (_magnitudeX > activeConfig.DeadZone || _magnitudeY > activeConfig.DeadZone)
            
                {
                float _angle = (float)Math.Atan2((yEnd - activeConfig.YStart), (xEnd - activeConfig.XStart));

                _angle = (float)(180 / Math.PI) * _angle;

                if (_angle > -112.5 && _angle <= -67.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.up]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);

                    //lblOutput = 

                }
                else if (_angle > -157.5 && _angle <= -112.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.up]);
                    }

                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.left]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
                }
                else if (_angle > 157.5 || (_angle > -179.999 && _angle <= -157.5)) //FLAGGED MIGHT BE WRONG
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.left]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
                }
                else if (_angle > 112.5 && _angle <= 157.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.left]);
                    }

                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.down]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                }
                else if (_angle > 67.5 && _angle <= 112.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.down]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                }
                else if (_angle > 22.5 && _angle <= 67.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.down]);
                    }
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                }
                else if (_angle > -22.5 && _angle <= 22.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                }
                else if (_angle > -67.5 && _angle <= -22.5)
                {
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.up]);
                    }
                    if (!CheckKey(activeConfig.KeyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                }
            }
            else
            {
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
            }
        }

        private void CalculateZone(int mouseX, int mouseY)
        {
            //Cuts the screen into 4 sections
            int centerW = screenWidth / 2;
            int centerH = screenHeight / 2;

            //Mouse Pos Bools
            bool xPositive, yPositive, xNegative, yNegative;

            //Cut the center out
            int deadzoneX = screenWidth / 6;
            int deadzoneY = screenHeight / 6;

            //Check for mousePos in relation to deadzone
            xPositive = mouseX > centerW + deadzoneX;
            xNegative = mouseX < centerW - deadzoneX;
            yPositive = mouseY > centerH + deadzoneY;
            yNegative = mouseY < centerH - deadzoneY;

            if (yNegative && !CheckKey(activeConfig.KeyCodes[(int)directions.up]))
            {
                //lblOutput.Text = "Up";
                inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.up]);
            }

            if (yPositive && !CheckKey(activeConfig.KeyCodes[(int)directions.down]))
            {
                //lblOutput.Text = "Down";
                inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.down]);
            }

            if (xNegative && !CheckKey(activeConfig.KeyCodes[(int)directions.left]))
            {
                //lblOutput.Text = "Left";
                inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.left]);
            }

            if (xPositive && !CheckKey(activeConfig.KeyCodes[(int)directions.right]))
            {
                //lblOutput.Text = "Right";
                inputSimulator.Keyboard.KeyDown(activeConfig.KeyCodes[(int)directions.right]);
            }

            //Release Keys when needed
            if (!xPositive)
            {
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.right]);
            }

            if (!xNegative)
            {
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.left]);
            }

            if (!yPositive)
            {
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.down]);
            }

            if (!yNegative)
            {
                inputSimulator.Keyboard.KeyUp(activeConfig.KeyCodes[(int)directions.up]);
            }
        }

    }

}