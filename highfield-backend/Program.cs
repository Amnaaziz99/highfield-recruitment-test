using HighfieldRecruitment.Controllers;

namespace HighfieldRecruitment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureServices((context, services) =>
            {
                services.AddControllers();

                services.AddHttpClient<TestController>(client =>
                {
                    client.BaseAddress = new Uri("https://recruitment.highfieldqualifications.com/");
                });

                services.AddCors(options =>
                {
                    options.AddPolicy("AllowLocalhost4200",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200")
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });
                });
            });

            webBuilder.Configure((context, app) =>
            {
                if (context.HostingEnvironment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();

                app.UseCors("AllowLocalhost4200");

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
        });
    }
}
