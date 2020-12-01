using System.Collections.Generic;


namespace TaggerOutputObjectLibrary
{
    public class TaggerOutputObject
    {
        public Dictionary<int, string> ModelTags { get; set; }
        public Dictionary<string, int> POSSums = new Dictionary<string, int>();
        public string[] TaggedText { get; set; }
        public string[] TaggedText_TagsOnly { get; set; }
        public int TotalSentences { get; set; }
        public int TotalWC { get; set; }
    }

}
