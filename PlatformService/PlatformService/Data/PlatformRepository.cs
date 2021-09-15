using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository: IPlatformRepository
    {
        private readonly AppDbContext _context;

        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Platform> GetAll()
        {
            return _context.Platforms.ToList();
        }

        public Platform Find(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }
    }
}