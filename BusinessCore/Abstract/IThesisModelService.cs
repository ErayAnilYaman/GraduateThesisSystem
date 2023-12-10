namespace BusinessCore.Abstract
{
    #region Usings

    using CoreLayer.Results;
    using Data.Models.DTOs;


    #endregion
    public interface IThesisModelService
    {
        IDataResult<IEnumerable<ThesisModel>> GetModel();
    }
}
