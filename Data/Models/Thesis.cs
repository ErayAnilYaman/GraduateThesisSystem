
namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Thesis : IEntity
    {
        private ICollection<CoSupervisorThesis> _coSupervisorTheses;
        private ICollection<ThesisKeyword> _thesisKeywords;
        private ICollection<ThesisSubjectTopic> _subjectTopics;
        public Thesis()
        {
            _coSupervisorTheses = new HashSet<CoSupervisorThesis>();
            _thesisKeywords = new HashSet<ThesisKeyword>();
            _subjectTopics = new HashSet<ThesisSubjectTopic>();
        }
        [Key]
        public int ThesisID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(250)]
        public string Abstract { get; set; }
        [Required]
        public int AuthorID { get; set; }
        [Required]
        public int ThesisYear { get; set; }
        [Required]
        [StringLength(150)]
        public string Type { get; set; }
        [Required]
        public int UniversityID { get; set; }
        [Required]
        public int InstituteID { get; set; }
        [Required]
        public int SupervisorID { get; set; }
        [Required]
        public int Pages { get; set; }
        [Required]
        [StringLength(100)]
        public string Language { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        public virtual Author Author { get; set; }
        public virtual University University { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual ICollection<CoSupervisorThesis> CoSupervisorTheses { get { return _coSupervisorTheses; } set { value = _coSupervisorTheses; } }
        public virtual ICollection<ThesisKeyword> ThesisKeywords { get { return _thesisKeywords; } set { value = _thesisKeywords; } }
        public virtual ICollection<ThesisSubjectTopic> ThesisSubjectTopics
        {
            get { return _subjectTopics; }
            set
            {
                value = this._subjectTopics;
            }
        }
    }
}
