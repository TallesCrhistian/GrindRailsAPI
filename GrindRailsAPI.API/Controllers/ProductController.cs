using GrindRailsAPI.Shared.DTOs;
using GrindRailsAPI.Shared.ModelsView.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrindRailsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _iProductServices;

        public ProductController(IProductServices iProductServices)
        {
            _iProductServices = iProductServices;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateViewModel productCreateViewModel)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Create(productCreateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Read(Guid id)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Read(id);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Update(productUpdateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)

        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = await _iProductServices.Delete(clientUpdateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> List(ProductListViewModel productListViewModel)

        {
            ServiceResponseDTO<List<ProductViewModel>> serviceResponseDTO = await _iProductServices.List(productListViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

    }
}
