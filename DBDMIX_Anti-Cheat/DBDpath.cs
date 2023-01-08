using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DBDMIX_Anti_Cheat
{
       public class DBDPath
        {
        public string GetDBDPath()
         {
            //return @"C:\Users\Pyperdok\Desktop\DEVBUILD";
           // MessageBox.Show("Find Steam");

            string steamapps = Process.GetProcessesByName("Steam")[0].MainModule.FileName;

            steamapps = steamapps.Replace("Steam.exe", "steamapps");
            steamapps = steamapps.Replace("steam.exe", "steamapps");

           // MessageBox.Show($"SteamApps Dir: {steamapps}");
            try
            {
                string[] filesnames = Directory.GetFiles(steamapps);

             //   MessageBox.Show("Filenames GetFiles(steamapps)");


                for (int i = 0; i < filesnames.Length; i++)
                {
                    if (filesnames[i].IndexOf("appmanifest_381210.acf") != -1)
                    {
                //    MessageBox.Show("Found game path primary disk: " + steamapps + @"\common\Dead by Daylight");
                    return (steamapps + @"\common\Dead by Daylight");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          //  MessageBox.Show("open libraryfolders");
                StreamReader reader = new StreamReader($"{steamapps}\\libraryfolders.vdf");
            string line = "";

           // MessageBox.Show("Libraryfolders is Opened!");

            while ((line = reader.ReadLine()) != null)
                {
                    for (int disknumber = 1; disknumber < 11; disknumber++) // MAX DISKS 10
                    {
                        if (line.IndexOf($"\"{disknumber}\"") != -1)
                        {
                        line = line.Replace($"\"{disknumber}\"", "").Replace("\"", "").Replace(@"\\", @"\").Replace("\t", "").Replace(" ", "");
                     //   MessageBox.Show($"Line: {line}");
                        Console.WriteLine(line);
                            line += @"\steamapps";
                            string[] filesnames2 = Directory.GetFiles(line);
                            for (int i = 0; i < filesnames2.Length; i++)
                            {
                                if (filesnames2[i].IndexOf("appmanifest_381210.acf") != -1)
                                {
                             //   MessageBox.Show("Found game path other disk: "+line + @"\common\Dead by Daylight");
                                    return (line + @"\common\Dead by Daylight");
                                }
                            }
                        }
                    }
                }
                reader.Close();
                reader.Dispose();

            MessageBox.Show("Dead by Daylight is not found");
            Environment.Exit(1);
            Process.GetCurrentProcess().Kill();
            throw new Exception("Dead by Daylight is not found");
         }      
        }
    }
