using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ME.Core2.Entities
{
        [DataContract]
        [Serializable]
        public class CustomerRequest
        {
            [DataMember]
            [Required]
            public string customerId { get; set; }
            [DataMember]
            [Required]
            public double initialCredit { get; set; }

            public static CustomerRequest FromJson(string json) => JsonConvert.DeserializeObject<CustomerRequest>(json, CustomerRequestConverter.Settings);

    }

        internal static class CustomerRequestConverter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    new IsoDateTimeConverter{ DateTimeStyles = DateTimeStyles.AssumeUniversal}
                },
            };
        }

        [DataContract]
        [Serializable]
        public class CustomerInfo
        {
            [DataMember]
            [Required]
            // this is the customerId by definition
            public string id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            [Required]
            public string surname { get; set; }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }
}
