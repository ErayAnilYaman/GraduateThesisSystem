using BusinessCore.Abstract;
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
        public IEnumerable<Thesis> GetAll()
        {
            try
            {
                return _thesisDal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Thesis GetById(int id)
        {
            try
            {
                var thesis = _thesisDal.Get(T => T.ThesisID == id);
                if (thesis.GetType().Name.Equals("Data.Models.Thesis") && thesis != null)
                {
                    return (Thesis)thesis;

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
