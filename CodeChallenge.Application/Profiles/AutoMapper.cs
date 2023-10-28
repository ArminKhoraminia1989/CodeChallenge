using AutoMapper;
using CodeChallenge.Core.Entities;
using CodeChallenge.Core.Entities.BasicInfo;
using CodeChallenge.Dtos.Appointment;
using CodeChallenge.Dtos.AppointmentDrug;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using CodeChallenge.Dtos.BasicInfo.Drug;
using CodeChallenge.Dtos.Doctor;
using CodeChallenge.Dtos.DoctorScheduler;
using CodeChallenge.Dtos.Patient;

namespace CodeChallenge.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            #region DoctorType

            CreateMap<DoctorType, CreateDoctorTypeDto>().ReverseMap();
            CreateMap<DoctorType, UpdateDoctorTypeDto>().ReverseMap();
            CreateMap<DoctorType, DeleteDoctorTypeDto>().ReverseMap();
            CreateMap<DoctorType, ShowAllDoctorTypeDto>().ReverseMap();
            CreateMap<DoctorType, ShowDoctorTypeDto>().ReverseMap();

            #endregion

            #region Drug

            CreateMap<Drug, CreateDrugDto>().ReverseMap();
            CreateMap<Drug, UpdateDrugDto>().ReverseMap();
            CreateMap<Drug, DeleteDrugDto>().ReverseMap();
            CreateMap<Drug, ShowAllDrugDto>().ReverseMap();
            CreateMap<Drug, ShowDrugDto>().ReverseMap();

            #endregion

            #region Doctor

            CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();
            CreateMap<Doctor, DeleteDoctorDto>().ReverseMap();
            CreateMap<Doctor, ShowAllDoctorDto>().ReverseMap();
            CreateMap<Doctor, ShowDoctorDto>().ReverseMap();

            #endregion

            #region DoctorScheduler

            CreateMap<DoctorScheduler, CreateDoctorSchedulerDto>().ReverseMap();
            CreateMap<DoctorScheduler, UpdateDoctorSchedulerDto>().ReverseMap();
            CreateMap<DoctorScheduler, DeleteDoctorSchedulerDto>().ReverseMap();
            CreateMap<DoctorScheduler, ShowAllDoctorSchedulerDto>().ReverseMap();
            CreateMap<DoctorScheduler, ShowDoctorSchedulerDto>().ReverseMap();

            #endregion

            #region Patient

            CreateMap<Patient, CreatePatientDto>().ReverseMap();
            CreateMap<Patient, UpdatePatientDto>().ReverseMap();
            CreateMap<Patient, DeletePatientDto>().ReverseMap();
            CreateMap<Patient, ShowAllPatientDto>().ReverseMap();
            CreateMap<Patient, ShowPatientDto>().ReverseMap();

            #endregion

            #region Appointment

            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, DeleteAppointmentDto>().ReverseMap();
            CreateMap<Appointment, ShowAllAppointmentDto>().ReverseMap();
            CreateMap<Appointment, ShowAppointmentDto>().ReverseMap();

            #endregion

            #region AppointmentDrug

            CreateMap<AppointmentDrug, CreateAppointmentDrugDto>().ReverseMap();
            CreateMap<AppointmentDrug, UpdateAppointmentDrugDto>().ReverseMap();
            CreateMap<AppointmentDrug, DeleteAppointmentDrugDto>().ReverseMap();
            CreateMap<AppointmentDrug, ShowAllAppointmentDrugDto>().ReverseMap();
            CreateMap<AppointmentDrug, ShowAppointmentDrugDto>().ReverseMap();

            #endregion
        }
    }
}
