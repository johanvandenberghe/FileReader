using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace FileReader
{
    public class JsonFileReader : SecurisedFileReader, IEncodedFileReader
    {
        public JsonFileReader(IPermission permission) : base(permission, new string[] { "toto.json", "tata.json" })
        {
        }
        public override string ReadFile(string path)
        {
            PermissionDemand(path);
            if (path.Contains(".json"))
                return System.IO.File.ReadAllText(path);

            return  String.Empty;
        }
        public string ReadEncodedFile(string path, Func<string, string> decoder)
        {
            var encodedJson = ReadFile(path);
            return decoder(encodedJson);
        }
    }
}
