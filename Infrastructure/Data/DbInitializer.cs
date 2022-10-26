using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DbInitializer
{
    public static void Initialize(MeFitDbContext context)
    {
        const int profilesToFake = 20;
        context.Database.EnsureCreated();

        if (context.Profiles.Count() < profilesToFake)
        {
            FakeData.Init(profilesToFake);
            context.Profiles.AddRange(FakeData.Profiles);
            
            context.SaveChanges();
        }
        
        
    }
}