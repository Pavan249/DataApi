using DataApi.Core.IRepository;
using DataApi.Core.IService;
using DataApi.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataApi.Services.Service
{
    public class Services
    {
        public class DataServices : IDataService
        {
            private readonly IDataRepository _dataRepository;
            public DataServices(IDataRepository dataRepository)
            {
                _dataRepository = dataRepository;
            }

            public void CreateDataEntry(StudentData studentdata)
            {
                //business condition
                if (studentdata.Name != string.Empty && studentdata.Name != string.Empty)
                {
                    _dataRepository.CreateDataEntry(studentdata);
                }
            }
            public List<StudentData> Read()
            {

                return _dataRepository.Read();
            }
            public StudentData Detail(int studentid)
            {

                return _dataRepository.Detail(studentid);
            }
            public List<StudentData> Search(string search)
            {

                return _dataRepository.Search(search);
            }
            public StudentData Update(int studentid)
            {
                return _dataRepository.Update(studentid);
            }
            public void DeleteConform(int studentid)
            {
                _dataRepository.DeleteConform(studentid);
            }
            public List<Phone> Dropdown()
            {
                return _dataRepository.Dropdown();  
            }

        }


    }


}
