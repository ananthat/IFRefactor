using AcemStudios.ApiRefactor.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.Data.DTOs;

namespace AcmeStudios.ApiRefactor.DAL.Repository
{
    public interface IStudioItemRepository
    {
        Task<StudioItem> AddStudioItem(StudioItem newStudioItem);

        Task<List<StudioItem>> GetAllStudioHeaderItems();

        Task<StudioItem> GetStudioItemById(int id);

        Task<StudioItem> UpdateStudioItem(StudioItem updatedStudioItem);

        Task<bool> DeleteStudioItem(int id);

        Task<List<StudioItemType>> GetAllStudioItemTypes();
    }
}
