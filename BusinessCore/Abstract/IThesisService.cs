
namespace BusinessCore.Abstract
{
    using CoreLayer.Results;
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
        IDataResult<IEnumerable<Thesis>> GetAll();
        IDataResult<Thesis> GetById(int id);
    }
}
