using System;

namespace FileReader
{
    public class TextFileReader : IEncodedFileReader
    {
        public string ReadFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public string ReadEncodedFile(string path, Func<string, string> decoder)
        {
            var encodedContend = System.IO.File.ReadAllText(path);
            return decoder(encodedContend);
        }
    }
}
