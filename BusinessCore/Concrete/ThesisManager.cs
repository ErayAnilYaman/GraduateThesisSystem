
namespace BusinessCore.Concrete
{
    #region usings
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Filter;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Db;
    using Data.Models;
    using Data.Models.DTOs;
    using Microsoft.EntityFrameworkCore;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


    #endregion
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IThesisModelDal _thesisModelDal;

        public ThesisManager(IThesisDal thesisDal, IThesisModelDal thesisModelDal)
        {
            _thesisDal = thesisDal;
            _thesisModelDal = thesisModelDal;
        }
        public IDataResult<List<Thesis>> GetAll()
        {
            try
            {
                if (_thesisDal.GetAll() == null)
                {
                    return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll());
                }
                return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll() , ThesisMessages.ThesesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Thesis>>(ex.Message);
            }
        }

        public IDataResult<Thesis> GetByNumber(int number)
        {
            try
            {
                var thesis = _thesisDal.Get(T => T.NUMBER == number);
                if ( thesis != null)
                {
                    return new SuccessDataResult<Thesis>(thesis , ThesisMessages.ThesisFound);

                }
                return new ErrorDataResult<Thesis>(ThesisMessages.ThesisNotFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }

        public IDataResult<List<Thesis>> GetFilter(ThesisModel model)
        {
            try
            {
                //var result = model.GetType()
                //    .GetProperties()
                //    .Where(p => p.GetValue(model) != null).ToList();

                //Dictionary<string , object> nonNullPropertiesWithValues = GetProperties.GetNonNullProperties(model);
                //using (var db = new ThesesContext())
                //{
                //    IQueryable<Thesis> query = db.Set<Thesis>().AsQueryable();
                //    List<Thesis> result1;

                //    foreach (var item in nonNullPropertiesWithValues)
                //    {
                //        var key = item.Key;
                //        var value = item.Value;

                //        //if (typeof(Thesis).GetProperty(key) != null)
                //        //{
                //        //    query = query.Where(t => EF.Property<object>(t, key) == value);
                //        //}
                //        //result1 = db.Set<Thesis>().AsQueryable().Where(T => EF.Property<object>(T, key) == value).ToList();
                //    } 
                //    //var result = result1.ToList();
                //     //result = query.ToList();
                //    return new SuccessDataResult<List<Thesis>>(result1);

                //}
                return null;

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Thesis>>(ex.Message);

            }

        }
    }
}
