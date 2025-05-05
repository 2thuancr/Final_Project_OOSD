using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SanPhamService
    {
        public void TimKiemSanPham()
        {
            Console.Write("Nhập từ khóa tìm kiếm: ");
            string keyword = Console.ReadLine();
            var ketQua = danhSachSanPham.FindAll(sp => sp.tenSanPham.Contains(keyword));

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sản phẩm nào.");
            }
            else
            {
                Console.WriteLine("Kết quả tìm kiếm:");
                foreach (var sp in ketQua)
                {
                    Console.WriteLine($"- {sp.maSanPham}: {sp.tenSanPham} - {sp.gia}đ");
                }
            }
        }

        public SanPham GetSanPhamById(int id)
        {
            return danhSachSanPham.Find(sp => sp.maSanPham == id);
        }
        public void XemChiTietSanPham()
        {
            Console.Write("Nhập mã sản phẩm cần xem chi tiết: ");
            if (!int.TryParse(Console.ReadLine(), out int maSP))
            {
                Console.WriteLine("Mã sản phẩm không hợp lệ!");
                return;
            }

            var sp = GetSanPhamById(maSP);

            if (sp == null)
            {
                Console.WriteLine("Không tìm thấy sản phẩm với mã đã nhập.");
            }
            else
            {
                Console.WriteLine("\n--- CHI TIẾT SẢN PHẨM ---");
                Console.WriteLine($"Mã sản phẩm : {sp.maSanPham}");
                Console.WriteLine($"Tên sản phẩm: {sp.tenSanPham}");
                Console.WriteLine($"Giá         : {sp.gia}đ");
                Console.WriteLine($"Số lượng    : {sp.soLuong}");
                Console.WriteLine($"Thương hiệu : {sp.thuongHieu}");
            }
        }
        public void KiemTraTonKho(int maSP, int soLuongYeuCau)
        {
            var sp = GetSanPhamById(maSP);

            if (sp == null)
            {
                Console.WriteLine("Không tìm thấy sản phẩm với mã đã nhập.");
            }
            else
            {
                Console.WriteLine($"\nSản phẩm: {sp.tenSanPham}");
                Console.WriteLine($"Tồn kho hiện tại: {sp.soLuong}");

                if (sp.soLuong >= soLuongYeuCau)
                {
                    Console.WriteLine($"✅ Đủ hàng để đáp ứng số lượng yêu cầu: {soLuongYeuCau}.");
                }
                else
                {
                    Console.WriteLine($"❌ Không đủ hàng. Chỉ còn {sp.soLuong}, yêu cầu {soLuongYeuCau}.");
                }
            }
        }


        private List<SanPham> danhSachSanPham = new List<SanPham>
        {
            new SanPham { maSanPham = 1, tenSanPham = "Ao thun", gia = 150000, soLuong = 10, thuongHieu = "ABC" },
            new SanPham { maSanPham = 2, tenSanPham = "Quan jean", gia = 350000, soLuong = 5, thuongHieu = "XYZ" },
            new SanPham { maSanPham = 3, tenSanPham = "Ao so mi", gia = 250000, soLuong = 8, thuongHieu = "Uniqlo" },
            new SanPham { maSanPham = 4, tenSanPham = "Vay ngan", gia = 300000, soLuong = 6, thuongHieu = "Zara" },
            new SanPham { maSanPham = 5, tenSanPham = "Ao khoac", gia = 500000, soLuong = 4, thuongHieu = "H&M" },
            new SanPham { maSanPham = 6, tenSanPham = "Giay sneaker", gia = 700000, soLuong = 12, thuongHieu = "Nike" },
            new SanPham { maSanPham = 7, tenSanPham = "Dep quai ngang", gia = 120000, soLuong = 15, thuongHieu = "Adidas" },
            new SanPham { maSanPham = 8, tenSanPham = "Mu luoi trai", gia = 90000, soLuong = 20, thuongHieu = "Puma" },
            new SanPham { maSanPham = 9, tenSanPham = "Tui xach", gia = 450000, soLuong = 7, thuongHieu = "Gucci" },
            new SanPham { maSanPham = 10, tenSanPham = "Dong ho", gia = 1200000, soLuong = 3, thuongHieu = "Casio" },
            new SanPham { maSanPham = 11, tenSanPham = "That lung", gia = 180000, soLuong = 9, thuongHieu = "Levi's" },
            new SanPham { maSanPham = 12, tenSanPham = "Kinh mat", gia = 250000, soLuong = 6, thuongHieu = "RayBan" },
            new SanPham { maSanPham = 13, tenSanPham = "Ao hoodie", gia = 400000, soLuong = 5, thuongHieu = "Local Brand" },
            new SanPham { maSanPham = 14, tenSanPham = "Ao vest", gia = 900000, soLuong = 2, thuongHieu = "The Blues" },
            new SanPham { maSanPham = 15, tenSanPham = "Giay tay", gia = 850000, soLuong = 4, thuongHieu = "Vina Giay" },
            new SanPham { maSanPham = 16, tenSanPham = "Vo cotton", gia = 50000, soLuong = 30, thuongHieu = "Coolmate" },
            new SanPham { maSanPham = 17, tenSanPham = "Ao len", gia = 350000, soLuong = 6, thuongHieu = "Canifa" },
            new SanPham { maSanPham = 18, tenSanPham = "Khan quang co", gia = 150000, soLuong = 10, thuongHieu = "Gap" },
            new SanPham { maSanPham = 19, tenSanPham = "Ao ba lo", gia = 90000, soLuong = 20, thuongHieu = "Ninomaxx" },
            new SanPham { maSanPham = 20, tenSanPham = "Quan short", gia = 200000, soLuong = 11, thuongHieu = "Routine" }
        };
    }
}
