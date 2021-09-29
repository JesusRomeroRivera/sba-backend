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
 	public class ReportService : IReportService
 	{
 		private readonly IReportRepository _reportRepository;
 		private IUnitOfWork _unitOfWork;
 		public ReportService(IReportRepository object1, IUnitOfWork object2)
 		{
 			this._reportRepository = object1;
 			this._unitOfWork = object2;
 		}
 
 		public async Task<ReportResponse> DeleteAsync(int id)
 		{
 			var existingReport = await _reportRepository.FindById(id);
 
 			if (existingReport == null)
 				return new ReportResponse("Report not found");
 
 			try
 			{
 				_reportRepository.Remove(existingReport);
 				await _unitOfWork.CompleteAsync();
 
 				return new ReportResponse(existingReport);
 			}
 			catch (Exception ex)
 			{
 				return new ReportResponse($"An error ocurred while deleting the report: {ex.Message}");
 			}
 		}
 
 		public async Task<ReportResponse> GetByIdAsync(int id)
 		{
 			var existingReport = await _reportRepository.FindById(id);
 
 			if (existingReport == null)
 				return new ReportResponse("Report not found");
 			return new ReportResponse(existingReport);
 		}
 
 		public async Task<IEnumerable<Report>> ListAsync()
 		{
 			return await _reportRepository.ListAsync();
 		}
 
 		public async Task<ReportResponse> SaveAsync(Report report)
 		{
 			try
 			{
 				await _reportRepository.AddAsync(report);
 				await _unitOfWork.CompleteAsync();
 				return new ReportResponse(report);
 			}
 			catch (Exception e)
 			{
 				return new ReportResponse($"An error ocurred while saving the report: {e.Message}");
 			}
 		}
 		public async Task<ReportResponse> UpdateAsync(int id, Report report)
 		{
 			var existingReport = await _reportRepository.FindById(id);
 
 			if (existingReport == null)
 				return new ReportResponse("Report not found");

            //falta llenar los updates

            try
            {
 				_reportRepository.Update(existingReport);
 				await _unitOfWork.CompleteAsync();
 				return new ReportResponse(existingReport);
 			}
 			catch (Exception ex)
 			{
 				return new ReportResponse($"An error ocurred while updating the report: {ex.Message}");
 			}
 		}
 	}
 }
