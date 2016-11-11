using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsThatIForgetWhenISneeze.Application
{
    public static class FileManager
    {
        public static string GetPath(string fileName, string fileExtension,string folderPath="")
        {
            string path = null;
            if(!string.IsNullOrWhiteSpace(fileName)&&!string.IsNullOrWhiteSpace(fileExtension))
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                
                if (fileExtension.Contains("."))
                {
                    fileExtension=fileExtension.Replace(".", "");
                }
                if(string.IsNullOrWhiteSpace(folderPath))
                {
                    folderPath = "";
                }
                else if(folderPath[folderPath.Length-1]!='\\')
                {
                    folderPath += @"\";
                    //this ensures directory creation
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                        
                    }
                }
                path = string.Format(@"{0}\{1}{2}.{3}", basePath , folderPath,fileName,fileExtension);
                /*
                 * on asp.net it would be
                 * path=HttpContext.Current.Server.MapPath("{0}{1}.{2}",folderPath,fileName,fileExtension);
                 */

                
                //this ensures file creation
                
                var fs = File.Open(path, FileMode.OpenOrCreate);
                fs.Close();
                
            }
            return path;
        }
        public static void WriteFile(string fileName, string fileExtension,string fileContent, string folderPath = "")
        {
            string path = GetPath(fileName, fileExtension, folderPath);
            if(path==null)
            {
                throw new InvalidOperationException("write file path was invalid");
            }
            
            File.WriteAllText(path, fileContent);
        }
        public static string ReadFile(string fileName, string fileExtension, string folderPath = "")
        {
            return File.ReadAllText(GetPath(fileName, fileExtension, folderPath));
        }
    }
}
