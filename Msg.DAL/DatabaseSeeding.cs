using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.DAL
{
    public partial class ApplicationContext
    {

        private void ApplyAllSeedings(ModelBuilder builder)
        {
            SeedRoles(builder);
            SeedAdmin(builder);
            SeedDataLabels(builder);
            SeedDataPieces(builder);
            SeedSubstrates(builder);
            SeedPlants(builder);
            SeedDeviceTypes(builder);
            SeedPackTypes(builder);
            SeedDevices(builder);
        }

        private void SeedAdmin(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin",
                Email = "admin@gmail.com",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var password = passwordHasher.HashPassword(user, "admin123");
            user.PasswordHash = password;
            builder.Entity<User>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }

        private void SeedRoles(ModelBuilder builder) 
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
            );
        }

        private void SeedDataLabels(ModelBuilder builder)
        {
            builder.Entity<DataLabel>().HasData(
                new DataLabel() { Id = 1, Label = "PlantRequired" },
                new DataLabel() { Id = 2, Label = "SubstrateRequired" },
                new DataLabel() { Id = 3, Label = "OptimizingModelRequired"},
                new DataLabel() { Id = 4, Label = "DeviceActionRequired"},
                new DataLabel() { Id = 5, Label = "Optional"}
            );
        }

        private void SeedDataPieces(ModelBuilder builder)
        {
            var dataPieces = new List<DataPiece>()
            {
                new DataPiece() { Id = 1, Name = "Acidity", MeasureUnit = "pH" },
                new DataPiece() { Id = 2, Name = "Electrical Capacity", MeasureUnit = "mS cm" },
                new DataPiece() { Id = 3, Name = "Moisure Content", MeasureUnit = "%" }
            };

            var labelConnections = new List<DataLabelDataPiece>(); 

            foreach (var item in dataPieces)
            {
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 1, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 2, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 3, DataPieceId = item.Id });
                labelConnections.Add(new DataLabelDataPiece { DataLabelId = 4, DataPieceId = item.Id });
            }

            builder.Entity<DataPiece>().HasData(dataPieces);
            builder.Entity<DataLabelDataPiece>().HasData(labelConnections);
        }

        private void SeedSubstrates(ModelBuilder builder)
        {
            var substrates = new List<Substrate>()
            {
                new Substrate() { Id = 1, Name = "GT1", Price = 4, Volume = 2, Description = "GT1  (30%  sand  +20% organic  soil +  50% coco  coir)"},
                new Substrate() { Id = 2, Name = "GT2", Price = 14, Volume = 5, Description = "GT2  (75%  coco  coir  +  25% rice husk)"},
                new Substrate() { Id = 3, Name = "GT3", Price = 13.99, Volume = 3.5, Description = "GT3  (75% coco coir + CaO 2.2 mg/kg + acid humic 0.41%)"},
                new Substrate() { Id = 4, Name = "GT4", Price = 18, Volume = 6, Description = "GT4  (75% white sphagnum peat  +25% vermiculite (size  4–6  mm))"},
            };

            var dataPieces = new List<SubstrateDataPiece>()
            {
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 1, Value = 6.2 },
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 2, Value = 1.4 },
                new SubstrateDataPiece { SubstrateId = 1, DataPieceId = 3, Value = 48 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 1, Value = 6.0 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 2, Value = 0.4 },
                new SubstrateDataPiece { SubstrateId = 2, DataPieceId = 3, Value = 38 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 1, Value = 6.5 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 2, Value = 0.8 },
                new SubstrateDataPiece { SubstrateId = 3, DataPieceId = 3, Value = 55 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 1, Value = 6.2 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 2, Value = 0.6 },
                new SubstrateDataPiece { SubstrateId = 4, DataPieceId = 3, Value = 41 },
            };

            builder.Entity<Substrate>().HasData(substrates);
            builder.Entity<SubstrateDataPiece>().HasData(dataPieces);
        }

        private void SeedPlants(ModelBuilder builder)
        {
            var plants = new List<Plant>()
            {
                new Plant() { Id = 1, Name = "Beens", Description = "Regular beens"},
                new Plant() { Id = 2, Name = "Cucumber", Description = "Regular cucumber"},
            };

            var dataPieces = new List<PlantDataPiece>()
            {
                new PlantDataPiece { PlantId = 1, DataPieceId = 1, Value = 6.0 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 2, Value = 0.9 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 3, Value = 35 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 1, Value = 6.3 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 2, Value = 0.7 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 3, Value = 48 },
            };

            builder.Entity<Plant>().HasData(plants);
            builder.Entity<PlantDataPiece>().HasData(dataPieces);
        }

        private void SeedDeviceTypes(ModelBuilder builder)
        {
            var deviceTypes = new List<DeviceType>()
            {
                new DeviceType() { Id = 1, Name = "MSG Logger I", Description = "MSG Logger I is a smart device that analyzes substrates and provides detailed information about their composition, helping users make informed decisions about their usage and handling."},
                new DeviceType() { Id = 2, Name = "MSG Logger II", Description = "MSG Logger II is a smart device that designed to analyze the substrate, providing detailed information about its composition and properties, allowing for better decision-making and optimization of processes."},
                new DeviceType() { Id = 3, Name = "MSG Logger III", Description = "MSG Logger III is a substrate analysis smart device uses sensors to provide real-time data on the quality and composition of soil or other substrates for optimized plant growth."}
            };

            builder.Entity<DeviceType>().HasData(deviceTypes);
        }

        private void SeedPackTypes(ModelBuilder builder)
        {
            var packTypes = new List<PackType>()
            {
                new PackType { Id = 1, Name = "Basic bundle", Price = 10, Description = "This tiny bundle of smart devices is a collection of small, interconnected devices that work together to provide various functionalities such as monitoring, tracking, and controlling. Despite their small size, they offer great convenience and versatility for a wide range of applications." },
                new PackType { Id = 2, Name = "Mid bundle", Price = 22, Description = "The medium-sized bundle of smart devices includes a variety of tools that can be used for monitoring and controlling various aspects of a project. These devices can communicate with each other and with a central hub, providing real-time data and insights for project managers."},
                new PackType { Id = 3, Name = "Advansed bundle", Price = 45, Description = "An advanced bundle of smart devices consists of highly sophisticated and interconnected devices that utilize cutting-edge technologies to enhance automation, productivity, and efficiency in various industries. These devices can be customized to fit specific needs and can communicate and exchange data with each other, leading to optimized performance and decision-making."},
                new PackType { Id = 4, Name = "Professional bundle", Price = 99, Description = "The professional bundle of smart devices is a comprehensive set of tools designed for advanced data collection and analysis. It includes high-quality sensors, data loggers, and software for precise and accurate measurement in various industries, including scientific research, engineering, and manufacturing."}
            };

            var devicesInPack = new List<DeviceInPack>()
            {
                new DeviceInPack() { Id = 1, PackTypeId = 1, DeviceTypeId = 1, Amount = 4 },
                new DeviceInPack() { Id = 2, PackTypeId = 2, DeviceTypeId = 1, Amount = 6 },
                new DeviceInPack() { Id = 3, PackTypeId = 2, DeviceTypeId = 2, Amount = 2 },
                new DeviceInPack() { Id = 4, PackTypeId = 3, DeviceTypeId = 1, Amount = 6 },
                new DeviceInPack() { Id = 5, PackTypeId = 3, DeviceTypeId = 2, Amount = 5 },
                new DeviceInPack() { Id = 6, PackTypeId = 3, DeviceTypeId = 3, Amount = 2 },
                new DeviceInPack() { Id = 7, PackTypeId = 4, DeviceTypeId = 1, Amount = 10 },
                new DeviceInPack() { Id = 8, PackTypeId = 4, DeviceTypeId = 2, Amount = 10 },
                new DeviceInPack() { Id = 9, PackTypeId = 4, DeviceTypeId = 3, Amount = 4 },
            };

            builder.Entity<PackType>().HasData(packTypes);
            builder.Entity<DeviceInPack>().HasData(devicesInPack);
        }

        private void SeedDevices(ModelBuilder builder)
        {
            builder.Entity<DevicePack>().HasData(new DevicePack
            {
                Id = 1, PackTypeId = 1, UserId = "b74ddd14-6340-4840-95c2-db12554843e5", DateBought = DateOnly.FromDateTime(DateTime.Now)
            });
            
            builder.Entity<Device>().HasData(new Device
            {
                Id = 1, DevicePackId = 1, PlantId = 1, DeviceTypeId = 1, 
            });
        }
    }
}
