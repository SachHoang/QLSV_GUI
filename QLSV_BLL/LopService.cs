using QLSV_DAL.Model1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_BLL
{
    public class LopService
    {
        public List<Lop> GetAll()  
        {
            QLSV_Model context = new QLSV_Model();
            return context.Lop.ToList();
        }
    }
}
