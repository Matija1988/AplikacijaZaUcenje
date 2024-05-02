using System.Runtime.CompilerServices;

namespace AplikacijaZaUcenje.Extenzije
{
    public static class AppExtensions
    {
        public static void AddAplikacijaCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
