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
            public int CustomerQuantityOnHand { get; set; }

            [JsonProperty("customerQuantityOnOrder")]
            public int CustomerQuantityOnOrder { get; set; }

            [JsonProperty("customerQuantityUnavailable")]
            public int CustomerQuantityUnavailable { get; set; }

            [JsonProperty("customerNetAvailable")]
            public int CustomerNetAvailable { get; set; }

            [JsonProperty("distributorQuantityOnHand")]
            public int DistributorQuantityOnHand { get; set; }

            [JsonProperty("distributorQuantityOnOrder")]
            public int DistributorQuantityOnOrder { get; set; }

            [JsonProperty("distributorQuantityUnavailable")]
            public int DistributorQuantityUnavailable { get; set; }

            [JsonProperty("distributorNetAvailable")]
            public int DistributorNetAvailable { get; set; }

            [JsonProperty("totalQuantityOnHand")]
            public int TotalQuantityOnHand { get; set; }

            [JsonProperty("totalQuantityOnOrder")]
            public int TotalQuantityOnOrder { get; set; }

            [JsonProperty("totalQuantityUnavailable")]
            public int TotalQuantityUnavailable { get; set; }

            [JsonProperty("totalNetAvailable")]
            public int TotalNetAvailable { get; set; }

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
            public int lineno { get; set; }
            public int seqno { get; set; }
            public string fieldname { get; set; }
            public string fieldvalue { get; set; }
        }



    }
}
