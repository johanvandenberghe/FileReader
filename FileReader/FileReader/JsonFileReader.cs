using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace FileReader
{
    public class JsonFileReader : IFileReader, IEncodedFileReader
    {
        public string ReadEncodedFile(string path, Func<string, string> decoder)
        {
            var encodedJson = ReadFile(path);
            return decoder(encodedJson);
        }

        public string ReadFile(string path)
        {
            if(path.Contains(".json"))
                return System.IO.File.ReadAllText(path);

            return String.Empty;
        }
    }
}
