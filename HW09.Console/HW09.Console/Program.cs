using System.Net;

namespace HW09Console;

class Program
{
    static void Main(string[] args)
    {
        // Откуда будем качать
        string remoteUrl = "https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg";
        //string remoteUrl = "https://zastavok.net/download/31918/1920x1080/";
        // Как назовем файл на диске
        string fileName = "bigimage.jpg";
        // Качаем картинку в текущую директорию
        var imageDownloader = new ImageDownloader();

        imageDownloader.ImageStarted += DisplayMessage;        
        Task t = imageDownloader.DownloadAsync(remoteUrl, fileName);
        imageDownloader.ImageCompleted += DisplayMessage;

        Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.A)
            {
                Console.WriteLine();
                Console.WriteLine("Завершаем работу...");
                Environment.Exit(0);
            }
            else
            {
                CheckCompleted(t);
            }
        }

        void DisplayMessage(string message) => Console.WriteLine(message);
    }

    private static void CheckCompleted(Task t)
    {
        Console.WriteLine();
        if (t.IsCompleted)
        {
            Console.WriteLine("Картинка загружена");
        }
        else
        {
            Console.WriteLine("Картинка еще не загружена");
        }
    }
}
public delegate void DownloadHandler(string message);
class ImageDownloader
{
    public event DownloadHandler ImageStarted;
    public event DownloadHandler ImageCompleted;
    public void Download(string remoteUrl, string fileName)
    {
        var myWebClient = new WebClient();
        ImageStarted?.Invoke("Скачивание файла началось");
        Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUrl);
        myWebClient.DownloadFile(remoteUrl, fileName);
        ImageCompleted?.Invoke("Скачивание файла закончилось");
        Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUrl);
    }

    public async Task DownloadAsync(string remoteUrl, string fileName)
    {
        var myWebClient = new WebClient();
        ImageStarted?.Invoke("Скачивание файла началось");
        Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, remoteUrl);
        await myWebClient.DownloadFileTaskAsync(remoteUrl, fileName);
        ImageCompleted?.Invoke("Скачивание файла закончилось");
        Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, remoteUrl);
    }
}
