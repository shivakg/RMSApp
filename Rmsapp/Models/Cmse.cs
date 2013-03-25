using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Rmsapp.Models
{
    public class Cmse
    {
        public int ID
        {
            get;
            set;
        }
         
        public DateTime PayDate
        {
            get;
            set;
        }
        public int VoucherNo
        {
            get;
            set;
        }
        public string ChequeNo
        {
            get;
            set;
        }
        public int CustomerNo
        {
            get;
            set;
        }
        public string CustomerType
        {
            get;
            set;
        }
        public int AccountNo
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public string PayMode
        {
            get;
            set;
        }
        public decimal PayAmount
        {
            get;
            set;
        }


    }
   
}