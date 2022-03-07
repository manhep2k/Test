using Microsoft.AspNetCore.Mvc;
using QLHĐSolotion.Application.KhachHang.KH;
using QLHĐSolotion.ViewModel.Doitac.Dtos;

namespace QLHĐSolotion.BackEndAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KhachHangController : ControllerBase

    {
        //private readonly testDbontext _context;
        private readonly IPublicKhachHangServicer _KhachHangService;
        //private readonly IDoitacService _doitacService;
        public KhachHangController(IPublicKhachHangServicer KhachHangService)/*, testDbontext context*/
        {
            //_context = context;
            _KhachHangService = KhachHangService;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doitac = await _KhachHangService.GetAll();
            return Ok(doitac);
        }

        //create
        [HttpPost]
        [Consumes("multipart/form-data")]
        //[Authorize]
        public async Task<IActionResult> Create([FromForm] CtrKhachHangCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _KhachHangService.Create(request);
            //request.CtrKhachHangID = Guid.NewGuid();
            if (productId == 0)
                return BadRequest();

            //var product = await _doitacService.GetById(productId, request.LanguageId);
            return Ok(productId);
        }


        [HttpPut]

        public async Task<IActionResult> Update(/*[FromRoute] Guid productId,*/ [FromForm] CtrKhachHangUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = new Guid();
            //request.CtrKhachHangID = productId;
            var affectedResult = await _KhachHangService.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok(affectedResult);
        }

        // Delete
        [HttpDelete("{doitacID}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int doitacID)
        {
            var affectedResult = await _KhachHangService.Delete(doitacID);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
