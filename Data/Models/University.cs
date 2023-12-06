
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
    public class University : IEntity
    {
        private ICollection<Institute> _instutes;
        private ICollection<Thesis> _theses;
        public University()
        {
            _instutes = new HashSet<Institute>();
            _theses = new HashSet<Thesis>();
        }
        [Key]
        public int UniversityID { get; set; }
        [Required]
        [StringLength(150)]
        public string UniversityName { get; set; }
        public virtual ICollection<Institute> Institutes { get { return _instutes; } set { value = this._instutes; } }
        public virtual ICollection<Thesis> Theses { get{ return _theses; } set { value = this._theses; } }

    }
}
