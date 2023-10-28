using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;

namespace CodeChallenge.Application.Repository
{
    public interface IAppointmentRepository 
    {
        Task<BaseResponse> CreateAsync(Appointment Appointment);
        Task<BaseResponse> UpdateAsync(Appointment Appointment);
        Task<BaseResponse> DeleteAsync(int Id);
        Task<Tuple<DateTime, bool>> SetEarliest(int DoctorId , int PatientId , int DurationonMinuts);
    }
}
