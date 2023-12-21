using Data.Models.Abstract;

namespace Data.Models.DTOs
{
    public class ThesisModel : IEntity
    {
        public int? UNIVERSITYID { get; set; }
        public virtual University? University { get; set; }
        public int? INSTITUTEID { get; set; }
        public virtual Institute? Institute { get; set; }
        public string? TITLE { get; set; }
        public string? AUTHORNAME { get; set; }
        public string? AUTHORLASTNAME { get; set; }
        public string? SUPERVISORFIRSTNAME { get; set; }
        public string? SUPERVISORLASTNAME { get; set; }
        public string? TYPE { get; set; }
        public string? LANGUAGE { get; set; }
        public int? NUMBER { get; set; }
        public string? THESISYEAR { get; set; }
    }
}
