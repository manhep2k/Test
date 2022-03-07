using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLHĐSolotion.Application.Doitac.Dtos;

namespace QLHĐSolotion.ViewModel.Doitac.Dtos
{
    public  interface IPublicDoiTacServicer
    {
        Task<PagedResult<KhachHangViewModels>> GetAllByCategoryId(GetPublicKhachHangPagingRequest request);

         Task<List<KhachHangViewModels>> GetAll();
        Task<Guid> Create(CtrKhachHangCreateRequest request);

        Task<Guid> Update(CtrKhachHangUpdateRequest request);

        Task<int> Delete(Guid doitacID);


        //List<DoiTacViewModels> GetAll();
        List<KhachHangViewModels> GetAllPaging(String keywork, int pageIndex, int pageSize);
    }

}
