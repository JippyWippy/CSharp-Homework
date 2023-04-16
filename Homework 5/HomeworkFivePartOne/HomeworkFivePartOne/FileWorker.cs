using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkFivePartOne
{
    public record class FileWorker
    {
        public string fileName { get; private set; }
        public DateTime fileCreationTime { get; private set; }
        public string fileExtension { get; private set; }

        public FileWorker(string fileName, DateTime fileCreationTime, string fileExtension)
        {
            this.fileName = fileName;
            this.fileCreationTime = fileCreationTime;
            this.fileExtension = fileExtension;

            if (fileExtension == "")
            {
                this.fileExtension = "Каталог";
            }
        }

        public StringBuilder ReturnString(List<FileWorker> fileList)
        {
            string fileCreationTimeString = Convert.ToString(fileCreationTime);
            StringBuilder summaryOfStrings = new StringBuilder();
            summaryOfStrings.AppendLine(fileName);
            summaryOfStrings.AppendLine(fileCreationTimeString);
            summaryOfStrings.AppendLine(fileExtension);
            summaryOfStrings.AppendLine("\t");

            return summaryOfStrings;
        }
    }
}
