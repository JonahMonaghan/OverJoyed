using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GregsStack.InputSimulatorStandard.Native;
using static OverJoyedWINFORM.DictionaryEnums;

namespace OverJoyedWINFORM
{
    class Config
    {
        public string Name { get; set; }
        public List<VirtualKeyCode> KeyCodes { get; set; }
        public bool IsVector { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenScaling { get; set; }

        public float XStart { get; set; }
        public float YStart { get; set; }
        public float DeadZone { get; set; }
        public bool RtcLC { get; set; }
        public bool RtcRC { get; set; }
        public bool SwitchConfig { get; set; }
        public Config AltConfig { get; set; }
        public Config()
        {

            KeyCodes = new List<VirtualKeyCode>();

            Name = "Default";
            KeyCodes.Add(VirtualKeyCode.VK_W);
            KeyCodes.Add(VirtualKeyCode.VK_S);
            KeyCodes.Add(VirtualKeyCode.VK_A);
            KeyCodes.Add(VirtualKeyCode.VK_D);
            KeyCodes.Add(VirtualKeyCode.VK_Z); 
            KeyCodes.Add(VirtualKeyCode.VK_X);
            ScreenWidth = 1920;
            ScreenHeight = 1080;
            ScreenScaling = 100;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            KeyCodes.Add(VirtualKeyCode.VK_W);
            KeyCodes.Add(VirtualKeyCode.VK_S);
            KeyCodes.Add(VirtualKeyCode.VK_A);
            KeyCodes.Add(VirtualKeyCode.VK_D);
            KeyCodes.Add(VirtualKeyCode.VK_Z);
            KeyCodes.Add(VirtualKeyCode.VK_X);
            ScreenWidth = 1920;
            ScreenHeight = 1080;
            ScreenScaling = 100;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = 1920;
            ScreenHeight = 1080;
            ScreenScaling = 100;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<int> lst)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = 1920;
            ScreenHeight = 1080;
            ScreenScaling = 100;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, int sW, int sH, int sS)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<int> lst, int sW, int sH, int sS)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, int sW, int sH, int sS, bool iV)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<int> lst, int sW, int sH, int sS, bool iV)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<int> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ, bool l, bool r)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = l;
            RtcRC = r;
        }

        public Config(string n, List<int> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ, bool l, bool r)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = l;
            RtcRC = r;
        }

        public Config(string n, List<string> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ, bool l, bool r, Config c)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = l;
            RtcRC = r;
            SwitchConfig = true;
            AltConfig = c;
        }

        public Config(string n, List<int> lst, int sW, int sH, int sS, bool iV, float xS, float yS, float dZ, bool l, bool r, Config c)
        {
            KeyCodes = new List<VirtualKeyCode>();

            Name = n;
            foreach (int i in lst)
            {
                KeyCodes.Add((VirtualKeyCode)i);
            }
            ScreenWidth = sW;
            ScreenHeight = sH;
            ScreenScaling = sS;
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = l;
            RtcRC = r;
            SwitchConfig = true;
            AltConfig = c;
        }

    }
}
