using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rmsapp.ViewModels
{
    public class CmsDataSummary
    {
       [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PayDate { get; set; }
        public int VoucherNumber { get; set; }
        public string ChequeNumber { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerType { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string PayMode { get; set; }
        public decimal PayAmount { get; set; }
        public int DupCount { get; set; }
        //public int VoucherCount { get; set; }

    }
}