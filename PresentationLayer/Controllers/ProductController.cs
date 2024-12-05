using Microsoft.AspNetCore.Mvc;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.BusinessLogicLayer.Services.ReadAllServices;
using newyape.BusinessLogicLayer.Services.ReadServices;
using newyape.BusinessLogicLayer.Services.CreateServices;
using newyape.BusinessLogicLayer.Services.UpdateServices;

namespace newyape.PresentationLayer.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { 
        private readonly IReadAllService<ProductDTO> _readAllService; 
        private readonly IReadService<ProductDTO> _readService;
        private readonly ICreateService<ProductDTO> _createService;
        private readonly IUpdateService<ProductDTO> _updateService;

        public ProductController([FromKeyedServices("readallProducts")] IReadAllService<ProductDTO> readAllService,
        [FromKeyedServices("readProduct")] IReadService<ProductDTO> readService,
        [FromKeyedServices("createProduct")] ICreateService<ProductDTO> createService,
        [FromKeyedServices("updateProduct")] IUpdateService<ProductDTO> updateService)
        {
            _readAllService = readAllService;
            _readService = readService;
            _createService = createService;
            _updateService = updateService;
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType<ProductDTO>(200)]
        [ProducesResponseType<string>(400)]
        public ActionResult GetAll()
        {
            var result = _readAllService.ReadAll();

            if (result != null)
            {
                return Ok(result);
            }
            
            return BadRequest();
        }


        [HttpGet("get/{id}")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType<ProductDTO>(200)]
        [ProducesResponseType<ProductDTO>(400)]
        public ActionResult ReadOne(int id)
        {
            var result = _readService.Read(id);

            if (result != null)
            {
                return Ok(result);
            }  

            return BadRequest();
        }

        [HttpPost("create")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody] ProductDTO Product)
        {   
            _createService.Create(Product);         
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Delete(int id)
        {            
            return Ok();
        }

        [HttpPost("update/{id}")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult Update(int id, [FromBody] ProductDTO entityDTO)
        {
            _updateService.Update(id, entityDTO);
            return Ok();
        }
    }
}
