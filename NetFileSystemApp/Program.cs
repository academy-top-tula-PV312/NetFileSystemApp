using System.Text;

string filePath = @"D:\RPO\file01.dat";

string text = "В следующем примере показано, как выполнять асинхронную запись в файл. Этот код выполняется в приложении WPF с именем TextBlock с именем UserInput и кнопкой, подключенной к обработчику событий Click, который называется Button_Click. Путь к файлу необходимо изменить на файл, который существует на компьютере.";


//using (FileStream stream = File.Open(filePath, FileMode.OpenOrCreate))
//{
//    byte[] buffer = Encoding.UTF8.GetBytes(text);

//    await stream.WriteAsync(buffer);
//}

//using (FileStream stream = File.Open(filePath, FileMode.Open))
//{
//    byte[] buffer = new byte[stream.Length];

//    await stream.ReadAsync(buffer, 0, buffer.Length);
//    string textRead = Encoding.UTF8.GetString(buffer);

//    Console.WriteLine(textRead);
//}








