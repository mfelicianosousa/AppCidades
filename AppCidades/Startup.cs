using AppCidades.Adapter;
using AppCidades.Bordas.Adapter;
using AppCidades.Bordas.Repositorios;
using AppCidades.Context;
using AppCidades.Entities;
using AppCidades.Repositorio;
using AppCidades.Services;
using AppCidades.UseCase.Pessoa;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCidades
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LocalDbContext>(opt => opt
             .UseNpgsql(Configuration.GetConnectionString("urlSquadra")));


            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IAdicionarPessoaUseCase, AdicionarPessoaUseCase>();
            services.AddScoped<IAtualizarPessoaUseCase, AtualizarPessoaUseCase>();
            services.AddScoped<IRemoverPessoaUseCase, RemoverPessoaUseCase>();
            services.AddScoped<IRetornarListaPessoaUseCase, RetornarListaPessoaUseCase>();
            services.AddScoped<IRetornarPessoaPorIdUseCase, RetornarPessoaPorIdUseCase>();
            services.AddScoped<IRepositorioPessoas, RepositorioPessoas>();
            services.AddScoped<IAdicionarPessoaAdapter, AdicionarPessoaAdapter>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                */
                endpoints.MapControllers();
            });
        }
    }
}
