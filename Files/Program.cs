using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {

        public static void GetDriveInfo()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();

            foreach (DriveInfo driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive{0}", driveInfo.Name);
                Console.WriteLine("Filetype:{0}", driveInfo.DriveType);

                if (driveInfo.IsReady == true)
                {
                    Console.WriteLine("Volumelabel:{0}", driveInfo.VolumeLabel);
                    Console.WriteLine("Filesystem:{0}", driveInfo.DriveFormat);
                    Console.WriteLine("Availablespacetocurrentuser:{0} bytes", driveInfo.AvailableFreeSpace);

                    Console.WriteLine("Totalavailablespace:{0} bytes",driveInfo.TotalFreeSpace);

                    Console.WriteLine("Totalsizeofdrive:{0} bytes", driveInfo.TotalSize);
                }
                Console.WriteLine("***********");
            }
        }

        public static void CreateDir()
        {
            var directory = Directory.CreateDirectory(@"C:\Temp\ProgrammingInCSharp\Directory");

            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            directoryInfo.Create();
        }

        public static void DeleteDirIfExists()
        {
            if (Directory.Exists(@"C:\Temp\ProgrammingInCSharp\Directory"))
            {
                Directory.Delete(@"C:\Temp\ProgrammingInCSharp\Directory");
            }

            var directoryInfo = new DirectoryInfo(@"C:\Temp\ProgrammingInCSharp\DirectoryInfo");
            if (directoryInfo.Exists)
            {
                directoryInfo.Delete();
            }
        }

        public static void AccessToDir()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("TestDirectory");
            directoryInfo.Create();
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(
                new FileSystemAccessRule("everyone",
                FileSystemRights.ReadAndExecute,
                AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);
        }

        public static void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if(currentLevel >= maxLevel)
            {
                return;
            }
            string indent = new string('-', currentLevel);
            try
            {
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);
                foreach(DirectoryInfo subDirectory in subDirectories)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine(indent + "Can't access: " + directoryInfo.Name);
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine(indent + "Can't find: " + directoryInfo.Name);
                return;
            }
        }

        public static void GetFiles()
        {
            Console.WriteLine("**************");
            foreach (string file in Directory.GetFiles(@"C:\Windows"))
            {
                Console.WriteLine(file);
            }
            Console.WriteLine("**************");
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
            foreach(FileInfo fileInfo in directoryInfo.GetFiles())
            {
                Console.WriteLine(fileInfo.FullName);
            }
            Console.WriteLine("**************");

        }

        static void Main(string[] args)
        {
            GetDriveInfo();
            //CreateDir();
            DeleteDirIfExists();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");
            ListDirectories(directoryInfo, "*a*", 5, 0);

            GetFiles();

            Console.ReadKey();
        }
    }
}
