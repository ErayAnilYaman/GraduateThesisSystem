
namespace Data.Models
{
    using Data.Models.Abstract;
    #region usings
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;

    #endregion

    public class ThesisSubjectTopic:IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ThesisID { get; set; }
        [Required]
        public int TopicID { get; set; }

        public virtual Thesis Thesis { get; set; }
        public virtual SubjectTopic SubjectTopic { get; set; }
    }

}
