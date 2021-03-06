﻿using GamingProject.Data.Context;
using GamingProject.Models;
using GamingProject.Services.DTOs;
using GamingProject.Services.Mappers.Contract;
using GamingProject.Services.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingProject.Services.Services
{
    public class SessionService : ISessionService
    {
        private readonly GamingProjectContext _context;
        private readonly IDTOServiceMapper<Session,SessionDTO> _sessionMapper;
        private readonly IDTOServiceMapper<Session, DisplaySessionDTO> _displaySessionMapper;

        public SessionService(GamingProjectContext context, 
                              IDTOServiceMapper<Session, SessionDTO> sessionMapper,
                              IDTOServiceMapper<Session,DisplaySessionDTO> displaySessionMapper)
        {
            _context = context;
            _sessionMapper = sessionMapper;
            _displaySessionMapper = displaySessionMapper;
        }

        public async Task<SessionDTO> Create(SessionDTO dto)
        {
            var session = new Session()
            {
                DeviceID = dto.DeviceID,
                SessionStart = DateTime.Now,
                UserID = dto.UserID,
            };

            var user = await _context.Users.FindAsync(dto.UserID);
            user.IsInSession = true;
            await _context.SaveChangesAsync();

            var device = await _context.Devices.FindAsync(dto.DeviceID);
            device.Available = false;
            await _context.SaveChangesAsync();

            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task EndUserSessionAsync(string id, TimeSpan time)
        {
            var user = await _context.Users.FirstAsync(x => x.Id == id);
            var session = await _context.Sessions.FirstAsync(x => x.UserID == id && x.IsDeleted == false);
            var device = await _context.Devices.FirstAsync(x => x.DeviceName == session.DeviceID);

            device.Available = true;
            device.PlayedTime += time;
            await _context.SaveChangesAsync();

            session.IsDeleted = true;
            session.Duration = time;
            session.Price = 1;//SET PRICE
            await _context.SaveChangesAsync();

            user.IsInSession = false;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<SessionDTO>> GetActiveSessionsAsync()
        {
            var sessions = await _context.Sessions.Where(s => s.IsDeleted == false).Include(x=>x.Device).ToListAsync();
            var sessionsDTO =  _sessionMapper.MapFrom(sessions);

            return sessionsDTO;
        }
        public async Task<ICollection<DisplaySessionDTO>> GetSessionHistoryAsync(string date)
        {
            var sessions = await _context.Sessions
                .Include(s=>s.User)
                .Include(s=>s.Device)
                .Where(s => s.SessionStart.ToString().StartsWith(date))
                .ToListAsync();
            var sessionDtos = _displaySessionMapper.MapFrom(sessions);
            
            return sessionDtos;
        }

        public async Task<double> GetSum(string id)
        {
            var session = await _context.Sessions.FirstAsync(x => x.UserID == id && x.IsDeleted == false);
            var hoursplayed = DateTime.Now.Subtract(session.SessionStart).TotalHours;

            return hoursplayed * 2;
        }
    }
}
