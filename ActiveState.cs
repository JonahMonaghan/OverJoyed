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
using static OverJoyedWINFORM.DictionaryEnums;

namespace OverJoyedWINFORM
{

    //inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_A);

    /*KeyCodes Array Explained:
    * KeyCodes Array Works in this order:
    * 0: Up
    * 1: Down
    * 2: Left
    * 3: Right
    * 
    * If Length > 4:
    * 4: Up, Left
    */

    public partial class ActiveMode : Form
    {

        Config activeConfig;

        //Size values will need to be fetched from config file
        int screenWidth = 1920;
        int screenHeight = 1080;

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
        private float deadZone = 100f;

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
            timer.Tick += new EventHandler(TimerTick);
            timer.Interval = 30; //Counts by ms
            timer.Enabled = true; //Ensure that the timer is enabled
            timer.Start(); //Start the timer

            this.Paint += this.pnlDraw_Paint;

            AssignKeyCodes();

            xStart = screenWidth / 2;
            yStart = screenHeight / 2;

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
            
            if (keyCodes.Count > 3 && isActive) //If the config is properly setup and the software is active
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
                }else if (counter == 7)
                {
                    xStart = float.Parse(configReader);
                }else if (counter == 8)
                {
                    yStart = float.Parse(configReader);
                }else if(counter == 9)
                {
                    deadZone = float.Parse(configReader);
                }else if (counter == 10)
                {
                    returnToCenterLC = bool.Parse(configReader);
                }else if (counter == 11)
                {
                    returnToCenterRC = bool.Parse(configReader);
                }
                counter++;
            }
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
            float _magnitudeX = Math.Abs(MousePosition.X - xStart);
            float _magnitudeY = Math.Abs(MousePosition.Y - yStart);
            float _mouseAngle = (float)Math.Atan2((MousePosition.Y - yStart), (MousePosition.X - xStart));
            _mouseAngle = (float)(180 / Math.PI) * _mouseAngle;

            bool markNextLine = false;

            if (_magnitudeX > deadZone || _magnitudeY > deadZone)
            {
                e.Graphics.DrawEllipse(penA, new RectangleF(screenWidth / 2 - deadZone, screenHeight / 2 - deadZone, deadZone * 2, deadZone * 2));
            }
            else
            {
                e.Graphics.DrawEllipse(penB, new RectangleF(screenWidth / 2 - deadZone, screenHeight / 2 - deadZone, deadZone * 2, deadZone * 2));
            }
            

            for (float _angle = -157.5f; _angle <= 157.5; _angle += 45f)
            {
                float _x1 = (float)Math.Sin((float)(Math.PI / 180) * (_angle + 90)) * deadZone + (screenWidth / 2);
                float _y1 = (float)Math.Cos((float)(Math.PI / 180) * (_angle - 90)) * deadZone + (screenHeight / 2);
                float _x2 = ((float)Math.Cos((float)(Math.PI / 180) * _angle) * 100f) + _x1;
                float _y2 = ((float)Math.Sin((float)(Math.PI / 180) * _angle) * 100f) + _y1;

                if ((_mouseAngle > _angle && _mouseAngle <= _angle + 45f && (_magnitudeX > deadZone || _magnitudeY > deadZone)) || markNextLine)
                {
                    e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);
                    markNextLine = !markNextLine;

                    if(_mouseAngle >= 157.5)
                    {
                       _x1 = (float)Math.Sin((float)(Math.PI / 180) * (-1 * _angle + 90)) * deadZone + (screenWidth / 2);
                       _y1 = (float)Math.Cos((float)(Math.PI / 180) * (-1 * _angle - 90)) * deadZone + (screenHeight / 2);
                       _x2 = ((float)Math.Cos((float)(Math.PI / 180) * -1 * _angle) * 100f) + _x1;
                       _y2 = ((float)Math.Sin((float)(Math.PI / 180) * -1 * _angle) * 100f) + _y1;
                       e.Graphics.DrawLine(penB, _x1, _y1, _x2, _y2);
                    }
                }
                else
                {
                    e.Graphics.DrawLine(penA, _x1, _y1, _x2, _y2);
                }
            }

            e.Graphics.DrawRectangle(penC, new Rectangle(new Point((int)xEnd, (int)yEnd), new Size(3, 3)));

            //IF - Mouse is within angles, draw that angle at full opacity, else draw with slight transparancy
            
        }

        void _mouse_OnMousePressed(object sender, MousePressedArgs e)
        {

            xEnd = Cursor.Position.X;
            yEnd = Cursor.Position.Y;

            float _magnitudeX = Math.Abs(xStart - xEnd);
            float _magnitudeY = Math.Abs(yStart - yEnd);

            if (isActive)
            {
                if (e.action == 1) //Btn A Down
                {
                    if (returnToCenterLC)
                    {
                        if (_magnitudeX < deadZone || _magnitudeY < deadZone) {
                            inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.A]);
                        }

                    }
                    else
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.A]);
                    }
                }
                else if (e.action == 2) //Btn B Down
                {
                    inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.B]);
                }
                else if (e.action == 3) //Btn A Up
                {
                    if (returnToCenterLC)
                    {
                        Cursor.Position = new Point((int)xStart, (int)yStart);
                    }
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.A]);
                }
                else if (e.action == 4) //Btn B Up
                {
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.B]);
                }else if (e.action == 5) //LMOUSE DBLCLK
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

            float _magnitudeX = Math.Abs(xStart - xEnd);
            float _magnitudeY = Math.Abs(yStart - yEnd);


            if (_magnitudeX > deadZone || _magnitudeY > deadZone)
            {
                float _angle = (float)Math.Atan2((yEnd - yStart), (xEnd - xStart));

                _angle = (float)(180 / Math.PI) * _angle;

                if (_angle > -112.5 && _angle <= -67.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.up]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);

                    //lblOutput = 

                }
                else if (_angle > -157.5 && _angle <= -112.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.up]);
                    }

                    if (!CheckKey(keyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.left]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
                }
                else if (_angle > 157.5 || (_angle > -179.999 && _angle <= -157.5)) //FLAGGED MIGHT BE WRONG
                {
                    if (!CheckKey(keyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.left]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
                }
                else if (_angle > 112.5 && _angle <= 157.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.left]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.left]);
                    }

                    if (!CheckKey(keyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.down]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                }
                else if (_angle > 67.5 && _angle <= 112.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.down]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                }
                else if (_angle > 22.5 && _angle <= 67.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.down]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.down]);
                    }
                    if (!CheckKey(keyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                }
                else if (_angle > -22.5 && _angle <= 22.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                }
                else if (_angle > -67.5 && _angle <= -22.5)
                {
                    if (!CheckKey(keyCodes[(int)directions.up]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.up]);
                    }
                    if (!CheckKey(keyCodes[(int)directions.right]))
                    {
                        inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.right]);
                    }

                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                    inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                }
            }
            else
            {
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
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

            if (yNegative && !CheckKey(keyCodes[(int)directions.up]))
            {
                //lblOutput.Text = "Up";
                inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.up]);
            }

            if (yPositive && !CheckKey(keyCodes[(int)directions.down]))
            {
                //lblOutput.Text = "Down";
                inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.down]);
            }

            if (xNegative && !CheckKey(keyCodes[(int)directions.left]))
            {
                //lblOutput.Text = "Left";
                inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.left]);
            }

            if (xPositive && !CheckKey(keyCodes[(int)directions.right]))
            {
                //lblOutput.Text = "Right";
                inputSimulator.Keyboard.KeyDown(keyCodes[(int)directions.right]);
            }

            //Release Keys when needed
            if (!xPositive)
            {
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.right]);
            }

            if (!xNegative)
            {
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.left]);
            }

            if (!yPositive)
            {
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.down]);
            }

            if (!yNegative)
            {
                inputSimulator.Keyboard.KeyUp(keyCodes[(int)directions.up]);
            }
        }

    }

}