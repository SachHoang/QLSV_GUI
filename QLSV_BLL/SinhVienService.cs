using QLSV_DAL.Model1;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_BLL
{
    public class SinhVienService
    {
        public List<SinhVien1> GetAll()
        {
            QLSV_Model context = new QLSV_Model();
            return context.SinhVien1.ToList();
        }

        public SinhVien1 FindByID(string MaSV)
        {
            QLSV_Model context = new QLSV_Model();
            return context.SinhVien1.Where(p => p.MaSV == MaSV).FirstOrDefault();
        }
        public void Add(SinhVien1 s)
        {
            QLSV_Model context = new QLSV_Model();
            context.SinhVien1.AddOrUpdate(s);
            context.SaveChanges();
        }
        public void Save(SinhVien1 s1)
        {
            QLSV_Model context = new QLSV_Model();
            context.SaveChanges();
        }
        public void delete(string maso)
        {
            QLSV_Model context = new QLSV_Model();
            SinhVien1 s = context.SinhVien1.FirstOrDefault(p => p.MaSV == maso);
            if (s != null)
            {
                context.SinhVien1.Remove(s);
                context.SaveChanges();
            }

        }
    }
}
