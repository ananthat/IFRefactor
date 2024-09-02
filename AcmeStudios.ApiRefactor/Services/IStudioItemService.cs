﻿using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeStudios.ApiRefactor.Services
{
    public interface IStudioItemService
    {
        Task<List<GetStudioItemDto>> GetAllStudioItemsAsync();
        Task<GetStudioItemDto> GetStudioItemByIdAsync(int id);
        Task<GetStudioItemDto> AddStudioItemAsync(AddStudioItemDto newStudioItem);
        Task<GetStudioItemDto> UpdateStudioItemAsync(UpdateStudioItemDto updatedStudioItem);
        Task<bool> DeleteStudioItemAsync(int id);
        Task<List<StudioItemType>> GetAllStudioItemTypesAsync();
    }
}
