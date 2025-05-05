using System;
using Services;
using UI;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Khởi tạo các service
        var sanPhamService = new SanPhamService();
        var donHangService = new DonHangService();
        var gioHangService = new GioHangService(sanPhamService, donHangService);

        // Khởi tạo các UI tương ứng
        var sanPhamUI = new SanPhamUI(sanPhamService);
        var gioHangUI = new GioHangUI(gioHangService);
        var donHangUI = new DonHangUI(donHangService);

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== ỨNG DỤNG QUẢN LÝ BÁN HÀNG ===");
            Console.WriteLine("1. Quản lý sản phẩm");
            Console.WriteLine("2. Quản lý giỏ hàng");
            Console.WriteLine("3. Quản lý đơn hàng");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    sanPhamUI.HienThiMenu();
                    break;
                case "2":
                    gioHangUI.HienThiMenu();
                    break;
                case "3":
                    donHangUI.HienThiMenu();
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
