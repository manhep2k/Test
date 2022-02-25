using QLHĐSolotion.ViewModel.Doitac.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHĐSolotion.ViewModel.KhachHang.Dtos
{
    public class GetPublicKhachHangPagingRequest: PagingRequestBase
    {
        public Guid CtrDoiTacID { get; set; }
    }
}
