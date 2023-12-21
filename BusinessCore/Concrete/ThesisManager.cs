
namespace BusinessCore.Concrete
{
    #region usings
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models;
    using Data.Models.DTOs;


    #endregion
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IThesisModelDal _thesisModelDal;

        public ThesisManager(IThesisDal thesisDal)
        {
            _thesisDal = thesisDal;
        }
        public IDataResult<IEnumerable<Thesis>> GetAll()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Thesis>>(_thesisDal.GetAll() , ThesisMessages.ThesesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Thesis>>(ex.Message);
            }
        }

        public IDataResult<Thesis> GetById(int id)
        {
            try
            {
                var thesis = _thesisDal.Get(T => T.THESISID == id);
                if (thesis.GetType().Name.Equals("Data.Models.Thesis") && thesis != null)
                {
                    return new SuccessDataResult<Thesis>(thesis , ThesisMessages.ThesisFound);

                }
                return new ErrorDataResult<Thesis>(ThesisMessages.ThesisFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }

        public IDataResult<IEnumerable<ThesisModel>> GetFilter(ThesisModel model)
        {
            try
            {
                var result = (IEnumerable<ThesisModel>)model.GetType()
                    .GetProperties()
                    .Where(p => p.GetValue(model) != null &&!p.GetValue(model)!.Equals(p.PropertyType.IsValueType ?
                Activator.CreateInstance(p.PropertyType) : null));
                    
                return new SuccessDataResult<IEnumerable<ThesisModel>>(result);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<IEnumerable<ThesisModel>>(ex.Message);


            }

        }
    }
}
