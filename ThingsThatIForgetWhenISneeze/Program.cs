using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsThatIForgetWhenISneeze.Application;
using ThingsThatIForgetWhenISneeze.Repository;

namespace ThingsThatIForgetWhenISneeze
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonManager jsonManager = new JsonManager();
            //Getting generic objects
            foreach(var v in jsonManager.DeserializedData)
            {
                //<condition>?<true>:<false>
                string sValue = v.Value != null ? v.Value.ToString() : "\"null\"";
                Console.WriteLine(v.Key + "is " + sValue);
            }
            Console.WriteLine("\nLet's access true object results:");
            //Now getting true objects
            foreach (var v in jsonManager.GetResults())
            {
                Console.WriteLine("\n\tresult Title:"+v.Title);
                Console.WriteLine("\tresult Url:" + v.Url);
            }

            Console.WriteLine("\nLet's create an object now and save it to a file");
            string fileName = "testFile";
            string fileExtension = "json";
            string folderName = @"Tests\fakes\";
            folderName = @"Tests";
            Console.WriteLine(string.Format(@"{0}\{1}.{2} created",folderName, fileName,fileExtension));
            BasicInfoRepository repo = new BasicInfoRepository();
            repo.CreateNewBasicInfo("John", "Connor");
            string inText = repo.GetAllBasicInfoSerialized();
            Console.WriteLine("inText will be:");
            Console.WriteLine(inText);
            FileManager fileManager = new FileManager(AppDomain.CurrentDomain.BaseDirectory);
            fileManager.WriteFile(fileName, fileExtension, inText, folderName);
            string outText = fileManager.ReadFile(fileName, fileExtension, folderName);
            Console.WriteLine("text retrieved from file is:");
            Console.WriteLine(outText);
            //To prevent de program from ending
            var k = Console.ReadKey();
        }
    }
}
