using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities.BasicInfo;

namespace CodeChallenge.Application.Repository.BasicInfo
{
    public interface IDoctorTypeRepository
    {
        Task<BaseResponse> CheckData(DoctorType DoctorType , string Mode);
    }
}
