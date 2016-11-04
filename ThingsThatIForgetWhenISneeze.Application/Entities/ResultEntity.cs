using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsThatIForgetWhenISneeze.Application.Entities
{
    public class ResultEntity
    {

        [JsonProperty(PropertyName = "GsearchResultClass")]
        public string GsearchResultClass { get; set; }


        [JsonProperty(PropertyName = "unescapeUrl")]
        public string UnescapeUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        
        [JsonProperty(PropertyName = "visibleUrl")]
        public string VisibleUrl { get; set; }


        [JsonProperty(PropertyName = "cacheUrl")]
        public string CacheUrl { get; set; }


        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }


        [JsonProperty(PropertyName = "titleNoFormatting")]
        public string TitleNoFormatting { get; set; }


        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }




    }
}
