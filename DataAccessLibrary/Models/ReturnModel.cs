using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ReturnModel
    {
        public string CustomerNumber { get; set; }

        public string UserID { get; set; }

        public string Cono { get; set; }

        public string Whse { get; set; }

        public string ReplenexNumber { get; set; }

        public int Qty { get; set; }

        public string UnitOfIssue { get; set; }

        public string ProductName { get; set; }

        public string SupplyProPrice { get; set; }

        public string ShipTo { get; set; }

        public int SupplyProQty { get; set; }

        public DateTime SupplyProQtyDate { get; set; }

        public int WhseQtyAvail { get; set; }

        public int ID { get; set; }

    }
}
