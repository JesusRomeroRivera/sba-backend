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
 	[Route("api/opinion")]
 	[ApiController]
 	public class OpinionsController : ControllerBase
 	{
 		private readonly IOpinionService _opinionService;
 		private readonly IMapper _mapper;
 
 		public OpinionsController(IOpinionService opinionService, IMapper mapper)
 		{
 			_opinionService = opinionService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "opinions" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(OpinionResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveOpinionResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var opinion = _mapper.Map<SaveOpinionResource, Opinion>(resource);
 			var result = await _opinionService.SaveAsync(opinion);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var opinionResource = _mapper.Map<Opinion, OpinionResource>(result.Resource);
 			return Ok(opinionResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "opinions" })]
 		[HttpPut("{opinionId}")]
 		[ProducesResponseType(typeof(OpinionResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int opinionId, [FromBody] SaveOpinionResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var opinion = _mapper.Map<SaveOpinionResource, Opinion>(resource);
 			var result = await _opinionService.UpdateAsync(opinionId, opinion);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var opinionResource = _mapper.Map<Opinion, OpinionResource>(result.Resource);
 			return Ok(opinionResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "opinions" })]
 		[HttpGet("{opinionId}")]
 		[ProducesResponseType(typeof(OpinionResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int opinionId)
 		{
 			var result = await _opinionService.GetByIdAsync(opinionId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var opinionResource = _mapper.Map<Opinion, OpinionResource>(result.Resource);
 
 			return Ok(opinionResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "opinions" })]
 		[HttpDelete("{opinionId}")]
 		[ProducesResponseType(typeof(OpinionResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int opinionId)
 		{
 			var result = await _opinionService.DeleteAsync(opinionId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var opinionResource = _mapper.Map<Opinion, OpinionResource>(result.Resource);
 			return Ok(opinionResource);
 		}
 	}
 }
