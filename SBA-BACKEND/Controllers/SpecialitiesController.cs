using AutoMapper;
 using Microsoft.AspNetCore.Http;
 using Microsoft.AspNetCore.Mvc;
 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using Swashbuckle.AspNetCore.Annotations;
 using SBA_BACKEND.Domain.Models;
 using SBA_BACKEND.Domain.Services;
 using SBA_BACKEND.Resources;
 using SBA_BACKEND.API.Extensions;
 using Swashbuckle.Swagger;
 
 namespace SBA_BACKEND.Controllers
 {
 	[Route("api/speciality")]
 	[ApiController]
 	public class SpecialitiesController : ControllerBase
 	{
 		private readonly ISpecialityService _specialityService;
 		private readonly IMapper _mapper;
 
 		public SpecialitiesController(ISpecialityService specialityService, IMapper mapper)
 		{
 			_specialityService = specialityService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "specialties" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(SpecialityResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveSpecialityResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var speciality = _mapper.Map<SaveSpecialityResource, Speciality>(resource);
 			var result = await _specialityService.SaveAsync(speciality);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var specialityResource = _mapper.Map<Speciality, SpecialityResource>(result.Resource);
 			return Ok(specialityResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "specialties" })]
 		[HttpPut("{specialityId}")]
 		[ProducesResponseType(typeof(SpecialityResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int specialityId, [FromBody] SaveSpecialityResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var speciality = _mapper.Map<SaveSpecialityResource, Speciality>(resource);
 			var result = await _specialityService.UpdateAsync(specialityId, speciality);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var specialityResource = _mapper.Map<Speciality, SpecialityResource>(result.Resource);
 			return Ok(specialityResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "specialties" })]
 		[HttpGet("{specialityId}")]
 		[ProducesResponseType(typeof(SpecialityResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int specialityId)
 		{
 			var result = await _specialityService.GetByIdAsync(specialityId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var specialityResource = _mapper.Map<Speciality, SpecialityResource>(result.Resource);
 
 			return Ok(specialityResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "specialties" })]
 		[HttpDelete("{specialityId}")]
 		[ProducesResponseType(typeof(SpecialityResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int specialityId)
 		{
 			var result = await _specialityService.DeleteAsync(specialityId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var specialityResource = _mapper.Map<Speciality, SpecialityResource>(result.Resource);
 			return Ok(specialityResource);
 		}
 	}
 }
