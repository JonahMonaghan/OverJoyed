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
            { "up", VirtualKeyCode.UP },
            { "down", VirtualKeyCode.DOWN},
            { "left", VirtualKeyCode.LEFT},
            { "right", VirtualKeyCode.RIGHT},
            { "space", VirtualKeyCode.SPACE},
            { "lshift", VirtualKeyCode.LSHIFT},
            { "rshift", VirtualKeyCode.RSHIFT},
            { "w", VirtualKeyCode.VK_W},
            { "a", VirtualKeyCode.VK_A},
            { "s", VirtualKeyCode.VK_S},
            { "d", VirtualKeyCode.VK_D},
            { "z", VirtualKeyCode.VK_Z},
            { "x", VirtualKeyCode.VK_X},
            { "e", VirtualKeyCode.VK_E},
            { "a1", VirtualKeyCode.VK_1}
        };
    }
}
