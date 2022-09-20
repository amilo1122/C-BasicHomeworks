using System.Text;

namespace HW10;

class Program
{
    static void Main(string[] args)
    {
        // Создать директории c:\Otus\TestDir1 и c:\Otus\TestDir2 с помощью класса DirectoryInfo.
        string[] pathArray = { @"c:\Otus\TestDir1", @"c:\Otus\TestDir2" };
        foreach (string path in pathArray)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                dir.Create();
                Console.WriteLine("The directory was created successfully");
            }
            else
            {
                Console.WriteLine("That path exists already");
            }

        }

        // В каждой директории создать несколько файлов File1...File10 с помощью класса File.
        foreach (string path in pathArray)
        {
            if (Directory.Exists(path))
            {
                for (int i = 1; i <= 10; i++)
                {
                    var fileName = path + @"\File" + i.ToString() + ".txt";
                    using (FileStream fs = File.Create(fileName))
                    {
                        Console.WriteLine("The file {0} was created", fileName);
                    }
                }
            }
            else
            {
                Console.WriteLine("That path is missing");
            }
        }

        // В каждый файл записать его имя в кодировке UTF8. Учесть, что файл может быть удален, либо отсутствовать права на запись.
        foreach (string path in pathArray)
        {
            if (Directory.Exists(path))
            {
                var fileArray = Directory.GetFiles(path);
                foreach (var file in fileArray)
                {
                    using (FileStream fs = File.Create(file))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(file);
                        // Add some information to the file.
                        fs.Write(info);
                        //sw.WriteLine(file);
                        Console.WriteLine("The file {0} was modified", file);
                    }
                }
                
            }
        }

        // Каждый файл дополнить текущей датой (значение DateTime.Now) любыми способами: синхронно и\или асинхронно.
        foreach (string path in pathArray)
        {
            if (Directory.Exists(path))
            {
                var fileArray = Directory.GetFiles(path);
                foreach (var file in fileArray)
                {
                    File.AppendAllText(file, "\n");
                    File.AppendAllText(file, DateTime.Now.ToString());
                }

            }
        }

        // Прочитать все файлы и вывести на консоль: имя_файла: текст + дополнение.
        foreach (string path in pathArray)
        {
            if (Directory.Exists(path))
            {
                var fileArray = Directory.GetFiles(path);
                foreach (var file in fileArray)
                {
                    using (StreamReader sr = File.OpenText(file))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }

            }
        }
    }
}
