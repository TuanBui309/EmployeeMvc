﻿using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;

namespace Entity.Services;

public class DistrictService : IDistrictService
{
	private readonly IDistrictRepository _districtRepository;
	
	public DistrictService(IDistrictRepository districtRepository) 
	{
		_districtRepository = districtRepository;
	}

	public async Task<ResponseEntity> DeleteDistrict(int id)
	{
		try
		{
			var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == id);
			if (district == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			await _districtRepository.DeleteAsync(district);
			return new ResponseEntity(StatusCodeConstants.OK, district, MessageConstants.DELETE_SUCCESS);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.DELETE_ERROR);
		}
	}

	public async Task<ResponseEntity> GetAllDistrict()
	{
		try
		{
			var districts = await _districtRepository.GetAllAsync();
			return new ResponseEntity(StatusCodeConstants.OK, districts, MessageConstants.MESSAGE_SUCCESS_200);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.NOT_FOUND, ex.Message, MessageConstants.MESSAGE_ERROR_400);
		}
	}

	public async Task<IEnumerable<DistrictView>> GetListDistrict(string keyWord = "", int? pageNumber = null)
	{
		var districts = await _districtRepository.GetAllDistrictByKeyWord(keyWord,pageNumber);
		return districts;
	}

	public async Task<ResponseEntity> GetSingleDistrictById(int id)
	{
		var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == id);
		return new ResponseEntity(StatusCodeConstants.OK, district, MessageConstants.MESSAGE_SUCCESS_200);
	}

	public async Task<ResponseEntity> GetSingleDistrict(int id)
	{
		var district = await _districtRepository.GetSingleByIdAsync(x => x.Id == id);
		if (district == null)
		{
			return new ResponseEntity(StatusCodeConstants.NOT_FOUND, district, MessageConstants.MESSAGE_ERROR_404);
		}
		var result = new DistrictViewModel
		{
			CityId = district.CityId,
			DistrictName = district.DistrictName,
		};
		return new ResponseEntity(StatusCodeConstants.OK, result, MessageConstants.MESSAGE_SUCCESS_200);
	}
	public async Task<ResponseEntity> GetMultiDistrictByCondition(int cityId)
	{
		try
		{
			var districts = await _districtRepository.GetMultiByCondition(c => c.CityId == cityId);
			return new ResponseEntity(StatusCodeConstants.OK, districts, MessageConstants.MESSAGE_SUCCESS_200);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.MESSAGE_ERROR_404);
		}
	}

	public async Task<ResponseEntity> InsertDistrict(DistrictViewModel model)
	{
		try
		{
                District districts = new()
                {
                    CityId = model.CityId,
                    DistrictName = model.DistrictName
                };
                await _districtRepository.InsertAsync(districts);
			return new ResponseEntity(StatusCodeConstants.OK, districts, MessageConstants.INSERT_SUCCESS);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.INSERT_ERROR);
		}
	}

	public async Task<ResponseEntity> UpdateDistrict(DistrictViewModel model)
	{
		try
		{
			var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == model.Id);
			if (district == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			district.CityId = model.CityId;
			district.DistrictName = model.DistrictName;
			await _districtRepository.UpdateAsync(district, district);
			return new ResponseEntity(StatusCodeConstants.OK, district, MessageConstants.UPDATE_SUCCESS);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.UPDATE_ERROR);
		}
	}
}
