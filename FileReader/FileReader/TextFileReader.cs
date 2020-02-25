using System;

namespace FileReader
{
    public class TextFileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }
    }
}
