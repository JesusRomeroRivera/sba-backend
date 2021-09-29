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
 	[Route("api/report")]
 	[ApiController]
 	public class ReportsController : ControllerBase
 	{
 		private readonly IReportService _reportService;
 		private readonly IMapper _mapper;
 
 		public ReportsController(IReportService reportService, IMapper mapper)
 		{
 			_reportService = reportService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "reports" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(ReportResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveReportResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var report = _mapper.Map<SaveReportResource, Report>(resource);
 			var result = await _reportService.SaveAsync(report);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);
 			return Ok(reportResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "reports" })]
 		[HttpPut("{reportId}")]
 		[ProducesResponseType(typeof(ReportResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int reportId, [FromBody] SaveReportResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var report = _mapper.Map<SaveReportResource, Report>(resource);
 			var result = await _reportService.UpdateAsync(reportId, report);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);
 			return Ok(reportResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "reports" })]
 		[HttpGet("{reportId}")]
 		[ProducesResponseType(typeof(ReportResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int reportId)
 		{
 			var result = await _reportService.GetByIdAsync(reportId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);
 
 			return Ok(reportResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "reports" })]
 		[HttpDelete("{reportId}")]
 		[ProducesResponseType(typeof(ReportResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int reportId)
 		{
 			var result = await _reportService.DeleteAsync(reportId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var reportResource = _mapper.Map<Report, ReportResource>(result.Resource);
 			return Ok(reportResource);
 		}
 	}
 }
