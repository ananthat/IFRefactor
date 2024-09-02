using AcmeStudios.ApiRefactor.Data.DTOs;
using AcmeStudios.ApiRefactor.Model;
using AcmeStudios.ApiRefactor.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using System.Threading.Tasks;
using AcmeStudios.ApiRefactor.DAL.Entities;

namespace AcemStudios.ApiRefactor.Controllers
{
    [Route("peoplespartnership/api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        private readonly IStudioItemService _studioItemService;
        private readonly IMapper _mapper;

        public StudioController(IStudioItemService studioItemService, IMapper mapper)
        {
            _studioItemService = studioItemService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var endPointResponse = new EndPointResponse<List<GetStudioItemDto>>();
            try
            {
                var studioItems = await _studioItemService.GetAllStudioItemsAsync();
                
                endPointResponse.Data = _mapper.Map<List<GetStudioItemDto>>(studioItems); ;
                endPointResponse.IsSuccess = true;
                endPointResponse.StatusCode = HttpStatusCode.OK;
                return Ok(endPointResponse);
            }
            catch (Exception ex)
            {
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var endPointResponse = new EndPointResponse<GetStudioItemDto>();
            try
            {
                var studioItem = await _studioItemService.GetStudioItemByIdAsync(id);
                endPointResponse.IsSuccess = true;
                endPointResponse.Data = _mapper.Map<GetStudioItemDto>(studioItem);
                endPointResponse.StatusCode = HttpStatusCode.OK;
                return Ok(endPointResponse);
            }
            catch (KeyNotFoundException ex)
            {
                endPointResponse.CustomMessage = ex.Message;
                endPointResponse.StatusCode = HttpStatusCode.NotFound;
                return NotFound(endPointResponse);
            }
            catch (Exception ex)
            {
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddStudioItemDto addStudioItemDto)
        {
            var endPointResponse = new EndPointResponse<GetStudioItemDto>();
            try
            {
                if (addStudioItemDto == null)
                {
                    return BadRequest();
                }
                var newStudioItem = await _studioItemService.AddStudioItemAsync(addStudioItemDto);
                endPointResponse.Data = _mapper.Map<GetStudioItemDto>(newStudioItem);
                endPointResponse.StatusCode = HttpStatusCode.OK;
                return Ok(newStudioItem.StudioItemId);
            }
            catch (Exception ex)
            {
                endPointResponse.IsSuccess = false;
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudioItemDto updateStudioItemDto)
        {
            var endPointResponse = new EndPointResponse<GetStudioItemDto>();
            try
            {
                if (updateStudioItemDto == null)
                {
                    return BadRequest();
                }

                var updatedStudioItem = await _studioItemService.UpdateStudioItemAsync(updateStudioItemDto);
                endPointResponse.Data = _mapper.Map<GetStudioItemDto>(updatedStudioItem);
                endPointResponse.StatusCode = HttpStatusCode.OK;
                return Ok(endPointResponse);
            }
            catch (KeyNotFoundException ex)
            {
                endPointResponse.IsSuccess = false;
                endPointResponse.StatusCode = HttpStatusCode.NotFound;
                return NotFound(endPointResponse);
            }
            catch (Exception ex)
            {
                endPointResponse.IsSuccess = false;
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var endPointResponse = new EndPointResponse<GetStudioItemDto>();
            try
            {
                var result = await _studioItemService.DeleteStudioItemAsync(id);
                endPointResponse.StatusCode = HttpStatusCode.OK;
                endPointResponse.IsSuccess = true;
                return Ok(endPointResponse);
            }
            catch (KeyNotFoundException ex)
            {
                endPointResponse.StatusCode = HttpStatusCode.NotFound;
                return NotFound(endPointResponse);
            }
            catch (Exception ex)
            {
                endPointResponse.IsSuccess = false;
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudioItemTypes()
        {
            var endPointResponse = new EndPointResponse<List<StudioItemType>>();
            try
            {
                var studioItemTypesDto = await _studioItemService.GetAllStudioItemTypesAsync();
                endPointResponse.Data = studioItemTypesDto;
                endPointResponse.IsSuccess = true;
                endPointResponse.StatusCode = HttpStatusCode.OK;
                return Ok(endPointResponse);
            }
            catch (KeyNotFoundException ex)
            {
                endPointResponse.StatusCode = HttpStatusCode.NotFound;
                return NotFound(endPointResponse);
            }
            catch (Exception ex)
            {
                endPointResponse.IsSuccess = false;
                endPointResponse.CustomMessage = ex.ToString();
                endPointResponse.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)endPointResponse.StatusCode, endPointResponse);
            }
        }
    }
}