
using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
//using System.Runtime.InteropServices;
using Steamworks;
using System.Diagnostics;
using Newtonsoft.Json;
//using System.Web.Script.Serialization;
using System.Management;
using System.Security.Cryptography;

namespace DBDMIX_Anti_Cheat
{
    public partial class Form_Auth : Form
    {


        private static List<string> ConfigWhiteList = new List<string>() {
            "r.SkeletalMeshLODBias=10",
            "r.DefaultFeature.Bloom=False",
            "r.DefaultFeature.AmbientOcclusion=False",
            "r.DefaultFeature.AmbientOcclusionStaticFraction=False",
            "r.DefaultFeature.MotionBlur=False",
            "r.DefaultFeature.LensFlare=False",
            "r.DefaultFeature.AntiAliasing=0",
            "r.MSAA.CompositingSampleCount=1",
            "r.MaxAnisotropy=0",
            "r.TranslucencyLightingVolumeDim=1",
            "r.SceneColorFormat=3",
            "r.ParticleLightQuality=0",
            "r.BloomQuality=0",
            "r.MaterialQualityLevel=0",
            "r.DetailMode=0",
            "r.Tonemapper.GrainQuantization=0",
            "r.Tonemapper.Sharpen=0.3",
            "r.LightPropagationVolume=0",
            "r.MotionBlurQuality=0",
            "r.lodbias=0.7",
            "r.EarlyZPass=1",
            "r.EarlyZPassMovable=0",
            "r.AmbientOcclusionMipLevelFactor=0.0",
            "r.AmbientOcclusionMaxQuality=0",
            "r.AmbientOcclusionLevels=0",
            "r.AmbientOcclusionRadiusScale=0",
            "r.DistanceFieldShadowing=0",
            "r.DistanceFieldAO=0",
            "r.PostProcessAAQuality=0",
            "r.BlurGBuffer=0",
            "r.LensFlareQuality=0",
            "r.SceneColorFringeQuality=0",
            "r.EyeAdaptationQuality=1",
            "r.FastBlurThreshold=0",
            "r.LightShaftQuality=0",
            "r.Shadow.CachedShadowsCastFromMovablePrimitives=0",
            "r.LPV.RSMResolution=4",
            "r.Streaming.MipBias=2",
            "r.SSR=0",
            "r.SSR.Quality=0",
            "r.TranslucencyVolumeBlur=0",
            "r.SSS.Scale=0",
            "r.SSS.SampleSet=0",
            "r.SSS.Quality=0",
            "r.Shadow.CSM.MaxCascades=0",
            "r.Filter.SizeScale=0.2",
            "r.setres=1280x720wf",
            "r.ShadowQuality=1",
            "r.VSync=0",
            "r.PostProcessQuality=0",
            "foliage.DitheredLOD=0",
            "foliage.DensityScale=0.1",
            "grass.DensityScale=0.1"
    };

        private List<string> ConfigNames = new List<string>() 
        {
            "ApexDestruction.ini",
            "Compat.ini",
            "DBDChunking.ini",
            "DeviceProfiles.ini",
            "Engine.ini",
            "Game.ini",
            "GameplayTags.ini",
            "GameUserSettings.ini",
            "Hardware.ini",
            "Input.ini",
            "Paper2D.ini",
            "PhysXVehicles.ini",
            "Scalability.ini"
        };


        static bool CheckConfig(string line)
        {
            int status = 0;
            for(int i = 0; i < ConfigWhiteList.Count; i++)
            {
                string whitelist_command = ConfigWhiteList[i].ToLower();

                if (line.IndexOf($"{whitelist_command}") != -1 && line.Length == whitelist_command.Length)
                {
                    Console.WriteLine($"WhiteList Command: {line}");
                    status++;
                }
            }

            if(status != 0)
            {
                return true;
            }

            return false;
        }
        static int logginstatus = 0;
        private void OpenConfigs()
        {

            logginstatus = 1;
            string system_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string config_path = "\\DeadByDaylight\\Saved\\Config\\WindowsNoEditor\\";

            while (true)
            {

             
                Dictionary<int, List<string>> UserConfig = new Dictionary<int, List<string>>();
                int UserConfig_index = 0;
                
                for (int i = 0; i < ConfigNames.Count; i++)
                {
                    
                    string path = system_path + config_path + ConfigNames[i];
                    try
                    {
                        string line;
                        using (StreamReader stream = new StreamReader(path))
                        {
                            int number_line = 0;
                            while ((line = stream.ReadLine()) != null)
                            {
                              //  bool detected_status = false;

                                line = line.ToLower();
                                line = line.Replace(" ", "");
                                line = line.Replace("'", "");

                                line = line.Replace("\"", "");

                               // line = line.Replace("<", ""); Для рофла оставлю
                                int r_index = 0;

                                if ((r_index = line.IndexOf(";")) != -1)
                                {
                                    line = line.Remove(r_index);
                                }

                                if ((line.IndexOf("r.") != -1 && line.IndexOf("debugexecbindings") == -1) ||
                                    line.IndexOf("foliage.ditheredlod") != -1 ||
                                    line.IndexOf("foliage.densityscale") != -1 ||
                                    line.IndexOf("grass.densityscale") != -1
                                    )
                                {
                                    if (CheckConfig(line) == false)
                                    {
                                        Console.WriteLine($"Detected unknown render settings!: {line}");
                                     //   detected_status = true;
                                        //
                                        UserConfig.Add(UserConfig_index, new List<string>()
                                            { line, "0" });
                                        UserConfig_index++;
                                        //
                                    }
                                    else
                                    {
                                        UserConfig.Add(UserConfig_index, new List<string>()
                                            { line, "1" });
                                        UserConfig_index++;
                                    }
                                }
                         
                                //  Console.WriteLine($"{number_line}) {line}");
                                number_line++;
                            }
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("ПРОИЗОШЛА ОШИБКА ЖОПЫ");
                        Application.Exit();
                        Process.GetCurrentProcess().Kill();
                    }
                }

                if (logginstatus != 1)
                    break;
                //Send Query Presence Token = Nft8m8IKKGrR5wKiB21cIsCNTPVCa8Fksh1Q
                string json = JsonConvert.SerializeObject(UserConfig);

                //  Console.WriteLine(json);
                string url = $"https://dbdmix.xyz/anti_cheat.php?token=Nft8m8IKKGrR5wKiB21cIsCNTPVCa8Fksh1Q&login={correct_login}&steam={SteamClient.SteamId}";

                string result = http(url, "POST", json, true);
                   Console.WriteLine(result);
                
                if (result == "-1")
                {
                    bool retry_status = false;
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(500);
                        Console.WriteLine($"Retry Config query: {i}");
                        if (http(url, "POST", json, true) != "-1")
                        {
                            retry_status = true;
                            break;
                        }
                    }
                    if(retry_status == false)
                    {
                        MessageBox.Show("Ошибка отправки данных конфига на сервер");
                        Application.Exit();
                        Process.GetCurrentProcess().Kill();
                    }
                }
                    
                
                
                //
                Thread.Sleep(5000);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        private string GetHardwaretoHash()
        {
            string HWRD_Info = "";
            ManagementObjectSearcher HWRD_Search = new ManagementObjectSearcher("select * from Win32_BaseBoard");
            foreach (ManagementObject id in HWRD_Search.Get())
                HWRD_Info += id["SerialNumber"].ToString();

          //  ManagementObjectSearcher HWRD_Search = new ManagementObjectSearcher("select * from Win32_DiskDrive");
          //  foreach (ManagementObject id in HWRD_Search.Get())
          //      HWRD_Info += id["SerialNumber"].ToString();

            HWRD_Info = HWRD_Info.Replace(" ", "");

          //  Console.WriteLine(HWRD_Info);

            //string source = "Hello World!";
            SHA256 sha256Hash = SHA256.Create();
            string hash = GetHash(sha256Hash, HWRD_Info);

          //  Console.WriteLine($"The SHA256 hash of {HWRD_Info} is: {hash}.");
            return hash;
        }

        public Form_Auth()
        {
            

            InitializeComponent();

            

            this.Resize += new System.EventHandler(this.button_close_Click);
            //
            Refresh();

            L_SteamID.Hide();
            TB_SteamID.Hide();
            L_SteamID_Border.Hide();

            BT_Logout.Text = "Logout";
            BT_Logout.Size = new Size(96, 36);
            BT_Logout.BackgroundImage = Properties.Resources.KNOPKA_1_zZz;
            BT_Logout.Location = new Point(340, 85);
            BT_Logout.Font = new Font("Tahoma", 11, FontStyle.Regular);
            BT_Logout.FlatStyle = FlatStyle.Popup;
            BT_Logout.Click += new EventHandler(this.B_Logout_Click);


            // this.Controls.Add(BT_Logout);


            //correct_token = 1;
            status.Text = "Token - OK";
            status.ForeColor = System.Drawing.Color.Lime;
            status.BackColor = System.Drawing.Color.Transparent;
            status.Location = new System.Drawing.Point(125, y_cord);
            this.Controls.Add(status);
            Hide();
            //    this.Controls.Remove(Token_Field);
            this.Controls.Remove(status);
            //    this.Controls.Remove(button_connect);
            //  this.Controls.Remove(Enter_your_token);

            //    button_connect.Hide();
            //  
            Token_Auth_status.Text = "OK (Pyperdok)";
            Token_Auth_status.AutoSize = true;
            Token_Auth_status.ForeColor = System.Drawing.Color.Lime;
            Token_Auth_status.BackColor = System.Drawing.Color.Transparent;
            Token_Auth_status.Location = new System.Drawing.Point(168, 25);
            Token_Auth_status.Font = new Font("Tahoma", 7, FontStyle.Regular);

            Ban_Status_status.Text = "OK";
            Ban_Status_status.AutoSize = true;
            Ban_Status_status.ForeColor = System.Drawing.Color.Lime;
            Ban_Status_status.BackColor = System.Drawing.Color.Transparent;
            Ban_Status_status.Location = new System.Drawing.Point(155, 40);
            Ban_Status_status.Font = new Font("Tahoma", 7, FontStyle.Regular);

            Anti_Cheat_Service_status.Text = "OK";
            Anti_Cheat_Service_status.AutoSize = true;
            Anti_Cheat_Service_status.ForeColor = System.Drawing.Color.Lime;
            Anti_Cheat_Service_status.BackColor = System.Drawing.Color.Transparent;
            Anti_Cheat_Service_status.Location = new System.Drawing.Point(190, 55);
            Anti_Cheat_Service_status.Font = new Font("Tahoma", 7, FontStyle.Regular);

            DBD_Version_status.Text = "3.0.2 (Last Version)";
            DBD_Version_status.AutoSize = true;
            DBD_Version_status.ForeColor = System.Drawing.Color.Lime;
            DBD_Version_status.BackColor = System.Drawing.Color.Transparent;
            DBD_Version_status.Location = new System.Drawing.Point(168, 70);
            DBD_Version_status.Font = new Font("Tahoma", 7, FontStyle.Regular);

            DBD_Launch_status.Text = "Launched";
            DBD_Launch_status.AutoSize = true;
            DBD_Launch_status.ForeColor = System.Drawing.Color.Lime;
            DBD_Launch_status.BackColor = System.Drawing.Color.Transparent;
            DBD_Launch_status.Location = new System.Drawing.Point(168, 85);
            DBD_Launch_status.Font = new Font("Tahoma", 7, FontStyle.Regular);


            //
            Start_Secure_Session.Text = "Secure Session Started";
            Start_Secure_Session.AutoSize = true;
            Start_Secure_Session.ForeColor = System.Drawing.Color.Lime;
            Start_Secure_Session.BackColor = System.Drawing.Color.Transparent;
            Start_Secure_Session.Location = new System.Drawing.Point(100, 105);
            Start_Secure_Session.Font = new Font("Tahoma", 10, FontStyle.Regular);

            Token_Auth.Text = "Authorization:";
            Token_Auth.AutoSize = true;
            Token_Auth.ForeColor = System.Drawing.Color.White;
            Token_Auth.BackColor = System.Drawing.Color.Transparent;
            Token_Auth.Location = new System.Drawing.Point(100, 25);
            Token_Auth.Font = new Font("Tahoma", 7, FontStyle.Regular);

            Ban_Status.Text = "Ban Status:";
            Ban_Status.AutoSize = true;
            Ban_Status.ForeColor = System.Drawing.Color.White;
            Ban_Status.BackColor = System.Drawing.Color.Transparent;
            Ban_Status.Location = new System.Drawing.Point(100, 40);
            Ban_Status.Font = new Font("Tahoma", 7, FontStyle.Regular);

            Anti_Cheat_Service.Text = "Anti-Cheat Service:";
            Anti_Cheat_Service.AutoSize = true;
            Anti_Cheat_Service.ForeColor = System.Drawing.Color.White;
            Anti_Cheat_Service.BackColor = System.Drawing.Color.Transparent;
            Anti_Cheat_Service.Location = new System.Drawing.Point(100, 55);
            Anti_Cheat_Service.Font = new Font("Tahoma", 7, FontStyle.Regular);

            DBD_Version.Text = "Game Version:";
            DBD_Version.AutoSize = true;
            DBD_Version.ForeColor = System.Drawing.Color.White;
            DBD_Version.BackColor = System.Drawing.Color.Transparent;
            DBD_Version.Location = new System.Drawing.Point(100, 70);
            DBD_Version.Font = new Font("Tahoma", 7, FontStyle.Regular);

            DBD_Launch.Text = "Launch Game:";
            DBD_Launch.AutoSize = true;
            DBD_Launch.ForeColor = System.Drawing.Color.White;
            DBD_Launch.BackColor = System.Drawing.Color.Transparent;
            DBD_Launch.Location = new System.Drawing.Point(100, 85);
            DBD_Launch.Font = new Font("Tahoma", 7, FontStyle.Regular);


            //Gifs
            gif_load_cyrlce_1.Image = Properties.Resources.load;
            gif_load_cyrlce_1.BackColor = System.Drawing.Color.Transparent;
            gif_load_cyrlce_1.Size = new Size(8, 8);
            gif_load_cyrlce_1.SizeMode = PictureBoxSizeMode.StretchImage;
            gif_load_cyrlce_1.Location = new System.Drawing.Point(215, 27);

            gif_load_cyrlce_2.Image = Properties.Resources.load;
            gif_load_cyrlce_2.BackColor = System.Drawing.Color.Transparent;
            gif_load_cyrlce_2.Size = new Size(8, 8);
            gif_load_cyrlce_2.SizeMode = PictureBoxSizeMode.StretchImage;
            gif_load_cyrlce_2.Location = new System.Drawing.Point(203, 42);

            gif_load_cyrlce_3.Image = Properties.Resources.load;
            gif_load_cyrlce_3.BackColor = System.Drawing.Color.Transparent;
            gif_load_cyrlce_3.Size = new Size(8, 8);
            gif_load_cyrlce_3.SizeMode = PictureBoxSizeMode.StretchImage;
            gif_load_cyrlce_3.Location = new System.Drawing.Point(238, 57);

            gif_load_cyrlce_4.Image = Properties.Resources.load;
            gif_load_cyrlce_4.BackColor = System.Drawing.Color.Transparent;
            gif_load_cyrlce_4.Size = new Size(8, 8);
            gif_load_cyrlce_4.SizeMode = PictureBoxSizeMode.StretchImage;
            gif_load_cyrlce_4.Location = new System.Drawing.Point(216, 72);

            gif_load_cyrlce_5.Image = Properties.Resources.load;
            gif_load_cyrlce_5.BackColor = System.Drawing.Color.Transparent;
            gif_load_cyrlce_5.Size = new Size(8, 8);
            gif_load_cyrlce_5.SizeMode = PictureBoxSizeMode.StretchImage;
            gif_load_cyrlce_5.Location = new System.Drawing.Point(208, 87);


            //
            this.Controls.Add(gif_load_cyrlce_1);
            this.Controls.Add(gif_load_cyrlce_2);
            this.Controls.Add(gif_load_cyrlce_3);
            this.Controls.Add(gif_load_cyrlce_4);
            this.Controls.Add(gif_load_cyrlce_5);

            gif_load_cyrlce_1.Hide();
            gif_load_cyrlce_2.Hide();
            gif_load_cyrlce_3.Hide();
            gif_load_cyrlce_4.Hide();
            gif_load_cyrlce_5.Hide();
            //



            //Status
            this.Controls.Add(DBD_Launch_status);
            this.Controls.Add(DBD_Version_status);
            this.Controls.Add(Anti_Cheat_Service_status);
            this.Controls.Add(Ban_Status_status);
            this.Controls.Add(Token_Auth_status);
            //
            this.Controls.Add(Start_Secure_Session);
            this.Controls.Add(DBD_Launch);
            this.Controls.Add(DBD_Version);
            this.Controls.Add(Anti_Cheat_Service);
            this.Controls.Add(Ban_Status);
            this.Controls.Add(Token_Auth);

            Token_Auth.Hide();
            Ban_Status.Hide();
            Anti_Cheat_Service.Hide();
            DBD_Version.Hide();
            DBD_Launch.Hide();

            Token_Auth_status.Hide();
            Ban_Status_status.Hide();
            Anti_Cheat_Service_status.Hide();
            DBD_Version_status.Hide();
            DBD_Launch_status.Hide();

            Start_Secure_Session.Hide();
            TB_Login.Select();

            this.Controls.Add(BT_Logout);
            BT_Logout.Hide();

          
            try
            {
                //SteamClient.Init(202351);
                SteamClient.Init(202351);
            }
            
            catch
            {
                MessageBox.Show("Error: Steam is not initializated");
                SteamClient.Shutdown();

                Environment.Exit(1);
                Process.GetCurrentProcess().Kill();
            }

            if (SteamClient.IsLoggedOn == false)
            {
                MessageBox.Show("Error: Steam is not started");
                SteamClient.Shutdown();

                Environment.Exit(1);
                Process.GetCurrentProcess().Kill();
            }

            
   
            Console.WriteLine(SteamApps.AppInstallDir(381210));



            // Console.WriteLine(steam_path);


            //  SteamAPI.RestartAppIfNecessary((AppId_t)381210);
            //Steam API is Working


            // SteamFileInfo = Callback<FileDetailsResult_t>.Create(OnGetFileInfo);


            new Thread(() =>
                 {
                     while (true)
                     {
                         SteamClient.RunCallbacks();
                         Thread.Sleep(100);
                         // Console.WriteLine("Callback Updated");
                     }
                 }).Start();

            // bool IsInstalled = SteamApps.IsAppInstalled(381210);
            // if (IsInstalled != true)
            // {
            //     MessageBox.Show("Dead by Daylight is not installed. Please, install the game and try again", "RPL Anti-Cheat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     Environment.Exit(1);
            // }
            // string GameFolderDir = SteamApps.AppInstallDir(381210);
            // Console.WriteLine(GameFolderDir);
            // string path = @"\DeadByDaylight\Content\Paks\";

            // List<string> ShaList = new List<string>();

            //new Thread(async () =>
            // {
            //     for (int i = 0; i < 40; i++)
            //         ShaList.Add(await GetSHAFile($"pakchunk{i}-WindowsNoEditor.pak"));
            // }).Start();

            // int wait = 0;
            // while (ShaList.Count != 40 && wait < 5)
            // {
            //     wait++;
            //     Thread.Sleep(1000);
            // }
            // if (wait >= 5) {
            //     throw new ArgumentException("SHA is doesnt found");
            // }
            // ShaCheck(ShaList);

            if(Process.GetProcessesByName("DeadByDaylight").Length != 0 || Process.GetProcessesByName("DeadByDaylight-Win64-Shipping").Length != 0)
            {
                MessageBox.Show("Dead by Daylight is running. Please close the game and run Anti-Cheat");
                Environment.Exit(1);
                Process.GetCurrentProcess().Kill();
            }
        }
       
        async Task<string> GetSHAFile(string pakname)
        {
            try
            {
                string depot = $"DeadByDaylight\\Content\\Paks\\{pakname}";
                Steamworks.Data.FileDetails? SteamFileInfo = await SteamApps.GetFileDetailsAsync(depot);

                Console.WriteLine($"Steam SHA-1: {SteamFileInfo.Value.Sha1}");
                return SteamFileInfo.Value.Sha1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "-1";
        }
        
        int y_cord = 100;
        //int correct_token = 0;
        Label status = new Label();

        public static Button BT_Logout = new Button();


        
        public static Label Token_Auth = new Label();
        public static Label Ban_Status = new Label();
        public static Label Anti_Cheat_Service = new Label();
        public static Label DBD_Version = new Label();
        public static Label DBD_Launch = new Label();
        public static Label Start_Secure_Session = new Label();

        public static Label Token_Auth_status = new Label();
        public static Label Ban_Status_status = new Label();
        public static Label Anti_Cheat_Service_status = new Label();
        public static Label DBD_Version_status = new Label();
        public static Label DBD_Launch_status = new Label();

        //Gifs
        public static PictureBox gif_load_cyrlce_1 = new PictureBox();
        public static PictureBox gif_load_cyrlce_2 = new PictureBox();
        public static PictureBox gif_load_cyrlce_3 = new PictureBox();
        public static PictureBox gif_load_cyrlce_4 = new PictureBox();
        public static PictureBox gif_load_cyrlce_5 = new PictureBox();
        private static bool Rememberme_status = false;


        private void TB_SteamID_Focused(object sender, EventArgs e)
        {
            Console.WriteLine("Focused");
            L_SteamID_Border.BackColor = Color.FromArgb(147, 0, 0);
        }

        private void TB_SteamID_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave");
            L_SteamID_Border.BackColor = Color.White;
        }

        private void TB_Login_Focused(object sender, EventArgs e)
        {
            Console.WriteLine("Focused");
            L_Login_Border.BackColor = Color.FromArgb(147, 0, 0);
        }

        private void TB_Password_Focused(object sender, EventArgs e)
        {
            Console.WriteLine("Focused");
            L_Password_Border.BackColor = Color.FromArgb(147, 0, 0);
        }

        private void TB_Login_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave");
            L_Login_Border.BackColor = Color.White;
        }

        private void TB_Password_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave");
            L_Password_Border.BackColor = Color.White;
        }

        private void Checkbox_Remember_MouseEnter(object sender, EventArgs e)
        {
            Checkbox_Remember.BackColor = Color.Black;
        }

        private void CheckBox_Remember_Click(object sender, EventArgs e) { 
            if(Rememberme_status == false)
            {
                Checkbox_Remember.Size = new Size(20, 20);
                Checkbox_Remember.FlatAppearance.BorderSize = 0;
                Rememberme_status = true;
                Checkbox_Remember.BackgroundImage = Properties.Resources.checkbox_rpl;
                Refresh();
                Console.WriteLine("Checkbox Activated");
            }
            else if(Rememberme_status == true)
            {
                Checkbox_Remember.Size = new Size(20, 20);
                Checkbox_Remember.FlatAppearance.BorderSize = 2;
                Rememberme_status = false;
                Checkbox_Remember.BackgroundImage = null;
                Refresh();
                Console.WriteLine("Checkbox Deactivated");
            }
        }

        private void B_Logout_Click(object sender, EventArgs e)
        {
           // SteamAPI.Shutdown();

            Environment.Exit(1);
            Process.GetCurrentProcess().Kill();
            logginstatus = 0;

            Token_Auth.Hide();
            Ban_Status.Hide();
            Anti_Cheat_Service.Hide();
            DBD_Version.Hide();
            DBD_Launch.Hide();
            Start_Secure_Session.Hide();

            Token_Auth_status.Hide();
            Ban_Status_status.Hide();
            Anti_Cheat_Service_status.Hide();
            DBD_Version_status.Hide();
            DBD_Launch_status.Hide();

            BT_Logout.Hide();
            BT_Logout.Text = "Logout";

            L_Email.Show();
            L_Password.Show();
            B_Login.Show();
            TB_Login.Show();
            TB_Password.Show();
            L_Login_Border.Show();
            L_Password_Border.Show();

            BT_Register.Show();

          //  Checkbox_Remember.Show();
          //  L_Remember.Show();
            Refresh();



        }
        //


       private static string correct_login = String.Empty;
       private static string correct_password = String.Empty;
        private void B_Login_Click(object sender, EventArgs e)
        {
            // Токен вводимый в поле
        //    string token = Token_Field.Text;

            if (Login(TB_Login.Text, TB_Password.Text) == 1)//TB_Login.Text == "dbd_pyperdok@bhvr.com" && TB_Password.Text == "1234") //token == "1234Q"
            {
                correct_login = TB_Login.Text;
                correct_password = TB_Password.Text;
                // Console.WriteLine("ТЫ ЕБАЛН");
                //  MessageBox.Show("ВЫ ЕБЛАН");

                //  L_Error_Login_Password.Visible = true;
                // PB_Logo_AC.Hide();

                BT_Register.Hide();

                L_Error_Login_Password.Hide();
                L_Email.Hide();
                L_Password.Hide();

                TB_Login.Hide();
                TB_Password.Hide();
                B_Login.Hide();

                Checkbox_Remember.Hide();
                L_Remember.Hide();

                L_Login_Border.Hide();
                L_Password_Border.Hide();



                Show();

               

                Thread Authentication = new Thread(Authentication_Start);
                Authentication.Start();
            }
            else
            {
                L_Error_Login_Password.Show();
            }
        }

        protected List<string> ShaList = new List<string>();
        private static string http(string url, string method, string postData = "", bool configcheck = false)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                WebRequest request = WebRequest.Create(url);

                request.Method = method;

                request.ContentType = "application/json";

                if (method == "POST")
                {
                    byte[] data = Encoding.ASCII.GetBytes(postData);

                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }




                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine($"Http Status Code: {response.StatusCode}");

                Stream Data_Stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(Data_Stream);
                string otvet = reader.ReadToEnd();

                return otvet;
            }
            catch (Exception ex)
            {             
                if (configcheck != true)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                    Application.Exit();
                    Process.GetCurrentProcess().Kill();
                }
            }
            return "-1";
        }

  
        private int Check_Ban_Status()
        {
            return 0;
        }
        private int Login(string login, string password)
        {
         //   this.Enabled = false;
            //token  AOrpi3IsDp68gwWgGnbp2JhncpGD4dez

            string hrdw = GetHardwaretoHash();
            string url = $"https://dbdmix.xyz/anti_cheat.php?token=AOrpi3IsDp68gwWgGnbp2JhncpGD4dez&login={login}&password={password}&hardware={hrdw}";
            string auth_result = http(url, "GET");
            if (auth_result == "1")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Authentication_Start()
        {
            string token_status = String.Empty;
            string ban_status = String.Empty;
            string anti_cheat_service_status = String.Empty;
            string dbd_version_status = String.Empty;
            string dbd_launch_status = String.Empty;




            Thread get_token_status = new Thread(() => 
            {
                Action action_get_token_status = () => {
                    //token zGouOfIjBBmKkW8gkQHTmgFywsbxQxYzDB2p
                    string hrdw = GetHardwaretoHash();
                    string url = $"https://dbdmix.xyz/anti_cheat.php?token=zGouOfIjBBmKkW8gkQHTmgFywsbxQxYzDB2p&login={correct_login}&steam={SteamClient.SteamId}";
                    if (http(url, "GET") == "1")
                    {
                        Token_Auth_status.Text = $"OK({SteamClient.Name})";
                        Token_Auth_status.ForeColor = System.Drawing.Color.Lime;
                    }
                    else
                    {
                        Token_Auth_status.Text = $"Error";
                        Token_Auth_status.ForeColor = System.Drawing.Color.Red;
                        
                    }
                };
                Invoke(action_get_token_status);
                              
            });
            get_token_status.Start();

            Action action_token = () =>
            {
                Refresh();
                Token_Auth.Show();
                Token_Auth_status.Text = "Checking";
                Token_Auth_status.ForeColor = System.Drawing.Color.Yellow;
                Token_Auth_status.Show();
                gif_load_cyrlce_1.Show();
            };
            Invoke(action_token);

            get_token_status.Join();
            // Проверка Ответа

            //
            Action action_token_status = () =>
            {
                Refresh();
                gif_load_cyrlce_1.Hide();
            };
            Invoke(action_token_status);

            if (Token_Auth_status.Text == "Error")
            {
               // Thread theard_retry = new Thread(() =>
              //  {
                    Action retry = () =>
                    {
                        Refresh();
                        BT_Logout.Show();
                        BT_Logout.Text = "Retry";
                        Refresh();
                    };
                    Invoke(retry);
              //  });
              //  theard_retry.Start();
                return;
            }
            string ban_result = String.Empty;
            string service_result = String.Empty;

            Thread get_ban_status = new Thread(() => 
            {
                //token W7Rc3XMdld55LqfXPSOgok5wu9gNnC2rPkzL
                string url = $"https://dbdmix.xyz/anti_cheat.php?token=W7Rc3XMdld55LqfXPSOgok5wu9gNnC2rPkzL&login={correct_login}";
                ban_result = http(url, "GET");
                if (ban_result == "0")
                {
                    Action action_ban_result = () =>
                    {
                        Refresh();
                        Ban_Status_status.Text = $"OK";
                        Ban_Status_status.ForeColor = System.Drawing.Color.Lime;
                        Refresh();
                    };
                    Invoke(action_ban_result);
                }
                else if(ban_result == "1")
                {
                    Action retry = () =>
                    {
                        Refresh();

                        Ban_Status_status.Text = $"Banned";
                        Ban_Status_status.ForeColor = System.Drawing.Color.Red;

                        BT_Logout.Show();
                        BT_Logout.Text = "Retry";
                        Refresh();

                        MessageBox.Show("ВЫ НЕ ПРОШЛИ ЁБКУ АНТИ-ЧИТА");

                        //ROFL
                        //PictureBox volga = new PictureBox();
                        //volga.Image = Properties.Resources.volga_t800;
                        //volga.Location = new Point(0, -100);
                        //volga.Size = new Size(500, 500);
                        //this.Controls.Add(volga);
                    };
                    Invoke(retry);
                }
                else
                {
                    Action retry = () =>
                    {
                        Refresh();

                        Ban_Status_status.Text = $"Error";
                        Ban_Status_status.ForeColor = System.Drawing.Color.Red;

                        BT_Logout.Show();
                        BT_Logout.Text = "Retry";
                        Refresh();
                    };
                    Invoke(retry);
                }
            });

            get_ban_status.Start();

            Action action_ban_status = () =>
            {
                Refresh();
                Ban_Status.Show();
                Ban_Status_status.Text = "Checking";
                Ban_Status_status.ForeColor = System.Drawing.Color.Yellow;
                Ban_Status_status.Show();
                gif_load_cyrlce_2.Show();
            };
            Invoke(action_ban_status);

            get_ban_status.Join();
            //
            //
            Action action_ban_status_status = () =>
            {
                Refresh();
                gif_load_cyrlce_2.Hide();
            };
            Invoke(action_ban_status_status);

            if (ban_result != "0")
                return;

            Thread get_anti_cheat_service = new Thread(() => 
            {
                string url = $"https://dbdmix.xyz/anti_cheat.php?token=anti_cheat_check";
                service_result = http(url, "GET");
                if (service_result == "1")
                {
                    Action action_anti_cheat = () =>
                    {
                        Refresh();
                        Anti_Cheat_Service_status.Text = "OK"; //OK
                        Anti_Cheat_Service_status.ForeColor = System.Drawing.Color.Lime;
                        Refresh();
                    };
                    Invoke(action_anti_cheat);
                }
                else
                {
                    Action retry = () =>
                    {
                        Refresh();
                        Anti_Cheat_Service_status.Text = "Offline"; //OK
                        Anti_Cheat_Service_status.ForeColor = System.Drawing.Color.Red;

                        BT_Logout.Show();
                        BT_Logout.Text = "Retry";

                        Refresh();
                    };
                    Invoke(retry);
                }
            });
            get_anti_cheat_service.Start();

            Action action_anti_cheat_service = () =>
            {
                Refresh();
                Anti_Cheat_Service.Show();
                Anti_Cheat_Service_status.Text = "Checking";
                Anti_Cheat_Service_status.ForeColor = System.Drawing.Color.Yellow;
                Anti_Cheat_Service_status.Show();
                gif_load_cyrlce_3.Show();
            };
            Invoke(action_anti_cheat_service);

            get_anti_cheat_service.Join();
            //
            //
            Action action_anti_cheat_service_status = () =>
            {
                Refresh();
                gif_load_cyrlce_3.Hide();
            };
            Invoke(action_anti_cheat_service_status);

            if (service_result != "1")
                return;

          //  MessageBox.Show($"Start get_dbd_version");

            Thread get_dbd_version = new Thread(() =>
            {
                SteamClient.Shutdown();
                SteamClient.Init(381210);

                if (SteamApps.IsAppInstalled(381210) == false)
                {
                    MessageBox.Show("Dead by Daylight is not installed. Please install Dead by Daylight");
                    Environment.Exit(1);
                    Process.GetCurrentProcess().Kill();
                }

            //    MessageBox.Show($"Start Get steamCLSH");

                try
                {

                    new Thread(async () =>
                    {
                        ShaList.Add(await GetSHAFile($"pakchunk0-WindowsNoEditor.pak"));
                        ShaList.Add(await GetSHAFile($"pakchunk1-WindowsNoEditor.pak"));
                    }).Start();

                    Thread.Sleep(3000);
                    int wait = 0;
                    while (ShaList.Count != 2 && wait < 5)
                    {
                        wait++;
                        Thread.Sleep(1000);
                    }
                    if (wait >= 5)
                    {
                        throw new ArgumentException("SHA is doesnt found");
                    }
                    SteamClient.Shutdown();
                    SteamClient.Init(202351);

                    ShaList[0] = ShaList[0].Replace("0", "");
                    ShaList[1] = ShaList[1].Replace("0", "");
                    GC.Collect();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            get_dbd_version.Start();

            Action action_dbd_version = () => 
            {
                Refresh();
                DBD_Version.Show();
                DBD_Version_status.Text = "Checking";
                DBD_Version_status.ForeColor = System.Drawing.Color.Yellow;
                DBD_Version_status.Show();
                gif_load_cyrlce_4.Show();
            };
            Invoke(action_dbd_version);

            get_dbd_version.Join();
            //
            //

            //  MessageBox.Show($"get dbd version");

            Thread Paks = new Thread(() => {
                Paks_Check(ShaList);
            });
            Paks.Start();

            while (PaksReady == false)
            {
                Thread.Sleep(1000);
            }

            Action action_dbd_version_status = () => 
            {
                Refresh();
                DBD_Version_status.Text = "OK"; // 3.0.2 (Last Version)
                DBD_Version_status.ForeColor = System.Drawing.Color.Lime;
                gif_load_cyrlce_4.Hide();
            };
            Invoke(action_dbd_version_status);

            //   MessageBox.Show($"DBD launching...");


            //TEST PAKS
            Thread get_dbd_launch = new Thread(() =>
            {
                Process dbd = new Process();
                Process[] steam = Process.GetProcessesByName("Steam");
                string steampath = steam[0].MainModule.FileName;
                dbd.StartInfo.FileName = $"{steampath}";
                dbd.StartInfo.Arguments = "-applaunch 381210";
                dbd.Start();

                dbd.Dispose();


                while (true)
                {
                    Process[] dbd_check = Process.GetProcessesByName("DeadByDaylight-Win64-Shipping");
                    if (dbd_check.Length != 0)
                        break;
                    Thread.Sleep(100);
                }


            });
            get_dbd_launch.Start();

            Action action_dbd_launch = () =>
            {
                Refresh();
                DBD_Launch.Show();
                DBD_Launch_status.Text = "Starting";
                DBD_Launch_status.ForeColor = System.Drawing.Color.Yellow;
                DBD_Launch_status.Show();
                gif_load_cyrlce_5.Show();
            };
            Invoke(action_dbd_launch);

            get_dbd_launch.Join();
            //
            //
            Action action_dbd_launch_status = () =>
            {
                Refresh();
                DBD_Launch_status.Text = "Launched";
                DBD_Launch_status.ForeColor = Color.Lime;
                Start_Secure_Session.Show();
                gif_load_cyrlce_5.Hide();

                BT_Logout.Show();
                
                BT_Logout.Show();
            };

            Invoke(action_dbd_launch_status);

         //   MessageBox.Show("AC is Started");


         //   MessageBox.Show("CNF op");
            Thread Configs = new Thread(OpenConfigs);
            Configs.Start();

          //  MessageBox.Show("CNF is op");


        //    MessageBox.Show("PStart");
 
         //   MessageBox.Show("check dbd");

            Thread dbd_check_live = new Thread(() =>
            {
                while(true)
                {
                    Process[] dbd = Process.GetProcessesByName("DeadByDaylight-Win64-Shipping");
                    if (dbd.Length == 0)
                    {
                        Environment.Exit(1);
                        Process.GetCurrentProcess().Kill();
                    }
                    Thread.Sleep(800);
                }
            });
            dbd_check_live.Start();
        }

       static bool PaksReady = false;

        private static void Paks_Check(List<string> ShaList)
        {
         //   MessageBox.Show("PCheck");
            ShaCheck shacheck = new ShaCheck();

            string pak0 = "";
            string pak1 = "";


         //   MessageBox.Show("Find DBDPATH");
            DBDPath dbdpath = new DBDPath();

            string Pakspath = (dbdpath.GetDBDPath() + @"\DeadbyDaylight\Content\Paks\");

         //   MessageBox.Show($"Game Path: {Pakspath}");

            while (true) {
              pak0 = shacheck.GenerateSha1FromFile($"{Pakspath}pakchunk0-WindowsNoEditor.pak", 8388608);
                pak1 = shacheck.GenerateSha1FromFile($"{Pakspath}pakchunk1-WindowsNoEditor.pak", 8388608);

                PaksReady = true;

                pak0 = pak0.Replace("0", "");
                pak1 = pak1.Replace("0", "");

                List<List<string>> data = new List<List<string>>();

                if (ShaList[0] == pak0)
                    data.Add(new List<string> { "pak0", "1" });
                else
                    data.Add(new List<string> { "pak0", "0" });

                if (ShaList[1] == pak1)
                    data.Add(new List<string> { "pak1", "1" });
                else
                    data.Add(new List<string> { "pak1", "0" });

                string body = JsonConvert.SerializeObject(data);

                string url = $"https://dbdmix.xyz/anti_cheat.php?token=p1&login={correct_login}";
                string result = http(url, "POST", $"{body}", true);
                bool http_retry = false;
                if (result == "-1")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (http(url, "POST", $"{body}", true) != "-1")
                        {
                            http_retry = true;
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    if (http_retry == false)
                        throw new ArgumentException("SHA Retry Checking Failure");
                }
                Thread.Sleep(1000);            
            }
        }

        private void button_connect_Enter(object sender, EventArgs e)
        {
           // button1.BackColor
         //   button_connect.BackColor = System.Drawing.Color.Black;
         //   button_connect.ForeColor = System.Drawing.Color.Blue;
        }

        private void button_connect_Leave(object sender, EventArgs e)
        {
          //  button_connect.BackColor = System.Drawing.Color.Blue;
          //  button_connect.ForeColor = System.Drawing.Color.White;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
              //  Close();


                Refresh();
                Hide();
                Tray.Visible = true;
                // задаем иконку всплывающей подсказки
                Tray.BalloonTipIcon = ToolTipIcon.Info;
                // задаем текст подсказки
                Tray.BalloonTipText = "Anti-Cheat is Here and Working!";
                // устанавливаем зголовк
                Tray.BalloonTipTitle = "Dead by Daylight Anti-Cheat";
                // отображаем подсказку 1 сек
                Tray.ShowBalloonTip(1);
            }

        }

        private void Tray_Double_Click(object sender, EventArgs e)
        {
            Refresh();
            Show();
            Tray.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_Auth_Load(object sender, EventArgs e)
        {

            //
        }

        private Point MouseHook;
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void Form_Alien_Closing(object sender, FormClosingEventArgs e)
        {
            //if ((e.CloseReason == CloseReason.UserClosing |
            //    e.CloseReason == CloseReason.MdiFormClosing |
            //    e.CloseReason == CloseReason.TaskManagerClosing |
            //    e.CloseReason == CloseReason.FormOwnerClosing) && correct_token != 0)
            //{
            //    e.Cancel = true;
            //}
           // Console.WriteLine("КЛОЗ НАХУЙ");
            Application.Exit();
          //  Environment.Exit(1);
            Process.GetCurrentProcess().Kill();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void BT_Register_Click(object sender, EventArgs e)
        {
 
            B_Login.Hide();
            BT_Register.Hide();
            Checkbox_Remember.Hide();
            L_Error_Login_Password.Hide();
            L_Remember.Hide();
            L_SteamID.Show();
            TB_SteamID.Show();
            L_SteamID_Border.Show();
             this.Size = new Size(453, 180);
            BT_Confirm_Register.Show();
        }

        private void BT_Confirm_Register_Click(object sender, MouseEventArgs e)
        {

            if (TB_SteamID.Text != SteamClient.SteamId.ToString())
            {
                MessageBox.Show("Please input your SteamID64 which authorizated in Steam", "Anti-Cheat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string hrdw = GetHardwaretoHash();
            string url = $"https://dbdmix.xyz/anti_cheat.php?register=1&login={TB_Login.Text}&password={TB_Password.Text}&steam={TB_SteamID.Text}&hardware={hrdw}";
            string status = http(url, "GET");

            if (status != "1")
            {
                MessageBox.Show("Register Error! Please try again.", "Anti-Cheat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Register is Completed! Program is restarting!", "Anti-Cheat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
            Refresh();
            B_Login.Show();
            BT_Register.Show();
            Checkbox_Remember.Hide();
            L_Error_Login_Password.Hide();
            L_Remember.Hide();
            L_SteamID.Hide();
            TB_SteamID.Hide();
            L_SteamID_Border.Hide();
            this.Size = new Size(453, 160);
            BT_Confirm_Register.Hide();
            Refresh();
        }
    }
}
