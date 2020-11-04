using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspnetCoreAmazone.Service;

namespace MyAspnetCoreAmazone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAspnetCoreAmazoneController : ControllerBase
    {

        private Service.IProductService _productService;
        private readonly ILogger<MyAspnetCoreAmazoneController> _logger;

        public MyAspnetCoreAmazoneController(Service.IProductService productService, ILogger<MyAspnetCoreAmazoneController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpPost("GetAllProductsFor")]
        public ProductListResponse GetAllProductsFor([FromBody]ProductListRequest productListRequest)
        {


            ProductListResponse result = null;
            try
            {
                result = _productService.GetAllProductsFor(productListRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetBsysSwapBySessionID endpoint with ex message : " + ex.Message + "ex inner message " + ex?.InnerException?.Message + "Ex stactrace " + ex.StackTrace);

            }

            return result;
        }
    }
}