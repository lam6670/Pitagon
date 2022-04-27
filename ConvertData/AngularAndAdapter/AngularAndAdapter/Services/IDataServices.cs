using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAdapter.Services
{
    public interface IDataServices
    {
        //string to anything
        public string StringToBase64(string str);
        public string StringToByte(string str);
        public string StringToHex(string str);
        // anything convert to string
        public string ByteToString(string str);
        public string Base64ToString(string str);
        public string HexToString(string str);
        // Hex convert
        public string HexToBase64(string str);
        public string HexToByte(string str);
        // Base64 convert
        public string Base64ToHex(string str);
        public string Base64ToByte(string str);
        // Byte convert
        public string ByteToHex(string str);
        public string ByteToBase64(string str);

    }
}
