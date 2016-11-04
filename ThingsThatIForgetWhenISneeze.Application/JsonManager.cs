using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsThatIForgetWhenISneeze.Application
{
    public class JsonManager
    {
        private string _jsonSample = null;
        public JsonManager()
        {
            initializeJson();
        }
        public void CookJson()
        {
            Dictionary<string, object> responseObj=JsonConvert.DeserializeObject<Dictionary<string,object>>(_jsonSample);
        }
        private void initializeJson()
        {
            _jsonSample = @"{
                ""responseData"": {
                    ""results"": [
                        {
                            ""GsearchResultClass"": ""GwebSearch"",
                            ""unescapedUrl"": ""http://en.wikipedia.org/wiki/Paris_Hilton"",
                            ""url"": ""http://en.wikipedia.org/wiki/Paris_Hilton"",
                            ""visibleUrl"": ""en.wikipedia.org"",
                            ""cacheUrl"": ""http://www.google.com/search?q=cache:TwrPfhd22hYJ:en.wikipedia.org"",
                            ""title"": ""Paris Hilton - Wikipedia, the free encyclopedia"",
                            ""titleNoFormatting"": ""Paris Hilton - Wikipedia, the free encyclopedia"",
                            ""content"": ""[1] In 2006, she released her debut album...""
                        },
                        {
                            ""GsearchResultClass"": ""GwebSearch"",
                            ""unescapedUrl"": ""http://www.imdb.com/name/nm0385296/"",
                            ""url"": ""http://www.imdb.com/name/nm0385296/"",
                            ""visibleUrl"": ""www.imdb.com"",
                            ""cacheUrl"": ""http://www.google.com/search?q=cache:1i34KkqnsooJ:www.imdb.com"",
                            ""title"": ""Paris Hilton"",
                            ""titleNoFormatting"": ""Paris Hilton"",
                            ""content"": ""Self: Zoolander. Socialite Paris Hilton...""
                        }
                    ],
                    ""cursor"": {
                        ""pages"": [
                            {
                            ""start"": ""0"",
                            ""label"": 1
                            },
                            {
                            ""start"": ""4"",
                            ""label"": 2
                            },
                            {
                            ""start"": ""8"",
                            ""label"": 3
                            },
                            {
                            ""start"": ""12"",
                            ""label"": 4
                            }
                        ],
                        ""estimatedResultCount"": ""59600000"",
                        ""currentPageIndex"": 0,
                        ""moreResultsUrl"": ""http://www.google.com/search?oe=utf8&ie=utf8...""
                    }
                },
                ""responseDetails"": null,
                ""responseStatus"": 200
            }";
        }
    }
}
