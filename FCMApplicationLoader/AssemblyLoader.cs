using System;
using System.Collections.Generic;
// using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
// using System.Security.Principal;
using System.Windows.Forms;
using FCMBusinessLibrary;

namespace FCMApplicationLoader
{
    public class AssemblyLoader
    {
        private Assembly _assembly;
        private string ServerPath { get; set; }
        private string LocalPath { get; set; }

        private string ServerPathMainAssembly { get; set; }
        private string LocalPathMainAssembly { get; set; }
        public bool AssemblyIsLoaded { get; set; }
        public bool AssemblyCanBeLoaded { get; set; }

        public AssemblyLoader()
        {
            AssemblyIsLoaded = false;

            string localAssembly = FCMXmlConfig.Read(fcmConfigXml.LocalAssemblyFolder);
            string serverAssembly = FCMXmlConfig.Read(fcmConfigXml.ServerAssemblyFolder);

            if (string.IsNullOrEmpty(localAssembly))
            {
                MessageBox.Show("FCMConfig.xml is not setup correctly - missing Local Assembly Folder.");
                return;
            }
            if (string.IsNullOrEmpty(serverAssembly))
            {
                MessageBox.Show("FCMConfig.xml is not setup correctly - missing Server Assembly Folder.");
                return;
            }
            // Get local assemblies folder location
            // LocalPath = @"C:\Program Files\fcm\";
            LocalPath = @localAssembly;
            // LocalPathMainAssembly = @"C:\Program Files\fcm\fcm.exe";
            LocalPathMainAssembly = @LocalPath+"fcm.exe";

            // Get server assemblies folder location
            // ServerPath = @"C:\Users\MACHADO\Dropbox\FCM\fcm\bin\Debug\";
            ServerPath = @serverAssembly;
            // ServerPathMainAssembly = @"C:\Users\MACHADO\Dropbox\FCM\fcm\bin\Debug\fcm.exe";
            ServerPathMainAssembly = @ServerPath + "fcm.exe";


            AssemblyName localAssemblyName = new AssemblyName();
            AssemblyName serverAssemblyName = new AssemblyName();
            string versionLocal = "";
            string versionServer = "";

            // Get the local version of the assembly
            if (File.Exists(LocalPathMainAssembly))
            {
                localAssemblyName = AssemblyName.GetAssemblyName(LocalPathMainAssembly);
                versionLocal = localAssemblyName.Version.ToString();
            }
            
            // Get the server version of the assembly
            if (!File.Exists(ServerPathMainAssembly))
            {
                MessageBox.Show("Error. Server version not found. Path= " + ServerPathMainAssembly);
                return;
            }

            serverAssemblyName = AssemblyName.GetAssemblyName(ServerPathMainAssembly);
            versionServer = serverAssemblyName.Version.ToString();

            if (versionLocal == versionServer)
            {
                // All good
                AssemblyCanBeLoaded = true;
                return;
            }

            MessageBox.Show("Version will be upgraded. " + versionServer);

            // At this point the files are not the same, need to replace the local files.
            //

            // Check if files are there
            var filesInServer = Directory.GetFiles(ServerPath);

            foreach (var serverfile in filesInServer)
            {
                string sfile = serverfile.Replace("\\", ",");
                var partsOfFile = sfile.Split(',');

                var filename = partsOfFile[partsOfFile.Length-1];

                string localFilePathName = LocalPath + filename;
                string serverFilePathName = ServerPath + filename;

                if (File.Exists(localFilePathName))
                {
                    // Copy Server files
                    // 

                    try
                    {
                        File.Delete(localFilePathName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting file " + localFilePathName + "  " + ex.ToString());
                    }
                }

                try
                {
                    File.Copy(serverFilePathName, localFilePathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error copying file " + serverFilePathName + "  " + ex.ToString());
                }
            }

            AssemblyCanBeLoaded = true;

        }

        public void LoadFCMClient()
        {
            try
            {
                _assembly = Assembly.LoadFrom(LocalPathMainAssembly);

                string typeAssembly = "fcm.Windows.UIfcm";
                Type type = _assembly.GetType(typeAssembly);
                var _addIn = (Form)Activator.CreateInstance(type);
                _addIn.Tag = LocalPathMainAssembly;
                _addIn.ShowDialog();

                var version = _addIn.ProductVersion;

                AssemblyIsLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                AssemblyIsLoaded = false;
                throw;
            }
        }

    
    }

    public class fcmConfigXml
    {
        public static string ConnectionString = "ConnectionString";
        public static string ConnectionStringServer = "ConnectionStringServer";
        public static string ConnectionStringLocal = "ConnectionStringLocal";
        public static string LocalAssemblyFolder = "LocalAssemblyFolder";
        public static string ServerAssemblyFolder = "ServerAssemblyFolder";
    }
}
