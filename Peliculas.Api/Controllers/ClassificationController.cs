using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Core.DTOs;
using Peliculas.Core.Entities;
using Peliculas.Core.Interface;

namespace Peliculas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : Controller
    {
        private IClassificationRepository _classificationResponsy;
        private readonly IMapper _mapper;
        public ClassificationController(IClassificationRepository classificationRepository, IMapper mapper)
        {
            _classificationResponsy = classificationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassifications()
        {
            var classifications = await _classificationResponsy.GetClassifications();
            var classificationDto = _mapper.Map<IEnumerable<ClassificationsDto>>(classifications);
            return Ok(classificationDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassification(int id)
        {
            var classification = await _classificationResponsy.GetClassifications(id);
            var classificationDto = _mapper.Map<ClassificationsDto>(classification);
            return Ok(classificationDto);
        }
        [HttpPost]
        public async Task<IActionResult> InsertClassification(Classifications newclassification)
        {
            await _classificationResponsy.InsertClassification(newclassification);
            var classificationDto = _mapper.Map<ClassificationsDto>(newclassification);
            return Ok(classificationDto);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClassification(ClassificationsDto upclassification)
        {
            var classification = _mapper.Map<Classifications>(upclassification);
            await _classificationResponsy.UpdateClassification(classification);
            return Ok(classification);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassification(int id)
        {
            var classification = await _classificationResponsy.DeleteClassification(id);
            return Ok(classification);
        }
    }
}
