using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DiffMatchPatchToNodeView
{
    public class TreeViewParser
    {
        public TreeViewModel ToTreeView(XDocument xmlDocument)
        {
            var rootNode = xmlDocument.Root;

            return ParseNode(rootNode, 1);
        }

        private TreeViewModel ParseNode(XElement node, int parentId)
        {
            if (node.HasElements)
            {
                var index = 0;
                var children = new List<TreeViewModel>();
                bool hasChild = false;
                foreach (var element in node.Elements())
                {
                    children.Add(ParseNode(element, parentId * 10 + index));
                    index++;
                }

                return new TreeViewModel
                {
                    Children = children,
                    Value = hasChild ? string.Empty : node.Value,
                    AbsolutPath = node.GetAbsoluteXPath(),
                    ID = parentId,
                    Xml = node.ToString(),
                    NodeName = node.Name.ToString(),
                    Attributes = node.GetAttributes()
                };
            }
            else
            {
                return new TreeViewModel
                {
                    ID = parentId,
                    Value = node.Value,
                    AbsolutPath = node.GetAbsoluteXPath(),
                    NodeName = node.Name.ToString(),
                    Attributes = node.GetAttributes(),
                    Xml = node.ToString(),
                };
            }
        }
    }
}
