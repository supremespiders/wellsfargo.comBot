using System.Collections.Generic;
using Newtonsoft.Json;

namespace wellsfargo.comBot.Models
{
    public class LinkResponse
    {
        public class CustomerViewsList
        {
            public bool selected { get; set; }
            public string url { get; set; }
            public string viewId { get; set; }
            public string viewName { get; set; }
            public string viewType { get; set; }
        }


        public class ViewInfo
        {
            public List<CustomerViewsList> customerViewsList { get; set; }
        }


        public class EDocsHomeModel
        {
            public ViewInfo viewInfo { get; set; }
        }

        public EDocsHomeModel eDocsHomeModel { get; set; }
    }
}