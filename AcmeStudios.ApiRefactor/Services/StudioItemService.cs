using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.DAL.Repository;
using AcmeStudios.ApiRefactor.Data.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcmeStudios.ApiRefactor.Services
{
    public class StudioItemService : IStudioItemService
    {
        private readonly IStudioItemRepository _studioItemRepository;
        private readonly IMapper _mapper;

        public StudioItemService(IStudioItemRepository studioItemRepository, IMapper mapper)
        {
            _studioItemRepository = studioItemRepository;
            _mapper = mapper;
        }

        public async Task<List<GetStudioItemDto>> GetAllStudioItemsAsync()
        {
            var studioItems = await _studioItemRepository.GetAllStudioHeaderItems();
            return _mapper.Map<List<GetStudioItemDto>>(studioItems);
        }

        public async Task<GetStudioItemDto> GetStudioItemByIdAsync(int id)
        {
            var studioItem = await _studioItemRepository.GetStudioItemById(id);
            if (studioItem == null)
            {
                throw new KeyNotFoundException("Studio item not found.");
            }
            return _mapper.Map<GetStudioItemDto>(studioItem);
        }

        public async Task<GetStudioItemDto> AddStudioItemAsync(AddStudioItemDto newStudioItem)
        {
            var studioItem = _mapper.Map<StudioItem>(newStudioItem);
            studioItem = await _studioItemRepository.AddStudioItem(studioItem);
            return _mapper.Map<GetStudioItemDto>(studioItem);
        }

        public async Task<GetStudioItemDto> UpdateStudioItemAsync(UpdateStudioItemDto updatedStudioItem)
        {
            var studioItem = await _studioItemRepository.GetStudioItemById(updatedStudioItem.StudioItemId);
            if (studioItem == null)
            {
                throw new KeyNotFoundException("Studio item not exist.");
            }
            _mapper.Map(updatedStudioItem, studioItem);
            studioItem = await _studioItemRepository.UpdateStudioItem(studioItem);
            return _mapper.Map<GetStudioItemDto>(studioItem);
        }

        public async Task<bool> DeleteStudioItemAsync(int id)
        {
            var studioItem = await _studioItemRepository.DeleteStudioItem(id);
            if (!studioItem)
            {
                throw new KeyNotFoundException("Studio item not exist.");
            }
            else
            {
                return true;
            }   
        }

        public async Task<List<StudioItemType>> GetAllStudioItemTypesAsync()
        {
            var itemTypes = await _studioItemRepository.GetAllStudioItemTypes();
            if (itemTypes == null || itemTypes.Count == 0)
            {
                throw new KeyNotFoundException("No Data Found.");
            }
            return _mapper.Map<List<StudioItemType>>(itemTypes);
        }
    }
}
