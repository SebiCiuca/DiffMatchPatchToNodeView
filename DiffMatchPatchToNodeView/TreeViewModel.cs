using System;
using System.Collections.Generic;
using System.Text;

namespace DiffMatchPatchToNodeView
{
    public class TreeViewModel
    {
        public long ID { get; set; }
        public string NodeName { get; set; }
        public string AbsolutPath { get; set; }
        public string Value { get; set; }
        public string Xml { get; set; }
        public int Operation { get; set; } = 2;
        public List<TreeViewModel> Children { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}
