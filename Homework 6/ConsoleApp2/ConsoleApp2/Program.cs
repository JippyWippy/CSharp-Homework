using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string pathToTheCsv = "%AppData%\\HomeworkFive.txt";
                using (StreamReader readPathToCsv = new StreamReader(pathToTheCsv))
                {
                    string? path = await readPathToCsv.ReadToEndAsync();
                    using (StreamReader readSummaryFile = new StreamReader(path))
                    {
                        string? line;
                        while ((line = await readSummaryFile.ReadLineAsync()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
               
                FileInfo deleteFile = new FileInfo(pathToTheCsv);
                deleteFile.Delete();
                Console.Read();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Путь до указанной папки указан неверно!");
                Console.Read();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Путь до указанного файла не найден!");
                Console.Read();
            }
             catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Вы не имеете доступа к запрашиваемому диску!");
            }
            finally
            {
                Console.Read();
            }
        }
    }
}

