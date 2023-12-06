﻿
namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Supervisor : IEntity
    {
        private ICollection<CoSupervisorThesis> _coSupervisorTheses;
        public Supervisor()
        {
            _coSupervisorTheses = new HashSet<CoSupervisorThesis>();
        }
        [Key]   
        public int SupervisorID { get; set; }
        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public virtual ICollection<CoSupervisorThesis> CoSupervisorTheses { get { return _coSupervisorTheses; } set {value = this._coSupervisorTheses; } }


    }
}
