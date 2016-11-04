using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsThatIForgetWhenISneeze.Application.Entities
{
    public class ResultsEntity
    {

        [JsonProperty(PropertyName = "results")]
        public List<ResultEntity> Results { get; set; }


    }
}
