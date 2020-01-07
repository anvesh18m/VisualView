using System;
using System.Collections.Generic;
using System.Text;

namespace OJSTech.Models
{

    public class PagesData
    {
        public Hit[] hits { get; set; }
        public int nbHits { get; set; }
        public int page { get; set; }
        public int nbPages { get; set; }
        public int hitsPerPage { get; set; }
        public bool exhaustiveNbHits { get; set; }
        public string query { get; set; }
        public string _params { get; set; }
        public int processingTimeMS { get; set; }
    }

    public class Hit
    {
        public DateTime created_at { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public int points { get; set; }
        public string story_text { get; set; }
        public object comment_text { get; set; }
        public int num_comments { get; set; }
        public object story_id { get; set; }
        public object story_title { get; set; }
        public object story_url { get; set; }
        public object parent_id { get; set; }
        public int created_at_i { get; set; }
        public string[] _tags { get; set; }
        public string objectID { get; set; }
        public _Highlightresult _highlightResult { get; set; }
    }

    public class _Highlightresult
    {
        public Title title { get; set; }
        public Url url { get; set; }
        public Author author { get; set; }
        public Story_Text story_text { get; set; }
    }

    public class Title
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public object[] matchedWords { get; set; }
    }

    public class Url
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public object[] matchedWords { get; set; }
    }

    public class Author
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public object[] matchedWords { get; set; }
    }

    public class Story_Text
    {
        public string value { get; set; }
        public string matchLevel { get; set; }
        public object[] matchedWords { get; set; }
    }
}
