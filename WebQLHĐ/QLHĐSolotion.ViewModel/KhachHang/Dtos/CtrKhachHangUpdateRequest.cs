using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHĐSolotion.Application.KhachHang.Dtos
{
    public class CtrKhachHangUpdateRequest
    {
        public Guid CtrDoiTacID { get; set; }

        public string MaDoitac { get; set; }

        public string TenDoiTac { get; set; }

        public string DiaChi { get; set; }

        public int MaSoThue { get; set; }

        public int DienThoai { get; set; }

        public string TaiKhoanDangNhap { get; set; }
    }
}
