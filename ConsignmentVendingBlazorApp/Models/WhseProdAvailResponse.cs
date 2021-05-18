using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignmentVendingBlazorApp.Models
{
    public class WhseProdAvailResponse
    {

        public class Rootobject
        {
            [JsonProperty("response")]
            public Response Response { get; set; }
        }

        public class Response
        {
            [JsonProperty("cErrorMessage")]
            public string CErrorMessage { get; set; }

            [JsonProperty("crossReferenceProduct")]
            public string CrossReferenceProduct { get; set; }

            [JsonProperty("crossReferenceType")]
            public string CrossReferenceType { get; set; }

            [JsonProperty("returnUnitOfMeasure")]
            public string ReturnUnitOfMeasure { get; set; }

            [JsonProperty("customerQuantityOnHand")]
            public decimal CustomerQuantityOnHand { get; set; }

            [JsonProperty("customerQuantityOnOrder")]
            public decimal CustomerQuantityOnOrder { get; set; }

            [JsonProperty("customerQuantityUnavailable")]
            public decimal CustomerQuantityUnavailable { get; set; }

            [JsonProperty("customerNetAvailable")]
            public decimal CustomerNetAvailable { get; set; }

            [JsonProperty("distributorQuantityOnHand")]
            public decimal DistributorQuantityOnHand { get; set; }

            [JsonProperty("distributorQuantityOnOrder")]
            public decimal DistributorQuantityOnOrder { get; set; }

            [JsonProperty("distributorQuantityUnavailable")]
            public decimal DistributorQuantityUnavailable { get; set; }

            [JsonProperty("distributorNetAvailable")]
            public decimal DistributorNetAvailable { get; set; }

            [JsonProperty("totalQuantityOnHand")]
            public decimal TotalQuantityOnHand { get; set; }

            [JsonProperty("totalQuantityOnOrder")]
            public decimal TotalQuantityOnOrder { get; set; }

            [JsonProperty("totalQuantityUnavailable")]
            public decimal TotalQuantityUnavailable { get; set; }

            [JsonProperty("totalNetAvailable")]
            public decimal TotalNetAvailable { get; set; }

            [JsonProperty("customerOnlyFlag")]
            public bool CustomerOnlyFlag { get; set; }

            [JsonProperty("tUnavaildetail")]
            public Tunavaildetail TUnavaildetail { get; set; }

            [JsonProperty("tOutfieldvalue")]
            public Toutfieldvalue TOutfieldvalue { get; set; }
        }

        public class Tunavaildetail
        {
            public object[] tunavaildetail { get; set; }
        }

        public class Toutfieldvalue
        {
            public TOutfieldvalue[] toutfieldvalue { get; set; }
        }

        public class TOutfieldvalue
        {
            public string level { get; set; }
            public string lineno { get; set; }
            public string seqno { get; set; }
            public string fieldname { get; set; }
            public string fieldvalue { get; set; }
        }



    }
}
