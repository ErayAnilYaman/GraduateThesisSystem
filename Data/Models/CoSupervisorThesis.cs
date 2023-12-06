
namespace Data.Models
{
    #region Usings
    using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class CoSupervisorThesis : IEntity
    {
        [Key]
        public int CoSupervisorThesisID { get; set; }
        [Required]
        public int ThesisID { get; set; }
        [Required]
        public int SupervisorID { get; set; }
        public virtual Thesis  Thesis { get; set; }
        public virtual Supervisor Supervisor{ get; set; }
    }
}
