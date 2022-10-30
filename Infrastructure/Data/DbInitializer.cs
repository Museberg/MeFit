using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DbInitializer
{
    public static void Initialize(MeFitDbContext context)
    {
        const int profilesToFake = 30;
        context.Database.EnsureCreated();

        if (context.Profiles.Count() < profilesToFake / 3)
        {
            FakeData.Init(profilesToFake);
            context.Profiles.AddRange(FakeData.Profiles);
            
            context.SaveChanges();
        }
        
        
    }
}