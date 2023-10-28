
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities.BasicInfo;
using CodeChallenge.Core.Entities.Enums;
using System.Linq.Expressions;
using CodeChallenge.Application.Repository.BasicInfo;

namespace CodeChallenge.Application.Services.BasicInfo
{
    public class DoctorTypeService : IDoctorTypeRepository
    {

        private IGenericRepository<DoctorType> _repDoctorType;

        public DoctorTypeService(IGenericRepository<DoctorType> repDoctorType)
        {
            _repDoctorType = repDoctorType;
        }

        public async Task<BaseResponse> CheckData(DoctorType DoctorType, string Mode)
        {
            BaseResponse response = new BaseResponse();

            if (Mode == "Create" || Mode == "Update")
            {
                if (!Utilities.Utilities.CheckTypeDoctor(DoctorType.Type))
                {
                    response.Message = ErrorResource.TypeDoctorCheck;
                    response.IsSuccess = false;
                    return response;
                }

                if (DoctorType.Type == EnumDoctorType.General)
                {
                    if (!(DoctorType.MinTimeVisit == 5 && DoctorType.MaxTimeVisit == 15))
                    {
                        response.Message = ErrorResource.GereralTimeAppointment;
                        response.IsSuccess = false;
                        return response;
                    }
                }
                if (DoctorType.Type == EnumDoctorType.Specialist)
                {
                    if (!(DoctorType.MinTimeVisit == 10 && DoctorType.MaxTimeVisit == 30))
                    {
                        response.Message = ErrorResource.SpecialistTimeAppointment;
                        response.IsSuccess = false;
                        return response;
                    }
                }
            }

            Expression<Func<DoctorType, bool>> queryFilter = x => x.Type == DoctorType.Type;

            switch (Mode)
            {
                case "Create":
                    var create = _repDoctorType.CreateAsync(DoctorType, queryFilter);
                    if (create.Exception.InnerException.Message is null)
                    {
                        response.Id = create.Id;
                        response.Message = ErrorResource.CreateSuccess;
                        response.IsSuccess = true;
                        response.CodeStatus = 200;
                        break;
                    }
                    else
                    {
                        response.Message = create.Exception.InnerException.Message;
                        response.IsSuccess = false;
                        break;
                    }

                case "Update":
                    var update = await _repDoctorType.UpdateAsync(DoctorType, queryFilter);
                    if (update == true)
                    {
                        response.Id = DoctorType.Id;
                        response.Message = ErrorResource.UpdateSuccess;
                        response.IsSuccess = true;
                        response.CodeStatus = 200;
                        break;
                    }
                    else
                    {
                        response.Message = ErrorResource.UpdateNotSuccess;
                        response.IsSuccess = false;
                        break;
                    }

                case "Delete":
                    var delete = await _repDoctorType.DeleteAsync(DoctorType.Id);
                    if (delete == true)
                    {
                        response.Id = DoctorType.Id;
                        response.Message = ErrorResource.DeleteSuccess;
                        response.IsSuccess = true;
                        response.CodeStatus = 200;
                        break;
                    }
                    else
                    {
                        response.Message = ErrorResource.DeleteNotSuccess;
                        response.IsSuccess = false;
                        break;
                    }
                default:
                    response.IsSuccess = false;
                    break;
            }
            return response;
        }
    }
}
