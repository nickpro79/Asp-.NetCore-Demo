namespace Asp_.NetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMvc();
            var app = builder.Build();


            if (app.Environment.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
