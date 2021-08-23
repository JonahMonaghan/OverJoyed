using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace OverJoyedWINFORM
{
    public class MouseListener
    {

        //Memory Locations
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_RBUTTONDOWN = 0X0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_RBUTTONDBLCLK = 0x0206;


        //No Idea
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);


        //Ptr Delegate
        private delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);


        //EventArgs e
        public event EventHandler<MousePressedArgs> OnMousePressed;

        private MouseHookHandler _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public MouseListener()
        {
            _proc = HookCallback;
        }

        public void HookMouse()
        {
            _hookID = SetHook(_proc);
        }

        public void UnHookMouse()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(1));

            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONUP)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(3));
            }

            if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONDOWN)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(2));
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONUP)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(4));
            }
            
            if(nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDBLCLK)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(5));
                Debug.WriteLine("Dbl Click!");
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_RBUTTONDBLCLK)
            {
                OnMousePressed?.Invoke(this, new MousePressedArgs(6));
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

    }

        /*LOGIC:
             * If I assign a number to each action, the event will return an action ID
             * Action 1: LDown
             * Action 2: RDown
             * Action 3: LUp
             * Action 4: RUp
             * Right?
             */
        public class MousePressedArgs : EventArgs
        {
            public int action { get; private set; }

            public MousePressedArgs(int btn)
            {
                action = btn;
            }
        }
}
