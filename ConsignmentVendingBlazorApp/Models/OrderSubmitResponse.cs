using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsignmentVendingBlazorApp.Models
{
    public class OrderSubmitResponse
    {
        public class Rootobject
        {
            [JsonProperty("response")]
            public Response Response { get; set; }
        }

        public class Response
        {
            [JsonProperty("sxt_func_ack")]
            public Sxt_Func_Ack Sxt_func_ack { get; set; }
            [JsonProperty("sxapi_oehdr")]
            public Sxapi_Oehdr Sxapi_oehdr { get; set; }
            [JsonProperty("sxapi_oeitm")]
            public Sxapi_Oeitm Sxapi_oeitm { get; set; }
        }

        public class Sxt_Func_Ack
        {
            [JsonProperty("sxt_func_ack")]
            public Sxt_Func_Ack1[] Sxt_func_ack { get; set; }
        }

        public class Sxt_Func_Ack1
        {
            [JsonProperty("coNo")]
            public int CoNo { get; set; }
            [JsonProperty("correlation_data")]
            public string Correlation_data { get; set; }
            [JsonProperty("data1")]
            public string Data1 { get; set; }
            [JsonProperty("errorNo")]
            public int ErrorNo { get; set; }
            [JsonProperty("msg")]
            public string Msg { get; set; }
            [JsonProperty("seqNo")]
            public int SeqNo { get; set; }
            [JsonProperty("trxType")]
            public string TrxType { get; set; }
        }

        public class Sxapi_Oehdr
        {
            [JsonProperty("sxapi_oehdr")]
            public Sxapi_Oehdr1[] Sxapi_oehdr { get; set; }
        }

        public class Sxapi_Oehdr1
        {
            public string invoiceDt { get; set; }
            public string invNr { get; set; }
            public string invSuf { get; set; }
            public string custPo { get; set; }
            public string invType { get; set; }
            public string refer { get; set; }
            public string partnerId { get; set; }
            public string buyParty { get; set; }
            public string dept { get; set; }
            public string orderDisp { get; set; }
            public string _event { get; set; }
            public string vendNo2 { get; set; }
            public string cancelDt { get; set; }
            public string shipDt { get; set; }
            public string promiseDt { get; set; }
            public string reqShipDt { get; set; }
            public string shipVia { get; set; }
            public string poIssDt { get; set; }
            public string enterDt { get; set; }
            public string pkgId { get; set; }
            public string ackType { get; set; }
            public string currentDt { get; set; }
            public string user1 { get; set; }
            public string user2 { get; set; }
            public string user3 { get; set; }
            public string userInv { get; set; }
            public string transType { get; set; }
            public string shipInstr { get; set; }
            public string placedBy { get; set; }
            public string whse { get; set; }
            public string coreChg { get; set; }
            public string datcCost { get; set; }
            public string downPmt { get; set; }
            public string specDiscAmt { get; set; }
            public string restockAmt { get; set; }
            public string taxAmt { get; set; }
            public string gstTaxAmt { get; set; }
            public string pstTaxAmt { get; set; }
            public string woDiscAmt { get; set; }
            public string termsDiscAmt { get; set; }
            public string coNo { get; set; }
        }

        public class Sxapi_Oeitm
        {
            public Sxapi_Oeitm1[] sxapi_oeitm { get; set; }
        }

        public class Sxapi_Oeitm1
        {
            public string lineIden { get; set; }
            public string qtyUom { get; set; }
            public string prodSvcCd { get; set; }
            public string sellerProd { get; set; }
            public string buyerProd { get; set; }
            public string descrip { get; set; }
            public string user1 { get; set; }
            public string user2 { get; set; }
            public string user3 { get; set; }
            public string user4 { get; set; }
            public string user5 { get; set; }
            public string ordStatCd { get; set; }
            public string chgCd { get; set; }
            public string boType { get; set; }
            public string user6 { get; set; }
            public string user7 { get; set; }
            public string user8 { get; set; }
            public string user9 { get; set; }
            public string user10 { get; set; }
            public string specCostTy { get; set; }
            public string sCostUnit { get; set; }
            public string xrefProdTy { get; set; }
            public string taxableFl { get; set; }
            public string taxableTy { get; set; }
            public string taxGroup { get; set; }
            public string promiseDt { get; set; }
            public string reqShipDt { get; set; }
            public string specNsType { get; set; }
            public string upc { get; set; }
            public string sxLineNo { get; set; }
            public string qtyShip { get; set; }
            public string price { get; set; }
            public string discPct { get; set; }
            public string qtyOrd { get; set; }
            public string discAmt { get; set; }
            public string taxAmt1 { get; set; }
            public string taxAmt2 { get; set; }
            public string taxAmt3 { get; set; }
            public string taxAmt4 { get; set; }
            public string upcSection1 { get; set; }
            public string upcSection2 { get; set; }
            public string upcSection3 { get; set; }
            public string upcSection4 { get; set; }
            public string upcSection5 { get; set; }
            public string upcSection6 { get; set; }
            public string restockChg { get; set; }
            public string spCostUnit { get; set; }
        }

    }

}
