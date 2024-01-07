﻿
namespace BusinessCore.Abstract
{
    
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CoreLayer.Results;
    using Data.Models;
    using Data.Models.DTOs;
    #endregion
    public interface IThesisService
    {
        IDataResult<List<Thesis>> GetAll();
        IDataResult<Thesis> GetByNumber(int number);
        IDataResult<List<Thesis>> GetFilter(ThesisModel model);
        IDataResult<List<Thesis>> GetAllByUsername(string username);
        IResult Add(Thesis thesis);
        IResult Update(Thesis thesis);
        IResult Delete(int id);
        
    }
}
