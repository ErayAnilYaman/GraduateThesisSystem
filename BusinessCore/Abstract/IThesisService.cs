
namespace BusinessCore.Abstract
{
    using Data.Models;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface IThesisService
    {
        IEnumerable<Thesis> GetAll();
        Thesis GetById(int id);
    }
}
