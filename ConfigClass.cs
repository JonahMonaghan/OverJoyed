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
        public float XStart { get; set; }
        public float YStart { get; set; }
        public float DeadZone { get; set; }
        public bool RtcLC { get; set; }
        public bool RtcRC { get; set; }
        public bool SwitchConfig { get; set; }
        public Config AltConfig { get; set; }
        public Config()
        {
            Name = "Default Configuration";
            KeyCodes.Add(VirtualKeyCode.VK_W);
            KeyCodes.Add(VirtualKeyCode.VK_S);
            KeyCodes.Add(VirtualKeyCode.VK_A);
            KeyCodes.Add(VirtualKeyCode.VK_D);
            KeyCodes.Add(VirtualKeyCode.VK_Z); 
            KeyCodes.Add(VirtualKeyCode.VK_X);
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n)
        {
            Name = n;
            KeyCodes.Add(VirtualKeyCode.VK_W);
            KeyCodes.Add(VirtualKeyCode.VK_S);
            KeyCodes.Add(VirtualKeyCode.VK_A);
            KeyCodes.Add(VirtualKeyCode.VK_D);
            KeyCodes.Add(VirtualKeyCode.VK_Z);
            KeyCodes.Add(VirtualKeyCode.VK_X);
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst)
        {
            
            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            IsVector = true;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, bool iV)
        {
            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            IsVector = iV;
            XStart = Screen.PrimaryScreen.Bounds.Width / 2;
            YStart = Screen.PrimaryScreen.Bounds.Height / 2;
            DeadZone = 100f;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, bool iV, float xS, float yS, float dZ)
        {
            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = false;
            RtcRC = false;
        }

        public Config(string n, List<string> lst, bool iV, float xS, float yS, float dZ, bool l, bool r)
        {
            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
            IsVector = iV;
            XStart = xS;
            YStart = yS;
            DeadZone = dZ;
            RtcLC = l;
            RtcRC = r;
        }

        public Config(string n, List<string> lst, bool iV, float xS, float yS, float dZ, bool l, bool r, Config c)
        {
            Name = n;
            VirtualKeyCode code;
            foreach (string s in lst)
            {
                strToKey.TryGetValue(s, out code);
                KeyCodes.Add(code);
            }
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
