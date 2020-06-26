using System.IO.Ports;

namespace ControllerLib
{
    internal class DataTranslator
    {
        private SerialPort serialPort;
        private string key;
        private int size;
        private byte[] dataArray;


        internal DataTranslator(SerialPort serialPort, string key, int size)
        {
            this.serialPort = serialPort;
            this.key = key;
            this.size = size;
        }

        // Used to get data
        private byte[] GetData(string line)
        {
            byte[] dataArray = new byte[size];
            int byteArrayIndex = 0;
            string value = "";

            for (int i = key.Length + 1; i < line.Length; i++)
            {
                if (line[i] == '-')
                {
                    dataArray[byteArrayIndex] = byte.Parse(value);
                    byteArrayIndex++;
                    value = "";

                    continue;
                }
                value += line[i];
            }

            return dataArray;
        }

        // Used to get key
        private string GetKey(string line)
        {
            string key = "";

            for (int i = 0; (!string.IsNullOrEmpty(line)) && (i < line.Length); i++)
                if (line[i] != ':')
                    key += line[i];
                else
                    break;

            return key;
        }

        /// <summary>
        /// Used to convert serial line into useable data
        /// </summary>
        internal bool ConvertLine(string line)
        {
            // Gets key and checks key if it's valid
            if (GetKey(line) != key)
                return false;

            // Gets data from line
            dataArray = GetData(line);

            // Write hash to notefy arduiono that the packet was recived
            serialPort.WriteLine("#");

            return true;
        }

        /// <summary>
        /// Used to get byte from dataArray
        /// </summary>
        internal byte GetByte(int index)
        {
            return dataArray[index];
        }

        /// <summary>
        /// Used to get short from dataArray
        /// </summary>
        internal short GetShort(int index)
        {
            return (short)((dataArray[index+1] << 8) | (dataArray[index]));
        }

        /// <summary>
        /// Used to get int from dataArray
        /// </summary>
        internal int GetInt(int index)
        {
            return ((dataArray[index + 3] << 24) | (dataArray[index+2] << 16) | (dataArray[index+1] << 8) | (dataArray[index]));
        }
    }
}
