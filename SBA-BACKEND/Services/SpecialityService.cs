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
 	public class SpecialityService : ISpecialityService
 	{
 		private readonly ISpecialityRepository _specialityRepository;
 		private IUnitOfWork _unitOfWork;
 		public SpecialityService(ISpecialityRepository object1, IUnitOfWork object2)
 		{
 			this._specialityRepository = object1;
 			this._unitOfWork = object2;
 		}
 
 		public async Task<SpecialityResponse> DeleteAsync(int id)
 		{
 			var existingSpeciality = await _specialityRepository.FindById(id);
 
 			if (existingSpeciality == null)
 				return new SpecialityResponse("Speciality not found");
 
 			try
 			{
 				_specialityRepository.Remove(existingSpeciality);
 				await _unitOfWork.CompleteAsync();
 
 				return new SpecialityResponse(existingSpeciality);
 			}
 			catch (Exception ex)
 			{
 				return new SpecialityResponse($"An error ocurred while deleting the speciality: {ex.Message}");
 			}
 		}
 
 		public async Task<SpecialityResponse> GetByIdAsync(int id)
 		{
 			var existingSpeciality = await _specialityRepository.FindById(id);
 
 			if (existingSpeciality == null)
 				return new SpecialityResponse("Speciality not found");
 			return new SpecialityResponse(existingSpeciality);
 		}
 
 		public async Task<IEnumerable<Speciality>> ListAsync()
 		{
 			return await _specialityRepository.ListAsync();
 		}
 
 		public async Task<SpecialityResponse> SaveAsync(Speciality speciality)
 		{
 			try
 			{
 				await _specialityRepository.AddAsync(speciality);
 				await _unitOfWork.CompleteAsync();
 				return new SpecialityResponse(speciality);
 			}
 			catch (Exception e)
 			{
 				return new SpecialityResponse($"An error ocurred while saving the speciality: {e.Message}");
 			}
 		}
 		public async Task<SpecialityResponse> UpdateAsync(int id, Speciality speciality)
 		{
 			var existingSpeciality = await _specialityRepository.FindById(id);
 
 			if (existingSpeciality == null)
 				return new SpecialityResponse("Speciality not found");

            //falta llenar los updates

            try
            {
 				_specialityRepository.Update(existingSpeciality);
 				await _unitOfWork.CompleteAsync();
 				return new SpecialityResponse(existingSpeciality);
 			}
 			catch (Exception ex)
 			{
 				return new SpecialityResponse($"An error ocurred while updating the speciality: {ex.Message}");
 			}
 		}
 	}
 }
