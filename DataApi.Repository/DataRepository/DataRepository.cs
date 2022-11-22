using DataApi.Core.IRepository;
using DataApi.Core.Model;
using DataApi.Entity;
using DataApi.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace DataApi.Repository.DataRepository
{
    public class DataRepository : IDataRepository
    {
        //public tablesContext entity;
        private readonly tablesContext _tablecontext;
        public DataRepository(tablesContext tablecontext)
        {
            _tablecontext = tablecontext;
        }
        public void CreateDataEntry(StudentData studentdata)
        {
            if (studentdata != null)
            {
                if (studentdata.StudentId == 0)
                {
                    DataApi.Entity.Models.StudentDetails stud = new Entity.Models.StudentDetails();

                    stud.Name = studentdata.Name;
                    stud.Email = studentdata.Email;
                    stud.Address = studentdata.Address;
                    stud.PhoneNum = studentdata.PhoneNum;
                    stud.Password = studentdata.Password;
                    stud.ReTypePassword = studentdata.ReTypePassword;
                    stud.LocationId=studentdata.LocationId;
                    _tablecontext.StudentDetails.Add(stud);
                    _tablecontext.SaveChanges();
                }
                else
                {
                    var insert = _tablecontext.StudentDetails.Where(x => x.StudentId == studentdata.StudentId).SingleOrDefault();
                    if (insert != null)
                    {
                        insert.Name = studentdata.Name;
                        insert.Email = studentdata.Email;
                        insert.Address = studentdata.Address;
                        insert.PhoneNum = studentdata.PhoneNum;
                        insert.Password = studentdata.Password;
                        insert.ReTypePassword = studentdata.ReTypePassword;
                        insert.LocationId = studentdata.LocationId;
                        _tablecontext.SaveChanges();
                    }
                }
            }
        }
        public List<StudentData> Read()
        {
            {
                List<StudentData> model = new List<StudentData>();
                var data = _tablecontext.StudentDetails.Where(x => x.Is_deleted == false).ToList();
                foreach (var item in data)
                {
                    StudentData studentdetails = new StudentData();
                    studentdetails.StudentId = item.StudentId;
                    studentdetails.Name = item.Name;
                    studentdetails.Email = item.Email;
                    studentdetails.Address = item.Address;
                    studentdetails.PhoneNum = item.PhoneNum;
                    studentdetails.Password = item.Password;
                    var section = _tablecontext.PhoneDetail.Where(x => x.LocationId == item.LocationId).SingleOrDefault();
                    studentdetails.Location= section.Location;
                    studentdetails.ReTypePassword = item.ReTypePassword;
                    studentdetails.LocationId=item.LocationId;
                    model.Add(studentdetails);
                }
                return model;
            }
        }
        public StudentData Detail(int studentid)
        {
            {
              
                var data = _tablecontext.StudentDetails.Where(x => x.StudentId == studentid).SingleOrDefault();
                StudentData studentdetails = new StudentData();
                studentdetails.StudentId = data.StudentId;
                studentdetails.Name = data.Name;
                studentdetails.Email = data.Email;
                studentdetails.Address = data.Address;
                studentdetails.PhoneNum = data.PhoneNum;
                studentdetails.Password = data.Password;
                studentdetails.ReTypePassword = data.ReTypePassword;
                studentdetails.LocationId=data.LocationId;
                var section = _tablecontext.PhoneDetail.Where(x => x.LocationId == studentdetails.LocationId).SingleOrDefault();
                studentdetails.Location = section.Location;
                return studentdetails;
            }
        }
        public List<StudentData> Search(string search)
        {
            {
                List<StudentData> model = new List<StudentData>();
                var data = _tablecontext.StudentDetails.Where(x => x.Name.Contains(search)&& x.Is_deleted == false).ToList();
                foreach (var item in data)
                {
                     if (search!=" " && search!=null )
                    {
                        StudentData studentdetails = new StudentData();
                        studentdetails.StudentId = item.StudentId;
                        studentdetails.Name = item.Name;
                        studentdetails.Email = item.Email;
                        studentdetails.Address = item.Address;
                        studentdetails.PhoneNum = item.PhoneNum;
                        studentdetails.Password = item.Password;
                        studentdetails.ReTypePassword = item.ReTypePassword;
                        studentdetails.LocationId=item.LocationId;
                        model.Add(studentdetails);
                    }

                }
                return model;
            }
        }
        public StudentData Update(int studentid)
        {
            StudentData studentdata = new StudentData();
            var d = _tablecontext.StudentDetails.Where(x => x.StudentId == studentid&&x.Is_deleted==false).SingleOrDefault();
            studentdata.StudentId = d.StudentId;
            studentdata.Name = d.Name;
            studentdata.Email = d.Email;
            studentdata.Address = d.Address;
            studentdata.PhoneNum = d.PhoneNum;
            studentdata.Password = d.Password;
            studentdata.ReTypePassword = d.ReTypePassword;
            studentdata.LocationId = d.LocationId;
            var section = _tablecontext.PhoneDetail.Where(x => x.LocationId == studentdata.LocationId).SingleOrDefault();
            studentdata.Location = section.Location;
            return studentdata;
        }
        public void DeleteConform(int studentid)
        {
            var del = _tablecontext.StudentDetails.Where(x => x.StudentId == studentid).SingleOrDefault();
            if (del != null)
            {
                del.Is_deleted = true;
                _tablecontext.SaveChanges();
            } 

        }
        public List<Phone> Dropdown()
        {
            List<Phone> Local = new List<Phone>();
            var Block = _tablecontext.PhoneDetail.Where(x => !x.Is_deleted).ToList();
            if (Block != null && Block.Count > 0)
            {
                foreach (var item in Block)
                {
                    Phone location = new Phone();
                    location.LocationId = item.LocationId;
                    location.Location = item.Location;
                    Local.Add(location);
                }
            }
            return Local;

        }
    }
}
