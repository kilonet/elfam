using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using elfam.web.Attributes;
using elfam.web.Models;
using NUnit.Framework;

namespace elfam.web.Tests
{
    public class Tests
    {
        [Test]
        public void TestReflect()
        {
            Assert.IsTrue(typeof(Category).IsSubclassOf(typeof(DomainEntity)));
        }

        [Test]
        public void TestEnum()
        {
            foreach (PaymentType pay in Enum.GetValues(typeof(PaymentType)))
            {
                Console.WriteLine((int)pay);
                Console.WriteLine(Description(pay));
            }
        }

        public int Hash(int a)
        {
            a = (a ^ 61) ^ (a >> 16);
            a = a + (a << 3);
            a = a ^ (a >> 4);
            a = a * 0x27d4eb2d;
            a = a ^ (a >> 15);
            return a;
        }

        [Test]
        public void Test36()
        {
            UInt16 userId = 65535;
            DateTime now = DateTime.Now;
            DateTime y2010 = new DateTime(2010, 1, 1);
            DateTime y2040 = new DateTime(2040, 1, 1);
            TimeSpan span = y2040 - y2010;
            Assert.IsTrue(span.TotalSeconds < UInt32.MaxValue);
            UInt32 secs = (uint) span.TotalSeconds;
            byte[] userBytes = BitConverter.GetBytes(userId);
            byte[] secsBytes = BitConverter.GetBytes(secs);
            byte[] magicBytes = new byte[8];
//            userBytes.CopyTo(magicBytes, 0);
//            secsBytes.CopyTo(magicBytes, 2);
            UInt64 magic = BitConverter.ToUInt64(magicBytes, 0);


            ulong i = UInt64.MaxValue;
            ulong p;
            ulong reminder;
            uint bas = 36;
            List<ulong> rems = new List<ulong>();
            while (true)
            {
                p = i/bas;
                reminder = i%bas;
                i = p;
                rems.Add(reminder);
                if (p == 0) break;
            }

            StringBuilder sb = new StringBuilder();
//            foreach (ulong rem in rems)
//            {
//                sb.Append(ConvertTo36((byte) rem));
//            }

            MessageBox.Show(sb.ToString() + " " + rems.Count);
                       
            RC2CryptoServiceProvider aes = new RC2CryptoServiceProvider();
            MemoryStream ms = new MemoryStream();

            byte[] rgbKey = Encoding.Default.GetBytes("cjkywtqwertyuiop");
             byte[] rgbIV = Encoding.Default.GetBytes("cdtnbnasdfghjklz"); ;
            CryptoStream cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            foreach (byte b in BitConverter.GetBytes(int.MaxValue))
            {
                cryptoStream.WriteByte(b);    
            }
            cryptoStream.Close();

            byte[] cipherTextinBytes = ms.ToArray();



        }

        public void Mail()
        {
//            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
//            message.cc
//            message.From = "from e-mail";
//            message.To = "to e-mail";
//            message.Subject = "Message Subject";
//            message.Body = "Message Body";
//            System.Web.Mail.SmtpMail.SmtpServer = "SMTP Server Address";
//            System.Web.Mail.SmtpMail.Send(message);
        }

        private string ConvertTo36(byte b)
        {
            switch (b)
            {
                case 0: return "q";
                case 1: return "a";
                case 2: return "z";
                case 3: return "x";
                case 4: return "s";
                case 5: return "w";
                case 6: return "e";
                case 7: return "d";
                case 8: return "c";
                case 9: return "v";
                case 10: return "f";
                case 11: return "r";
                case 12: return "g";
                case 13: return "b";
                case 14: return "n";
                case 15: return "h";
                case 16: return "y";
                case 17: return "u";
                case 18: return "j";
                case 19: return "m";
                case 20: return "k";
                case 21: return "i";
                case 22: return "o";
                case 23: return "l";
                case 24: return "p";
                case 25: return "t";
                
                

                    }
            throw new ArgumentException();
        }

        [Test]
        public void TestDate()
        {
            DateTime y2000 = new DateTime(2010, 1, 1);
            DateTime now = DateTime.Now;
            TimeSpan span = now - y2000;
            
            long delta = now.Ticks - y2000.Ticks;
        }

        [Test]
        public void TestHash()
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = BitConverter.GetBytes(1000);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            BitConverter.ToInt32(encodedBytes, 0);
        }


        public static string Description(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);

                if (attrs.Length > 0)
                    return ((Description)attrs[0]).Text;
            }
            return en.ToString();
        }

    }
}
