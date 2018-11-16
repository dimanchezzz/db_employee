using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Web.Script.Serialization;

namespace Course_kepeer_1
{
    class Coding
    {
        byte[] S = new byte[256];
        int x = 0;
        int y = 0;     
      //  byte[] key = ASCIIEncoding.ASCII.GetBytes(main_user_window.Thisuser.Login);              
        public Coding()
        {   
         //   init(key);
        }
        private void init(byte[] key)
        {
            int keyLength = key.Length;
            for (int i = 0; i < 256; i++)
            {
                S[i] = (byte)i;
            }
            int j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (j + S[i] + key[i % keyLength]) % 256;
                S.Swap(i, j);
            }
        }
        public string Encode(string line)
        {
            JavaScriptSerializer seriallizer = new JavaScriptSerializer();

            byte[] test = ASCIIEncoding.ASCII.GetBytes(line);
            byte[] data = test.Take(test.Length).ToArray();

            byte[] cipher = new byte[data.Length];

            for (int m = 0; m < data.Length; m++)
            {
                cipher[m] = (byte)(data[m] ^ keyItem());
            }
            string json = seriallizer.Serialize(cipher);
            return json;
        }
        public string Decode(string code)
        {
            JavaScriptSerializer seriallizer = new JavaScriptSerializer();
            byte[] cipher = seriallizer.Deserialize<byte[]>(code);
            byte[] data = cipher.Take(cipher.Length).ToArray();
            byte[] chipher = new byte[data.Length];
            for (int m = 0; m < data.Length; m++)
            {
                chipher[m] = (byte)(data[m] ^ keyItem());
            }
            string go;
            go = ASCIIEncoding.ASCII.GetString(chipher);
            return go;
        }
        private byte keyItem()
        {
            x = (x + 1) % 256;
            y = (y + S[x]) % 256;
            S.Swap(x, y);
            return S[(S[x] + S[y]) % 256];
        }
    }
    static class SwapExt
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            T temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}