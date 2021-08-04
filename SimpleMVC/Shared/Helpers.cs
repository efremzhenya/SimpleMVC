using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleMVC
{
    public static class HelperExtensions
    {
        public static bool IsValidPath(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            FileInfo fi;
            try
            {
                fi = new FileInfo(path);
            }
            catch
            { 
                return false;
            }

            return fi != null;
        }
    }
}