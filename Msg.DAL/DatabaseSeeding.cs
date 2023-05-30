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
            SeedUser(builder);
            SeedDataLabels(builder);
            SeedDataPieces(builder);
            SeedSubstrates(builder);
            SeedPlants(builder);
            SeedDeviceTypes(builder);
            SeedPackTypes(builder);
            SeedDevices(builder);
            SeedWarnings(builder);
            SeedDeviceDataPieces(builder);
            SeedOrders(builder);
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

        private void SeedUser(ModelBuilder builder)
        {
            User user = new User
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserName = "test",
                Email = "test@gmail.com",
                NormalizedUserName = "TEST",
                NormalizedEmail = "TEST@GMAIL.COM",
                LockoutEnabled = false,
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            var password = passwordHasher.HashPassword(user, "test123");
            user.PasswordHash = password;
            builder.Entity<User>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "fab4fac1-c546-41de-aebc-a14da6895711" }
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
                new Substrate() { Id = 1, Name = "GT1", Price = 4, Volume = 2, Description = "GT1  (30%  sand  +20% organic  soil +  50% coco  coir)", PhotoUrl = "https://leto.ua/img/uploads/premed/1643110922_10432f5562ba003d1b82_thumb.png"},
                new Substrate() { Id = 2, Name = "GT2", Price = 14, Volume = 5, Description = "GT2  (75%  coco  coir  +  25% rice husk)", PhotoUrl = "https://content.rozetka.com.ua/goods/images/big/176571065.jpg"},
                new Substrate() { Id = 3, Name = "GT3", Price = 13.99, Volume = 3.5, Description = "GT3  (75% coco coir + CaO 2.2 mg/kg + acid humic 0.41%)", PhotoUrl = "https://cdn.27.ua/799/f5/e5/1373669_3.jpeg"},
                new Substrate() { Id = 4, Name = "GT4", Price = 18, Volume = 6, Description = "GT4  (75% white sphagnum peat  +25% vermiculite (size  4–6  mm))", PhotoUrl = "https://svitroslyn.ua/upload/iblock/555/555e0ae93baa97d7931bdd1d689596b3.jpg"},
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
                new Plant() { Id = 1, Name = "Beens", Description = "Regular beens", PhotoUrl = "https://cms.lowimpact.org/wp-content/uploads/2sprouting.jpg"},
                new Plant() { Id = 2, Name = "Cucumber", Description = "Regular cucumber", PhotoUrl = "https://cdn.shopify.com/s/files/1/2404/9387/products/image_671dd898-1e92-4944-a414-cfc6bcdc32f4_1024x1024@2x.jpg?v=1642634342"},
                new Plant() { Id = 3, Name = "Beetroot", Description = "Regular beetroot", PhotoUrl = "https://cdn.shopify.com/s/files/1/0273/5551/2875/products/Picture4_900x.png?v=1592058144"}
            };

            var dataPieces = new List<PlantDataPiece>()
            {
                new PlantDataPiece { PlantId = 1, DataPieceId = 1, Value = 6.0 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 2, Value = 0.9 },
                new PlantDataPiece { PlantId = 1, DataPieceId = 3, Value = 45 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 1, Value = 6.3 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 2, Value = 0.7 },
                new PlantDataPiece { PlantId = 2, DataPieceId = 3, Value = 48 },
                new PlantDataPiece { PlantId = 3, DataPieceId = 1, Value = 6.1 },
                new PlantDataPiece { PlantId = 3, DataPieceId = 2, Value = 1 },
                new PlantDataPiece { PlantId = 3, DataPieceId = 3, Value = 50 },
            };

            builder.Entity<Plant>().HasData(plants);
            builder.Entity<PlantDataPiece>().HasData(dataPieces);
        }

        private void SeedDeviceTypes(ModelBuilder builder)
        {
            var deviceTypes = new List<DeviceType>()
            {
                new DeviceType() { Id = 1, Name = "MSG Logger I", Description = "MSG Logger I is a smart device that analyzes substrates and provides detailed information about their composition, helping users make informed decisions about their usage and handling.", Image = "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg"},
                new DeviceType() { Id = 2, Name = "MSG Logger II", Description = "MSG Logger II is a smart device that designed to analyze the substrate, providing detailed information about its composition and properties, allowing for better decision-making and optimization of processes.", Image = "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg"},
                new DeviceType() { Id = 3, Name = "MSG Logger III", Description = "MSG Logger III is a substrate analysis smart device uses sensors to provide real-time data on the quality and composition of soil or other substrates for optimized plant growth.", Image = "https://s.alicdn.com/@sc04/kf/Hf3c0c4b0bc524290a994f996fdc37989K.jpg_300x300.jpg"}
            };

            builder.Entity<DeviceType>().HasData(deviceTypes);
        }

        private void SeedPackTypes(ModelBuilder builder)
        {
            var packTypes = new List<PackType>()
            {
                new PackType { Id = 1, Name = "Basic bundle", Price = 10, Description = "This tiny bundle of smart devices is a collection of small, interconnected devices that work together to provide various functionalities such as monitoring, tracking, and controlling. Despite their small size, they offer great convenience and versatility for a wide range of applications.", Image = "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053" },
                new PackType { Id = 2, Name = "Mid bundle", Price = 22, Description = "The medium-sized bundle of smart devices includes a variety of tools that can be used for monitoring and controlling various aspects of a project. These devices can communicate with each other and with a central hub, providing real-time data and insights for project managers.", Image = "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053" },
                new PackType { Id = 3, Name = "Advansed bundle", Price = 45, Description = "An advanced bundle of smart devices consists of highly sophisticated and interconnected devices that utilize cutting-edge technologies to enhance automation, productivity, and efficiency in various industries. These devices can be customized to fit specific needs and can communicate and exchange data with each other, leading to optimized performance and decision-making.", Image = "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053" },
                new PackType { Id = 4, Name = "Professional bundle", Price = 99, Description = "The professional bundle of smart devices is a comprehensive set of tools designed for advanced data collection and analysis. It includes high-quality sensors, data loggers, and software for precise and accurate measurement in various industries, including scientific research, engineering, and manufacturing.", Image = "https://cdn3.volusion.com/paumk.gawml/v/vspfiles/photos/WGBOX1-2.jpg?v-cache=1313743053" }
            };

            var devicesInPack = new List<DeviceInPack>()
            {
                new DeviceInPack() { Id = 1, PackTypeId = 1, DeviceTypeId = 1, Amount = 1 },
                new DeviceInPack() { Id = 2, PackTypeId = 2, DeviceTypeId = 1, Amount = 2 },
                new DeviceInPack() { Id = 3, PackTypeId = 2, DeviceTypeId = 2, Amount = 1 },
                new DeviceInPack() { Id = 4, PackTypeId = 3, DeviceTypeId = 1, Amount = 2 },
                new DeviceInPack() { Id = 5, PackTypeId = 3, DeviceTypeId = 2, Amount = 2 },
                new DeviceInPack() { Id = 6, PackTypeId = 3, DeviceTypeId = 3, Amount = 1 },
                new DeviceInPack() { Id = 7, PackTypeId = 4, DeviceTypeId = 2, Amount = 3 },
                new DeviceInPack() { Id = 8, PackTypeId = 4, DeviceTypeId = 3, Amount = 2 },
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

        private void SeedWarnings(ModelBuilder builder)
        {
            builder.Entity<Warning>().HasData(new List<Warning>
            {
                new Warning { Id = 1, IsSolved = false },
                new Warning { Id = 2, IsSolved = false },
                new Warning { Id = 3, IsSolved = false }
            });
        }

        private void SeedDeviceDataPieces(ModelBuilder builder)
        {
            var pieces = new List<DeviceDataPiece>
            {
                new DeviceDataPiece { Id = 1, DataPieceId = 1, Date = new DateOnly(2023, 5, 2), DeviceId = 1, Value = 6.2 },
                new DeviceDataPiece { Id = 4, DataPieceId = 1, Date = new DateOnly(2023, 5, 3), DeviceId = 1, Value = 6.23 },
                new DeviceDataPiece { Id = 7, DataPieceId = 1, Date = new DateOnly(2023, 5, 4), DeviceId = 1, Value = 6.24 },
                new DeviceDataPiece { Id = 10, DataPieceId = 1, Date = new DateOnly(2023, 5, 5), DeviceId = 1, Value = 6.2 },
                new DeviceDataPiece { Id = 13, DataPieceId = 1, Date = new DateOnly(2023, 5, 6), DeviceId = 1, Value = 6.2 },
                new DeviceDataPiece { Id = 16, DataPieceId = 1, Date = new DateOnly(2023, 5, 7), DeviceId = 1, Value = 6.2 },
                new DeviceDataPiece { Id = 19, DataPieceId = 1, Date = new DateOnly(2023, 5, 8), DeviceId = 1, Value = 6.3 },
                new DeviceDataPiece { Id = 22, DataPieceId = 1, Date = new DateOnly(2023, 5, 9), DeviceId = 1, Value = 6.34 },
                new DeviceDataPiece { Id = 25, DataPieceId = 1, Date = new DateOnly(2023, 5, 10), DeviceId = 1, Value = 6.38 },
                new DeviceDataPiece { Id = 28, DataPieceId = 1, Date = new DateOnly(2023, 5, 11), DeviceId = 1, Value = 6.45, WarningId = 1},
                new DeviceDataPiece { Id = 31, DataPieceId = 1, Date = new DateOnly(2023, 5, 12), DeviceId = 1, Value = 6.6, WarningId = 2 },
                new DeviceDataPiece { Id = 34, DataPieceId = 1, Date = new DateOnly(2023, 5, 13), DeviceId = 1, Value = 6.5, WarningId = 3 },
                new DeviceDataPiece { Id = 37, DataPieceId = 1, Date = new DateOnly(2023, 5, 14), DeviceId = 1, Value = 6.4 },
                new DeviceDataPiece { Id = 40, DataPieceId = 1, Date = new DateOnly(2023, 5, 15), DeviceId = 1, Value = 6.3 },
                new DeviceDataPiece { Id = 43, DataPieceId = 1, Date = new DateOnly(2023, 5, 16), DeviceId = 1, Value = 6.2 },
                new DeviceDataPiece { Id = 46, DataPieceId = 1, Date = new DateOnly(2023, 5, 17), DeviceId = 1, Value = 6.21 },
                new DeviceDataPiece { Id = 49, DataPieceId = 1, Date = new DateOnly(2023, 5, 18), DeviceId = 1, Value = 6.211 },
                new DeviceDataPiece { Id = 52, DataPieceId = 1, Date = new DateOnly(2023, 5, 19), DeviceId = 1, Value = 6.18 },
                new DeviceDataPiece { Id = 55, DataPieceId = 1, Date = new DateOnly(2023, 5, 20), DeviceId = 1, Value = 6.18 },
                new DeviceDataPiece { Id = 58, DataPieceId = 1, Date = new DateOnly(2023, 5, 21), DeviceId = 1, Value = 6.17 },
                new DeviceDataPiece { Id = 61, DataPieceId = 1, Date = new DateOnly(2023, 5, 22), DeviceId = 1, Value = 6.19 },
                new DeviceDataPiece { Id = 64, DataPieceId = 1, Date = new DateOnly(2023, 5, 23), DeviceId = 1, Value = 6.2 },

                new DeviceDataPiece { Id = 2, DataPieceId = 2, Date = new DateOnly(2023, 5, 2), DeviceId = 1, Value = 0.83 },
                new DeviceDataPiece { Id = 5, DataPieceId = 2, Date = new DateOnly(2023, 5, 3), DeviceId = 1, Value = 0.85 },
                new DeviceDataPiece { Id = 8, DataPieceId = 2, Date = new DateOnly(2023, 5, 4), DeviceId = 1, Value = 0.83 },
                new DeviceDataPiece { Id = 11, DataPieceId = 2, Date = new DateOnly(2023, 5, 5), DeviceId = 1, Value = 0.86 },
                new DeviceDataPiece { Id = 14, DataPieceId = 2, Date = new DateOnly(2023, 5, 6), DeviceId = 1, Value = 0.87 },
                new DeviceDataPiece { Id = 17, DataPieceId = 2, Date = new DateOnly(2023, 5, 7), DeviceId = 1, Value = 0.83 },
                new DeviceDataPiece { Id = 20, DataPieceId = 2, Date = new DateOnly(2023, 5, 8), DeviceId = 1, Value = 0.88 },
                new DeviceDataPiece { Id = 23, DataPieceId = 2, Date = new DateOnly(2023, 5, 9), DeviceId = 1, Value = 0.888 },
                new DeviceDataPiece { Id = 26, DataPieceId = 2, Date = new DateOnly(2023, 5, 10), DeviceId = 1, Value = 0.867 },
                new DeviceDataPiece { Id = 29, DataPieceId = 2, Date = new DateOnly(2023, 5, 11), DeviceId = 1, Value = 0.864, WarningId = 1 },
                new DeviceDataPiece { Id = 32, DataPieceId = 2, Date = new DateOnly(2023, 5, 12), DeviceId = 1, Value = 0.89, WarningId = 2 },
                new DeviceDataPiece { Id = 35, DataPieceId = 2, Date = new DateOnly(2023, 5, 13), DeviceId = 1, Value = 0.9, WarningId = 3 },
                new DeviceDataPiece { Id = 38, DataPieceId = 2, Date = new DateOnly(2023, 5, 14), DeviceId = 1, Value = 0.9 },
                new DeviceDataPiece { Id = 41, DataPieceId = 2, Date = new DateOnly(2023, 5, 15), DeviceId = 1, Value = 0.91 },
                new DeviceDataPiece { Id = 44, DataPieceId = 2, Date = new DateOnly(2023, 5, 16), DeviceId = 1, Value = 0.911 },
                new DeviceDataPiece { Id = 47, DataPieceId = 2, Date = new DateOnly(2023, 5, 17), DeviceId = 1, Value = 0.905 },
                new DeviceDataPiece { Id = 50, DataPieceId = 2, Date = new DateOnly(2023, 5, 18), DeviceId = 1, Value = 0.89 },
                new DeviceDataPiece { Id = 53, DataPieceId = 2, Date = new DateOnly(2023, 5, 19), DeviceId = 1, Value = 0.898 },
                new DeviceDataPiece { Id = 56, DataPieceId = 2, Date = new DateOnly(2023, 5, 20), DeviceId = 1, Value = 0.901 },
                new DeviceDataPiece { Id = 59, DataPieceId = 2, Date = new DateOnly(2023, 5, 21), DeviceId = 1, Value = 0.87 },
                new DeviceDataPiece { Id = 62, DataPieceId = 2, Date = new DateOnly(2023, 5, 22), DeviceId = 1, Value = 0.864 },
                new DeviceDataPiece { Id = 65, DataPieceId = 2, Date = new DateOnly(2023, 5, 23), DeviceId = 1, Value = 0.861 },

                new DeviceDataPiece { Id = 3, DataPieceId = 3, Date = new DateOnly(2023, 5, 2), DeviceId = 1, Value = 42 },
                new DeviceDataPiece { Id = 6, DataPieceId = 3, Date = new DateOnly(2023, 5, 3), DeviceId = 1, Value = 42 },
                new DeviceDataPiece { Id = 9, DataPieceId = 3, Date = new DateOnly(2023, 5, 4), DeviceId = 1, Value = 42 },
                new DeviceDataPiece { Id = 12, DataPieceId = 3, Date = new DateOnly(2023, 5, 5), DeviceId = 1, Value = 43 },
                new DeviceDataPiece { Id = 15, DataPieceId = 3, Date = new DateOnly(2023, 5, 6), DeviceId = 1, Value = 43 },
                new DeviceDataPiece { Id = 18, DataPieceId = 3, Date = new DateOnly(2023, 5, 7), DeviceId = 1, Value = 42 },
                new DeviceDataPiece { Id = 21, DataPieceId = 3, Date = new DateOnly(2023, 5, 8), DeviceId = 1, Value = 44 },
                new DeviceDataPiece { Id = 24, DataPieceId = 3, Date = new DateOnly(2023, 5, 9), DeviceId = 1, Value = 44 },
                new DeviceDataPiece { Id = 27, DataPieceId = 3, Date = new DateOnly(2023, 5, 10), DeviceId = 1, Value = 46 },
                new DeviceDataPiece { Id = 30, DataPieceId = 3, Date = new DateOnly(2023, 5, 11), DeviceId = 1, Value = 42, WarningId = 1 },
                new DeviceDataPiece { Id = 33, DataPieceId = 3, Date = new DateOnly(2023, 5, 12), DeviceId = 1, Value = 45, WarningId = 2 },
                new DeviceDataPiece { Id = 36, DataPieceId = 3, Date = new DateOnly(2023, 5, 13), DeviceId = 1, Value = 46, WarningId = 3 },
                new DeviceDataPiece { Id = 39, DataPieceId = 3, Date = new DateOnly(2023, 5, 14), DeviceId = 1, Value = 45 },
                new DeviceDataPiece { Id = 42, DataPieceId = 3, Date = new DateOnly(2023, 5, 15), DeviceId = 1, Value = 45 },
                new DeviceDataPiece { Id = 45, DataPieceId = 3, Date = new DateOnly(2023, 5, 16), DeviceId = 1, Value = 47 },
                new DeviceDataPiece { Id = 48, DataPieceId = 3, Date = new DateOnly(2023, 5, 17), DeviceId = 1, Value = 46 },
                new DeviceDataPiece { Id = 51, DataPieceId = 3, Date = new DateOnly(2023, 5, 18), DeviceId = 1, Value = 45 },
                new DeviceDataPiece { Id = 54, DataPieceId = 3, Date = new DateOnly(2023, 5, 19), DeviceId = 1, Value = 47 },
                new DeviceDataPiece { Id = 57, DataPieceId = 3, Date = new DateOnly(2023, 5, 20), DeviceId = 1, Value = 43 },
                new DeviceDataPiece { Id = 60, DataPieceId = 3, Date = new DateOnly(2023, 5, 21), DeviceId = 1, Value = 44 },
                new DeviceDataPiece { Id = 63, DataPieceId = 3, Date = new DateOnly(2023, 5, 22), DeviceId = 1, Value = 45 },
                new DeviceDataPiece { Id = 66, DataPieceId = 3, Date = new DateOnly(2023, 5, 23), DeviceId = 1, Value = 44 },
            };

            builder.Entity<DeviceDataPiece>().HasData(pieces);
        }

        private void SeedOrders(ModelBuilder builder)
        {
            var orders = new List<Order>()
            {
                new Order { Id = 1, Date = new DateOnly(2023, 5, 22), Email = "test@gmail.com", PackTypeId = 1, Phone = "1111111111", Processed = true },
                new Order { Id = 2, Date = new DateOnly(2023, 5, 24), Email = "test@gmail.com", PackTypeId = 1, Phone = "1111111111", Processed = true },
                new Order { Id = 3, Date = new DateOnly(2023, 5, 27), Email = "test@gmail.com", PackTypeId = 2, Phone = "1111111111", Processed = false },
                new Order { Id = 4, Date = new DateOnly(2023, 5, 27), Email = "test@gmail.com", PackTypeId = 3, Phone = "1111111111", Processed = true },
                new Order { Id = 5, Date = new DateOnly(2023, 5, 27), Email = "test@gmail.com", PackTypeId = 4, Phone = "1111111111", Processed = false },
                new Order { Id = 6, Date = new DateOnly(2023, 5, 28), Email = "test@gmail.com", PackTypeId = 2, Phone = "1111111111", Processed = true },
            };

            var packs = new List<DevicePack>
            {
                new DevicePack { Id = 2, DateBought = new DateOnly(2023, 5, 22), UserId = "fab4fac1-c546-41de-aebc-a14da6895711", PackTypeId = 1 },
                new DevicePack { Id = 3, DateBought = new DateOnly(2023, 5, 24), UserId = "fab4fac1-c546-41de-aebc-a14da6895711", PackTypeId = 1 },
                new DevicePack { Id = 4, DateBought = new DateOnly(2023, 5, 27), UserId = "fab4fac1-c546-41de-aebc-a14da6895711", PackTypeId = 3 },
                new DevicePack { Id = 5, DateBought = new DateOnly(2023, 5, 28), UserId = "fab4fac1-c546-41de-aebc-a14da6895711", PackTypeId = 2 },
            };

            builder.Entity<Order>().HasData(orders);
            builder.Entity<DevicePack>().HasData(packs);
        }
    }
}
