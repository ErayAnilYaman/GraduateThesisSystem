using BusinessCore.Abstract;
using CoreLayer.Results;
using Data.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Concrete
{
    public class ThesisModelManager : IThesisModelService
    {
        public IDataResult<IEnumerable<ThesisModel>> GetModel()
        {
			try
			{
				// dondurcek seyi bul.
				return new SuccessDataResult<IEnumerable<ThesisModel>>();
			}
			catch (Exception ex)
			{

				return new ErrorDataResult<IEnumerable<ThesisModel>>(ex.Message);
			}
        }
    }
}
