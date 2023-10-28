using CodeChallenge.Application.Repository;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Core.Entities;
using CodeChallenge.Core.Entities.BasicInfo;
using System.Linq.Expressions;

namespace CodeChallenge.Application.Services
{
    public class AppointmentService : IAppointmentRepository
    {
        private readonly IGenericRepository<Appointment> _repAppointment;
        private readonly IGenericRepository<DoctorType> _repDoctorType;
        private readonly IGenericRepository<Doctor> _repDoctor;
        private readonly IGenericRepository<Patient> _repPatient;
        private readonly IGenericRepository<DoctorScheduler> _repDoctorScheduler;
        private readonly IDoctorSchedulerRepository _Scheduler;

        public AppointmentService(
            IGenericRepository<Appointment> repAppointment,
            IGenericRepository<Doctor> repDoctor,
            IGenericRepository<Patient> repPatient,
            IGenericRepository<DoctorType> repDoctorType,
            IGenericRepository<DoctorScheduler> repDoctorScheduler,
            IDoctorSchedulerRepository Scheduler)
        {
            _repAppointment = repAppointment;
            _repDoctorType = repDoctorType;
            _repDoctor = repDoctor;
            _repPatient = repPatient;
            _repDoctorScheduler = repDoctorScheduler;
            _Scheduler = Scheduler;
        }

        BaseResponse _response = new BaseResponse();

        public async Task<BaseResponse> CreateAsync(Appointment Appointment)
        {
            // چک کردن ساعات و روزهای کاری هفته
            if (!(await CheckWeeklyTime(Appointment.StartTime, Appointment.EndTime)))
            {
                _response.Message = ErrorResource.ValidationDayOfWeek;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن اینکه در زمان ایجاد دکتر یا بیمار با این مشخصات وجود داشته باشد
            if (!(await CheckDctorAndPatient(Appointment.DoctorId, Appointment.PatientId)))
            {
                _response.Message = ErrorResource.ValidationDoctorAndPatient;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن حداکثر 2 ویزیت برای یک بیمار در روز
            if (!(await CheckMaxAppointmentForPatientOnDay(Appointment.StartTime, Appointment.PatientId)))
            {
                _response.Message = ErrorResource.MaxAppoinyInDay;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن زمان ویزیت
            if (!(await CheckDuration(Appointment.DoctorId, Appointment.DurationTime)))
            {
                _response.Message = ErrorResource.ValidationDuration;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن زمانبندی دکتر مربوطه
            bool existSchedul = await CheckSchedul(Appointment.DoctorId, Appointment.StartTime, Appointment.EndTime);
            if (!existSchedul)
            {
                _response.Message = ErrorResource.ValidationSchedul;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن اینکه در زمان ایجاد ویزینی با این مشخصات وجود نداشته باشد
            bool exist = await CheckExist(Appointment);
            if (exist)
            {
                _response.Message = ErrorResource.AppointmentExist;
                _response.IsSuccess = false;
                return _response;
            }

            var Create = await _repAppointment.CreateAsync(Appointment);

            _response.Id = Create.Id;
            _response.Message = ErrorResource.CreateSuccess;
            _response.IsSuccess = true;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> DeleteAsync(int Id)
        {
            // چک کردن اینکه در زمان حذف ویزینی با این مشخصات وجود داشته باشد
            var Appoint = await _repAppointment.GetById(Id);
            if (Appoint == null)
            {
                _response.Message = ErrorResource.AppointmentDoesNotExist;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن ساعات و روزهای کاری هفته
            if (!(await CheckWeeklyTime(Appoint.StartTime, Appoint.EndTime)))
            {
                _response.Message = ErrorResource.ValidationDayOfWeek;
                _response.IsSuccess = false;
                return _response;
            }
            // چک کردن اینکه در زمان حذف بیماری با این مشخصات از قبل وقت ملاقات نداشته باشد
            bool existAppoint = await CheckOpenAppoint(Id);
            if (existAppoint)
            {
                _response.Message = ErrorResource.PatientHasVisit;
                _response.IsSuccess = false;
                return _response;
            }

            var delete = await _repAppointment.DeleteAsync(Id);

            _response.Message = ErrorResource.DeleteSuccess;
            _response.IsSuccess = delete;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<BaseResponse> UpdateAsync(Appointment Appointment)
        {
            // چک کردن اینکه در زمان اصلاح بیماری با این مشخصات از قبل وقت ملاقات باز نداشته باشد
            //bool exist = await CheckOpenAppoint(Appointment.Id);
            //if (exist)
            //{
            //    _response.Message = ErrorResource.SchedulerConflict;
            //    _response.IsSuccess = false;
            //    return _response;
            //}

            //var update = await _repAppointment.UpdateAsync(Appointment);

            _response.Message = ErrorResource.UpdateSuccess;
            _response.IsSuccess = true;
            _response.CodeStatus = 200;

            return _response;
        }

        public async Task<Tuple<DateTime, bool>> SetEarliest(int DoctorId, int PatientId, int DurationonMinuts)
        {
            // محاسبه حداکثر زمانبندی دکتر 
            var MaxSchedul = await _Scheduler.GetMaxSchedulDate(DoctorId);
            if (!MaxSchedul.Item2) return Tuple.Create(DateTime.Now, false);

            // ست کردن مقادیر اولیه برای زمان
            DateTime TempDateTimeStart = DateTime.Now;
            DateTime TempDateTimeEnd = TempDateTimeStart.AddMinutes(DurationonMinuts);

            while (TempDateTimeEnd < MaxSchedul.Item1)
            {
                // اگر زمان در زمانبندی دکتر در آن روز نبود یا بیمار در آن 
                // روز 2 بار نوبت داشت یک روز جلوتر را چک کند
                if (!Utilities.Utilities.CheckDayOfWeek(TempDateTimeStart, TempDateTimeEnd)
                    ||
                    !(await CheckMaxAppointmentForPatientOnDay(TempDateTimeStart, PatientId)))
                {
                    TempDateTimeStart = TempDateTimeStart.AddDays(1);
                    TempDateTimeStart = new DateTime(TempDateTimeStart.Year, TempDateTimeStart.Month, TempDateTimeStart.Day, 09, 00, 00, 00);
                    var TmpMinSchedul = await _Scheduler.GetMinSchedulDate(DoctorId, TempDateTimeStart);

                    if (!TmpMinSchedul.Item2) return Tuple.Create(DateTime.Now, false);

                    TempDateTimeStart = TmpMinSchedul.Item1;
                    TempDateTimeEnd = TempDateTimeStart.AddMinutes(DurationonMinuts);
                }

                // زمان محاسبه شده از حداکثر زمانبندی دکتر بالا نزند
                if (TempDateTimeStart > MaxSchedul.Item1 || TempDateTimeEnd > MaxSchedul.Item1)
                    Tuple.Create(TempDateTimeStart, false);

                // چک کردن اینکه در این زمان رزرو دیگری هست یا نه
                Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> Filter = (v =>
                ((v.StartTime <= TempDateTimeStart && TempDateTimeStart <= v.EndTime) ||
                (v.StartTime <= TempDateTimeEnd && TempDateTimeEnd <= v.EndTime) ||
                (TempDateTimeStart <= v.StartTime && TempDateTimeEnd >= v.EndTime)) &&
                ((v.DoctorId == DoctorId || v.PatientId == PatientId)));

                var Appoint = await _repAppointment.FindIdByFilter(Filter);

                if (Appoint == null)
                    return Tuple.Create(TempDateTimeStart, true);
                else
                {
                    // اگر این زمان رزرو دیگری بود ابتدای زمان از انتهای زمان رزرو بدست می آید
                    TempDateTimeStart = Appoint.EndTime.AddMinutes(1);
                    TempDateTimeEnd = TempDateTimeStart.AddMinutes(DurationonMinuts);
                }
            }

            return Tuple.Create(DateTime.Now, false);
        }

        private async Task<bool> CheckExist(Appointment Appointment)
        {
            Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> Filter = (v =>
            ((v.StartTime <= Appointment.StartTime && Appointment.StartTime <= v.EndTime) ||
                (v.StartTime <= Appointment.EndTime && Appointment.EndTime <= v.EndTime) ||
                (Appointment.StartTime <= v.StartTime && Appointment.EndTime >= v.EndTime)) &&
                ((v.DoctorId == Appointment.DoctorId || v.PatientId == Appointment.PatientId) &&
                v.IsVisitByDoctor == false));

            var Appoint = await _repAppointment.FindIdByFilter(Filter);

            if (Appoint == null)
                return false;
            else
                return true;
        }
        private async Task<bool> CheckAppoint(int Id)
        {
            Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> Filter = (x => x.PatientId == Id);
            var Appoint = await _repAppointment.FindIdByFilter(Filter);

            if (Appoint == null)
                return false;
            else
                return true;
        }
        private async Task<bool> CheckOpenAppoint(int Id)
        {
            Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> Filter = (
            x => x.PatientId == Id && x.IsVisitByDoctor == false);
            var Appoint = await _repAppointment.FindIdByFilter(Filter);

            if (Appoint == null)
                return false;
            else
                return true;
        }
        private async Task<bool> CheckDuration(int TypeDoctorId, int Duration)
        {
            var doctor = await _repDoctor.GetById(TypeDoctorId);
            var type = await _repDoctorType.GetById(doctor.TypeDoctorId);

            if (type == null) return false;
            if (!(Duration >= type.MinTimeVisit && Duration <= type.MaxTimeVisit)) return false;
            return true;
        }
        private async Task<bool> CheckSchedul(int DoctorId, DateTime StartDate, DateTime EndDate)
        {
            Expression<Func<CodeChallenge.Core.Entities.DoctorScheduler, bool>> Filter = (x =>
            x.DoctorId == DoctorId &&
            x.StartTime <= StartDate && x.EndTime >= StartDate &&
            x.StartTime <= EndDate && x.EndTime >= EndDate);

            var Schedul = await _repDoctorScheduler.FindIdByFilter(Filter);
            if (Schedul == null) return false;
            return true;
        }
        private async Task<bool> CheckDctorAndPatient(int DoctorId, int PatientId)
        {
            var doctor = await _repDoctor.GetById(DoctorId);
            if (doctor == null) return false;

            var patient = await _repPatient.GetById(PatientId);
            if (patient == null) return false;

            return true;
        }
        private async Task<bool> CheckWeeklyTime(DateTime StartDate, DateTime EndDate)
        {
            return Utilities.Utilities.CheckDayOfWeek(StartDate, EndDate);
        }
        private async Task<bool> CheckMaxAppointmentForPatientOnDay(DateTime StartDate, int PatientId)
        {
            DateTime TempStartSate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 00, 00, 00, 00);
            DateTime TempEndSate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 23, 59, 59, 00);

            Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> Filter = (v =>
            ((v.StartTime <= TempStartSate && TempStartSate <= v.EndTime) ||
                (v.StartTime <= TempEndSate && TempEndSate <= v.EndTime) ||
                (TempStartSate <= v.StartTime && TempEndSate >= v.EndTime)) &&
                v.PatientId == PatientId);

            var CountAppoint = await _repAppointment.GetCount(Filter);

            if (CountAppoint >= 2) return false;

            return true;
        }
    }
}
