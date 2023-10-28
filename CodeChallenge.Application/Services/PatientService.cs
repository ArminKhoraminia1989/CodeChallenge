using Azure;
using CodeChallenge.Data.DBContext;
using CodeChallenge.Application.Repository;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Application.Services
{
    public class PatientService : IPatientRepository
    {
        private readonly CodeChallengeDBContext _context;
        private readonly IGenericRepository<Patient> _repPatient;

        public PatientService(CodeChallengeDBContext context,IGenericRepository<Patient> repPatient)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _repPatient = repPatient;
        }

        BaseResponse _response = new BaseResponse();

        public async Task<BaseResponse> CreateAsync(Patient Patient)
        {
            bool exist = CheckExist(Patient); // چک کردن اینکه در زمان ایجاد بیماری با این مشخصات وجود نداشته باشد
            if (exist)
            {
                _response.Message = ErrorResource.PatientExist;
                _response.IsSuccess = false;
                return _response;
            }

            if (!Utilities.Utilities.CheckGender(Patient.Gender)) // چک کردن جنسیت
            {
                _response.Message = ErrorResource.GenderCheck;
                _response.IsSuccess = false;
                return _response;
            }

            var Create = await _repPatient.CreateAsync(Patient);

            _response.Id = Create.Id;
            _response.Message = ErrorResource.CreateSuccess;
            _response.IsSuccess = true;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> DeleteAsync(int Id)
        {
            var Patient = _repPatient.GetById(Id); // چک کردن اینکه در زمان حذف بیماری با این مشخصات وجود داشته باشد
            if (Patient == null)
            {
                _response.Message = ErrorResource.PatientNotExist;
                _response.IsSuccess = false;
                return _response;
            }
            bool existVisit = CheckVisit(Id); // چک کردن اینکه در زمان حذف بیماری با این مشخصات از قبل وقت ملاقات نداشته باشد
            if (existVisit)
            {
                _response.Message = ErrorResource.PatientHasVisit;
                _response.IsSuccess = false;
                return _response;
            }

            var delete = await _repPatient.DeleteAsync(Id);

            _response.Message = ErrorResource.DeleteSuccess;
            _response.IsSuccess = delete;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> UpdateAsync(Patient Patient)
        {
            bool existPatient = CheckExistUpdate(Patient); // چک کردن اینکه در زمان ایجاد بیماری با این مشخصات وجود نداشته باشد
            if (existPatient)
            {
                _response.Message = ErrorResource.PatientExist;
                _response.IsSuccess = false;
                return _response;
            }

            bool existVisit = CheckOpenVisit(Patient.Id); // چک کردن اینکه در زمان اصلاح بیماری با این مشخصات از قبل وقت ملاقات باز نداشته باشد
            if (existVisit)
            {
                _response.Message = ErrorResource.SchedulerConflict;
                _response.IsSuccess = false;
                return _response;
            }

            if (!Utilities.Utilities.CheckGender(Patient.Gender)) // چک کردن جنسیت
            {
                _response.Message = ErrorResource.GenderCheck;
                _response.IsSuccess = false;
                return _response;
            }

            var update = await _repPatient.UpdateAsync(Patient);

            _response.Message = ErrorResource.UpdateSuccess;
            _response.IsSuccess = update;
            _response.CodeStatus = 200;

            return _response;
        }

        private bool CheckExist(Patient Patient)
        {
            var tmpPatient = _context.Patient.FirstOrDefault(p =>
            (p.FirstName == Patient.FirstName && p.LastName == Patient.LastName) ||
                p.NationalCode == Patient.NationalCode || p.EmailAddress == Patient.EmailAddress);

            if (tmpPatient == null)
                return false;
            else
                return true;
        }
        private bool CheckExistUpdate(Patient Patient)
        {
            var tmpPatient = _context.Patient.FirstOrDefault(p =>
            ((p.FirstName == Patient.FirstName && p.LastName == Patient.LastName) ||
                p.NationalCode == Patient.NationalCode || p.EmailAddress == Patient.EmailAddress) &&
                p.Id != Patient.Id);

            if (tmpPatient == null)
                return false;
            else
                return true;
        }

        private bool CheckVisit(int Id)
        {
            var tmpVisit = _context.Appointment.FirstOrDefault(v => v.PatientId == Id);
            if (tmpVisit == null)
                return false;
            else
                return true;
        }

        private bool CheckOpenVisit(int Id)
        {
            var tmpVisit = _context.Appointment.FirstOrDefault(v => v.PatientId == Id && v.IsVisitByDoctor == false);
            if (tmpVisit == null)
                return false;
            else
                return true;
        }
    }
}
