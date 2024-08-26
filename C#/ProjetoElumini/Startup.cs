using Calculadora.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProjetoElumini
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configura o CORS para permitir requisições de 'http://localhost:4200'
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // Adiciona o suporte para controllers com views
            services.AddControllers();

            // Registra o serviço de cálculo de CDB
            services.AddScoped<ICalculadoraService, CdbCalculatorService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Exibe informações detalhadas de erro em ambiente de desenvolvimento
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Exibe uma página de erro genérica em ambiente de produção
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Redireciona HTTP para HTTPS
            app.UseHttpsRedirection();
            // Serve arquivos estáticos (como CSS, JS e imagens)
            app.UseStaticFiles();
            // Adiciona o roteamento
            app.UseRouting();

            // Aplica a política de CORS
            app.UseCors("AllowSpecificOrigin");

            // Habilita a autorização
            app.UseAuthorization();

            // Configura os endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}