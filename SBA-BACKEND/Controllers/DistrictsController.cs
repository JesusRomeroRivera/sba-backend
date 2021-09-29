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
 	[Route("api/district")]
 	[ApiController]
 	public class DistrictsController : ControllerBase
 	{
 		private readonly IDistrictService _districtService;
 		private readonly IMapper _mapper;
 
 		public DistrictsController(IDistrictService districtService, IMapper mapper)
 		{
 			_districtService = districtService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "districts" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(DistrictResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveDistrictResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var district = _mapper.Map<SaveDistrictResource, District>(resource);
 			var result = await _districtService.SaveAsync(district);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
 			return Ok(districtResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "districts" })]
 		[HttpPut("{districtId}")]
 		[ProducesResponseType(typeof(DistrictResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int districtId, [FromBody] SaveDistrictResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var district = _mapper.Map<SaveDistrictResource, District>(resource);
 			var result = await _districtService.UpdateAsync(districtId, district);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
 			return Ok(districtResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "districts" })]
 		[HttpGet("{districtId}")]
 		[ProducesResponseType(typeof(DistrictResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int districtId)
 		{
 			var result = await _districtService.GetByIdAsync(districtId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
 
 			return Ok(districtResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "districts" })]
 		[HttpDelete("{districtId}")]
 		[ProducesResponseType(typeof(DistrictResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int districtId)
 		{
 			var result = await _districtService.DeleteAsync(districtId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);
 			return Ok(districtResource);
 		}
 	}
 }
