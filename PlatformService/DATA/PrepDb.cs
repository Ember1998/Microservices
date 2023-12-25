namespace PlatformService;

public static class PrepDb
{
    public static void PrepPopulate(this IApplicationBuilder app)
    {
        using (var scrvicescope = app.ApplicationServices.CreateScope())
        {
            SeedData(scrvicescope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    public static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any())
        {
            System.Console.WriteLine("Seeding Data...");

            context.Platforms.AddRange(new Platform(){
                Name ="Dotnet",
                Publisher = "Microsoft"
            });
            context.SaveChanges();
        }
        else{
            System.Console.WriteLine("Data already exists");
        }
    }
}
