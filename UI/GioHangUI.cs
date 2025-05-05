using System;
using Services;

namespace UI
{
    public class GioHangUI
    {
        private GioHangService gioHangService;

        public GioHangUI(GioHangService gioHangService)
        {
            this.gioHangService = gioHangService;
        }

        // Phương thức đặt hàng
        public void DatHang()
        {
            Console.Clear();
            Console.WriteLine("--- THÊM SẢN PHẨM VÀO GIỎ HÀNG ---");
            gioHangService.DatHang();
        }

        // Phương thức hiển thị menu cho giỏ hàng
        public void HienThiMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MENU GIỎ HÀNG ===");
                Console.WriteLine("1. Đặt hàng");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DatHang();
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
