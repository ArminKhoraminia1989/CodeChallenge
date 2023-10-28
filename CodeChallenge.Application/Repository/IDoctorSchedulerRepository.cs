using CodeChallenge.Core.Entities;
using CodeChallenge.Application.Responses;

namespace CodeChallenge.Application.Repository
{
    public interface IDoctorSchedulerRepository
    {
        Task<BaseResponse> CreateAsync(DoctorScheduler Scheduler);
        Task<BaseResponse> UpdateAsync(DoctorScheduler Scheduler);
        Task<BaseResponse> DeleteAsync(int Id);
        Task<Tuple<DateTime, bool>> GetMaxSchedulDate(int DoctorId);
        Task<Tuple<DateTime, bool>> GetMinSchedulDate(int DoctorId, DateTime dateTime);
    }
}
