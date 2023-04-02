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
        public static void WriteStartElement(this StreamWriter startElement, string name)
        {
            startElement.Write($"<{name}>");
        }

        public static void WriteEndElement(this StreamWriter endElement, string name)
        {
            endElement.Write($"</{name}>");
        }

        public static void WriteElement(this StreamWriter writeElement, string name, string value)
        {
            writeElement.WriteStartElement(name);
            writeElement.Write(value);
            writeElement.WriteEndElement(name);
        }

        public static void WriteRootStart(this StreamWriter rootStart)
        {
            rootStart.WriteStartElement("root");
        }

        public static void WriteRootEnd(this StreamWriter rootEnd)
        {
            rootEnd.WriteEndElement("root");
        }

        public static void WriteElementsStart(this StreamWriter elementsStart)
        {
            elementsStart.WriteStartElement("elements");
        }

        public static void WriteElementsEnd(this StreamWriter elementsEnd)
        {
            elementsEnd.WriteEndElement("elements");
        }
    }
}
