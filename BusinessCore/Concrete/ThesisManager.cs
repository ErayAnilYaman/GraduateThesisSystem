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
                    return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAll() , ThesisMessages.ThesisNotFound);
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

                using (var db = new ThesesContext())
                {
                    Dictionary<string, object> nonNullPropertiesWithValues = GetProperties.GetNonNullProperties(model!);
                    List<Thesis> query = _thesisDal.GetAll();
                    for (int i = 0; i < nonNullPropertiesWithValues.Count; i++)
                    {
                        var key = nonNullPropertiesWithValues.ElementAt(i).Key;
                        object value = nonNullPropertiesWithValues.ElementAt(i).Value;
                        if (typeof(Thesis).GetProperty(key) != null)
                        {
                            var propertyInfo = typeof(Thesis).GetProperty(key);
                            var propertyType = propertyInfo.PropertyType;

                            if (!(key.Contains("ID") || key.Contains("YEAR")))
                            {
                                string stringValue = value.ToString();
                                query = query.Where(t => propertyInfo.GetValue(t).ToString().Contains(stringValue)).ToList();
                            }
                            else
                            {
                                int intValue = Convert.ToInt32(value);
                                query = query.Where(t => (int)propertyInfo.GetValue(t) == intValue).ToList();
                            }
                        }
                        
                    }
                    //var result = result1.ToList();
                    //result = query.ToList();
                    return new SuccessDataResult<List<Thesis>>(query);
                }

            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Thesis>>(ex.Message);

            }

        }
    }
}
