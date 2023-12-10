
namespace BusinessCore.Abstract
{
    
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CoreLayer.Results;
    using Data.Models;
    #endregion
    public interface IThesisService
    {
        IDataResult<IEnumerable<Thesis>> GetAll();
        IDataResult<Thesis> GetById(int id);
    }
}
