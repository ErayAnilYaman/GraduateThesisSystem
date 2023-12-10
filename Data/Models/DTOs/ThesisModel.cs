using Data.Models.Abstract;

namespace Data.Models.DTOs
{
    public class ThesisModel : IEntity
    {

        public string TITLE { get; set; }
        public string AUTHORNAME { get; set; }
        public string SUPERVISORFIRSTNAME { get; set; }
        public string SUPERVISORLASTNAME { get; set; }
        public string ABSTRACT { get; set; }
        public string INSTITUTENAME { get; set; }
        public string UNIVERSITYNAME { get; set; }
        public string TYPE { get; set; }
        public int NUMBER { get; set; }
        public int THESISYEAR { get; set; }
    }
}
