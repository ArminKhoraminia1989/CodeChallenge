using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;

namespace CodeChallenge.Application.Repository
{
    public interface IAppointmentDrugRepository
    {
        Task<BaseResponse> CreateAsync(AppointmentDrug AppointmentDrug);
        Task<BaseResponse> UpdateAsync(AppointmentDrug AppointmentDrug);
        Task<BaseResponse> DeleteAsync(int Id);
    }
}
