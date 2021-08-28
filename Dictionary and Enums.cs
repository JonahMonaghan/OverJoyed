using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GregsStack.InputSimulatorStandard.Native;

namespace OverJoyedWINFORM
{
    class DictionaryEnums
    {
        //Enums
        public enum directions
        {
            up,
            down,
            left,
            right,
            A,
            B
        }


        public static Dictionary<string, VirtualKeyCode> strToKey = new Dictionary<string, VirtualKeyCode>()
        {
            //Special Keys
            { "up", VirtualKeyCode.UP },
            { "down", VirtualKeyCode.DOWN},
            { "left", VirtualKeyCode.LEFT},
            { "right", VirtualKeyCode.RIGHT},
            { "space", VirtualKeyCode.SPACE},
            { "lshift", VirtualKeyCode.LSHIFT},
            { "rshift", VirtualKeyCode.RSHIFT},

            //Letters
            { "q", VirtualKeyCode.VK_Q},
            { "w", VirtualKeyCode.VK_W},
            { "e", VirtualKeyCode.VK_E},
            { "r", VirtualKeyCode.VK_R},
            { "t", VirtualKeyCode.VK_T},
            { "y", VirtualKeyCode.VK_Y},
            { "u", VirtualKeyCode.VK_U},
            { "i", VirtualKeyCode.VK_I},
            { "o", VirtualKeyCode.VK_O},
            { "p", VirtualKeyCode.VK_P},
            { "a", VirtualKeyCode.VK_A},
            { "s", VirtualKeyCode.VK_S},
            { "d", VirtualKeyCode.VK_D},
            { "f", VirtualKeyCode.VK_F},
            { "g", VirtualKeyCode.VK_G},
            { "h", VirtualKeyCode.VK_H},
            { "j", VirtualKeyCode.VK_J},
            { "k", VirtualKeyCode.VK_K},
            { "l", VirtualKeyCode.VK_Q},
            { "z", VirtualKeyCode.VK_Z},
            { "x", VirtualKeyCode.VK_X},
            { "c", VirtualKeyCode.VK_C},
            { "v", VirtualKeyCode.VK_V},
            { "b", VirtualKeyCode.VK_B},
            { "n", VirtualKeyCode.VK_N},
            { "m", VirtualKeyCode.VK_M},

            //Alpha Numbers
            { "alpha1", VirtualKeyCode.VK_1},
            { "alpha2", VirtualKeyCode.VK_2},
            { "alpha3", VirtualKeyCode.VK_3},
            { "alpha4", VirtualKeyCode.VK_4},
            { "alpha5", VirtualKeyCode.VK_5},
            { "alpha6", VirtualKeyCode.VK_6},
            { "alpha7", VirtualKeyCode.VK_7},
            { "alpha8", VirtualKeyCode.VK_8},
            { "alpha9", VirtualKeyCode.VK_9},
            { "alpha0", VirtualKeyCode.VK_0},

            //Numpad Numbers
            { "num1", VirtualKeyCode.NUMPAD1},
            { "num2", VirtualKeyCode.NUMPAD2},
            { "num3", VirtualKeyCode.NUMPAD3},
            { "num4", VirtualKeyCode.NUMPAD4},
            { "num5", VirtualKeyCode.NUMPAD5},
            { "num6", VirtualKeyCode.NUMPAD6},
            { "num7", VirtualKeyCode.NUMPAD7},
            { "num8", VirtualKeyCode.NUMPAD8},
            { "num9", VirtualKeyCode.NUMPAD9},
            { "num0", VirtualKeyCode.NUMPAD0}

        };
    }
}
