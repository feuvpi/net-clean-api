using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using team_manegement_api.Core;

namespace team_manegement_api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseContext, DapperContext>();
            services.AddTransient<IBaseRepository<Atleta>, AtletaRepository>();
            services.AddTransient<IBaseRepository<Nota>, NotaRepository>();
            services.AddTransient<IBaseRepository<Time>, TimeRepository>();
            services.AddTransient<IBaseRepository<TimeAtleta>, TimeAtletaRepository>();
            services.AddTransient<IBaseRepository<Partida>, PartidaRepository>();
            services.AddTransient<IBaseRepository<PartidaAtleta>, PartidaAtletaRepository>();
            services.AddTransient<IBaseRepository<ExameMedico>, ExameMedicoRepository>();
            services.AddTransient<IBaseRepository<Usuario>, UsuarioRepository>();
            services.AddTransient<IBaseRepository<GrupoPartida>, GrupoPartidaRepository>();

            services.AddTransient<AtletaService>();
            services.AddTransient<NotaService>();
            services.AddTransient<TimeService>();
            services.AddTransient<TimeAtletaService>();
            services.AddTransient<PartidaService>();
            services.AddTransient<PartidaAtletaService>();
            services.AddTransient<ExameMedicoService>();
            services.AddTransient<UsuarioService>();
            services.AddTransient<GrupoPartidaService>();
            return services;
        }
    }
}
