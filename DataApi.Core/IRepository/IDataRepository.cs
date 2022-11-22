using DataApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.Core.IRepository
{
    public interface IDataRepository
    {
        void CreateDataEntry(StudentData studentdata);
        StudentData Detail(int studentid);
        StudentData Update(int studentid);
        void DeleteConform(int studentid);
        List<StudentData> Search(string search);
        List<StudentData> Read();
        List<Phone> Dropdown();
    }
}
