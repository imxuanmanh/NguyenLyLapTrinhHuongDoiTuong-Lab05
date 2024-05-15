using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab5
{
    public class CPU : IThietBi
    {
        private int gia;
        private float tocdo;
        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public float TocDo
        {
            get { return tocdo; }
            set { tocdo = value; }
        }

        public CPU()
        {
            Console.WriteLine("Thong tin CPU");
            Console.Write("Nhap gia: ");
            Gia = int.Parse(Console.ReadLine());
            Console.Write("Nhap toc do: ");
            TocDo = float.Parse(Console.ReadLine());
        }

        public CPU(float td, int g)
        {
            this.Gia = g;
            this.TocDo = td;
        }
        public override string ToString()
        {
            return String.Format("Cpu |Gia(VND): {0, 5} |Toc do(GHz): {1, 8}", Gia, TocDo);
        }
    }
}

