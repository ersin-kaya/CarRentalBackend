using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public static class GuidHelperManager
    {
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
