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
            [JsonProperty("invoiceDt")]
            public string InvoiceDt { get; set; }
            [JsonProperty("invNr")]
            public string InvNr { get; set; }
            [JsonProperty("invSuf")]
            public string InvSuf { get; set; }
            [JsonProperty("custPo")]
            public string CustPo { get; set; }
            [JsonProperty("invType")]
            public string InvType { get; set; }
            [JsonProperty("refer")]
            public string Refer { get; set; }
            [JsonProperty("partnerId")]
            public string PartnerId { get; set; }
            [JsonProperty("buyParty")]
            public string BuyParty { get; set; }
            [JsonProperty("dept")]
            public string Dept { get; set; }
            [JsonProperty("orderDisp")]
            public string OrderDisp { get; set; }
            [JsonProperty("_event")]
            public string Event { get; set; }
            [JsonProperty("vendNo2")]
            public string VendNo2 { get; set; }
            [JsonProperty("cancelDt")]
            public string CancelDt { get; set; }
            [JsonProperty("shipDt")]
            public string ShipDt { get; set; }
            [JsonProperty("promiseDt")]
            public string PromiseDt { get; set; }
            [JsonProperty("reqShipDt")]
            public string ReqShipDt { get; set; }
            [JsonProperty("shipVia")]
            public string ShipVia { get; set; }
            [JsonProperty("poIssDt")]
            public string PoIssDt { get; set; }
            [JsonProperty("enterDt")]
            public string EnterDt { get; set; }
            [JsonProperty("pkgId")]
            public string PkgId { get; set; }
            [JsonProperty("ackType")]
            public string AckType { get; set; }
            [JsonProperty("currentDt")]
            public string CurrentDt { get; set; }
            [JsonProperty("user1")]
            public string User1 { get; set; }
            [JsonProperty("user2")]
            public string User2 { get; set; }
            [JsonProperty("user3")]
            public string User3 { get; set; }
            [JsonProperty("userInv")]
            public string UserInv { get; set; }
            [JsonProperty("transType")]
            public string TransType { get; set; }
            [JsonProperty("shipInstr")]
            public string ShipInstr { get; set; }
            [JsonProperty("placedBy")]
            public string PlacedBy { get; set; }
            [JsonProperty("whse")]
            public string Whse { get; set; }
            [JsonProperty("coreChg")]
            public string CoreChg { get; set; }
            [JsonProperty("datcCost")]
            public string DatcCost { get; set; }
            [JsonProperty("downPmt")]
            public string DownPmt { get; set; }
            [JsonProperty("specDiscAmt")]
            public string SpecDiscAmt { get; set; }
            [JsonProperty("restockAmt")]
            public string RestockAmt { get; set; }
            [JsonProperty("taxAmt")]
            public string TaxAmt { get; set; }
            [JsonProperty("gstTaxAmt")]
            public string GstTaxAmt { get; set; }
            [JsonProperty("pstTaxAmt")]
            public string PstTaxAmt { get; set; }
            [JsonProperty("woDiscAmt")]
            public string WoDiscAmt { get; set; }
            [JsonProperty("termsDiscAmt")]
            public string TermsDiscAmt { get; set; }
            [JsonProperty("coNo")]
            public string CoNo { get; set; }
        }

        public class Sxapi_Oeitm
        {
            public Sxapi_Oeitm1[] Sxapi_oeitm { get; set; }
        }

        public class Sxapi_Oeitm1
        {
            [JsonProperty("lineIden")]
            public string LineIden { get; set; }
            [JsonProperty("qtyUom")]
            public string QtyUom { get; set; }
            [JsonProperty("prodSvcCd")]
            public string ProdSvcCd { get; set; }
            [JsonProperty("sellerProd")]
            public string SellerProd { get; set; }
            [JsonProperty("buyerProd")]
            public string BuyerProd { get; set; }
            [JsonProperty("descrip")]
            public string Descrip { get; set; }
            [JsonProperty("user1")]
            public string User1 { get; set; }
            [JsonProperty("user2")]
            public string User2 { get; set; }
            [JsonProperty("user3")]
            public string User3 { get; set; }
            [JsonProperty("user4")]
            public string User4 { get; set; }
            [JsonProperty("user5")]
            public string User5 { get; set; }
            [JsonProperty("ordStatCd")]
            public string OrdStatCd { get; set; }
            [JsonProperty("chgCd")]
            public string ChgCd { get; set; }
            [JsonProperty("boType")]
            public string BoType { get; set; }
            [JsonProperty("user6")]
            public string User6 { get; set; }
            [JsonProperty("user7")]
            public string User7 { get; set; }
            [JsonProperty("user8")]
            public string User8 { get; set; }
            [JsonProperty("user9")]
            public string User9 { get; set; }
            [JsonProperty("user10")]
            public string User10 { get; set; }
            [JsonProperty("specCostTy")]
            public string SpecCostTy { get; set; }
            [JsonProperty("sCostUnit")]
            public string SCostUnit { get; set; }
            [JsonProperty("xrefProdTy")]
            public string XrefProdTy { get; set; }
            [JsonProperty("taxableFl")]
            public string TaxableFl { get; set; }
            [JsonProperty("taxableTy")]
            public string TaxableTy { get; set; }
            [JsonProperty("taxGroup")]
            public string TaxGroup { get; set; }
            [JsonProperty("promiseDt")]
            public string PromiseDt { get; set; }
            [JsonProperty("reqShipDt")]
            public string ReqShipDt { get; set; }
            [JsonProperty("specNsType")]
            public string SpecNsType { get; set; }
            [JsonProperty("upc")]
            public string Upc { get; set; }
            [JsonProperty("sxLineNo")]
            public string SxLineNo { get; set; }
            [JsonProperty("qtyShip")]
            public string QtyShip { get; set; }
            [JsonProperty("price")]
            public string Price { get; set; }
            [JsonProperty("discPct")]
            public string DiscPct { get; set; }
            [JsonProperty("qtyOrd")]
            public string QtyOrd { get; set; }
            [JsonProperty("discAmt")]
            public string DiscAmt { get; set; }
            [JsonProperty("taxAmt1")]
            public string TaxAmt1 { get; set; }
            [JsonProperty("taxAmt2")]
            public string TaxAmt2 { get; set; }
            [JsonProperty("taxAmt3")]
            public string TaxAmt3 { get; set; }
            [JsonProperty("taxAmt4")]
            public string TaxAmt4 { get; set; }
            [JsonProperty("upcSection1")]
            public string UpcSection1 { get; set; }
            [JsonProperty("upcSection2")]
            public string UpcSection2 { get; set; }
            [JsonProperty("upcSection3")]
            public string UpcSection3 { get; set; }
            [JsonProperty("upcSection4")]
            public string UpcSection4 { get; set; }
            [JsonProperty("upcSection5")]
            public string UpcSection5 { get; set; }
            [JsonProperty("upcSection6")]
            public string UpcSection6 { get; set; }
            [JsonProperty("restockChg")]
            public string RestockChg { get; set; }
            [JsonProperty("spCostUnit")]
            public string SpCostUnit { get; set; }
        }

    }

}
