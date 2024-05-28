using Microsoft.OpenApi.Models;

namespace TasksAPI.Services.Extensions
{
    public static class SwaggerDocExtension
    {
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                new OpenApiInfo
                {

                    Title = "TasksAPI",
                    Description = "API para controle de tarefas",

                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Felipe Honorio",
                        Email = "felipehonoriomoraes01@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/felipe-honorio-b3aab7150/")
                    }
                });
                options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement
                (new OpenApiSecurityRequirement
                {

                {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                },

                        new List<string>()

                    }
                });
            });
            return services;
        }
        public static IApplicationBuilder UseSwaggerDoc
       (this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TasksAPI");
            });
            return app;
        }
    }
}
