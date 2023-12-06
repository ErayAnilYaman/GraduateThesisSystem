using BusinessCore.Abstract;
using CoreLayer.Results;
using Data.Abstract;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Concrete
{
    public class ThesisManager : IThesisService
    {
        private readonly IThesisDal _thesisDal;
        public ThesisManager(IThesisDal thesisDal)
        {
            _thesisDal = thesisDal;
        }
        public IDataResult<IEnumerable<Thesis>> GetAll()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Thesis>>(_thesisDal.GetAll());
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
                var thesis = _thesisDal.Get(T => T.ThesisID == id);
                if (thesis.GetType().Name.Equals("Data.Models.Thesis") && thesis != null)
                {
                    return new SuccessDataResult<Thesis>(thesis , "Tez Bulundu");

                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }
    }
}
