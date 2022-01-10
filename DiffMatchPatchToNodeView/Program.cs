using System;
using System.IO;
using System.Xml.Linq;

namespace DiffMatchPatchToNodeView
{
    class Program
    {
        private static string REF_XML_FILE_PATH = "ref_xml.txt";
        private static string COMP_XML_FILE_PATH = "comp_xml.txt";
        static void Main(string[] args)
        {
            var refXml = File.ReadAllText(REF_XML_FILE_PATH);
            var compXml = File.ReadAllText(COMP_XML_FILE_PATH);

            var referenceXml = XDocument.Parse(refXml);
            var sourceXml = XDocument.Parse(compXml);

            XmlComparer comparer = new XmlComparer();
            TreeViewParser parser = new TreeViewParser();

            var diffs = comparer.Compare(sourceXml, referenceXml);

            var refTree = parser.ToTreeView(referenceXml);
            var sourceTree = parser.ToTreeView(sourceXml);
        }
    }
}
