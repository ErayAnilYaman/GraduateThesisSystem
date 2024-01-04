﻿
namespace CoreLayer.Results
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }

    }
}
