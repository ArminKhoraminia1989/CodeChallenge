using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;

namespace CodeChallenge.Application.Repository
{
    public interface IPatientRepository
    {
        Task<BaseResponse> CreateAsync(Patient Patient);
        Task<BaseResponse> UpdateAsync(Patient Patient);
        Task<BaseResponse> DeleteAsync(int Id);
    }
}
