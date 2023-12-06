using Data.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ThesisKeyword : IEntity
    {
        public int ThesisKeywordID { get; set; }
        [Required]
        public int ThesisID { get; set; }
        [Required]
        public int KeywordID { get; set; }
        public virtual Thesis Thesis { get; set; }
        public virtual Keyword Keyword { get; set; }
    }
}
