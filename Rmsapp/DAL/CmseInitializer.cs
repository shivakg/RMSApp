using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Rmsapp.Models;

namespace Rmsapp.DAL
{
    public class CmseInitializer : DropCreateDatabaseIfModelChanges<CmseDBContext>
    {
        protected override void Seed(CmseDBContext context)
        {
            var cmses = new List<Cmse>
            {
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 123456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 124456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 133456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 143456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 133456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 133456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse { PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 133456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100},
                new Cmse {  PayDate = DateTime.Parse("2002-01-10"),   VoucherNo = 133456,  ChequeNo = "" ,CustomerNo = 123456,CustomerType="GOV",AccountNo= 345678,AccountName="Shiva",PayMode="GV",PayAmount= 100}
            };
            cmses.ForEach(s => context.Cmses.Add(s));
            context.SaveChanges();
        }
    }
}