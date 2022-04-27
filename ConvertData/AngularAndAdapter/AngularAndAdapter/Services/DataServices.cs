using AngularAndAdapter.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularAndAdapter.Services
{
    public class DataServices : IDataServices
    {
        private readonly ICommand _Icommand;

        public DataServices(ICommand icommand)
        {
            _Icommand = icommand;
        }
        // string to anything
        public string StringToBase64(string str)
        {
            return _Icommand.StringToBase64(str);
        }

        public string StringToByte(string str)
        {
            return _Icommand.StringToByte(str);
        }

        public string StringToHex(string str)
        {
            throw new NotImplementedException();
        }
        // convert anything to string
        public string Base64ToString(string str)
        {
            return _Icommand.Base64ToString(str);
        }
        public string HexToString(string str)
        {
            return _Icommand.HexToString(str);
        }
        public string ByteToString(string str)
        {
            return _Icommand.ByteToString(str);
        }
        //Hex convert
        public string HexToBase64(string str)
        {
            return _Icommand.HexToBase64(str);
        }
        public string HexToByte(string str)
        {
            return _Icommand.HexToByte(str);
        }
        //Base64 convert
        public string Base64ToHex(string str)
        {
            return _Icommand.Base64ToHex(str);
        }

        public string Base64ToByte(string str)
        {
            return _Icommand.Base64ToByte(str);
        }
        //Byte convert
        public string ByteToHex(string str)
        {
            return _Icommand.ByteToHex(str);
        }

        public string ByteToBase64(string str)
        {
            return _Icommand.ByteToBase64(str);
        }
    }
}
