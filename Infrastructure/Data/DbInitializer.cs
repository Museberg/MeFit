using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DbInitializer
{
    public static void Initialize(MeFitDbContext context)
    {
        const int programsToFake = 30;
        context.Database.EnsureCreated();

        if (context.Profiles.Count() < programsToFake / 3)
        {
            // FakeData.Init(programsToFake);
            // context.Programs.AddRange(FakeData.Programs);
            //
            // context.SaveChanges();
        }
        
        
    }
}