using AutoMapper;
using GrindRailsAPI.Data.Interfaces;
using GrindRailsAPI.Shared.DTOs;
using GrindRailsAPI.Shared.Messages;
using GrindRailsAPI.Shared.Messages._200OkMessages;
using GrindRailsAPI.Shared.ModelsView.Product;
using System.Net;


namespace GrindRailsAPI.Services
{
    public class ProductServices
    {
        private readonly IWorkUnit _iWorkUnit;
        private readonly IMapper _mapper;
        private readonly IProductBusiness _iClientBusiness;

        public ProductServices(IWorkUnit workUnit, IMapper mapper, IProductBusiness iClientBusiness)
        {
            _iWorkUnit = workUnit;
            _mapper = mapper;
            _iClientBusiness = iClientBusiness;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Create(ProductCreateViewModel productCreateModelView)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productCreateModelView);
                productDTO = await _iClientBusiness.Create(productDTO);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = HttpStatusCode.Created;
                serviceResponseDTO.Message = OkCreatedMessages.ProductCreated;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode =HttpStatusCode.InternalServerError;
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Read(Guid id)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = await _iClientBusiness.Read(id);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = HttpStatusCode.OK;
                serviceResponseDTO.Message = OkReadMessages.ProductRead;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = HttpStatusCode.InternalServerError;
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Update(ProductViewModel clientUpdateViewModel)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(clientUpdateViewModel);
                productDTO = await _iClientBusiness.Update(productDTO);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = HttpStatusCode.OK;
                serviceResponseDTO.Message = OkUpdateMessages.ProductUpdated;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = HttpStatusCode.InternalServerError;
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<ProductViewModel>> Delete(Guid id)
        {
            ServiceResponseDTO<ProductViewModel> serviceResponseDTO = new ServiceResponseDTO<ProductViewModel>();

            try
            {               
               ProductDTO productDTO = await _iClientBusiness.Delete(id);

                serviceResponseDTO.GenericData = _mapper.Map<ProductViewModel>(productDTO);
                serviceResponseDTO.StatusCode = HttpStatusCode.OK;
                serviceResponseDTO.Message = OkDeleteMessages.ProductDeleted;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = HttpStatusCode.InternalServerError;
            }

            return serviceResponseDTO;
        }


        public async Task<ServiceResponseDTO<List<ProductViewModel>>> List(ProductListViewModel productListViewModel)
        {
            ServiceResponseDTO<List<ProductViewModel>> serviceResponseDTO = new ServiceResponseDTO<List<ProductViewModel>>();

            try
            {
                ProductDTO productDTO = _mapper.Map<ProductDTO>(productListViewModel);

                List<ProductDTO> productsDTO = await _iClientBusiness.Update(productDTO);

                serviceResponseDTO.GenericData = _mapper.Map<List<ProductViewModel>>(productsDTO);
                serviceResponseDTO.StatusCode = HttpStatusCode.OK;
                serviceResponseDTO.Message = OkListMessages.ProductListed;
                serviceResponseDTO.Sucess = true;

                await _iWorkUnit.CommitAsync();
            }
            catch (Exception ex)
            {
                _iWorkUnit.Rollback();

                serviceResponseDTO.Sucess = false;
                serviceResponseDTO.Message = ex.Message;
                serviceResponseDTO.StatusCode = HttpStatusCode.InternalServerError;
            }

            return serviceResponseDTO;
        }
    }
}
