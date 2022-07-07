using Core.Constants;
using Core.Utilities.Helpers.GuidHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public IDataResult<string> Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string fileExtension = Path.GetExtension(file.FileName);
                string guid = GuidHelperManager.GetNewGuid();
                string filePath = guid + fileExtension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return new SuccessDataResult<string>(data: filePath);
                }
            }
            return new ErrorDataResult<string>(data: null);
        }

        public IDataResult<string> Update(IFormFile file, string root, string filePath)
        {
            Delete(filePath);
            return new SuccessDataResult<string>(data: Upload(file, root).Data);
        }

        public IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult(Messages.FileDeleted);
            }
            return new ErrorResult(Messages.FileNotFound);
        }
    }
}
