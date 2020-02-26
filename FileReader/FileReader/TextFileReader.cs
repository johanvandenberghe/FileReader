using System;
using System.Security;

namespace FileReader
{
    public class TextFileReader : SecurisedFileReader, IEncodedFileReader
    {
        public TextFileReader(IPermission permission) : base(permission, new string[] { "toto", "tata" })
        {
        }
        public override string ReadFile(string path)
        {
            PermissionDemand(path);
            return System.IO.File.ReadAllText(path);
        }

        public string ReadEncodedFile(string path, Func<string, string> decoder)
        {
            PermissionDemand(path);
            var encodedContend = System.IO.File.ReadAllText(path);
            return decoder(encodedContend);
        }
    }
}
