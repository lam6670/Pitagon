using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularAndAdapter.DAO
{
    public class MockData:ICommand
    {
        //String to anything
        public string StringToBase64(string str)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string StringToHex(string str)
        {
            var plainTextHex = string.Join("",
                str.Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));
            return plainTextHex;
        }

        public string StringToByte(string str)
        {
            byte[] pass = Encoding.UTF8.GetBytes(str);
            string passconverted = "";
            for (int i = 0; i < pass.Length; i++)
            {
                passconverted = passconverted + pass[i].ToString();
                if (i < pass.Length - 1)
                {
                    passconverted = passconverted + "-";
                }
            }
            return passconverted;
        }
        //Everything convert to String
        public string Base64ToString(string str)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public string HexToString(string str)
        {
            byte[] hex = Enumerable.Range(0, str.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                     .ToArray();
            return System.Text.Encoding.ASCII.GetString(hex);
        }

        public string ByteToString(string str)
        {
            string[] text = str.Split("-");
            List<byte> result = new List<byte>();
                for (int i = 0; i < text.Length; i++)
                {
                result.Add((byte)int.Parse(text[i].ToString()));
                }
            return Encoding.ASCII.GetString(result.ToArray());
        }
        // Hex convert
        public string HexToBase64(string str)
        {
            string plaintext = HexToString(str);
            return StringToBase64(plaintext); ;
        }

        public string HexToByte(string str)
        {
            string plaintext = HexToString(str);
            return StringToByte(plaintext);
        }
        // Base64 Convert
        public string Base64ToHex(string str)
        {
            string plaintext = Base64ToString(str);
            return StringToHex(plaintext);
        }
        public string Base64ToByte(string str)
        {
            string plaintext = Base64ToString(str);
            return StringToByte(plaintext);
        }
        // Byte[] convert
        public string ByteToHex(string str)
        {
            string plaintext = ByteToString(str);
            return StringToHex(plaintext);
        }

        public string ByteToBase64(string str)
        {
            string plaintext = ByteToString(str);
            return StringToBase64(plaintext);
        }
        
    }
}
