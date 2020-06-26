using System;
using System.Runtime.InteropServices;


enum ScanCodeKey
{
    Num1 = 0x02,
    Num2 = 0x03,	
    Num3 = 0x04,	
    Num4 = 0x05,	
    Num5 = 0x06,	
    Num6 = 0x07,	
    Num7 = 0x08,	
    Num8 = 0x09,	
    Num9 = 0x0a,	
    Num0 = 0x0b,	
    Minus = 0x0c,	
    Equals = 0x0d,	
    Backspace = 0x0e,	
    Tab= 0x0f,	
    Q= 0x10,	
    W= 0x11,	
    E= 0x12,	
    R= 0x13,	
    T= 0x14,	
    Y= 0x15,	
    U= 0x16,	
    I= 0x17,	
    O= 0x18,	
    P= 0x19,	
    A= 0x1e,	
    S= 0x1f,	
    D= 0x20,	
    F= 0x21,	
    G= 0x22,	
    H= 0x23,	
    J= 0x24,	
    K= 0x25,	
    L= 0x26,	
    Enter= 0x1c,	
    LShift= 0x2a,	
    Z= 0x2c,	
    X= 0x2d,	
    C= 0x2e,	
    V= 0x2f,	
    B= 0x30,	
    N= 0x31,	
    M= 0x32,	
    RShift= 0x36,	
    LCtrl= 0x38,	
    LAlt= 0x71,	
    Space= 0x39,	
	RAlt = 0x72,
    RCtrl = 0x3a,
    Insert = 0x7b,
    Delete = 0x79,
    Home = 0x7f,
    End = 0x7a,
    PgUp = 0x6f,
    PgDn = 0x7e,
    Left = 0x56,
    Up = 0x48,
    Down = 0x50,
    Right = 0x7d,
    NumLock = 0x01,
    Ins = 0x52,
    Del = 0x53,
    KP_Enter = 0x4e,
    Esc = 0x64,
    F1 = 0x58,
    F2 = 0x59,
    F3 = 0x5a,
    F4 = 0x5b,
    F5 = 0x5c,
    F6 = 0x5d,
    F7 = 0x5e,
    F8 = 0x5f,
    F9 = 0x60,
    F10 = 0x61,
    F11 = 0x62,
    F12 = 0x63,
};

enum ScanCodeMouse
{
    LeftDown = 0x0002,
    RightDown = 0x0008,
    MiddleDown = 0x0020,
}

static class Input
{
    #region input functions from WinAPI
    [StructLayout(LayoutKind.Sequential)]
    private struct Point
    {
        public int X;
        public int Y;
    }

    [DllImport("User32.dll")]
    static private extern void keybd_event(
        byte bVk,
        byte bScan,
        uint dwFlags,
        IntPtr dwExtraInfo
    );
    [DllImport("User32.dll")]
    static private extern void mouse_event(
        uint dwFlags,
        int dx,
        int dy,
        uint dwData,
        IntPtr dwExtraInfo
    );

    [DllImport("User32.dll")]
    static private extern void SetCursorPos(int x, int y);

    [DllImport("User32.dll")]
    static private extern void GetCursorPos(out Point point);
    #endregion

    static private bool[] keyStates = new bool[255];
    static private bool[] mouseStates = new bool[255];

    static public void SetKeyState(ScanCodeKey key)
    {
        keyStates[(byte)key] = true;
        keybd_event(0, (byte)key, 8, IntPtr.Zero);
    }

    static public void DisableKeyState(ScanCodeKey key)
    {
        if (keyStates[(byte)key] == true)
        {
            keybd_event(0, (byte)key, 8 | 2, IntPtr.Zero);
            keyStates[(byte)key] = false;
        }
    }

    static public void SetMouseDelta(int x, int y)
    {
        mouse_event(0x8000 | 0x0001, x, y, 0, IntPtr.Zero);
    }

    static public void SetMouseState(ScanCodeMouse mouse)
    {
        mouseStates[(byte)mouse] = true;
        mouse_event((uint)mouse, 0, 0, 0, IntPtr.Zero);
        
    }

    static public void DisableMouseState(ScanCodeMouse mouse)
    {
        if (mouseStates[(byte)mouse] == true)
        {
            mouse_event((uint)mouse*2, 0, 0, 0, IntPtr.Zero);
            mouseStates[(byte)mouse] = false;
        }
    }
}

