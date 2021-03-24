namespace StringExtension
{
    public class Rootobject
    {
        public GoogleDictionaryResult[] Property1 { get; set; }
    }

    public class GoogleDictionaryResult
    {
        public string word { get; set; }
        public Phonetic[] phonetics { get; set; }
        public Meaning[] meanings { get; set; }
    }

    public class Phonetic
    {
        public string text { get; set; }
        public string audio { get; set; }
    }

    public class Meaning
    {
        public string partOfSpeech { get; set; }
        public Definition[] definitions { get; set; }
    }

    public class Definition
    {
        public string definition { get; set; }
        public string[] synonyms { get; set; }
        public string example { get; set; }
    }
}