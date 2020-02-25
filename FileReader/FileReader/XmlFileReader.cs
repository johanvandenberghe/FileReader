using System;
using System.Xml;

namespace FileReader
{
    public class XmlFileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            string result = string.Empty;
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        result += $"<{reader.Name}>";
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        result += reader.Value;
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        result += $"<{reader.Name}>";
                        break;
                }
            }

            return result;
        }
    }
}
