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
    public class RuleController : ControllerBase
    { 
        private readonly IReadAllService<RuleDTO> _readAllService; 
        private readonly IReadService<RuleDTO> _readService;
        private readonly ICreateService<RuleDTO> _createService;
        private readonly IUpdateService<RuleDTO> _updateService;

        public RuleController([FromKeyedServices("readallRules")] IReadAllService<RuleDTO> readAllService,
        [FromKeyedServices("readRule")] IReadService<RuleDTO> readService,
        [FromKeyedServices("createRule")] ICreateService<RuleDTO> createService,
        [FromKeyedServices("updateRule")] IUpdateService<RuleDTO> updateService)
        {
            _readAllService = readAllService;
            _readService = readService;
            _createService = createService;
            _updateService = updateService;
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType<RuleDTO>(200)]
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
        [ProducesResponseType<RuleDTO>(200)]
        [ProducesResponseType<RuleDTO>(400)]
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
        public ActionResult Create([FromBody] RuleDTO Rule)
        {   
            _createService.Create(Rule);         
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
        public ActionResult Update(int id, [FromBody] RuleDTO entityDTO)
        {
            _updateService.Update(id, entityDTO);
            return Ok();
        }
    }
}
