using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiskOpsConsoleApp
{
    class Operations
    {

        public static Disk GetFreeSpace(DriveInfo selectedDrive)
        {
            Disk diskInfo = new Disk();
            diskInfo.TotalFreeSpace = selectedDrive.TotalFreeSpace;
            diskInfo.TotalSize = selectedDrive.TotalSize;
            return diskInfo;
        }

        //public static Disk GetDirectoryInfo(DriveInfo selectedDrive)
        //{
        //    Disk diskInfo = new Disk();
        //    diskInfo.NoOfFiles =;

        //}



        public static Disk DirectoryFileCount(DirectoryInfo dirinfo, Disk disk)
        {
            try
            {
                disk.NoOfFiles = disk.NoOfFiles + dirinfo.GetFiles("*.*").Length;
                disk.NoOfDirectory = disk.NoOfDirectory + dirinfo.GetDirectories().Length;
                if (dirinfo.GetDirectories().Length > 0)
                {
                    foreach (DirectoryInfo subdirinfo in dirinfo.GetDirectories())
                    {
                        disk = DirectoryFileCount(subdirinfo, disk);

                    }

                }


            }
            catch (Exception ex)
            {
                //
            }
            return disk;

        }

        public static string GetFilePath(DirectoryInfo dirinfo, string filename)
        {
            string temp = "File not found";
            //Console.WriteL(".");
            try
            {
                foreach (FileInfo fileinfolist in dirinfo.GetFiles())
                {
                    if (fileinfolist.Name == filename)
                    {
                        return "File found at: " + fileinfolist.FullName;
                    }


                }

                foreach (DirectoryInfo subdirinfo in dirinfo.GetDirectories())
                {
                    temp = GetFilePath(subdirinfo, filename);
                    if (temp != "File not found")
                    {
                        break;


                    }

                }

            }
            catch (Exception ex)
            {

            }
            return temp;

        }


    }
}
