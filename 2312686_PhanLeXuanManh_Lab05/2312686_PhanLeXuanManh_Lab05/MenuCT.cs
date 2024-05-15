using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2312686_PhanLeXuanManh_Lab5
{
    class MenuCT
    {
        QuanLyMayTinh dsmt = new QuanLyMayTinh();
        private enum Menu
        {
            Thoat,
            NhapDanhSach,
            NhapTuFile,
            XuatDanhSach,
            TimMayTinhCoGiaLonNhat,
            TimDSCo2Ram,
            HienThiTheoGia,
            TongGia,
            SapXepGiamTheoTen,
            SapTangTheoSoThietBi,
            TimRamMaxMin,
            TimCpuMaxMin,
            TimMayTinhNhieuLinhKienNhat,
            XoaMayTinhTruocNamX,
            SapTangTheoSoLuongRam,
            ChenMayTinh,
            SuaThongTinMayTinh,
            ThongKeTenSoLuongTyLe,
            ThongKeNamSxSLTongGia,
            XoaMayTinhCoSoLinhKienItNhat
        }

        private static void XuatMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("               CHUONG TRINH QUAN LY MAY TINH");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Danh sach chuc nang:");
            Console.ResetColor();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(" 0. Thoat chuong trinh");
            Console.WriteLine(" 1. Nhap danh sach may tinh co dinh");
            Console.WriteLine(" 2. Nhap danh sach may tinh tu file");
            Console.WriteLine(" 3. Xuat danh sach may tinh");
            Console.WriteLine(" 4. Tim may tinh co gia lon nhat");
            Console.WriteLine(" 5. Tim danh sach may tinh co 2 thanh Ram");
            Console.WriteLine(" 6. Hien thi cac may tinh theo gia");
            Console.WriteLine(" 7. Tinh tong gia cua danh sach may tinh");
            Console.WriteLine(" 8. Sap xep danh sach may tinh giam theo ten");
            Console.WriteLine(" 9. Sap xep danh sach may tinh tang theo so thiet bi");
            Console.WriteLine("10. Tim cac may tinh co gia Ram cao nhat, thap nhat");
            Console.WriteLine("11. Tim cac may tinh co Cpu thap nhat, cao nhat");
            Console.WriteLine("12. Tim cac may tinh co nhieu linh kien nhat");
            Console.WriteLine("13. Xoa cac may tinh san xuat truoc nam x");
            Console.WriteLine("14. Sap xep danh sach may tinh tang theo so luong ram");
            Console.WriteLine("15. Chen may tinh vao truoc vi tri index");
            Console.WriteLine("16. Chinh sua thong tinh may tinh theo ma so");
            Console.WriteLine("17. Thong ke may tinh theo ten");
            Console.WriteLine("18. Thong ke may tinh theo nam san xuat");
            Console.WriteLine("19. Xoa tat ca may tinh co so linh kien it nhat");
        }

        private static Menu ChonMenu()
        {
            int chon;
            do
            {
                Console.WriteLine(new string('-',60));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Nhap chuc nang can thuc hien: ");
                Console.ResetColor();
                chon = int.Parse(Console.ReadLine());
                if ((int)Menu.Thoat <= chon && chon <= (int)Menu.XoaMayTinhCoSoLinhKienItNhat)
                    break;
            } while (true);
            return (Menu)chon;
        }
        private void XuLyMenu(Menu chon)
        {
            Console.Clear();
            switch (chon)
            {
                case Menu.NhapDanhSach:
                    dsmt.NhapCD();
                    Console.WriteLine("Danh sach may tinh da duoc nhap!");
                    break;

                case Menu.NhapTuFile:
                    dsmt.NhapTuFile();
                    Console.WriteLine("Danh sach may tinh da duoc nhap tu file!");
                    break;

                case Menu.XuatDanhSach:
                    Console.WriteLine("              DANH SACH MAY TINH");
                    dsmt.XuatDanhSach();
                    break;

                case Menu.TimMayTinhCoGiaLonNhat:
                    QuanLyMayTinh dskq = new QuanLyMayTinh();
                    Console.WriteLine("Danh sach may tinh co gia lon nhat:");
                    dskq = dsmt.MayTinhGiaLonNhat();
                    dskq.XuatDanhSach();
                    break;

                case Menu.TimDSCo2Ram:
                    dskq = new QuanLyMayTinh();
                    dskq = dsmt.MayTinhCo2Ram();
                    if (dskq.Count != 0)
                    {
                        Console.WriteLine("Danh sach may tinh co 2 thanh ram:");
                        dskq.XuatDanhSach();
                    }
                    else Console.WriteLine("Khong co may tinh nao co 2 thanh ram!");
                    break;

                case Menu.HienThiTheoGia:
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Nhap muc gia ban can tim");
                        Console.ResetColor();
                        Console.Write("Muc gia thap nhat: ");
                        int min = int.Parse(Console.ReadLine());
                        Console.Write("Muc gia cao nhat: ");
                        int max = int.Parse(Console.ReadLine());
                        if (max<min)
                        {
                            Console.Clear();
                            Console.WriteLine("Muc gia ban nhap khong hop ly. Vui long nhap lai!");
                        }    
                        else
                        {
                            dskq = dsmt.HienThiTheoGia(min, max);
                            if (dskq.Count != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Danh sach may tinh co gia nam trong khoang [{0}, {1}]", min, max);
                                dskq.XuatDanhSach();
                            }
                            else Console.WriteLine("Khong co may tinh nao co gia nam trong khoang [{0}, {1}]", min, max);
                            break;
                        }    
                    } while (true);
                    break;

                case Menu.TongGia:
                    Console.WriteLine("Tong gia cua cac may tinh trong danh sach: {0}", dsmt.TongGiaMayTinh());
                    break;

                case Menu.SapXepGiamTheoTen:
                    dsmt.SapXepGiamTheoTen();
                    Console.WriteLine("Danh sach may tinh duoc sap xep giam theo ten:");
                    dsmt.XuatDanhSach();
                    break;

                case Menu.SapTangTheoSoThietBi:
                    dsmt.SapXepTangTheoSoLuongThietBi();
                    Console.WriteLine("Danh sach may tinh duoc sap xep tang theo so luong thiet bi:");
                    dsmt.XuatDanhSach();
                    break;

                case Menu.TimRamMaxMin:
                    dsmt.RamMinMax();
                    break;

                case Menu.TimCpuMaxMin:
                    dsmt.CpuMinMax();
                    break;

                case Menu.TimMayTinhNhieuLinhKienNhat:
                    dskq = dsmt.MayTinhNhieuLinhKienNhat();
                    dskq.XuatDanhSach();
                    break;

                case Menu.XoaMayTinhTruocNamX:
                    Console.Write("Nhap nam: ");
                    int nam = int.Parse(Console.ReadLine());
                    dsmt.XoaTatCaMayTinhSanXuatTruocNamX(nam);
                    Console.WriteLine("Da xoa nhung may tinh duoc san xuat truoc nam {0}", nam);
                    break;

                case Menu.SapTangTheoSoLuongRam:
                    dsmt.SapXepTangTheoRam();
                    Console.WriteLine("Danh sach da duoc sap xep tang theo so luong ram!");
                    dsmt.XuatDanhSach();
                    break;

                case Menu.ChenMayTinh:
                    Console.Write("Nhap vi tri can chen: ");
                    int vt = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thong tin may tinh can chen");
                    Console.ResetColor();
                    Console.Write("Ma so: ");
                    string ms = Console.ReadLine();
                    Console.Write("Ten: ");
                    string ten = Console.ReadLine();
                    Console.Write("Nhap ngay sx(dd/mm/yyyy): ");
                    string time = Console.ReadLine();
                    DateTime ngaysx = DateTime.ParseExact(time, "dd/mm/yyyy", null);
                    MayTinh mt = new MayTinh(ms, ngaysx, ten);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thong tin may tinh can chen");
                    Console.ResetColor();
                    Console.Write("So Ram: ");
                    int soRam = int.Parse(Console.ReadLine());
                    for (int i = 0; i < soRam; i++)
                    {
                        Console.WriteLine("Ram {0}:", i + 1);
                        Console.Write("Dung luong: ");
                        float dungluong = float.Parse(Console.ReadLine());
                        Console.Write("Gia: ");
                        int gia = int.Parse(Console.ReadLine());
                        mt.ThemTB(new Ram(dungluong, gia));
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thong tin may tinh can chen");
                    Console.ResetColor();
                    Console.Write("So Cpu: ");
                    int soCpu = int.Parse(Console.ReadLine());
                    for (int i = 0; i < soCpu; i++)
                    {
                        Console.WriteLine("Cpu {0}:", i + 1);
                        Console.Write("Toc do: ");
                        float tocdo = float.Parse(Console.ReadLine());
                        Console.Write("Gia: ");
                        int gia = int.Parse(Console.ReadLine());
                        mt.ThemTB(new CPU(tocdo, gia));
                    }
                    dsmt.ChenMayTinh(vt, mt);
                    Console.Clear();
                    Console.WriteLine("Da chen may tinh vao vi tri cho truoc!");
                    break;

                case Menu.SuaThongTinMayTinh:
                    MayTinh mayTinh = null;
                    do
                    {
                        Console.Write("Nhap ma so cua may tinh can sua: ");
                        ms = Console.ReadLine();
                        if (ms == "0")
                        {
                            Console.WriteLine("Nhan phim bat ki de tiep tuc!");
                            break;
                        }

                        mayTinh = dsmt.KiemTraMaSo(ms);
                        if (mayTinh != null)
                        {
                            dsmt.SuaThongTinMayTinh(mayTinh);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Khong co may tinh mang ma so {0}, vui long nhap lai hoac nhap 0 de thoat!", ms);
                        }
                    } while (true); 
                    break;

                case Menu.ThongKeTenSoLuongTyLe:
                    dsmt.ThongKeTheoTen();
                    break;

                case Menu.ThongKeNamSxSLTongGia:
                    dsmt.ThongKeTheoNamSanXuat();
                    break;

                case Menu.XoaMayTinhCoSoLinhKienItNhat:
                    dsmt.XoaMayTinhCoSoLinhKienItNhat();
                    Console.WriteLine("Da xoa cac may tinh co it linh kien nhat!");
                    break;
            }
        }
        public void ChayChuongTrinh()
        {
            Menu chon;
            do
            {
                Console.Clear();
                XuatMenu();
                chon = ChonMenu();
                if (chon == Menu.Thoat)
                    break;
                XuLyMenu(chon);
                Console.ReadKey();
            } while (true);
        }
    }
}


