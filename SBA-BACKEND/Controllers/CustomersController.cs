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
 	[Route("api/customer")]
 	[ApiController]
 	public class CustomersController : ControllerBase
 	{
 		private readonly ICustomerService _customerService;
 		private readonly IMapper _mapper;
 
 		public CustomersController(ICustomerService customerService, IMapper mapper)
 		{
 			_customerService = customerService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "customers" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(CustomerResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
 			var result = await _customerService.SaveAsync(customer);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
 			return Ok(customerResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "customers" })]
 		[HttpPut("{customerId}")]
 		[ProducesResponseType(typeof(CustomerResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int customerId, [FromBody] SaveCustomerResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);
 			var result = await _customerService.UpdateAsync(customerId, customer);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
 			return Ok(customerResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "customers" })]
 		[HttpGet("{customerId}")]
 		[ProducesResponseType(typeof(CustomerResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int customerId)
 		{
 			var result = await _customerService.GetByIdAsync(customerId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
 
 			return Ok(customerResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "customers" })]
 		[HttpDelete("{customerId}")]
 		[ProducesResponseType(typeof(CustomerResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int customerId)
 		{
 			var result = await _customerService.DeleteAsync(customerId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);
 			return Ok(customerResource);
 		}
 	}
 }
