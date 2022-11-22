using DataApi.Core.IRepository;
using DataApi.Core.IService;
using DataApi.Core.Model;
using DataApi.Entity;
using DataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataModels.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Create");
                var Gettask = client.GetAsync(client.BaseAddress);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Phone>>();
                    readTask.Wait();
                    ViewBag.Location = readTask.Result;
                }


                return View();
            }
        }
        
        [HttpPost]
        public IActionResult Create(StudentData studentdata)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Create");
                var createtask = client.PostAsJsonAsync<StudentData>(client.BaseAddress, studentdata);
                createtask.Wait();
                var check = createtask.Result;
                if (check.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        [HttpGet]
        public ActionResult Read()
        {
            List<StudentData> studentdata = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Read");
                var Gettask = client.GetAsync(client.BaseAddress);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StudentData>>();
                    readTask.Wait();
                    studentdata = (List<StudentData>?)readTask.Result;
                }
                return View(studentdata);
            }
        }
     
        public ActionResult Search(string  search)
        {
            List<StudentData> studentdata = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Search?search=");
                var Gettask = client.GetAsync(client.BaseAddress + search);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<StudentData>>();
                    readTask.Wait();
                    studentdata = (List<StudentData>?)readTask.Result;
                }
                return View("Read",studentdata);
            }
        }

        public IActionResult Detail(int studentid)
        {
            StudentData studentdata = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Detail?studentid=");
                var responseTask = client.GetAsync(client.BaseAddress + studentid.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<StudentData>();
                    readTask.Wait();
                    studentdata = readTask.Result;
                }
            }
            return PartialView(studentdata);
        }
      

        [HttpGet]
        public IActionResult Update(int studentid)
        {
            Create();
            StudentData studentdata=null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Update?studentid=");
                var responseTask = client.GetAsync(client.BaseAddress + studentid.ToString());
                responseTask.Wait();
                 var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<StudentData>();
                    readTask.Wait();
                    studentdata = readTask.Result;
                }
            }
            return View("Create",studentdata);
        }
        public IActionResult Delete(int studentid)
        {
            using (var client = new HttpClient())
            {
           
                client.BaseAddress = new Uri("https://localhost:7224/api/Student/Delete?studentid=");  
                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + studentid.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}