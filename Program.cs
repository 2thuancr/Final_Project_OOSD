using System;
using Services;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var sanPhamService = new SanPhamService();
        var donHangService = new DonHangService();
        var gioHangService = new GioHangService(sanPhamService, donHangService);

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== ỨNG DỤNG QUẢN LÝ BÁN HÀNG ===");
            Console.WriteLine("1. Tìm kiếm sản phẩm");
            Console.WriteLine("2. Xem lịch sử đơn hàng");
            Console.WriteLine("3. Đặt hàng");
            Console.WriteLine("4. Xem chi tiết sản phẩm");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    sanPhamService.TimKiemSanPham();
                    break;
                case "2":
                    donHangService.XemLichSuDonHang();
                    break;
                case "3":
                    gioHangService.DatHang();
                    break;
                case "4":
                    sanPhamService.XemChiTietSanPham();
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
