
namespace Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;

    public class ThesisSubjectTopic:IEntity
    {
        [Key]
        public int ThesisSubjectTopicID { get; set; }
        
        public int ThesisID { get; set; }
        public int SubjectTopicID { get; set; }

        public virtual Thesis Thesis { get; set; }
        public virtual SubjectTopic SubjectTopic { get; set; }
    }

}
