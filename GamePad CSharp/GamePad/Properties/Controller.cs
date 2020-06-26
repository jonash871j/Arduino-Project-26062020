using System.IO.Ports;
using System.Threading;

namespace Controller
{
    class Controller
    {
        private SerialPort serialPort;
        private DataTranslator translator;
        private States states;

        public States States
        {
            get { return states; }
        }

        public Controller(string COMPort, int baudrate)
        {
            serialPort = new SerialPort(COMPort, baudrate);
            serialPort.ReadTimeout = -1;
            serialPort.WriteTimeout = -1;

            translator = new DataTranslator(serialPort, "controller", 5);
            states = new States();

            Thread thread = new Thread(CommunicatorThread);
            thread.Start();
        }

        // Used to communicate with arduino in thread
        private void CommunicatorThread()
        {
            serialPort.Open();

            while (serialPort.IsOpen)
                UpdateInputStates();
        }


        // Used to listen on serial line and update controller states
        private void UpdateInputStates()
        {
            try
            {  
                // Gets data line
                string line = serialPort.ReadLine();

                // Trys to convert data line into useable data
                if (translator.ConvertLine(line))
                    states.UpdateInput(translator);
            }
            catch
            {
                // Closes serial to arduino
                serialPort.Close();
            }
        }
    }
}
