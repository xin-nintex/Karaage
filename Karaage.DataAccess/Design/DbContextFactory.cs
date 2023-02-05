using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Karaage.DataAccess.Design;

public class DbContextFactory : IDesignTimeDbContextFactory<KaraageContext>
{
    public KaraageContext CreateDbContext(string[] args)
    {
        var connectionsString =
            Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING", EnvironmentVariableTarget.Machine);
        var builder = new DbContextOptionsBuilder<KaraageContext>();
        builder.UseNpgsql(connectionsString);
        return new KaraageContext(builder.Options);
    }
}