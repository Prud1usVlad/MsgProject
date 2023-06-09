﻿using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.BasicServices
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationContext _context;
        private readonly IUserService _userService;
        private readonly IMailingService _mailingService;
        private readonly DateTime anchorDate = new DateTime(2001, 1, 1);

        private string passwordCash;
        private string usernameCash;

        public OrderService(ApplicationContext context, IUserService userService, IMailingService mailingService)
        {
            _context = context;
            _userService = userService;
            _mailingService = mailingService;
        }

        public async Task<long> AddOrderAsync(Order order)
        {
            // In db DateTime has to have default value now()
            // In db UserId has to be nullable

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task ConfirmOrder(long id)
        {
            var order = await GetOrderAsync(id);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == order.Email);

            var newUserCreated = user is null;

            var packType = await _context.PackTypes
                .Include(t => t.DevicesInPack)
                .FirstOrDefaultAsync(t => t.Id == order.PackTypeId);

            var devicePack = await CreateDevicePack(order, user, packType);

            order.Processed = true;
            _context.Orders.Update(order);

            await _context.SaveChangesAsync();

            if (newUserCreated)
                _mailingService.SendUserCredentials(user, usernameCash, passwordCash);

        }

        public async Task DeleteOrderAsync(long id)
        {
            var order = await _context.Orders.FindAsync(id);
            
            if (order == null)
                throw new NullReferenceException();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderAsync(long id)
        {
            return await _context.Orders
                .Include(o => o.PackType)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.PackType)
                .ToListAsync();
        }

        private async Task<User> CreateNewUser(Order order)
        {
            passwordCash = Guid.NewGuid().ToString("d").Substring(1, 8);
            usernameCash = "user_" + GetTimestamp();

            return await _userService.CreateUserAsync(
                new User()
                {
                    UserName = usernameCash,
                    Email = order.Email,
                    PhoneNumber = order.Phone
                },
                passwordCash,
                new[] { "User" }
            );
        }

        private string GetTimestamp()
        {
            var elapsedSpan = new TimeSpan(DateTime.Now.Ticks - anchorDate.Ticks);
            return ((int)elapsedSpan.TotalSeconds).ToString();
        }

        private async Task<DevicePack> CreateDevicePack(Order order, User user, PackType packType)
        {
            if (user is null)
                user = await CreateNewUser(order);

            var devicePack = new DevicePack()
            {
                DateBought = DateOnly.FromDateTime(DateTime.Now),
                PackTypeId = packType.Id,
                UserId = user.Id,
                Devices = new List<Device>(),
            };

            _context.DevicePacks.Add(devicePack);

            _context.SaveChanges();

            FillPackWithDevices(packType, devicePack);

            return devicePack;
        }

        private void FillPackWithDevices(PackType packType, DevicePack devicePack)
        {
            foreach (var deviceInPack in packType.DevicesInPack)
                for (int i = 0; i < deviceInPack.Amount; i++)
                    devicePack.Devices.Add(
                        new Device()
                        {
                            DeviceTypeId = deviceInPack.DeviceTypeId,
                            DevicePackId = devicePack.Id,
                        }
                    );
        }
    }
}
