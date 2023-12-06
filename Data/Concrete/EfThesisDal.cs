
namespace Data.Concrete
{
    #region usings
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class EfThesisDal : EfEntityRepositoryBase<Thesis , ThesesContext>,IThesisDal
    {

    }
}
