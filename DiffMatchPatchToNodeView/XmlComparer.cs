using DiffMatchPatch;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DiffMatchPatchToNodeView
{
    public class XmlComparer
    {
        public List<Diff> Compare(XDocument source, XDocument reference)
        {           
            GoogleDiffMatchPatch diffMatchPatch = new GoogleDiffMatchPatch();

            return diffMatchPatch.DiffLineMode(reference.ToString(), source.ToString());
        }
    }
}
