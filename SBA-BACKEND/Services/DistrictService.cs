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
 	public class DistrictService : IDistrictService
 	{
 		private readonly IDistrictRepository _districtRepository;
 		private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DistrictResponse> DeleteAsync(int id)
 		{
 			var existingDistrict = await _districtRepository.FindById(id);
 
 			if (existingDistrict == null)
 				return new DistrictResponse("District not found");
 
 			try
 			{
 				_districtRepository.Remove(existingDistrict);
 				await _unitOfWork.CompleteAsync();
 
 				return new DistrictResponse(existingDistrict);
 			}
 			catch (Exception ex)
 			{
 				return new DistrictResponse($"An error ocurred while deleting the district: {ex.Message}");
 			}
 		}
 
 		public async Task<DistrictResponse> GetByIdAsync(int id)
 		{
 			var existingDistrict = await _districtRepository.FindById(id);
 
 			if (existingDistrict == null)
 				return new DistrictResponse("District not found");
 			return new DistrictResponse(existingDistrict);
 		}
 
 		public async Task<IEnumerable<District>> ListAsync()
 		{
 			return await _districtRepository.ListAsync();
 		}
 
 		public async Task<DistrictResponse> SaveAsync(District district)
 		{
 			try
 			{
 				await _districtRepository.AddAsync(district);
 				await _unitOfWork.CompleteAsync();
 				return new DistrictResponse(district);
 			}
 			catch (Exception e)
 			{
 				return new DistrictResponse($"An error ocurred while saving the district: {e.Message}");
 			}
 		}
 		public async Task<DistrictResponse> UpdateAsync(int id, District district)
 		{
 			var existingDistrict = await _districtRepository.FindById(id);
 
 			if (existingDistrict == null)
 				return new DistrictResponse("District not found");
 
 			//falta llenar los updates
 
 			try
 			{
 				_districtRepository.Update(existingDistrict);
 				await _unitOfWork.CompleteAsync();
 				return new DistrictResponse(existingDistrict);
 			}
 			catch (Exception ex)
 			{
 				return new DistrictResponse($"An error ocurred while updating the district: {ex.Message}");
 			}
 		}
 	}
 }
