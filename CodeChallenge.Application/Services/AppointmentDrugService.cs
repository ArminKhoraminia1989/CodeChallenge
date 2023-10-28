using CodeChallenge.Data.DBContext;
using CodeChallenge.Application.Repository;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Application.Services
{
    public class AppointmentDrugService : IAppointmentDrugRepository
    {
        private readonly CodeChallengeDBContext _context;
        private readonly IGenericRepository<AppointmentDrug> _repAppointmentDrug;

        public AppointmentDrugService(CodeChallengeDBContext context,
            IGenericRepository<AppointmentDrug> repAppointmentDrug)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _repAppointmentDrug = repAppointmentDrug;
        }

        BaseResponse _response = new BaseResponse();

        public Task<BaseResponse> CreateAsync(AppointmentDrug AppointmentDrug)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> UpdateAsync(AppointmentDrug AppointmentDrug)
        {
            throw new NotImplementedException();
        }
    }
}
