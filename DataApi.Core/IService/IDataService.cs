using DataApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.Core.IService
{
    public interface IDataService
    {
        void CreateDataEntry(StudentData studentdata);
        List<StudentData> Read();

        StudentData Update(int studentid);

        void DeleteConform(int studentid);

        List<StudentData> Search(string search);
        StudentData Detail(int studentid);
        List<Phone> Dropdown();
    }
}
