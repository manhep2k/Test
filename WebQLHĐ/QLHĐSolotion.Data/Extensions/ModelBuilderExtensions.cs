using Microsoft.EntityFrameworkCore;
using QLHĐSolotion.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLHĐSolotion.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtrDoiTac>().HasData(
              new CtrDoiTac()
              {
                  CtrDoiTacID = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE"),
                  MaDoitac = "01",
                  TenDoiTac = "phạm văn mạnh",
                  DiaChi = "phạm văn mạnh", 
                  MaSoThue = 777,
                  DienThoai = 1555555,
                  TaiKhoanDangNhap ="ADMIN"

              },
               new CtrDoiTac()
               {
                   CtrDoiTacID = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                   MaDoitac = "02",
                   TenDoiTac = "phạm văn mạnh",
                   DiaChi = "phạm văn mạnh",
                   MaSoThue = 777,
                   DienThoai = 1555555,
                   TaiKhoanDangNhap = "ADMIN"
               });

        }
    }
}
