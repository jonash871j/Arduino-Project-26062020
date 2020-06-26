using System.Threading;
using ControllerLib;

class Program
{
    static Controller p1 = new Controller("COM9", 11200);
    static Controller p2 = new Controller("COM10", 11200);

    static void InputPlayer1()
    {
        if (p1.States.JoystickY > 600)
            Input.SetKeyState(ScanCodeKey.Down);
        else
            Input.DisableKeyState(ScanCodeKey.Down);

        if (p1.States.JoystickY < 400)
            Input.SetKeyState(ScanCodeKey.Up);
        else
            Input.DisableKeyState(ScanCodeKey.Up);
    }
    static void InputPlayer2()
    {
        if (p2.States.JoystickY > 600)
            Input.SetKeyState(ScanCodeKey.S);
        else
            Input.DisableKeyState(ScanCodeKey.S);

        if (p2.States.JoystickY < 400)
            Input.SetKeyState(ScanCodeKey.W);
        else
            Input.DisableKeyState(ScanCodeKey.W);

        if (p2.States.Button1)
            Input.SetMouseState(ScanCodeMouse.LeftDown);
        else
            Input.DisableMouseState(ScanCodeMouse.LeftDown);
    }

    static void Main(string[] args)
    {
        while (true)
        {
            InputPlayer1();
            InputPlayer2();

            Thread.Sleep(1);
        }
    }
}
