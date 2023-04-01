using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Project2_Group4
{
    public static class XMLExtension
    {
        public static void WriteStartDocument(this XmlWriter writeStart, string encoding)
        {
            encoding = "UTF-8";
            writeStart.WriteStartDocument();
            writeStart.WriteProcessingInstruction("xml", $"version=\"1.0\" encoding=\"{encoding}\"");
        }

        public static void WriteStartRootElement(this XmlWriter writeStartRoot, string rootElementName)
        {
            writeStartRoot.WriteStartElement(rootElementName);
        }

        public static void WriteEndRootElement(this XmlWriter writeEndRoot)
        {
            writeEndRoot.WriteEndElement();
        }

        public static void WriteStartElement(this XmlWriter writeStartEle, string elementName)
        {
            writeStartEle.WriteStartElement(elementName);
        }

        public static void WriteEndElement(this XmlWriter writeEndEle)
        {
            writeEndEle.WriteEndElement();
        }

        public static void WriteAttribute(this XmlWriter writeAttr, string attributeName, string attributeValue)
        {
            writeAttr.WriteAttributeString(attributeName, attributeValue);
        }
    }
}
