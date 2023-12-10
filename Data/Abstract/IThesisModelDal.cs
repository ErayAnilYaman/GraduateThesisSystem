
namespace Data.Abstract
{
    #region usings
    using Data.Abstract.Base;
    using Data.Models.DTOs;

    #endregion

    public interface IThesisModelDal : IEntityRepositoryBase<ThesisModel>
    {
        IEnumerable<ThesisModel> GetThesisModel();
    }
}
