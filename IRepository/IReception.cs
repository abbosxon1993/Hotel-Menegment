using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
     public interface IReception
    {
        public  void AddPatient();

        public  void DeletePatient();

        public  ICollection<User> SearchPatient();

        public  void UpdatePatient();

        public  int NumberOfElements();

    }
}
