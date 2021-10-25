using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrmIntractor.Modal
{
    public class LeadInfo
    {
        [JsonProperty("First Name")]
        public string FirstName { get; set; }
        [JsonProperty("Last Name")]
        public string LastName { get; set; }
        [JsonProperty("Topic")]
        public string Topic { get; set; }
        [JsonProperty("Job Title")]
        public string jobtitle { get; set; }
    }

}
