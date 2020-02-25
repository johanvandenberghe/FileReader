using System;

namespace FileReader
{
    internal interface IEncodedFileReader : IFileReader
    {
        string ReadEncodedFile(string path, Func<string, string> decoder);
    }
}