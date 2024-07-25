using Hospital.API.Errors;
using Hospital.API.Helpers;
using Hospital.Core.Repositories.Interfaces;
using Hospital.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServiceExtensions(this IServiceCollection services)
        {

            #region
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfile));


            // Handling Validation Error
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                             .SelectMany(P => P.Value.Errors)
                                             .Select(E => E.ErrorMessage).ToArray();

                    var validtionErrorResponse = new ApivalidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(validtionErrorResponse);
                };
            });


            #endregion



            return services;
        }
    }
}
