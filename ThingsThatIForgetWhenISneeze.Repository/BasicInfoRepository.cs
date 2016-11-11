using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsThatIForgetWhenISneeze.Entities;

namespace ThingsThatIForgetWhenISneeze.Repository
{
    public class BasicInfoRepository
    {
        private List<BasicInfoEntity> _repoList;
        public BasicInfoRepository()
        {
            _repoList = new List<BasicInfoEntity>();
        }
        public void CreateNewBasicInfo(string name, string surname)
        {
            _repoList.Add(new BasicInfoEntity
            {
                Name=name,
                Surname=surname
            });
        }
        public string GetAllBasicInfoSerialized()
        {
            string result = null;
            result = Newtonsoft.Json.JsonConvert.SerializeObject(_repoList);
            return result;
        }
    }
}
