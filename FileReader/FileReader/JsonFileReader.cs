using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace FileReader
{
    public class JsonFileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            if(path.Contains(".json"))
                return System.IO.File.ReadAllText(path);

            return String.Empty;
        }
    }
}
