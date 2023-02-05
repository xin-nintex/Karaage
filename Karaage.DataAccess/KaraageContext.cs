using Karaage.Domain;
using Microsoft.EntityFrameworkCore;

namespace Karaage.DataAccess;

public class KaraageContext : DbContext
{
    public DbSet<EntityElement> EntityElements { get; set; } = null!;

    public KaraageContext(DbContextOptions<KaraageContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityElement>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<EntityElement>(x =>
        {
            x.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            x.Property(e => e.Type)
                .IsRequired()
                .HasDefaultValue(EntityType.YoutubeVideo);
            x.Property(e => e.ExternalId)
                .IsRequired();
            x.Property(e => e.IngestionDate)
                .HasDefaultValueSql("now()");
            x.Property(e => e.IngestionType)
                .HasDefaultValue(IngestionType.ManualEntry);
        });

        modelBuilder.Entity("Job", builder =>
        {
            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();
            builder.Property<DateTime>("CreatedAt")
                .IsRequired();
            builder.Property<Guid>("UniqueId")
                .IsRequired();
            builder.Property<DateTime>("CompletedAt");
            builder.HasKey("Id");
            builder.ToTable("Jobs", schema: "Processing");
        });

        modelBuilder.Entity("JobDetail", builder =>
        {
            builder.Property<int>("Id")
                .ValueGeneratedOnAdd();
            builder.Property<int>("JobId");
            builder.HasOne("Job")
                .WithMany("JobDetail")
                .HasForeignKey("JobId");
            builder.Property<long>("EntityId");
            builder.HasOne(typeof(EntityElement), nameof(EntityElement))
                .WithMany()
                .HasForeignKey("EntityId");
            builder.HasKey("Id");
            builder.ToTable("JobDetails", schema: "Processing");
        });
    }
}
