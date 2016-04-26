using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace VanillaSpamBot
{
    class WoWSlashCommand
    {

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr thWnd, int msg, int wParam, IntPtr lParam);

        private const int WM_CHAR = 0x0102;
        private const int VK_CONTROL = 0xA2;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int VK_RETURN = 0x0D;
        private const int VK_ESCAPE = 0x1B;

        public static void send(IntPtr hWnd, string slashCommand)
        {
            // Object savedClipboard = Clipboard.GetDataObject();
            //Clipboard.SetText(slashCommand);

            SendMessage(hWnd, WM_KEYDOWN, VK_ESCAPE, IntPtr.Zero);
            SendMessage(hWnd, WM_KEYUP, VK_ESCAPE, IntPtr.Zero);

            SendMessage(hWnd, WM_KEYDOWN, VK_RETURN, IntPtr.Zero);
            SendMessage(hWnd, WM_KEYUP, VK_RETURN, IntPtr.Zero);
            int i = 0;
            foreach (char c in slashCommand)
            {
                IntPtr val = new IntPtr(c);
                if(i<2)
                    Thread.Sleep(200);
                SendMessage(hWnd, WM_CHAR, c, IntPtr.Zero);
                SendMessage(hWnd, WM_KEYDOWN, VK_CONTROL, IntPtr.Zero);
                SendMessage(hWnd, WM_KEYDOWN, 0x56, IntPtr.Zero);
                SendMessage(hWnd, WM_KEYUP, 0x56, IntPtr.Zero);
                SendMessage(hWnd, WM_KEYUP, VK_CONTROL, IntPtr.Zero);
                i++;
            }
            SendMessage(hWnd, WM_KEYDOWN, VK_RETURN, IntPtr.Zero);
            SendMessage(hWnd, WM_KEYUP, VK_RETURN, IntPtr.Zero);
        }

        public static void enter(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_KEYDOWN, VK_RETURN, IntPtr.Zero);
            SendMessage(hWnd, WM_KEYUP, VK_RETURN, IntPtr.Zero);
        }
    }
}
