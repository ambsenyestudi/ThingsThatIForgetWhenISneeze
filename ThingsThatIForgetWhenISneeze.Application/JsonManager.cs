using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsThatIForgetWhenISneeze.Application.Entities;

namespace ThingsThatIForgetWhenISneeze.Application
{
    public class JsonManager
    {
        #region Fields
        private string _jsonSample = null;
        Dictionary<string, object> _responseObj;
        #endregion Fields
        #region Constructors
        public JsonManager()
        {
            initializeJson();
            cookJson();
        }
        #endregion Constructors
        #region PublicMethods
        public Dictionary<string, object> DeserializedData
        {
            get { return _responseObj; }
        }
        public List<ResultEntity> GetResults()
        {
            List<ResultEntity> result = new List<ResultEntity>();
            string resultsJson= _responseObj["responseData"].ToString();
            var res = JsonConvert.DeserializeObject<ResultsEntity>(resultsJson);
            if(res!=null)
            {
                result = res.Results;
            }
            return result;
        }
        #endregion PublicMethods
        #region PrivatecMethods
        private void cookJson()
        {
            _responseObj=JsonConvert.DeserializeObject<Dictionary<string, object>>(_jsonSample);
        }
        private void initializeJson()
        {
            using (StreamReader r = new StreamReader("./MockData/mock.json"))
            {
                _jsonSample = r.ReadToEnd();
            }
        }
        
        #endregion PrivatecMethods
    }
}
