using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHĐSolotion.Data.Entity
{
    public partial class CtrCongNo
    {
        public CtrCongNo()
        {
            CtrHopDongs = new HashSet<CtrHopDong>();
        }
    public Guid CtrCongNoID { set; get; }
        public string MaCongNo { set; get; }
        public decimal TongNo { set; get; }
        public decimal DaThanhToan { set; get; }
        public DateTime NgayThanhToan { set; get; }
        public decimal DuNo { set; get; }
        public decimal KhauTru { set; get; }
        public DateTime Kyhan { set; get; }
         public string GhiChu { set; get; }
        public bool Trangthai { get; set; }
        public Guid CtrHopDongID { set; get; }

        public virtual ICollection<CtrHopDong> CtrHopDongs { get; set; }
    }
}
