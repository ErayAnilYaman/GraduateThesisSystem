
namespace BusinessCore.Concrete
{
   
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models;
    #endregion
    public class InstituteManager : IInstituteService
    {
        private IInstituteDal _instituteDal;

        public InstituteManager(IInstituteDal instituteDal)
        {
            _instituteDal = instituteDal;
        }
        public IResult Add(Institute institute)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Institute> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Institute>> List()
        {
            var result = _instituteDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Institute>>(result , Messages.Listed);

            }
            return new ErrorDataResult<List<Institute>>(Messages.ErrorEncountered);

        }

        public IResult Update(Institute institute)
        {
            throw new NotImplementedException();
        }
    }
}
