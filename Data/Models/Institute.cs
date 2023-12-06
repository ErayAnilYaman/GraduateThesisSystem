
namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Institute : IEntity
    {
        private ICollection<Thesis> _theses;
        public Institute()
        {
            _theses = new HashSet<Thesis>();
        }
        [Key]
        public int InstituteID { get; set; }
        [Required]
        [StringLength(150)]
        public string InstituteName { get; set; }
        [Required]
        public int UniversityID { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Thesis> Theses{ get { return _theses; } set { value = this._theses; } }
    }
}
