using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab5
{
    public class QuanLyMayTinh
    {
        List<MayTinh> dsMayTinh = new List<MayTinh>();

        public int Count
        {
            get { return this.dsMayTinh.Count; }
        }

        public int Gia()
        {
            int tongGiaDs = 0;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                tongGiaDs += mt.TongGia();
            }
            return tongGiaDs;
        }

        public MayTinh this[int index]
        {
            get { return dsMayTinh[index]; }
            set { dsMayTinh[index] = value; }
        }

        public QuanLyMayTinh()
        {
            List<MayTinh> ds = new List<MayTinh>();
        }

        public void Them(MayTinh mt)
        {
            this.dsMayTinh.Add(mt);
        }

        public MayTinh KiemTraMaSo(string ms)
        {
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.MaSo.CompareTo(ms) == 0)
                    return mt;
            }
            return null;
        }

        public void NhapCD()
        {
            MayTinh mt = new MayTinh("157", new DateTime(2020, 10, 13), "Sony");
            mt.ThemTB(new CPU(3.0f, 10000));
            mt.ThemTB(new Ram(32, 3000));
            Them(mt);

            mt = new MayTinh("116", new DateTime(2020, 6, 11), "Dell");
            mt.ThemTB(new CPU(3.0f, 18000));
            mt.ThemTB(new Ram(256, 20000));
            mt.ThemTB(new Ram(128, 10000));
            Them(mt);

            mt = new MayTinh("804", new DateTime(2021, 10, 5), "HP");
            mt.ThemTB(new CPU(3.5f, 20000));
            mt.ThemTB(new CPU(5.0f, 50000));
            mt.ThemTB(new Ram(32, 3000));
            mt.ThemTB(new Ram(128, 10000));
            mt.ThemTB(new Ram(32, 5000));
            Them(mt);
        }

        public void NhapTuFile()
        {

            using (StreamReader sr = new StreamReader("dsMayTinh.txt"))
            {
                MayTinh mt = null;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('*');
                    if (data[0] == "MT")
                    {
                        mt = new MayTinh(data[1], DateTime.ParseExact(data[3], "MM/dd/yyyy", null), data[2]);
                        this.dsMayTinh.Add(mt);
                    }
                    else if (data[0] == "CPU" && mt != null)
                    {
                        mt.ThemTB(new CPU(float.Parse(data[1]), int.Parse(data[2])));
                    }
                    else if (data[0] == "RAM" && mt != null)
                    {
                        mt.ThemTB(new Ram(float.Parse(data[1]), int.Parse(data[2])));
                    }
                }
            }
        }

        private int GiaMax()
        {
            int gia_max = this.dsMayTinh[0].Gia;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.Gia > gia_max)
                {
                    gia_max = mt.Gia;
                }
            }
            return gia_max;
        }

        public QuanLyMayTinh MayTinhGiaLonNhat()
        {
            QuanLyMayTinh dskq = new QuanLyMayTinh();
            int max = this.GiaMax();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.Gia == max)
                    dskq.Them(mt);
            }
            return dskq;
        }

        public QuanLyMayTinh MayTinhCo2Ram()
        {
            QuanLyMayTinh dskq = new QuanLyMayTinh();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.SoRam == 2)
                    dskq.Them(mt);
            }
            return dskq;
        }

        public QuanLyMayTinh HienThiTheoGia(int min, int max)
        {
            QuanLyMayTinh dskq = new QuanLyMayTinh();
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.Gia >= min && mt.Gia <= max)
                    dskq.Them(mt);
            return dskq;
        }
        public int TongGiaMayTinh()
        {
            int tong_gia = 0;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                tong_gia += mt.Gia;
            }
            return tong_gia;
        }

        public void SapXepGiamTheoTen()
        {
            for (int i = 0; i < this.dsMayTinh.Count - 1; i++)
            {
                for (int j = i + 1; j < this.dsMayTinh.Count; j++)
                {
                    if (this.dsMayTinh[i].Ten.CompareTo(this.dsMayTinh[j].Ten) < 0)
                    {
                        MayTinh temp = this.dsMayTinh[i];
                        this.dsMayTinh[i] = this.dsMayTinh[j];
                        this.dsMayTinh[j] = temp;
                    }
                }
            }
        }

        public void SapXepTangTheoSoLuongThietBi()
        {
            this.dsMayTinh = this.dsMayTinh.OrderBy(mt => mt.SoThietBi).ToList();
        }
        
        private int giaRamMin()
        {
            int giaRamMin = this.dsMayTinh[0].GiaRam;
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaRam < giaRamMin)
                    giaRamMin = mt.GiaRam;
            return giaRamMin;
        }

        private int giaRamMax()
        {
            int giaRamMax = this.dsMayTinh[0].GiaRam;
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaRam > giaRamMax)
                    giaRamMax = mt.GiaRam;
            return giaRamMax;
        }

        public void RamMinMax()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sach may tinh co gia ram thap nhat: ");
            Console.ResetColor();
            foreach (MayTinh mt in this.dsMayTinh)
                if(mt.GiaRam == this.giaRamMin()) 
                {
                    Console.WriteLine(mt.ToString());
                }
            Console.WriteLine(new string('-', 60));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sach may tinh co gia ram cao nhat: ");
            Console.ResetColor();
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaRam == this.giaRamMax())
                {
                    Console.WriteLine(mt.ToString());
                }
        }

        private int giaCpuMin()
        {
            int giaCpuMin = this.dsMayTinh[0].GiaCpu;
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaCpu < giaCpuMin)
                    giaCpuMin = mt.GiaRam;
            return giaCpuMin;
        }

        private int giaCpuMax()
        {
            int giaCpuMax = this.dsMayTinh[0].GiaCpu;
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaCpu > giaCpuMax)
                    giaCpuMax = mt.GiaCpu;
            return giaCpuMax;
        }

        public void CpuMinMax()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sach may tinh co gia CPU thap nhat: ");
            Console.ResetColor();
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaCpu == this.giaCpuMin())
                {
                    Console.WriteLine(mt.ToString());
                }
            Console.WriteLine(new string('-', 60));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sach may tinh co gia CPU cao nhat: ");
            Console.ResetColor();
            foreach (MayTinh mt in this.dsMayTinh)
                if (mt.GiaCpu == this.giaCpuMax())
                {
                    Console.WriteLine(mt.ToString());
                }
        }

        private int LinhKienMax()
        {
            int so_linh_kien_max = this.dsMayTinh[0].SoThietBi;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.SoThietBi > so_linh_kien_max)
                    so_linh_kien_max = mt.SoThietBi;
            }
            return so_linh_kien_max;
        }

        private int LinhKienMin()
        {
            int so_linh_kien_min = this.dsMayTinh[0].SoThietBi;
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.SoThietBi < so_linh_kien_min)
                    so_linh_kien_min = mt.SoThietBi;
            }
            return so_linh_kien_min;
        }

        public QuanLyMayTinh MayTinhNhieuLinhKienNhat()
        {
            QuanLyMayTinh dskq = new QuanLyMayTinh();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (mt.SoThietBi == this.LinhKienMax())
                    dskq.Them(mt);
            }
            return dskq;
        }

        public void XoaTatCaMayTinhSanXuatTruocNamX(int x)
        {
            for (int i = 0; i < this.dsMayTinh.Count; i++)
            {
                if (this.dsMayTinh[i].NamSX < x)
                {
                    this.dsMayTinh.RemoveAt(i);
                    i--;
                }
            }
        }

        public void SapXepTangTheoRam()
        {
            for (int i = 0; i < this.dsMayTinh.Count - 1; i++)
                for (int j = i + 1; j < this.dsMayTinh.Count; j++)
                {
                    if (this.dsMayTinh[i].SoRam > this.dsMayTinh[j].SoRam ||
                        this.dsMayTinh[i].SoRam == this.dsMayTinh[j].SoRam && this.dsMayTinh[i].Gia > this.dsMayTinh[j].Gia)
                    {
                        MayTinh temp = this.dsMayTinh[i];
                        this.dsMayTinh[i] = this.dsMayTinh[j];
                        this.dsMayTinh[j] = temp;
                    }
                }
        }

        public void ChenMayTinh(int index, MayTinh mt)
        {
            this.dsMayTinh.Insert(index - 1, mt);
        }

        public void SuaThongTinMayTinh(MayTinh mt)
        {
            Console.WriteLine("Chon thong tin can sua\n0. Thoat\n1. Ten\n2. Ngay san xuat");
            Console.WriteLine(new string('-', 40));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nhap 1 so de chon chuc nang: ");
            Console.ResetColor();
            int chon = int.Parse(Console.ReadLine());
            switch(chon)
            {
                case 0:
                    Console.WriteLine("Nhan phim bat ki de tiep tuc!");
                    break;
                case 1:
                    Console.Write("Nhap ten moi: ");
                    mt.Ten = Console.ReadLine();
                    Console.WriteLine("Da cap nhat ten moi!");
                    break;
                case 2:
                    Console.Write("Nhap ngay sx moi: ");
                    DateTime newdate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    mt.NgaySx = newdate;
                    Console.WriteLine("Da cap nhat ngay san xuat!");
                    break;
            }    
        }

        public void ThongKeTheoTen()
        {
            Dictionary<string, List<MayTinh>> dsMayTinhTheoTen = new Dictionary<string, List<MayTinh>>();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (!dsMayTinhTheoTen.ContainsKey(mt.Ten))
                {
                    dsMayTinhTheoTen[mt.Ten] = new List<MayTinh>();
                }
                dsMayTinhTheoTen[mt.Ten].Add(mt);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thong ke may tinh theo ten\n");
            Console.ResetColor();
            Console.WriteLine("{0, -10}|{1, -10}|{2, -10}", "Ten", "So luong", "Ty le (%)");
            Console.WriteLine(new string('=', 32));
            foreach (var pair in dsMayTinhTheoTen)
            {
                float tyLe = (float)pair.Value.Count / this.dsMayTinh.Count * 100;
                Console.WriteLine("{0, -10}|{1, 10}|{2, 10}", pair.Key, pair.Value.Count, tyLe);
            }
        }

        public void ThongKeTheoNamSanXuat()
        {
            Dictionary<int, List<MayTinh>> dsMayTinhTheoNamSx = new Dictionary<int, List<MayTinh>>();
            foreach (MayTinh mt in this.dsMayTinh)
            {
                if (!dsMayTinhTheoNamSx.ContainsKey(mt.NamSX))
                {
                    dsMayTinhTheoNamSx[mt.NamSX] = new List<MayTinh>();
                }
                dsMayTinhTheoNamSx[mt.NamSX].Add(mt);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thong ke may tinh theo nam san xuat\n");
            Console.ResetColor();
            Console.WriteLine("{0, -10}|{1, -10}|{2, -10}|{3, -17}", "Nam SX", "So luong", "Tong gia", "Ty le tong gia(%)");
            Console.WriteLine(new string('=',50));
            foreach (var pair in dsMayTinhTheoNamSx)
            {
                int tongGia = 0;
                
                foreach (var mt in pair.Value)
                {
                    tongGia += mt.TongGia();
                }
                float tyLeTongGia = (float)Math.Round(((float)tongGia / this.Gia() * 100.0), 2);
                Console.WriteLine("{0, -10}|{1, 10}|{2, 10}|{3, 17}", pair.Key, pair.Value.Count, tongGia, tyLeTongGia);
            }
        }

        public void XoaMayTinhCoSoLinhKienItNhat()
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dsMayTinh[i].SoThietBi == this.LinhKienMin())
                    this.dsMayTinh.Remove(this.dsMayTinh[i]);
            }
        }

        public override string ToString()
        {
            string s = "Danh sach may tinh:\n";

            foreach (var mt in this.dsMayTinh)
                s += mt;
            return s;
        }

        public void XuatDanhSach()
        {
            Console.WriteLine(new String('=', 50));
            for (int i = 0; i < this.dsMayTinh.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("May Tinh {0}", i + 1);
                Console.ResetColor();
                Console.WriteLine("\tGia: {0} VND", this.dsMayTinh[i].Gia);
                Console.WriteLine(this.dsMayTinh[i].ToString());
                Console.WriteLine(new String('=', 50));
            }
            Console.WriteLine("Nhan phim bat ki de tiep tuc!");
        }
    }
}

