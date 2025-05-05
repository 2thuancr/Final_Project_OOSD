using System;
using Services;

namespace UI
{
    public class DonHangUI
    {
        private DonHangService donHangService;

        public DonHangUI(DonHangService donHangService)
        {
            this.donHangService = donHangService;
        }

        // Phương thức hiển thị lịch sử đơn hàng
        public void XemLichSuDonHang()
        {
            Console.Clear();
            Console.WriteLine("--- LỊCH SỬ ĐƠN HÀNG ---");
            var danhSachDonHang = donHangService.GetLichSuDonHang();

            if (danhSachDonHang.Count == 0)
            {
                Console.WriteLine("Không có đơn hàng nào.");
                return;
            }

            foreach (var donHang in danhSachDonHang)
            {
                Console.WriteLine($"Mã đơn hàng: {donHang.maDonHang}");
                Console.WriteLine($"Ngày đặt: {donHang.ngayDatHang}");
                Console.WriteLine($"Tổng tiền: {donHang.tongTien}đ");
                Console.WriteLine($"Trạng thái: {donHang.trangThai}");
                Console.WriteLine($"Phương thức thanh toán: {donHang.phuongThucThanhToan}");
                Console.WriteLine("----------------------------");
            }
        }

        // Phương thức hiển thị menu cho đơn hàng
        public void HienThiMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MENU ĐƠN HÀNG ===");
                Console.WriteLine("1. Xem lịch sử đơn hàng");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        XemLichSuDonHang();
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
