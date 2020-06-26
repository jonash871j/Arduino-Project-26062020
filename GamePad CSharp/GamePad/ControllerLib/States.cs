namespace ControllerLib
{
    public class States
    {
        private short joystickX = 512;
        private short joystickY = 512;
        private bool joystickButton = false;
        private bool button1 = false;
        private bool button2 = false;
        private bool button3 = false;
        private bool button4 = false;
        private bool button5 = false;
        private bool button6 = false;

        public short JoystickX
        {
            get { return joystickX; }
        }
        public short JoystickY
        {
            get { return joystickY; }
        }
        public bool JoystickButton
        {
            get { return joystickButton; }
        }
        public bool Button1
        {
            get { return button1; }
        }
        public bool Button2
        {
            get { return button2; }
        }
        public bool Button3
        {
            get { return button3; }
        }
        public bool Button4
        {
            get { return button4; }
        }
        public bool Button5
        {
            get { return button5; }
        }
        public bool Button6
        {
            get { return button6; }
        }

        internal States()
        {

        }
        internal States(DataTranslator dataTranslator)
        {
            UpdateInput(dataTranslator);
        }

        /// <summary>
        /// Used to update input from dataTranslator
        /// </summary>
        internal void UpdateInput(DataTranslator dataTranslator)
        {
            // Reads values from joystick
            joystickX = dataTranslator.GetShort(0);
            joystickY = dataTranslator.GetShort(2);
            joystickButton = GetBit(dataTranslator.GetByte(4), 6);

            // Reads values from the four game buttons
            button1 = GetBit(dataTranslator.GetByte(4), 5);
            button2 = GetBit(dataTranslator.GetByte(4), 4);
            button3 = GetBit(dataTranslator.GetByte(4), 3);
            button4 = GetBit(dataTranslator.GetByte(4), 2);

            // Reads values from the lower two game buttons
            button5 = GetBit(dataTranslator.GetByte(4), 1);
            button6 = GetBit(dataTranslator.GetByte(4), 0);
        }

        // Used to get a specific state of bit in a byte
        private bool GetBit(byte b, int bit)
        {
            return (b & (1 << bit)) != 0;
        }
    };
}
