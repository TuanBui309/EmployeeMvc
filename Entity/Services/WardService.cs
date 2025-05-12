using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;

namespace Entity.Services;

public class WardService : IWardService
{
	private readonly IWardRepository _wardRepository;
	private readonly IDistrictRepository _districtRepository;
	public WardService(IWardRepository wardRepository, IDistrictRepository districtRepository) : base()
	{
		_wardRepository = wardRepository;
            _districtRepository = districtRepository;
	}

	public async Task<ResponseEntity> DeleteWard(int id)
	{
		try
		{
			var ward = await _wardRepository.GetSingleByIdAsync(c => c.Id == id);
			if (ward == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			await _wardRepository.DeleteAsync(ward);
			return new ResponseEntity(StatusCodeConstants.OK, ward, MessageConstants.DELETE_SUCCESS);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.DELETE_ERROR);
		}
	}

	public async Task<ResponseEntity> GetAllWard()
	{
		var wards = await _wardRepository.GetAllAsync();
		return new ResponseEntity(StatusCodeConstants.OK, wards, MessageConstants.MESSAGE_SUCCESS_200);
	}

	public async Task<IEnumerable<WardViewModel>> GetListWard(string keyWord = "", int? pageNumber = null)
	{
		var wards = await _wardRepository.GetAllWardByKeyWord(keyWord, pageNumber);
		return wards;
	}

	public async Task<ResponseEntity> GetMultiWardByCondition(int DistrictId)
	{
		try
		{
			var wards = await _wardRepository.GetMultiByCondition(c => c.DistrictId == DistrictId);
			if (wards == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			return new ResponseEntity(StatusCodeConstants.OK, wards, MessageConstants.MESSAGE_SUCCESS_200);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.MESSAGE_ERROR_404);
		}
	}

	public async Task<ResponseEntity> GetSingleWard(int id)
	{
		var ward = await _wardRepository.GetSingleByIdAsync(x => x.Id == id);
		if (ward == null)
		{
			return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
		}
		var result = new WardViewModel
		{
			Id = ward.Id,
			DistrictId = ward.DistrictId,
			DistrictName = _districtRepository.GetSingleByIdAsync(x => x.Id == ward.DistrictId).Result?.DistrictName ?? "",
			WardName = ward.WardName,
		};
		return new ResponseEntity(StatusCodeConstants.OK, result, MessageConstants.MESSAGE_SUCCESS_200);
	}

	public async Task<ResponseEntity> GetSingleWardById(int id)
	{
		try
		{
			var ward = await _wardRepository.GetSingleByIdAsync(c => c.Id == id);
			if (ward == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			return new ResponseEntity(StatusCodeConstants.OK, ward, MessageConstants.MESSAGE_SUCCESS_200);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.MESSAGE_ERROR_404);
		}
	}

	public async Task<ResponseEntity> InsertWard(WardViewModel model)
	{
		try
		{
			Ward wards = new()
			{
				DistrictId = model.DistrictId,
				WardName = model.WardName
			};
			await _wardRepository.InsertAsync(wards);
			return new ResponseEntity(StatusCodeConstants.OK, wards, MessageConstants.INSERT_SUCCESS);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.INSERT_ERROR);
		}
	}

	public async Task<ResponseEntity> UpdateWard(WardViewModel model)
	{
		try
		{
			var ward = await _wardRepository.GetSingleByIdAsync(c => c.Id == model.Id);
			if (ward == null)
			{
				return new ResponseEntity(StatusCodeConstants.NOT_FOUND, "", MessageConstants.MESSAGE_ERROR_404);
			}
			ward.DistrictId = model.DistrictId;
			ward.WardName = model.WardName;
			await _wardRepository.UpdateAsync(ward, ward);
			return new ResponseEntity(StatusCodeConstants.OK, model, MessageConstants.MESSAGE_SUCCESS_200);
		}
		catch (Exception ex)
		{
			return new ResponseEntity(StatusCodeConstants.BAD_REQUEST, ex.Message, MessageConstants.UPDATE_ERROR);
		}
	}
}
