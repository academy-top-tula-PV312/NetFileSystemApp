using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFileSystemApp
{
    static class Examples
    {
        public static void DriveInfoExample()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Name: {drive.Name}");
                Console.WriteLine($"Type: {drive.DriveType}");

                if (drive.IsReady)
                {
                    Console.WriteLine($"Label: {drive.VolumeLabel}");
                    Console.WriteLine($"Total Memory: {drive.TotalSize}");
                    Console.WriteLine($"Total Free Memory: {drive.TotalFreeSpace}");
                }
                Console.WriteLine();
            }
        }

        public static void DirectoryExample()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine();

            string path = @"C:\";

            if (Directory.Exists(path))
            {
                Console.WriteLine("Directories:");
                foreach (var dir in Directory.GetDirectories(path, "M*"))
                    Console.WriteLine(dir);
                Console.WriteLine();

                Console.WriteLine("Files:");
                foreach (var file in Directory.GetFiles(path))
                    Console.WriteLine(file);
            }

            path = @"D:\RPO\temp";
            //Directory.CreateDirectory(path);

            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public static void DirectoryInfoExample()
        {
            string path = @"D:\";

            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                Console.WriteLine("Directories:");
                var dirs = dir.GetDirectories("M*");
                foreach (var d in dirs)
                    Console.WriteLine($"{d.Name}\t{d.FullName}");
                Console.WriteLine();

                var files = dir.GetFiles("*.pdf");
                foreach (var f in files)
                    Console.WriteLine($"{f.Name}\t{f.FullName}");
            }

            path = @"D:\RPO\temp";
            dir = new DirectoryInfo(path);

            //dir.Create();
            //if(dir.Exists)
            //    dir.Delete();

            dir.MoveTo(@"D:\hgfghfghf");
        }

        public static void FileExample()
        {
            

            string path = @"D:\RPO\myfile.bin";

            //if (!File.Exists(path))
            //    File.Create(path);


            //if(File.Exists(path))
            //    File.Delete(path);

            //File.Copy(path, @"D:\newmyfile.dat");

            //List<string> names = new() { "Bobby", "Sammy", "Jimmy" };
            //string text = "The following example demonstrates how to use the File class to check whether a file exists, and depending on the result, either create a new file and write to it, or open the existing file and read from it. Before running the code, create a c:\temp folder.";

            //File.WriteAllLines(path, names, Encoding.UTF8);
            //File.AppendAllText(path, text);

            //text = File.ReadAllText(path);
            //Console.WriteLine(text);

            //var textLines = File.ReadAllLines(path);
            //for(int i = textLines.Length - 1;  i >= 0; i--)
            //    Console.WriteLine(textLines[i]);




        }
    }
}
