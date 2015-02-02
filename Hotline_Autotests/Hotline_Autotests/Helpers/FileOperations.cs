using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hotline_Autotests.Helpers
{
    class FileOperations
    {
        public static String GetUrl(String FilePath)
        {
            String uri = "";
            XmlTextReader myXMLReader = new XmlTextReader(FilePath);

            while (myXMLReader.Read())
            {
                if (myXMLReader.NodeType==XmlNodeType.Element)
                {
                    if (myXMLReader.Name=="Url")
                    {
                        uri = myXMLReader.Value;
                    }
                    
                }

            }

            return uri;
        }
    }
}
