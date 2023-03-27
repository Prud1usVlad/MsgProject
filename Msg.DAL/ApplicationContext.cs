using Microsoft.EntityFrameworkCore;
using Msg.Core.BasicModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.DAL;

public partial class ApplicationContext : IdentityDbContext<User>
{
    public DbSet<DataPiece> DataPieces { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceDataPiece> DeviceDataPieces { get; set; }
    public DbSet<DeviceInPack> DevicesInPacks { get; set; }
    public DbSet<DevicePack> DevicePacks { get; set; }
    public DbSet<DeviceType> DeviceTypes { get; set; }
    public DbSet<PackType> PackTypes { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<PlantDataPiece> PlantDataPieces { get; set; }
    public DbSet<Substrate> Substrates { get; set; }
    public DbSet<SubstrateDataPiece> SubstrateDataPieces { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<DataLabel> DataLabels { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User Id=postgres;Password=pz0D0BU8xfgRLLEj;Server=db.zuprgdzopjrcemxqiegl.supabase.co;Port=5432;Database=postgres");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyAllSeedings(modelBuilder);

        modelBuilder.Entity<DeviceDataPiece>()
            .HasKey(x => new { x.DeviceId, x.DataPieceId });
        
        modelBuilder.Entity<SubstrateDataPiece>()
            .HasKey(x => new { x.SubstrateId, x.DataPieceId });
        
        modelBuilder.Entity<PlantDataPiece>()
            .HasKey(x => new { x.PlantId, x.DataPieceId });

        modelBuilder.Entity<DeviceInPack>()
            .HasKey(x => new { x.PackTypeId, x.DeviceTypeId });

        modelBuilder.Entity<DataLabelDataPiece>()
            .HasKey(x => new { x.DataLabelId, x.DataPieceId });

        modelBuilder.Entity<Device>()
            .HasOne(d => d.DeviceType)
            .WithMany(t => t.Devices);

        modelBuilder.Entity<Device>()
            .HasOne(d => d.DevicePack)
            .WithMany(p => p.Devices);

        modelBuilder.Entity<DeviceDataPiece>()
            .HasOne(p => p.Device)
            .WithMany(d => d.DataPieces);
        
        modelBuilder.Entity<DeviceDataPiece>()
            .HasOne(p => p.DataPiece)
            .WithMany(d => d.DeviceDataPieces);
        
        modelBuilder.Entity<PlantDataPiece>()
            .HasOne(p => p.Plant)
            .WithMany(d => d.Characteristics);
        
        modelBuilder.Entity<PlantDataPiece>()
            .HasOne(p => p.DataPiece)
            .WithMany(d => d.PlantDataPieces);
        
        modelBuilder.Entity<SubstrateDataPiece>()
            .HasOne(p => p.Substrate)
            .WithMany(d => d.Characteristics);
        
        modelBuilder.Entity<SubstrateDataPiece>()
            .HasOne(p => p.DataPiece)
            .WithMany(d => d.SubstrateDataPieces);

        modelBuilder.Entity<DataLabelDataPiece>()
            .HasOne(p => p.DataLabel)
            .WithMany(d => d.DataLabelDataPieces);

        modelBuilder.Entity<DataLabelDataPiece>()
            .HasOne(p => p.DataPiece)
            .WithMany(d => d.DataLabelDataPieces);

        modelBuilder.Entity<DeviceInPack>()
            .HasOne(d => d.DeviceType)
            .WithMany(t => t.DeviceInPacks);

        modelBuilder.Entity<DeviceInPack>()
            .HasOne(d => d.PackType)
            .WithMany(t => t.DevicesInPack);

        modelBuilder.Entity<DevicePack>()
            .HasOne(d => d.PackType)
            .WithMany(p => p.DevicePacks);

        modelBuilder.Entity<DevicePack>()
            .HasOne(p => p.User)
            .WithMany(u => u.DevicePacks);
            
    }
}