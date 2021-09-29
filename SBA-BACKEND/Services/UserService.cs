using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using SBA_BACKEND.Domain.Models;
 using SBA_BACKEND.Domain.Services.Communications;
 using SBA_BACKEND.Domain.Services;
 using SBA_BACKEND.Domain.Persistence.Repositories;
 
 
 namespace SBA_BACKEND.Services
 {
 	public class UserService : IUserService
 	{
 		private readonly IUserRepository _userRepository;
 		private IUnitOfWork _unitOfWork;
 		public UserService(IUserRepository object1, IUnitOfWork object2)
 		{
 			this._userRepository = object1;
 			this._unitOfWork = object2;
 		}
 
 		public async Task<UserResponse> DeleteAsync(int id)
 		{
 			var existingUser = await _userRepository.FindById(id);
 
 			if (existingUser == null)
 				return new UserResponse("User not found");
 
 			try
 			{
 				_userRepository.Remove(existingUser);
 				await _unitOfWork.CompleteAsync();
 
 				return new UserResponse(existingUser);
 			}
 			catch (Exception ex)
 			{
 				return new UserResponse($"An error ocurred while deleting the user: {ex.Message}");
 			}
 		}
 
 		public async Task<UserResponse> GetByIdAsync(int id)
 		{
 			var existingUser = await _userRepository.FindById(id);
 
 			if (existingUser == null)
 				return new UserResponse("User not found");
 			return new UserResponse(existingUser);
 		}
 
 		public async Task<IEnumerable<User>> ListAsync()
 		{
 			return await _userRepository.ListAsync();
 		}
 
 		public async Task<UserResponse> SaveAsync(User user)
 		{
 			try
 			{
 				await _userRepository.AddAsync(user);
 				await _unitOfWork.CompleteAsync();
 				return new UserResponse(user);
 			}
 			catch (Exception e)
 			{
 				return new UserResponse($"An error ocurred while saving the user: {e.Message}");
 			}
 		}
 		public async Task<UserResponse> UpdateAsync(int id, User user)
 		{
 			var existingUser = await _userRepository.FindById(id);
 
 			if (existingUser == null)
 				return new UserResponse("User not found");

            //falta llenar los updates

            try
            {
 				_userRepository.Update(existingUser);
 				await _unitOfWork.CompleteAsync();
 				return new UserResponse(existingUser);
 			}
 			catch (Exception ex)
 			{
 				return new UserResponse($"An error ocurred while updating the user: {ex.Message}");
 			}
 		}
 	}
 }
