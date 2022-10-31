using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DbInitializer
{
    public static void Initialize(MeFitDbContext context)
    {
        const int programsToFake = 1;
        context.Database.EnsureCreated();

        if (context.Programs.Count() < programsToFake)
        {
            FakeData.Init(programsToFake);
            context.Programs.AddRange(FakeData.Programs);
            
            context.SaveChanges();
        }
        
        
    }
}