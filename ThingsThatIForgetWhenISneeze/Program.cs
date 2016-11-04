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
            foreach(var v in jsonManager.DeserializedData)
            {
                //<condition>?<true>:<false>
                string sValue = v.Value != null ? v.Value.ToString() : "\"null\"";
                Console.WriteLine(v.Key + "is " + sValue);
            }
            //To prevent de program from ending
            var k = Console.ReadKey();
        }
    }
}
