using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkFivePartOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourceArchive = AppContext.BaseDirectory + "\\archiveHomework.zip";
                string destinationDirectory = AppContext.BaseDirectory + "\\testProgram";
                string summaryTextFile = AppContext.BaseDirectory + "\\summaryInfo.csv";
                string pathToTheCsv = "%AppData%\\HomeworkFive.txt";
                ZipFile.ExtractToDirectory(sourceArchive, destinationDirectory);

                DirectoryInfo directoryInfo = new DirectoryInfo(destinationDirectory);
                FileInfo[] filesInArchive = directoryInfo.GetFiles();
                DirectoryInfo[] directoriesInArchive = directoryInfo.GetDirectories();

                List<FileWorker> listOfFilesAndDirectories = new List<FileWorker>();
                listOfFilesAndDirectories.Sort();
                foreach (FileInfo files in filesInArchive)
                {
                    FileWorker file = new FileWorker(files.Name, files.CreationTime, files.Extension);
                    listOfFilesAndDirectories.Add(file);
                }

                foreach (DirectoryInfo directory in directoriesInArchive)
                {
                    FileWorker directories = new FileWorker(directory.Name, directory.CreationTime, directory.Extension);
                    listOfFilesAndDirectories.Add(directories);
                }

                using (StreamWriter summaryFile = new StreamWriter(summaryTextFile, false))
                {
                    foreach (FileWorker file in listOfFilesAndDirectories)
                    {
                        StringBuilder fileGroup = file.ReturnString(listOfFilesAndDirectories);
                        summaryFile.WriteLine(fileGroup);
                    }
                    Console.WriteLine($"Создание файла-документа, содержащий информацию о файлах и директориях, из архива прошло успешно!");
                }
                directoryInfo.Delete(true);

                using (StreamWriter pathFile = new StreamWriter(pathToTheCsv, false))
                {
                    pathFile.Write(summaryTextFile);
                }
                Console.Read();
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("Путь до указанного файла не найден!");
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