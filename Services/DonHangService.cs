using System;
using System.Collections.Generic;

namespace Services
{
    public class DonHangService
    {
        public void XemLichSuDonHang()
        {
            Console.WriteLine("\n--- LỊCH SỬ ĐƠN HÀNG ---");
            foreach (var dh in lichSuDonHang)
            {
                Console.WriteLine($"Mã ĐH: {dh.maDonHang} | Ngày: {dh.ngayDatHang.ToShortDateString()} | " +
                                  $"Tổng tiền: {dh.tongTien}đ | Trạng thái: {dh.trangThai} | Thanh toán: {dh.phuongThucThanhToan}");
            }
        }

        public void ThemDonHang(DonHang donHang)
        {
            lichSuDonHang.Add(donHang);
        }

        public List<DonHang> GetLichSuDonHang()
        {
            return lichSuDonHang;
        }

        public int TaoMaMoi()
        {
            return lichSuDonHang.Count + 1;
        }

        private List<DonHang> lichSuDonHang = new List<DonHang>
        {
            new DonHang { maDonHang = 1, ngayDatHang = DateTime.Now.AddDays(-5), tongTien = 500000, trangThai = "Da giao", phuongThucThanhToan = "Tien mat" },
            new DonHang { maDonHang = 2, ngayDatHang = DateTime.Now.AddDays(-2), tongTien = 250000, trangThai = "Dang giao", phuongThucThanhToan = "Chuyen khoan" },
            new DonHang { maDonHang = 3, ngayDatHang = DateTime.Now.AddDays(-10), tongTien = 750000, trangThai = "Da giao", phuongThucThanhToan = "Tien mat" },
            new DonHang { maDonHang = 4, ngayDatHang = DateTime.Now.AddDays(-1), tongTien = 300000, trangThai = "Dang giao", phuongThucThanhToan = "Chuyen khoan" },
        };

    }
}
