namespace WebApplication1
{

    class Program
    {
        private static void Main(string[] args)
        {
        

            CreateHostBuilder(args).Build().Run();  
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<startup>();
                  });
    }
}