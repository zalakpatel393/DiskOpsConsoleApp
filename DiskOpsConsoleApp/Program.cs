using System;
using System.IO;

namespace DiskOpsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivelist = DriveInfo.GetDrives();

            Console.WriteLine("Your PC has below drives:");
            for (int i = 0; i < drivelist.Length; i++)
            {

                Console.WriteLine(i + 1 + "." + drivelist[i].Name + "(" + (drivelist[i].IsReady ? drivelist[i].VolumeLabel : drivelist[i].DriveType.ToString()) + ")" );

            }


            Console.WriteLine("Select drive for operation:");
            int iOptions = Convert.ToInt32(Console.ReadLine());
            DriveInfo selectedDrive = drivelist[iOptions - 1];

            //
            Console.WriteLine("You have selected:" + selectedDrive.Name + Environment.NewLine);


            Console.WriteLine("1.Show Free Space");
            Console.WriteLine("2.Number of Directory and Files");
            Console.WriteLine("3.Find file");

            Console.WriteLine("Select Operation to perform:");

            int iOperation = Convert.ToInt32(Console.ReadLine());

            switch (iOperation)
            {
                case 1:
                    Console.WriteLine(selectedDrive.Name + " has " +
                        Math.Round(
                            (Operations.GetFreeSpace(selectedDrive).TotalFreeSpace) / (1024.00 * 1024.00 * 1024.00),
                            2) +
                        " GB free space");
                    break;

                case 2:

                    Disk disk = new Disk();
                    disk = Operations.DirectoryFileCount(selectedDrive.RootDirectory, disk);

                    Console.WriteLine("Total file count: " + disk.NoOfFiles);
                    Console.WriteLine("Total directory count: " + disk.NoOfDirectory);


                    break;

                case 3:
                    Console.WriteLine("Enter file name to search:");
                    string strSearch = Console.ReadLine();
                    Console.WriteLine("Searching....");
                    Console.WriteLine(Operations.GetFilePath(selectedDrive.RootDirectory, strSearch));
                    break;



                default:
                    Console.WriteLine("Invalid Option Selected!!");
                    break;



            }








        }





    }





}
