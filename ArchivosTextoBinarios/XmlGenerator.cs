using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivosTextoBinarios
{
    class XmlGenerator
    {
        private List<object> _objectList;
        private String xml;

        public XmlGenerator(List<object> objectList)
        {
            _objectList = objectList;
            xml += "<? xml version = \"1.0\" encoding = \"UTF-8\" ?>\n";
        }

        public void AddRoot(String raiz)
        {
            xml += CreateElement(raiz);
        }

        public String CreateElement(String elementName)
        {
            return "<" + elementName + ">" + "</" + elementName + ">" + "\n";
        }

        public void Add(String parentName, String childName)
        {
        }


    }
}
