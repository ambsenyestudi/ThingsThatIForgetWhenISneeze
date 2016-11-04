using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsThatIForgetWhenISneeze.Application;

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
            //To prevent de program from ending
            var k = Console.ReadKey();
        }
    }
}
