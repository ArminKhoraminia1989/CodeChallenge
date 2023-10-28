using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CodeChallenge.Data.DBContext;
using CodeChallenge.Application.Repository.BasicInfo;
using CodeChallenge.Application.Services.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using CodeChallenge.Dtos.BasicInfo.Drug;
using CodeChallenge.Validators.BasicInfo.DoctorType;
using CodeChallenge.Validators.BasicInfo.Drug;
using CodeChallenge.Dtos.Doctor;
using CodeChallenge.Validators.Doctor;
using CodeChallenge.Dtos.DoctorScheduler;
using CodeChallenge.Validators.DoctorScheduler;
using CodeChallenge.Dtos.Patient;
using CodeChallenge.Validators.Patient;
using CodeChallenge.Validators.Appointment;
using CodeChallenge.Validators.AppointmentDrug;
using CodeChallenge.Dtos.Appointment;
using CodeChallenge.Dtos.AppointmentDrug;
using CodeChallenge.Application.Repository;
using CodeChallenge.Application.Services;
using CodeChallenge.Data.Repository.BasicInfo;

namespace CodeChallenge.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection ApplicationServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            #region Connection String

            services.AddDbContext<CodeChallengeDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CodeChallengeConnection"))
            );

            #endregion

            #region MediatR Registerations

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            #endregion

            #region Ioc

            services.AddScoped(typeof(IAppointmentRepository), typeof(AppointmentService));
            services.AddScoped(typeof(IAppointmentDrugRepository), typeof(AppointmentDrugService));
            services.AddScoped(typeof(IDoctorSchedulerRepository), typeof(DoctorSchedulerService));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientService));
            services.AddScoped(typeof(IDoctorTypeRepository), typeof(DoctorTypeService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            #region Validator

            services.AddFluentValidationAutoValidation();

            services.AddTransient<IValidator<CreateDoctorTypeDto>, CreateDoctorTypeValidator>();
            services.AddTransient<IValidator<UpdateDoctorTypeDto>, UpdateDoctorTypeValidator>();
            services.AddTransient<IValidator<DeleteDoctorTypeDto>, DeleteDoctorTypeValidator>();
            services.AddTransient<IValidator<ShowDoctorTypeDto>, ShowDoctorTypeValidator>();

            services.AddTransient<IValidator<CreateDrugDto>, CreateDrugValidator>();
            services.AddTransient<IValidator<UpdateDrugDto>, UpdateDrugValidator>();
            services.AddTransient<IValidator<DeleteDrugDto>, DeleteDrugValidator>();
            services.AddTransient<IValidator<ShowDrugDto>, ShowDrugValidator>();

            services.AddTransient<IValidator<CreateDoctorDto>, CreateDoctorValidator>();
            services.AddTransient<IValidator<UpdateDoctorDto>, UpdateDoctorValidator>();
            services.AddTransient<IValidator<DeleteDoctorDto>, DeleteDoctorValidator>();
            services.AddTransient<IValidator<ShowDoctorDto>, ShowDoctorValidator>();

            services.AddTransient<IValidator<CreateDoctorSchedulerDto>, CreateDoctorSchedulerValidator>();
            services.AddTransient<IValidator<UpdateDoctorSchedulerDto>, UpdateDoctorSchedulerValidator>();
            services.AddTransient<IValidator<DeleteDoctorSchedulerDto>, DeleteDoctorSchedulerValidator>();
            services.AddTransient<IValidator<ShowDoctorSchedulerDto>, ShowDoctorSchedulerValidator>();

            services.AddTransient<IValidator<CreatePatientDto>, CreatePatientValidator>();
            services.AddTransient<IValidator<UpdatePatientDto>, UpdatePatientValidator>();
            services.AddTransient<IValidator<DeletePatientDto>, DeletePatientValidator>();
            services.AddTransient<IValidator<ShowPatientDto>, ShowPatientValidator>();

            services.AddTransient<IValidator<CreateAppointmentDto>, CreateAppointmentValidator>();
            services.AddTransient<IValidator<UpdateAppointmentDto>, UpdateAppointmentValidator>();
            services.AddTransient<IValidator<DeleteAppointmentDto>, DeleteAppointmentValidator>();
            services.AddTransient<IValidator<ShowAppointmentDto>, ShowAppointmentValidator>();

            services.AddTransient<IValidator<CreateAppointmentDrugDto>, CreateAppointmentDrugValidator>();
            services.AddTransient<IValidator<UpdateAppointmentDrugDto>, UpdateAppointmentDrugValidator>();
            services.AddTransient<IValidator<DeleteAppointmentDrugDto>, DeleteAppointmentDrugValidator>();
            services.AddTransient<IValidator<ShowAppointmentDrugDto>, ShowAppointmentDrugValidator>();

            #endregion

            #region Auto Mapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion


            return services;
        }
    }
}
