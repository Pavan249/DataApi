using DataApi.Core.IService;
using DataApi.Core.Model;
using DataApi.Entity;
using DataApi.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static DataApi.Services.Service.Services;

namespace DataApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private tablesContext _DbContext;

        private readonly IDataService _DataService;
        public StudentController(IDataService services)
        {
            _DataService = services;
        }
      
        [HttpGet]
        public IActionResult Create()
        {
            var value = _DataService.Dropdown();
            return Ok(value);
           
        }
        [HttpPost]
        public IActionResult Create(StudentData studentdata)
        {
            _DataService.CreateDataEntry(studentdata);
            return Ok();
        }

        [HttpGet]
        public ActionResult Read()
        {
            var r = _DataService.Read();
                return Ok(r);
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            var r = _DataService.Search(search);
            return Ok(r);
        }
        [HttpGet]
        public ActionResult Detail(int studentid)
        {
            var r = _DataService.Detail(studentid);
            return Ok(r);
        }

        [HttpGet]
        public IActionResult Update(int studentid)
        {
            var value = _DataService.Update(studentid);
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult Delete(int studentid)
        {
            _DataService.DeleteConform(studentid);
            return RedirectToAction("Read");
        }
       


    }
}
