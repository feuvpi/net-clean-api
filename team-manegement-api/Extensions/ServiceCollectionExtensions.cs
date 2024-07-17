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
            services.AddScoped<IBaseRepository<Atleta>, AtletaRepository>();
            services.AddScoped<IBaseRepository<Nota>, NotaRepository>();
            services.AddScoped<IBaseRepository<Time>, TimeRepository>();
            services.AddScoped<IBaseRepository<TimeAtleta>, TimeAtletaRepository>();
            services.AddScoped<IBaseRepository<Partida>, PartidaRepository>();
            services.AddScoped<IBaseRepository<PartidaAtleta>, PartidaAtletaRepository>();
            services.AddScoped<IBaseRepository<ExameMedico>, ExameMedicoRepository>();
            services.AddScoped<IBaseRepository<Usuario>, UsuarioRepository>();
            services.AddScoped<IBaseRepository<GrupoPartida>, GrupoPartidaRepository>();

            services.AddScoped<AtletaService>();
            services.AddScoped<NotaService>();
            services.AddScoped<TimeService>();
            services.AddScoped<TimeAtletaService>();
            services.AddScoped<PartidaService>();
            services.AddScoped<PartidaAtletaService>();
            services.AddScoped<ExameMedicoService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<GrupoPartidaService>();
            return services;
        }
    }
}
