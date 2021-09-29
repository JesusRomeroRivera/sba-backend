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
 	[Route("api/user")]
 	[ApiController]
 	public class UsersController : ControllerBase
 	{
 		private readonly IUserService _userService;
 		private readonly IMapper _mapper;
 
 		public UsersController(IUserService userService, IMapper mapper)
 		{
 			_userService = userService;
 			_mapper = mapper;
 		}
 
 		[SwaggerOperation(Tags = new[] { "users" })]
 		[HttpPost]
 		[ProducesResponseType(typeof(UserResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 			var user = _mapper.Map<SaveUserResource, User>(resource);
 			var result = await _userService.SaveAsync(user);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var userResource = _mapper.Map<User, UserResource>(result.Resource);
 			return Ok(userResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "users" })]
 		[HttpPut("{userId}")]
 		[ProducesResponseType(typeof(UserResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> PutAsync(int userId, [FromBody] SaveUserResource resource)
 		{
 			if (!ModelState.IsValid)
 				return BadRequest(ModelState.GetErrorMessages());
 
 			var user = _mapper.Map<SaveUserResource, User>(resource);
 			var result = await _userService.UpdateAsync(userId, user);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var userResource = _mapper.Map<User, UserResource>(result.Resource);
 			return Ok(userResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "users" })]
 		[HttpGet("{userId}")]
 		[ProducesResponseType(typeof(UserResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> GetAsync(int userId)
 		{
 			var result = await _userService.GetByIdAsync(userId);
 
 			if (!result.Success)
 				return BadRequest(result.Message);
 
 			var userResource = _mapper.Map<User, UserResource>(result.Resource);
 
 			return Ok(userResource);
 		}
 
 		[SwaggerOperation(Tags = new[] { "users" })]
 		[HttpDelete("{userId}")]
 		[ProducesResponseType(typeof(UserResource), 200)]
 		[ProducesResponseType(typeof(BadRequestResult), 404)]
 		public async Task<IActionResult> DeleteAsync(int userId)
 		{
 			var result = await _userService.DeleteAsync(userId);
 			if (!result.Success)
 				return BadRequest(result.Message);
 			var userResource = _mapper.Map<User, UserResource>(result.Resource);
 			return Ok(userResource);
 		}
 	}
 }
