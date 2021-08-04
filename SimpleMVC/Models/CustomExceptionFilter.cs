using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVC.Models
{
    public class CustomExceptionFilter: FilterAttribute, IExceptionFilter
    {
        private string LogPath => ConfigurationManager.AppSettings["LogPath"].ToString().Trim();

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.HttpContext.Response.StatusCode != 404 
                && LogPath.IsValidPath())
            {
                try
                {
                    File.AppendAllLines(LogPath, new string[]
                    { 
                        $"[{DateTime.Now:G}] {filterContext.Exception.Message}"
                    });
                }
                catch
                { }
            }
            //TODO: create custom error page and set filterContext.ExceptionHandled = true;
        }

        
    }
}