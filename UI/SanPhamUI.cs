using System;
using Services;

namespace UI
{
    public class SanPhamUI
    {
        private SanPhamService sanPhamService;

        public SanPhamUI(SanPhamService sanPhamService)
        {
            this.sanPhamService = sanPhamService;
        }

        // Phương thức cho phép người dùng tìm kiếm sản phẩm
        public void TimKiemSanPham()
        {
            Console.Clear();
            Console.WriteLine("--- TÌM KIẾM SẢN PHẨM ---");
            sanPhamService.TimKiemSanPham();
        }

        // Phương thức hiển thị chi tiết sản phẩm
        public void XemChiTietSanPham()
        {
            Console.Clear();
            Console.WriteLine("--- XEM CHI TIẾT SẢN PHẨM ---");
            Console.Write("Nhập mã sản phẩm: ");
            if (int.TryParse(Console.ReadLine(), out int maSP))
            {
                var sp = sanPhamService.GetSanPhamById(maSP);
                if (sp != null)
                {
                    Console.WriteLine($"Mã sản phẩm: {sp.maSanPham}");
                    Console.WriteLine($"Tên sản phẩm: {sp.tenSanPham}");
                    Console.WriteLine($"Giá: {sp.gia}đ");
                    Console.WriteLine($"Số lượng trong kho: {sp.soLuong}");
                    Console.WriteLine($"Thương hiệu: {sp.thuongHieu}");
                }
                else
                {
                    Console.WriteLine("Sản phẩm không tồn tại!");
                }
            }
            else
            {
                Console.WriteLine("Mã sản phẩm không hợp lệ!");
            }
        }

        // Phương thức kiểm tra tồn kho
        public void KiemTraTonKho()
        {
            Console.Clear();
            Console.WriteLine("--- KIỂM TRA TỒN KHO ---");
            Console.Write("Nhập mã sản phẩm: ");
            if (int.TryParse(Console.ReadLine(), out int maSP))
            {
                Console.Write("Nhập số lượng yêu cầu: ");
                if (int.TryParse(Console.ReadLine(), out int soLuongYeuCau))
                {
                    sanPhamService.KiemTraTonKho(maSP, soLuongYeuCau);
                }
                else
                {
                    Console.WriteLine("Số lượng không hợp lệ!");
                }
            }
            else
            {
                Console.WriteLine("Mã sản phẩm không hợp lệ!");
            }
        }

        // Phương thức hiển thị menu cho sản phẩm
        public void HienThiMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MENU SẢN PHẨM ===");
                Console.WriteLine("1. Tìm kiếm sản phẩm");
                Console.WriteLine("2. Xem chi tiết sản phẩm");
                Console.WriteLine("3. Kiểm tra tồn kho");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TimKiemSanPham();
                        break;
                    case "2":
                        XemChiTietSanPham();
                        break;
                    case "3":
                        KiemTraTonKho();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }
}
