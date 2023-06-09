﻿using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.BasicServices
{
    public class DeviceService : IDeviceService
    {
        private readonly ApplicationContext _context;

        public DeviceService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Device> GetDeviceAsync(long id)
        {
            return await _context.Devices
                .Include(d => d.DevicePack)
                    .ThenInclude(p => p.PackType)
                .Include(d => d.DeviceType)
                .Include(d => d.DataPieces)
                    .ThenInclude(p => p.DataPiece)
                .Include(d => d.Plant)
                    .ThenInclude(p => p.Characteristics)
                        .ThenInclude(c => c.DataPiece)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            return await _context.Devices
                .Include(d => d.DevicePack)
                    .ThenInclude(p => p.PackType)
                .Include(d => d.DeviceType)
                .Include(d => d.DataPieces)
                    .ThenInclude(p => p.DataPiece)
                .Include(d => d.Plant)
                    .ThenInclude(p => p.Characteristics)
                        .ThenInclude(c => c.DataPiece)
                .ToListAsync();
        }

        public async Task<List<Device>> GetUserDevicesAsync(string userId)
        {
            return await _context.Devices
                .Include(d => d.DevicePack)
                    .ThenInclude(p => p.PackType)
                .Include(d => d.DeviceType)
                .Include(d => d.DataPieces)
                    .ThenInclude(p => p.DataPiece)
                .Include(d => d.Plant)
                    .ThenInclude(p => p.Characteristics)
                        .ThenInclude(c => c.DataPiece)
                .Where(d => d.DevicePack.UserId == userId)
                .ToListAsync();
        }
        public async Task ChangeDevicePlant(long deviceId, long plantId)
        {
            var plant = await _context.Plants
                .FirstOrDefaultAsync(p => p.Id == plantId);

            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == deviceId);

            if (device is null || plant is null)
                throw new NullReferenceException("Some entities can not be found");

            device.PlantId = plant.Id;
            _context.Devices.Update(device);
            _context.SaveChanges();
        }
    }
}
