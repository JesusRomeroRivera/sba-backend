using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class UserResponse : BaseResponse<User>
	{
		public UserResponse(User resource) : base(resource)
		{
		}

		public UserResponse(string message) : base(message)
		{
		}
	}
}
