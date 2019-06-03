using System.IO;

namespace Tanki2._0
{
    internal partial class Program
    {
        
        class FileStorer
        {
            private string path;
            public string []Result;
            
            public FileStorer(string path)
            {
                this.path = path;
                Result = new string[0];
                ReadFile();
            }

            public void ReadFile()
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Add(line);
                    }
                }
            }

            private void Add(string item)
            {
                string[] newStr = new string[Result.Length + 1];
                for (int i = 0; i < Result.Length; i++)
                {
                    newStr[i] = Result[i];
                }

                newStr[Result.Length] = item;
                Result = newStr;
            }
            
            
        }
    }
}