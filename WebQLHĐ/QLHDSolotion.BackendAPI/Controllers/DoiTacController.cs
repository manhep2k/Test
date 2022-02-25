using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLHĐSolotion.Application.Doitac;
using QLHĐSolotion.Data.EF;
using QLHĐSolotion.ViewModel.Doitac.Dtos;

namespace QLHDSolotion.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoiTacController : ControllerBase

    {
        private readonly testDbontext _context;
        private readonly PublicDoiTacService _DoiTacService;

        public DoiTacController(PublicDoiTacService DoiTacService, testDbontext context)
        {
            _context = context;
            _DoiTacService = DoiTacService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doitac = await _DoiTacService.GetAll();
            return Ok( doitac);
        }
    }
}
