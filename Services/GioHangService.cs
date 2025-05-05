using System;
using System.Collections.Generic;

namespace Services
{
    public class GioHangService
    {
        private List<ChiTietGioHang> gioHang = new List<ChiTietGioHang>();
        private SanPhamService sanPhamService;
        private DonHangService donHangService;

        public GioHangService(SanPhamService sanPhamService, DonHangService donHangService)
        {
            this.sanPhamService = sanPhamService;
            this.donHangService = donHangService;
        }

        public void DatHang()
        {
            Console.WriteLine("--- THÊM SẢN PHẨM VÀO GIỎ ---");
            bool tiepTuc = true;
            while (tiepTuc)
            {
                Console.Write("Nhập mã sản phẩm: ");
                int maSP = int.Parse(Console.ReadLine());
                var sanPham = sanPhamService.GetSanPhamById(maSP);

                if (sanPham == null)
                {
                    Console.WriteLine("Sản phẩm không tồn tại!");
                    continue;
                }

                Console.Write("Nhập số lượng: ");
                int soLuong = int.Parse(Console.ReadLine());

                if (sanPham.soLuong < soLuong)
                {
                    Console.WriteLine("Không đủ hàng trong kho!");
                    continue;
                }

                gioHang.Add(new ChiTietGioHang
                {
                    maSanPham = sanPham.maSanPham,
                    soLuong = soLuong
                });

                Console.Write("Thêm sản phẩm khác? (y/n): ");
                tiepTuc = Console.ReadLine().ToLower() == "y";
            }

            TinhTongTien();
            Console.Write("Xác nhận đặt hàng? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                decimal tongTien = TinhTongTien();
                donHangService.ThemDonHang(new DonHang
                {
                    maDonHang = donHangService.TaoMaMoi(),
                    ngayDatHang = DateTime.Now,
                    tongTien = tongTien,
                    trangThai = "Da giao", // hoặc "Dang xu ly"
                    phuongThucThanhToan = "Tien mat" // hoặc lấy từ người dùng nếu bạn muốn
                });

                Console.WriteLine("Đặt hàng thành công!");
                gioHang.Clear();
            }
        }

        private decimal TinhTongTien()
        {
            decimal tongTien = 0;
            Console.WriteLine("\n--- GIỎ HÀNG ---");
            foreach (var ct in gioHang)
            {
                var sp = sanPhamService.GetSanPhamById(ct.maSanPham);
                decimal tien = sp.gia * ct.soLuong;
                Console.WriteLine($"- {sp.tenSanPham} x {ct.soLuong} = {tien}đ");
                tongTien += tien;
            }
            Console.WriteLine($"Tổng tiền: {tongTien}đ");
            return tongTien;
        }

    }
}
