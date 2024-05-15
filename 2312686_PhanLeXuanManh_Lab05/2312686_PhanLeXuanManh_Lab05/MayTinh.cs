using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab5
{
    public class MayTinh
    {
        #region Truong du lieu
        private List<IThietBi> dsThietBi;
        private string maso;
        private DateTime ngaysx;
        private string ten;
        #endregion 
        public string MaSo
        {
            get { return maso; }
            set { maso = value; }
        }

        public DateTime NgaySx
        {
            get { return ngaysx; }
            set { ngaysx = value; }
        }

        public int NamSX
        {
            get { return this.ngaysx.Year; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public int Gia
        {
            get { return this.TongGia(); }
        }

        public int GiaRam
        {
            get
            {
                int giaRam = 0;
                foreach (IThietBi tb in this.dsThietBi)
                {
                    if (tb is Ram)
                        giaRam += tb.Gia;
                }
                return giaRam;
            }
        }

        public int GiaCpu
        {
            get
            {
                int giaCpu = 0;
                foreach (IThietBi tb in this.dsThietBi)
                {
                    if (tb is CPU)
                        giaCpu += tb.Gia;
                }
                return giaCpu;
            }
        }

        public int SoThietBi
        {
            get { return this.dsThietBi.Count; }
        }

        public int SoRam
        {
            get { return this.dsThietBi.Count(tb => tb is Ram); }
        }

        public IThietBi this[int index]
        {
            get { return this.dsThietBi[index]; }
            set { this.dsThietBi[index] = value; }
        }

        public MayTinh()
        {
            this.dsThietBi = new List<IThietBi>();
        }

        public MayTinh(string ms, DateTime ngay, string t)
        {
            this.dsThietBi = new List<IThietBi>();
            this.MaSo = ms;
            this.ngaysx = ngay;
            this.Ten = t;
        }

        public MayTinh(string ms, DateTime ngay, string t, List<IThietBi> dstb)
        {
            this.dsThietBi = dstb;
            this.MaSo = ms;
            this.ngaysx = ngay;
            this.ten = t;
        }

        public void ThemTB(IThietBi tb)
        {
            this.dsThietBi.Add(tb);
        }

        public override string ToString()
        {
            string s = string.Format("\nMa so: {0} \nTen: {1} \nNgaySX: {2}",
                    this.MaSo, this.Ten, this.NgaySx.ToShortDateString());
            s += string.Format("\n-- Danh sach thiet bi (Tong so: {0}) ---------------", this.SoThietBi);
            foreach (var tb in this.dsThietBi)
                s += "\n" + tb.ToString();

            return s;
        }

        public int TongGia()
        {
            int s = 0;
            foreach (var tb in this.dsThietBi)
            {
                s += tb.Gia;
            }
            return s;
        }
    }
}
