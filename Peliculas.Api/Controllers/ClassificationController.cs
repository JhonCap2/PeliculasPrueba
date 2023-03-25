using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Api.Response;
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
            var response = new ApiResponse<IEnumerable<ClassificationsDto>>(classificationDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassification(int id)
        {
            var classification = await _classificationResponsy.GetClassifications(id);
            var classificationDto = _mapper.Map<ClassificationsDto>(classification);
            var response = new ApiResponse<ClassificationsDto>(classificationDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertClassification(Classifications newclassification)
        {
            await _classificationResponsy.InsertClassification(newclassification);
            var classificationDto = _mapper.Map<ClassificationsDto>(newclassification);
            var reponse = new ApiResponse<ClassificationsDto>(classificationDto);
            return Ok(reponse);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClassification(ClassificationsDto upclassification)
        {
            var classification = _mapper.Map<Classifications>(upclassification);
            await _classificationResponsy.UpdateClassification(classification);
            var reponse = new ApiResponse<Classifications>(classification);
            return Ok(reponse);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassification(int id)
        {
            var classification = await _classificationResponsy.DeleteClassification(id);
            return Ok(classification);
        }
    }
}
