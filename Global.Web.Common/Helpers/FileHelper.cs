using System;
using System.IO;
using System.Web;

namespace Global.Web.Common.Helpers
{
    public static class FileHelper
    {
        public static FileSaveResult SaveFile(string title, HttpPostedFileBase file)
        {
            FileSaveResult result = new FileSaveResult();
            try
            {
                if (!string.IsNullOrWhiteSpace(title))
                {
                    result.Title = title;
                }
                else
                {
                    result.Title = Path.GetFileNameWithoutExtension(file.FileName);
                }
                string fileExt = Path.GetExtension(file.FileName);
                // Append current time as postfix to make unique file name 
                string titleSlug = string.Format("{0}-{1}", result.Title.ToSlug(), DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                string fileToSave = string.Format("{0}{1}{2}\\{3}\\{4}{5}", 
                    AppDomain.CurrentDomain.BaseDirectory, 
                    WebContext.Current.SiteOption.BaseDirectory, 
                    WebContext.Current.SiteOption.ImageServeRoot, 
                    titleSlug[0], 
                    titleSlug, 
                    fileExt);
                file.SaveAs(fileToSave);

                result.FileUri = string.Format("/{0}/{1}{2}", titleSlug[0], titleSlug, fileExt);
                result.IsSuccessful = true;
            }
            catch
            {
                result.IsSuccessful = false;
            }
            return result;
        }
    }
}