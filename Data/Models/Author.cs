
namespace Data.Models
{
    #region Usings
using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    
    public class Author : IEntity
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
    }
}
