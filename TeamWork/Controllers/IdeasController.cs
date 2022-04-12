using Microsoft.AspNet.Identity;
using Ionic.Zip;
using TeamWork.Models;
using TeamWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using System.Web;
using PagedList;

namespace TeamWork.Controllers
{
    public class IdeasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {

            var ideas = db.Ideas.Include(i => i.Item);
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in db.Ideas
                         select l).OrderBy(x => x.Id);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        // GET: Comments/Create
        public ActionResult CreateComment()
        {

            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Comment comment, int? id)
        {
            var IdeaInDb = db.Ideas.SingleOrDefault(i => i.Id == id);
            var newComment = new Comment
            {
                Description = comment.Description,
                IdeaId = IdeaInDb.Id
            };
            if (ModelState.IsValid)
            {
                db.Comments.Add(newComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

         
            return View(comment);
        }
        // GET: Ideas
     

        // GET: Ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // GET: Ideas/Create
        [Authorize(Roles = "Staff")]
        public ActionResult Create(int? id)
        {
            var assignemntInDb = db.Items.SingleOrDefault(i => i.Id == id);

            ////////check validation: Deadline currentdate > EndDate
            //Find Enddate in currentDeadline
            int status = 1; // st=1 => can submit /// st=0 => can't submit
            /*  var endDateList = (from ass in db.Ideas
                                 where ass.Id == id
                                 join d in db.Items
                                 on ass.ItemId equals d.Id
                                 select d.EndDate).ToList();
              var endDate = endDateList[0];

              //check deadline
              if (DateTime.Now > endDate) //error
              {
                  status = 0;
              }
            */
            var newPostAssignmentViewModel = new PostAssignmentViewModel
            {
                Item = assignemntInDb,
                StatusPost = status
            };
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View(newPostAssignmentViewModel);
        }
        // POST: Ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId,Description,CreatedAt,File,UrlFile,NameOfFile")] HttpPostedFileBase file, Idea idea, Item item, int? id)

        {
            if (file == null)
            {
                return View("~/Views/ErrorValidations/Null.cshtml");
            }

            var validationExtension = System.IO.Path.GetExtension(file.FileName);
            if (validationExtension == ".jpg" || validationExtension == ".jpeg" || validationExtension == ".png" || validationExtension == ".doc" || validationExtension == ".docx" || validationExtension == ".pdf")
            {
                if (file != null && file.ContentLength > 0)
                {

                    var userName = User.Identity.GetUserName();
                    string prepend = userName;
                    //string converted = base64String.Replace('-', '+');
                    // converted = converted.Replace('_', '/');
                    idea.File = new byte[file.ContentLength]; // image stored in binary formate
                    file.InputStream.Read(idea.File, 0, file.ContentLength);
                    string fileName = prepend + System.IO.Path.GetFileName(file.FileName);
                    string urlImage = Server.MapPath("~/Files/" + fileName);
                    idea.NameOfFile = fileName;
                    file.SaveAs(urlImage);
                    idea.UrlFile = "Files/" + fileName;
                }

                var assignemntInDb = db.Items.SingleOrDefault(i => i.Id == id);

                /* var newPost = new Idea
                 {
                     NameOfFile = idea.NameOfFile,
                     ItemId = assignemntInDb.Id,
                     Description = idea.Description,

                     File = idea.File,
                     UrlFile = idea.UrlFile
                 };

                 if (newPost.Description == null || newPost.NameOfFile == null)
                 {
                     return View("~/Views/ErrorValidations/Null.cshtml");
                 }

                 var check = db.Ideas.Where(x => x.NameOfFile.Contains(newPost.NameOfFile)).FirstOrDefault();
                 if (check != null)
                 {
                     return View("~/Views/ErrorValidations/Null.cshtml");
                 }
                */
                if (file != null)
                {
                    idea.CreatedAt = DateTime.Now;
                    db.Ideas.Add(idea);
                    db.SaveChanges();
                    return RedirectToAction("SendEmailToUser", "Ideas");
                }

                ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", idea.ItemId);
                return View(idea);

            }
            else
            {
                return View("~/Views/ErrorValidations/Null.cshtml");
            }
        }

        // POST: Ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId,Description,CreatedAt,File,UrlFile,NameOfFile")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", idea.ItemId);
            return View(idea);
        }
        [Authorize(Roles = "Staff")]
        // GET: Ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idea idea = db.Ideas.Find(id);
            db.Ideas.Remove(idea);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Email
        public bool SendEmail(string toEmail, string emailSubject, string emailBody)
        {

            var senderEmail = ConfigurationManager.AppSettings["SenderEmail"].ToString();
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"].ToString();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

            MailMessage mailMessage = new MailMessage(senderEmail, toEmail, emailSubject, emailBody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;

            smtpClient.Send(mailMessage);

            return true;


        }

        public ActionResult SendEmailToUser()
        {
            bool result = false;

            var currentUser = User.Identity.GetUserId();
            var getUserName = User.Identity.GetUserName();

            result = SendEmail("huyhqgcd18671@fpt.edu.vn", "Notification Email", $"Staff: {getUserName} <br> Ideas:  <br> Already submit a post");


            Json(result, JsonRequestBehavior.AllowGet);
            return View();
        }

        //Download zip 
        //Coordinator & Marketing Manager
        
        [HttpGet]
        public ActionResult DownloadZip()
        {
            //get current user (coor / manager) 
            var currentUser = User.Identity.GetUserName();
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Files/"));
            List<DownloadZipViewmodel> fileViewmodels = new List<DownloadZipViewmodel>();
            foreach (string filePath in filePaths)
            {
                //Get filename
                string fileName = Path.GetFileName(filePath);
                //Split tail
                string[] splitTail = fileName.Split('.');
                //get file name without tail 
                string headfile = splitTail[0];
                //Get element
                string[] splitElement = headfile.Split('-');
                //Get student name 
                string studentName = splitElement[0];
             
                ////Get PostName////
                var postNameList = db.Ideas.Where(m => m.NameOfFile.Contains(fileName)).Select(m => m.Description).ToList();
               

   
                
                   
                        fileViewmodels.Add(new DownloadZipViewmodel()
                        {
                            /*FileName = Path.GetFileName(filePath),*/
                            FileName = Path.GetExtension(filePath),
                            FilePath = filePath,
    
                            StudentName = studentName,
                       
                        });
                    
                
            }
            return View(fileViewmodels);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DownloadZip(List<DownloadZipViewmodel> files)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                foreach (DownloadZipViewmodel file in files)
                {
                    if (file.IsSelected)
                    {
                        zip.AddFile(file.FilePath, "Files");
                    }
                }
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    return File(memoryStream.ToArray(), "application/zip", zipName);
                }
            }
        }

    }
}