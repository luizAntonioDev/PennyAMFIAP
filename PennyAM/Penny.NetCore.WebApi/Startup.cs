using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Penny.NetCore.WebApi.Context;
using Penny.NetCore.WebApi.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Penny.NetCore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Injecao de dependecia dos repositories

            services.AddScoped<IAcessoRepository, AcessoRepository>();
            services.AddScoped<ICarrinhoCompraRepository, CarrinhoCompraRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProdutoCarrinhoRepository, ProdutoCarrinhoRepository>();

            //String de conexao que sera utilizada

            services.AddDbContext<PennyContext>(
                options => options.UseSqlServer(Configuration
                                  .GetConnectionString("conexao")));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }, ArrayPool<char>.Shared));
            });


            services.AddHttpContextAccessor();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Penny Api",
                        Version = "v1",
                        Description = "Projeto Penny FIAP",
                        Contact = new Contact { Name = "Grupo Penny" }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
                c.WithMethods("GET", "POST", "PUT", "DELETE", "HEAD", "OPTIONS", "PATCH");
            });


            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((document, request) =>
                {
                    document.Paths = document.Paths.ToDictionary(p => p.Key.ToLowerInvariant(), p => p.Value);
                });
            });

            app.UseSwaggerUI(configuration =>
            {
                configuration.RoutePrefix = "";
                configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Penny V1.0");
                configuration.DocExpansion(DocExpansion.None);

            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
