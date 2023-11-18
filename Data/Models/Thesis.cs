using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Thesis : IEntity
    {

        public Thesis()
        {

        }
        public int ThesisID { get; set; }
        public int ThesisNumber { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int AuthorID { get; set; }
        public int ThesisYear { get; set; }
        public string ThesisType { get; set; }
        public int UniversityID { get; set; }
        public int InstituteID { get; set; }
        public int Pages { get; set; }
        public string ThesisLanguage { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual Author Author { get; set; }
        public virtual University University { get; set; }
        public virtual Institute Institute { get; set; }
    }
}
