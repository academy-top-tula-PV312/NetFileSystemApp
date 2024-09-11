using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static async Task FileStreamExampleAsync()
        {
            string filePath = @"D:\RPO\file01.dat";

            string text = "В следующем примере показано, как выполнять асинхронную запись в файл. Этот код выполняется в приложении WPF с именем TextBlock с именем UserInput и кнопкой, подключенной к обработчику событий Click, который называется Button_Click. Путь к файлу необходимо изменить на файл, который существует на компьютере.";
            int number = 123;
            double x = 345.3423;

            //using (FileStream stream = File.Open(filePath, FileMode.Create))
            //{
            //    byte[] buffer = Encoding.UTF8.GetBytes(text);
            //    //byte[] buffer = BitConverter.GetBytes(number);
            //    //await stream.WriteAsync(buffer, 0, buffer.Length);

            //    //buffer = BitConverter.GetBytes(x);
            //    await stream.WriteAsync(buffer, 0, buffer.Length);

            //}

            using (FileStream stream = File.Open(filePath, FileMode.Open))
            {


                //await stream.ReadAsync(buffer, 0, 4);
                //int num = BitConverter.ToInt32(buffer);
                //Console.WriteLine(num);

                //await stream.ReadAsync(buffer);
                //double xx = BitConverter.ToDouble(buffer);
                //Console.WriteLine(xx);

                stream.Seek(21, SeekOrigin.Begin);
                byte[] buffer = new byte[stream.Length - 21];

                await stream.ReadAsync(buffer, 0, buffer.Length);

                string textRead = Encoding.UTF8.GetString(buffer);
                Console.WriteLine(textRead);
            }

        }

        public static async Task TextStreamExampleAsync()
        {
            string pathFile = @"D:\RPO\file02.txt";

            string text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            string text2 = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";

            //using (StreamWriter writer = new(pathFile))
            //{
            //    await writer.WriteLineAsync(text);
            //}

            //using (StreamWriter writer = new(pathFile, true))
            //{
            //    await writer.WriteLineAsync(text2);
            //    await writer.FlushAsync();
            //}

            using (StreamReader reader = new(pathFile))
            {
                //for(int i = 0; i < 10; i++)
                //    Console.WriteLine((char)reader.Read());

                //int c;
                //while((c = reader.Read()) != -1)
                //    Console.Write((char)c);

                //string? textLine;
                //while((textLine = await reader.ReadLineAsync()) is not null)
                //    Console.WriteLine(textLine);

                text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
        }

        public static void BinaryStreamExample()
        {


            //int number = 123;
            //double x = 345.897;
            //string str = "Hello world";
            //bool flag = false;

            //string filePath = @"D:\RPO\file03.bin";

            //Employee employee = new() { Name = "Tommy", Birthday = DateTime.Now, Salary = 150500m };

            //#pragma warning disable SYSLIB0011 // Тип или член устарел
            //BinaryFormatter formatter = new();
            //using (FileStream writer = File.OpenWrite(filePath))
            //{
            //    formatter.Serialize(writer, employee);
            //}

#pragma warning restore SYSLIB0011 // Тип или член устарел

            //using(BinaryWriter writer = new(File.OpenWrite(filePath)))
            //{
            //    writer.Write(number);
            //    writer.Write(x);
            //    writer.Write(str);
            //    writer.Write(flag);
            //}

            //using (BinaryReader reader = new(File.OpenRead(filePath)))
            //{
            //    int n = reader.ReadInt32();
            //    double y = reader.ReadDouble();
            //    string s = reader.ReadString();
            //    bool f = reader.ReadBoolean();

            //    Console.WriteLine($"n = {n}\ny = {y}\ns = {s}\nf = {f}");
            //}


            //[Serializable]
            //class Employee
            //{
            //    public string? Name { get; set; }
            //    public DateTime Birthday { get; set; }
            //    public decimal Salary { get; set; }
            //}

        }
    }
}
