using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rmsapp.Models;
using PagedList;
using Rmsapp.DAL;
using Rmsapp.ViewModels;

namespace Rmsapp.Controllers
{
    public class CmsesController : Controller
    {
        private CmseDBContext db = new CmseDBContext();

        //
        // GET: /Cmses/
       

        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int ? page)
        {

            ViewBag.CurrentSort = sortOrder;
          ViewBag.PayDateSortParm = sortOrder == "PayDate" ? "PayDate desc" : "PayDate";
          ViewBag.VoucherNoSortParm = sortOrder == "VoucherNo" ? "VoucherNo desc" : "VoucherNo";
          ViewBag.ChequeNoSortParm = String.IsNullOrEmpty(sortOrder) ? "ChequeNo desc" : "ChequeNo";
          ViewBag.CustomerNoSortParm = sortOrder == "CustomerNo" ? "CustomerNo desc" : "CustomerNo";
          ViewBag.CustomerTypeSortParm = String.IsNullOrEmpty(sortOrder) ? "CustomerType desc" : "CustomerType";
          ViewBag.AccountNoSortParm = sortOrder == "AccountNo" ? "AccountNo desc" : "AccountNo";
          ViewBag.AccountNameSortParm = String.IsNullOrEmpty(sortOrder) ? "AccountName desc" : "AccountName";
          ViewBag.PayModeSortParm = String.IsNullOrEmpty(sortOrder) ? "PayMode desc" : "PayMode";
          ViewBag.PayAmountSortParm = sortOrder == "PayAmount" ? "PayAmount desc" : "PayAmount";

          if (Request.HttpMethod == "GET")
          {
              searchString = currentFilter;
          }
          else
          {
              page = 1;
          }

          ViewBag.CurrentFilter = searchString;


          
          var cmses = from s in db.Cmses
                         select s;

          if (!String.IsNullOrEmpty(searchString))
          {
              cmses = cmses.Where(s => s.AccountName.ToUpper().Contains(searchString.ToUpper())
                                        );
          }

          switch (sortOrder)
          {
              case "PayDate desc":
                  cmses = cmses.OrderByDescending(s => s.PayDate);
                  break;
              case "PayDate":
                  cmses = cmses.OrderBy(s => s.PayDate);
                  break;
              case "VoucherNo desc":
                  cmses = cmses.OrderByDescending(s => s.VoucherNo);
                  break;
              case "VoucherNo":
                  cmses = cmses.OrderBy(s => s.VoucherNo);
                  break;
              case "ChequeNo desc":
                  cmses = cmses.OrderByDescending(s => s.ChequeNo);
                  break;
              case "ChequeNo" :
                  cmses = cmses.OrderBy(s => s.ChequeNo);
                  break;
              case "CustomerNo desc":
                  cmses = cmses.OrderByDescending(s => s.CustomerNo);
                  break;
              case "CustomerNo":
                  cmses = cmses.OrderBy(s => s.CustomerNo);
                  break;
              case "CustomerType desc":
                  cmses = cmses.OrderByDescending(s => s.CustomerType);
                  break;
              case "CustomerType":
                  cmses = cmses.OrderBy(s => s.CustomerType);
                  break;
              case "AccountNo desc":
                  cmses = cmses.OrderByDescending(s => s.AccountNo);
                  break;
              case "AccountNo":
                  cmses = cmses.OrderBy(s => s.AccountNo);
                  break;
              case "AccountName desc":
                  cmses = cmses.OrderByDescending(s => s.AccountName);
                  break;
              case "AccountName":
                  cmses = cmses.OrderBy(s => s.AccountName);
                  break;
              case "PayMode desc":
                  cmses = cmses.OrderByDescending(s => s.PayMode);
                  break;
              case "PayMode":
                  cmses = cmses.OrderBy(s => s.PayMode);
                  break;
              case "PayAmount desc":
                  cmses = cmses.OrderByDescending(s => s.PayAmount);
                  break;
              case "PayAmount":
                  cmses = cmses.OrderBy(s => s.PayAmount);
                  break;
              default:
                  cmses = cmses.OrderBy(s => s.PayDate);
                 break;
           }
           
            //return View(db.Cmses.ToList());
          //return View(cmses.ToList());

          int pageSize = 3;
          int pageNumber = (page ?? 1);
          return View(cmses.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Cmses/Details/5

        public ActionResult Details(int id = 0)
        {

            try
            {
                Cmse cmse = db.Cmses.Find(id);
                if (cmse == null)
                {
                    return HttpNotFound();
                }
                return View(cmse);
            }
            catch (Exception ex) { throw ex; }
        }

        //
        // GET: /Cmses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cmses/Create

        [HttpPost]
        public ActionResult Create(Cmse cmse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Cmses.Add(cmse);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

               
            }
            catch (DataException) { 
           ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                            }
            return View(cmse);
        }

        //
        // GET: /Cmses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cmse cmse = db.Cmses.Find(id);
            if (cmse == null)
            {
                return HttpNotFound();
            }
            return View(cmse);
        }

        //
        // POST: /Cmses/Edit/5

        [HttpPost]
        public ActionResult Edit(Cmse cmse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(cmse).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (DataException) {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            
            }

            return View(cmse);
        }

        //
        // GET: /Cmses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cmse cmse = db.Cmses.Find(id);
            if (cmse == null)
            {
                return HttpNotFound();
            }
            return View(cmse);
        }

        //
        // POST: /Cmses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cmse cmse = db.Cmses.Find(id);
                db.Cmses.Remove(cmse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception Ex) { throw Ex; }
        }

        public ActionResult CmsDataReport()
        {
             var data = from cmse in db.Cmses
                       group cmse by cmse.VoucherNo into duplicateGroup
                       let cntr = duplicateGroup.Count()
                       orderby cntr
                       where cntr > 1
                        select new CmsDataSummary()
                        {
                            PayDate = duplicateGroup.FirstOrDefault().PayDate,
                            VoucherNumber = duplicateGroup.FirstOrDefault().VoucherNo,
                            ChequeNumber = duplicateGroup.FirstOrDefault().ChequeNo,
                            CustomerNumber = duplicateGroup.FirstOrDefault().CustomerNo,
                            CustomerType = duplicateGroup.FirstOrDefault().CustomerType,
                            AccountNumber  =duplicateGroup.FirstOrDefault().AccountNo,
                            AccountName = duplicateGroup.FirstOrDefault().AccountName,
                            PayMode = duplicateGroup.FirstOrDefault().PayMode,
                            PayAmount= duplicateGroup.FirstOrDefault().PayAmount,
                            DupCount = cntr
                        };
                     //  where dateGroup.Count() > 1
                       // select new CmsDataSummary()
                      // {
                        //   VoucherNo = dateGroup.Key,
                          //PayDate = dateGroup.PayDate,
                        //  VoucherCount = dateGroup.Count()
                       //};
            return View(data);
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}