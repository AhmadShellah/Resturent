﻿namespace DataCenter.GenricRepo
{
    public class SaveChangeRepository : ISaveChanges
    {
        protected readonly ApplicationDbContext _context;

        public SaveChangeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync(bool autoSave = false)
        {
            if (autoSave)
            {
                await _context.SaveChangesAsync();
            }
        }
    }
}