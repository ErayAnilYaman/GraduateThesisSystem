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
        public int THESISKEYWORDID { get; set; }
        [Required]
        public int THESISID{ get; set; }
        [Required]
        public int KEYWORDID { get; set; }
        public virtual Thesis THESIS{ get; set; }
        public virtual Keyword KEYWORD{ get; set; }
    }
}
