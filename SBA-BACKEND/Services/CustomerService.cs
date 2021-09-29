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
 	public class CustomerService : ICustomerService
 	{
 		private readonly ICustomerRepository _customerRepository;
 		private IUnitOfWork _unitOfWork;
 		public CustomerService(ICustomerRepository object1, IUnitOfWork object2)
 		{
 			this._customerRepository = object1;
 			this._unitOfWork = object2;
 		}
 
 		public async Task<CustomerResponse> DeleteAsync(int id)
 		{
 			var existingCustomer = await _customerRepository.FindById(id);
 
 			if (existingCustomer == null)
 				return new CustomerResponse("Customer not found");
 
 			try
 			{
 				_customerRepository.Remove(existingCustomer);
 				await _unitOfWork.CompleteAsync();
 
 				return new CustomerResponse(existingCustomer);
 			}
 			catch (Exception ex)
 			{
 				return new CustomerResponse($"An error ocurred while deleting the customer: {ex.Message}");
 			}
 		}
 
 		public async Task<CustomerResponse> GetByIdAsync(int id)
 		{
 			var existingCustomer = await _customerRepository.FindById(id);
 
 			if (existingCustomer == null)
 				return new CustomerResponse("Customer not found");
 			return new CustomerResponse(existingCustomer);
 		}
 
 		public async Task<IEnumerable<Customer>> ListAsync()
 		{
 			return await _customerRepository.ListAsync();
 		}
 
 		public async Task<CustomerResponse> SaveAsync(Customer customer)
 		{
 			try
 			{
 				await _customerRepository.AddAsync(customer);
 				await _unitOfWork.CompleteAsync();
 				return new CustomerResponse(customer);
 			}
 			catch (Exception e)
 			{
 				return new CustomerResponse($"An error ocurred while saving the customer: {e.Message}");
 			}
 		}
 		public async Task<CustomerResponse> UpdateAsync(int id, Customer customer)
 		{
 			var existingCustomer = await _customerRepository.FindById(id);
 
 			if (existingCustomer == null)
 				return new CustomerResponse("Customer not found");

            //falta llenar los updates

            try
            {
 				_customerRepository.Update(existingCustomer);
 				await _unitOfWork.CompleteAsync();
 				return new CustomerResponse(existingCustomer);
 			}
 			catch (Exception ex)
 			{
 				return new CustomerResponse($"An error ocurred while updating the customer: {ex.Message}");
 			}
 		}
 	}
 }
