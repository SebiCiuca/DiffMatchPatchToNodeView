using DiffMatchPatch;
using System.Collections.Generic;

namespace DiffMatchPatchToNodeView
{
    public class GoogleDiffMatchPatch : diff_match_patch
    {
        public List<Diff> DiffLineMode(string text1, string text2)
        {
            var a = diff_linesToChars(text1, text2);
            var lineText1 = a[0];
            var lineText2 = a[1];
            var lineArray = (IList<string>)a[2];
            var diffs = diff_main(lineText1.ToString(), lineText2.ToString(), false);
            diff_charsToLines(diffs, lineArray);

            return diffs;
        }
    }
}
