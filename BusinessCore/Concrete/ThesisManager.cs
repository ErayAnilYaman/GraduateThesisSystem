﻿namespace BusinessCore.Concrete
{
    #region usings
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Filter;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Db;
    using Data.Models;
    using Data.Models.Abstract;
    using Data.Models.DTOs;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


    #endregion
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        private readonly IAuthorDal _authorDal;
        private readonly ISupervisorDal _supervisorDal;
        private readonly IInstituteDal _instituteDal;
        private readonly IUniversityDal _universityDal;

        public ThesisManager(IThesisDal thesisDal)
        {
            _thesisDal = thesisDal;
            
        }
        public IResult Add(Thesis thesis)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Thesis>> GetAll()
        {
            try
            {
                if (_thesisDal.GetAll() == null)
                {
                    return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAllOfModel(), ThesisMessages.ThesisNotFound);
                }
                return new SuccessDataResult<List<Thesis>>(_thesisDal.GetAllOfModel(), ThesisMessages.ThesesListed);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Thesis>>(ex.Message);
            }
        }

        public IDataResult<List<Thesis>> GetAllByUsername(string username)
        {
            var result = _thesisDal.GetAllByUsername(username);
            if (result != null)
            {
                return new SuccessDataResult<List<Thesis>>(result,Messages.Listed);
            }
            return new ErrorDataResult<List<Thesis>>(ThesisMessages.ThesisFound);
        }

        public IDataResult<Thesis> GetByNumber(int number)
        {
            try
            {
                var thesis = _thesisDal.GetAllOfModelByNumber(number)[0];
                if (thesis != null)
                {
                    return new SuccessDataResult<Thesis>(thesis, ThesisMessages.ThesisFound);

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

                var result = GetFiltered(model);
                return new SuccessDataResult<List<Thesis>>(result);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Thesis>>(ex.Message);
            }
        }
        public IResult Update(Thesis thesis)
        {
            throw new NotImplementedException();
        }

        private List<Thesis> GetFiltered(ThesisModel model)
        {
            Dictionary<string, object> nonNullPropertiesWithValues = GetProperties.GetNonNullProperties(model);
            List<Thesis> query = _thesisDal.GetAllOfModel();
            for (int i = 0; i < nonNullPropertiesWithValues.Count; i++)
            {
                var key = nonNullPropertiesWithValues.ElementAt(i).Key;
                object value = nonNullPropertiesWithValues.ElementAt(i).Value;
                if (typeof(Thesis).GetProperty(key) != null)
                {
                    var propertyInfo = typeof(Thesis).GetProperty(key)!;

                    if (!(key.Contains("ID") || key.Contains("YEAR")))
                    {
                        string stringValue = value.ToString()!;
                        query = query.Where(t => propertyInfo.GetValue(t)!.ToString()!.Contains(stringValue)).ToList();
                    }
                    else
                    {
                        int intValue = Convert.ToInt32(value);
                        query = query.Where(t => (int)propertyInfo!.GetValue(t)! == intValue).ToList();
                    }
                }
                else
                {
                    if (key == "AUTHORNAME")
                    {
                        query = query.Where(t => (t.AUTHOR.AUTHORNAME + t.AUTHOR.LASTNAME).Replace(" ","").
                        Contains(value.ToString()!.Replace(" ", ""))).ToList();
                    }
                    else
                    {
                        query = query.Where(t => (t.SUPERVISOR.FIRSTNAME + t.SUPERVISOR.LASTNAME).Replace(" ", "").
                        Contains(value.ToString()!.Replace(" ", ""))).ToList();
                    }
                }
            }
            return query;
        }
    }
}
