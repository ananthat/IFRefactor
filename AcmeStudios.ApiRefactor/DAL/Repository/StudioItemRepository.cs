using AcemStudios.ApiRefactor;
using AcemStudios.ApiRefactor.Data;
using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.Data.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AcmeStudios.ApiRefactor.DAL.Repository
{
    public class StudioItemRepository : IStudioItemRepository
    {
        private readonly StudioDBContext _dbContext;
        public StudioItemRepository(StudioDBContext studioDBContext)
        {
            _dbContext = studioDBContext;
        }

        public async Task<StudioItem> AddStudioItem(StudioItem newStudioItem)
        {
            await _dbContext.StudioItems.AddAsync(newStudioItem);
            await _dbContext.SaveChangesAsync();
            return newStudioItem;
        }

        public async Task<List<StudioItem>> GetAllStudioHeaderItems()
        {
            return await _dbContext.StudioItems.ToListAsync();
        }

        public async Task<StudioItem> GetStudioItemById(int id)
        {
            return await _dbContext.StudioItems
                        .Include(type => type.StudioItemType)
                        .FirstOrDefaultAsync(x => x.StudioItemId == id);
        }

        public async Task<StudioItem> UpdateStudioItem(StudioItem updatedStudioItem)
        {
            _dbContext.StudioItems.Update(updatedStudioItem);
            await _dbContext.SaveChangesAsync();
            return updatedStudioItem;
        }

        public async Task<bool> DeleteStudioItem(int id)
        {
            var item = await _dbContext.StudioItems.FirstOrDefaultAsync(c => c.StudioItemId == id);
            if (item != null)
            {
                _dbContext.Remove(item);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            { 
                return false; 
            }
        }

        public async Task<List<StudioItemType>> GetAllStudioItemTypes()
        {
            return await _dbContext.StudioItemTypes.ToListAsync();
        }
    }
}
