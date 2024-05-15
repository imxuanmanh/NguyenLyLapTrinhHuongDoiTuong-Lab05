using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab5
{
    public class Ram : IThietBi
    {
        private int gia;
        private float dungluong;

        public int Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public float Dungluong
        {
            get { return dungluong; }
            set { dungluong = value; }
        }

        public Ram()
        {
            Console.Write("Nhap gia: ");
            this.Gia = int.Parse(Console.ReadLine());
            Console.Write("Nhap dung luong: ");
            this.Dungluong = float.Parse(Console.ReadLine());
        }

        public Ram(float dungluong, int gia)
        {
            this.Gia = gia;
            this.Dungluong = dungluong;
        }

        public override string ToString()
        {
            return String.Format("Ram |Gia(VND): {0, 5} |Dung luong(GB): {1, 5}", Gia, Dungluong);
        }
    }
}
