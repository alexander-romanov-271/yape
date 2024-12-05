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
    public class GuidelineController : ControllerBase
    { 
        private readonly IReadAllService<GuidelineDTO> _readAllService; 
        private readonly IReadService<GuidelineDTO> _readService;
        private readonly ICreateService<GuidelineDTO> _createService;
        private readonly IUpdateService<GuidelineDTO> _updateService;

        public GuidelineController([FromKeyedServices("readallGuidelines")] IReadAllService<GuidelineDTO> readAllService,
        [FromKeyedServices("readGuideline")] IReadService<GuidelineDTO> readService,
        [FromKeyedServices("createGuideline")] ICreateService<GuidelineDTO> createService,
        [FromKeyedServices("updateGuideline")] IUpdateService<GuidelineDTO> updateService)
        {
            _readAllService = readAllService;
            _readService = readService;
            _createService = createService;
            _updateService = updateService;
        }

        [HttpGet("get")]
        [Consumes("application/json")]
        [Produces("applicatoin/json")]
        [ProducesResponseType<GuidelineDTO>(200)]
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
        [ProducesResponseType<GuidelineDTO>(200)]
        [ProducesResponseType<GuidelineDTO>(400)]
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
        public ActionResult Create([FromBody] GuidelineDTO Guideline)
        {   
            _createService.Create(Guideline);         
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
        public ActionResult Update(int id, [FromBody] GuidelineDTO entityDTO)
        {
            _updateService.Update(id, entityDTO);
            return Ok();
        }
    }
}
