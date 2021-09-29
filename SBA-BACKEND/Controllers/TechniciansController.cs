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
 	[Route("api/technician")]
 	[ApiController]
 	public class TechniciansController : ControllerBase
 	{
 		private readonly ITechnicianService _technicianService;
 		private readonly IMapper _mapper;
 
 		public TechniciansController(ITechnicianService technicianService, IMapper mapper)
 		{
 			_technicianService = technicianService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "technicians" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(TechnicianResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveTechnicianResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var technician = _mapper.Map<SaveTechnicianResource, Technician>(resource);
 			var result = await _technicianService.SaveAsync(technician);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);
 			return Ok(technicianResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "technicians" })]
 		[HttpPut("{technicianId}")]
 		[ProducesResponseType(typeof(TechnicianResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int technicianId, [FromBody] SaveTechnicianResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var technician = _mapper.Map<SaveTechnicianResource, Technician>(resource);
 			var result = await _technicianService.UpdateAsync(technicianId, technician);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);
 			return Ok(technicianResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "technicians" })]
 		[HttpGet("{technicianId}")]
 		[ProducesResponseType(typeof(TechnicianResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int technicianId)
 		{
 			var result = await _technicianService.GetByIdAsync(technicianId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);
 
 			return Ok(technicianResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "technicians" })]
 		[HttpDelete("{technicianId}")]
 		[ProducesResponseType(typeof(TechnicianResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int technicianId)
 		{
 			var result = await _technicianService.DeleteAsync(technicianId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var technicianResource = _mapper.Map<Technician, TechnicianResource>(result.Resource);
 			return Ok(technicianResource);
 		}
 	}
 }
