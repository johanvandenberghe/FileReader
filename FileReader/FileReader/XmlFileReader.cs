using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Xml;

namespace FileReader
{
    public class XmlFileReader : SecurisedFileReader, IEncodedFileReader
    {
        public XmlFileReader(IPermission permission) :base(permission, new string[] { "toto", "tata" })
        {
        }

        public override string ReadFile(string path)
        {
            string result = string.Empty;
            PermissionDemand(path);

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

        public string ReadEncodedFile(string path, Func<string, string> decoder)
        {
            var encodedContend = System.IO.File.ReadAllText(path);
            return decoder(encodedContend);
        }
    }
}
