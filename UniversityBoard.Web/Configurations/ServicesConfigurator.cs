﻿namespace UniversityBoard.Web.Configurations
{
    using Microsoft.Extensions.DependencyInjection;

    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.BLL.Services;

    public static class ServicesConfigurator
    {
        public static void ConfigureBllServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IGroupServices, GroupServices>();
            services.AddTransient<IExamInfoServices, ExamInfoServices>();
            services.AddTransient<IAcademicDisciplineService, AcademicDisciplineService>();
            services.AddTransient<IEducationalDirectionServices, EducationalDirectionServices>();
            services.AddTransient<IAcademicDepartamentService, AcademicDepartamentServices>();
            services.AddTransient<IAttestationService, AttestationService>();
        }
    }
}