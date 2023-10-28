using Azure;
using CodeChallenge.Data.DBContext;
using CodeChallenge.Application.Repository;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeChallenge.Application.Services
{
    public class DoctorSchedulerService : IDoctorSchedulerRepository
    {

        private readonly CodeChallengeDBContext _context;
        private readonly IGenericRepository<DoctorScheduler> _repDoctorScheduler;
        private readonly IGenericRepository<Doctor> _repDoctor;

        public DoctorSchedulerService(CodeChallengeDBContext context,
            IGenericRepository<DoctorScheduler> repDoctorScheduler,
            IGenericRepository<Doctor> repDoctor)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _repDoctorScheduler = repDoctorScheduler;
            _repDoctor = repDoctor;
        }

        BaseResponse _response = new BaseResponse();

        public async Task<BaseResponse> CreateAsync(DoctorScheduler Scheduler)
        {
            // چک کردن ساعات و روزهای کاری هفته
            if (!(Utilities.Utilities.CheckDayOfWeek(Scheduler.StartTime, Scheduler.EndTime)))
            {
                _response.Message = ErrorResource.ValidationDayOfWeek;
                _response.IsSuccess = false;
                return _response;
            }

            bool exist = CheckExist(Scheduler); // چک کردن اینکه در زمان ایجاد تداخل زمانی وجود نداشته باشد
            if (exist)
            {
                _response.Message = ErrorResource.SchedulerConflict;
                _response.IsSuccess = false;
                return _response;
            }

            // چک کردن وجود داشتن دکتر
            if (!(await CheckExistDoctor(Scheduler.DoctorId)))
            {
                _response.Message = ErrorResource.DoctorNotExist;
                _response.IsSuccess = false;
                return _response;
            }

            // چک کردن تاریخ
            if (!Utilities.Utilities.CheckDate(Scheduler.StartTime, Scheduler.EndTime))
            {
                _response.Message = ErrorResource.DateCheck;
                _response.IsSuccess = false;
                return _response;
            }

            var Create = await _repDoctorScheduler.CreateAsync(Scheduler);

            _response.Id = Create.Id;
            _response.Message = ErrorResource.CreateSuccess;
            _response.IsSuccess = true;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> DeleteAsync(int Id)
        {
            var Scheduler = _context.DoctorScheduler.Find(Id); // چک کردن اینکه زمان بندی مورد نظر وجود داشته باشد
            if (Scheduler == null)
            {
                _response.Message = ErrorResource.SchedulerExistVisit;
                _response.IsSuccess = false;
                return _response;
            }
            bool existVisit = CheckVisit(Scheduler); // چک کردن اینکه در زمان حذف از قبل وقت ملاقات نداشته باشد
            if (existVisit)
            {
                _response.Message = ErrorResource.SchedulerExistVisit;
                _response.IsSuccess = false;
                return _response;
            }

            var delete = await _repDoctorScheduler.DeleteAsync(Scheduler.Id);

            _response.Message = ErrorResource.DeleteSuccess;
            _response.IsSuccess = delete;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> UpdateAsync(DoctorScheduler Scheduler)
        {
            // چک کردن تاریخ
            if (!Utilities.Utilities.CheckDate(Scheduler.StartTime, Scheduler.EndTime))
            {
                _response.Message = ErrorResource.DateCheck;
                _response.IsSuccess = false;
                return _response;
            }

            bool exist = CheckConflict(Scheduler); // چک کردن اینکه در زمان اصلاح تداخل زمانی وجود نداشته باشد
            if (exist)
            {
                _response.Message = ErrorResource.SchedulerConflict;
                _response.IsSuccess = false;
                return _response;
            }

            var update = await _repDoctorScheduler.UpdateAsync(Scheduler);

            _response.Message = ErrorResource.UpdateSuccess;
            _response.IsSuccess = update;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<Tuple<DateTime, bool>> GetMaxSchedulDate(int DoctorId)
        {
            var MaxSchedul = _context.DoctorScheduler.Where(c => c.DoctorId == DoctorId && c.EndTime >= DateTime.Now)
                 .OrderBy(c => c.EndTime).LastOrDefault();

            if (MaxSchedul == null)
                return Tuple.Create(DateTime.Now, false);

            return Tuple.Create(MaxSchedul.EndTime, true);
        }
        public async Task<Tuple<DateTime, bool>> GetMinSchedulDate(int DoctorId, DateTime dateTime)
        {
            var MinSchedul = _context.DoctorScheduler.Where(c => c.DoctorId == DoctorId &&
                 c.StartTime <= dateTime && c.EndTime >= dateTime)
                .OrderBy(c => c.StartTime).FirstOrDefault();

            if (MinSchedul == null)
            {
                MinSchedul = _context.DoctorScheduler.Where(
                    c => c.DoctorId == DoctorId && c.StartTime >= dateTime)
                    .OrderBy(c => c.StartTime).FirstOrDefault();
                if (MinSchedul == null)
                    return Tuple.Create(dateTime, false);

                return Tuple.Create(MinSchedul.StartTime, true);
            }
            else
                return Tuple.Create(dateTime, true);
        }

        private bool CheckExist(DoctorScheduler Scheduler)
        {
            var exist = _context.DoctorScheduler
                .FirstOrDefault(s => ((s.StartTime <= Scheduler.StartTime && Scheduler.StartTime <= s.EndTime) ||
                (s.StartTime <= Scheduler.EndTime && Scheduler.EndTime <= s.EndTime) ||
                (Scheduler.StartTime <= s.StartTime && Scheduler.EndTime >= s.EndTime)) &&
                (s.DoctorId == Scheduler.DoctorId));

            if (exist == null)
                return false;
            else
                return true;
        }
        private bool CheckConflict(DoctorScheduler Scheduler)
        {
            var conflict = _context.DoctorScheduler
                .FirstOrDefault(s => ((s.StartTime <= Scheduler.StartTime && Scheduler.StartTime <= s.EndTime) ||
                (s.StartTime <= Scheduler.EndTime && Scheduler.EndTime <= s.EndTime) ||
                (Scheduler.StartTime <= s.StartTime && Scheduler.EndTime >= s.EndTime)) &&
                (s.DoctorId == Scheduler.DoctorId) &&
                (s.Id != Scheduler.Id));

            if (conflict == null)
                return false;
            else
                return true;
        }
        private bool CheckVisit(DoctorScheduler Scheduler)
        {
            var visit = _context.Appointment
                .FirstOrDefault(v => ((v.StartTime <= Scheduler.StartTime && Scheduler.StartTime <= v.EndTime) ||
                (v.StartTime <= Scheduler.EndTime && Scheduler.EndTime <= v.EndTime) ||
                (Scheduler.StartTime <= v.StartTime && Scheduler.EndTime >= v.EndTime)) &&
                (v.DoctorId == Scheduler.DoctorId && v.IsVisitByDoctor == true));

            if (visit == null)
                return false;
            else
                return true;
        }
        private async Task<bool> CheckExistDoctor(int id)
        {
            Expression<Func<CodeChallenge.Core.Entities.Doctor, bool>> DoctorFilter = x => x.Id == id;
            return await _repDoctor.ExistFilter(DoctorFilter);
        }

    }
}
