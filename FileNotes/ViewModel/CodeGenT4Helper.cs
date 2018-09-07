using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FileNotes.ViewModel
{
    class CodeGenT4Helper
    {
        public List<string> GetNames()
        {
            List<string> result = new List<string>();
            XmlDocument doc = new XmlDocument();
            string absolutePath = "";//this.Host.ResolvePath("File.xml");
            doc.Load(absolutePath);
            foreach (XmlNode node in doc.SelectNodes("/Root/Element"))
            {
                result.Add(node.Attributes["Name"].InnerText);
            }
            return result;
        }
    }
}
