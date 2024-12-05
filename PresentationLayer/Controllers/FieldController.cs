using Microsoft.AspNetCore.Mvc;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.BusinessLogicLayer.Services.ReadAllServices;
using newyape.BusinessLogicLayer.Services.ReadServices;
using newyape.BusinessLogicLayer.Services.CreateServices;
using newyape.BusinessLogicLayer.Services.UpdateServices;

namespace newyape.PresentationLayer.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    { 
        private readonly IReadAllService<FieldDTO> _readAllService; 
        private readonly IReadService<FieldDTO> _readService;
        private readonly ICreateService<FieldDTO> _createService;
        private readonly IUpdateService<FieldDTO> _updateService;

        public FieldController(
            [FromKeyedServices("readallFields")] IReadAllService<FieldDTO> readAllService,
            [FromKeyedServices("readField")] IReadService<FieldDTO> readService,
            [FromKeyedServices("createField")] ICreateService<FieldDTO> createService,
            [FromKeyedServices("updateField")] IUpdateService<FieldDTO> updateService)
        {
            _readAllService = readAllService;
            _readService = readService;
            _createService = createService;
            _updateService = updateService;
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType<FieldDTO>(200)]
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
        [ProducesResponseType<FieldDTO>(200)]
        [ProducesResponseType<FieldDTO>(400)]
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
        public ActionResult Create([FromBody] FieldDTO field)
        {   
            _createService.Create(field);         
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
        public ActionResult Update(int id, [FromBody] FieldDTO entityDTO)
        {
            _updateService.Update(id, entityDTO);
            return Ok();
        }
    }
}
