namespace RazorPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //var bi = WebApplication.CreateBuilder(args);
            //bi.Services.AddRazorPages();
            //var c = bi.Build();
            //if(c.Environment.IsDevelopment()) { }
            //c.UseStaticFiles();
            //c.UseRouting();
            //c.UseAuthorization();
            //c.MapRazorPages();
            //c.Run();
            

        
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}