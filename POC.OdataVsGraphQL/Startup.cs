using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using POC.GraphQL;
using POC.GraphQL.Types;
using POC.Model;
using Splat;

namespace POC.OdataVsGraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllers();
        //    services.AddOData();
        //    services.AddMvc(option => option.EnableEndpointRouting = false);
        //}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);

            services.AddOData();

            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver((h, x) => s.GetServices(h)));//para poder injetar repositório na classe BlogQuery
            services.AddScoped<TestSchema>();
            services.AddScoped<TestQuery>();
            services.AddScoped<PessoaFisicaType>();
            services.AddScoped<TelefoneType>();
            services.AddApplicationInsightsTelemetry();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    //app.UseEndpoints(endpoints =>
        //    //{
        //    //    endpoints.MapControllers();
        //    //});
        //    var builder = new ODataConventionModelBuilder(app.ApplicationServices);

        //    builder.EntitySet<PessoaFisica>("PessoaFisica");

        //    app.UseMvc(routeBuilder =>
        //    {
        //        // and this line to enable OData query option, for example $filter
        //        routeBuilder.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

        //        routeBuilder.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

        //        // uncomment the following line to Work-around for #1175 in beta1
        //        routeBuilder.EnableDependencyInjection();
        //    });
        //    //app.UseMvc(o =>
        //    //{
        //    //    o.EnableDependencyInjection();
        //    //    o.Expand().Filter().Count().Select().OrderBy();
        //    //    o.MapODataServiceRoute("api", "odataapi", GetEdmModel());
        //    //});
        //}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseGraphiQl();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }

        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<PessoaFisica>("PessoaFisica");

            return odataBuilder.GetEdmModel();
        }

        //public static IEdmModel GetEdmModel()
        //{
        //    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

        //    // Habilita funções OData como $filter, $select e etc..
        //    builder.EntitySet<PessoaFisica>(nameof(PessoaFisica));
        //    return builder.GetEdmModel();
        //}
    }
}
