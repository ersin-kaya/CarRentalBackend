using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file, string root);
        IDataResult<string> Update(IFormFile file, string root, string filePath);
        IResult Delete(string filePath);
    }
}
