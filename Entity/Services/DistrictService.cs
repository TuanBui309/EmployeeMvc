using Entity.Common;
using Entity.Constants;
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

    public async Task<ResponseEntity> GetSingleDistrictById(int id)
    {
        var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == id);
        return new ResponseEntity(StatusCodeConstants.Ok, district, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetSingleDistrict(int id)
    {
        var district = await _districtRepository.GetSingleByIdAsync(x => x.Id == id);
        if (district == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, district, MessageConstants.NotFound);
        }
        var result = new DistrictViewModel
        {
            CityId = district.CityId,
            DistrictName = district.DistrictName,
        };
        return new ResponseEntity(StatusCodeConstants.Ok, result, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetAllDistrict()
    {
        try
        {
            var districts = await _districtRepository.GetAllAsync();
            return new ResponseEntity(StatusCodeConstants.Ok, districts, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, ex.Message, MessageConstants.NotFound);
        }
    }

    public async Task<IEnumerable<DistrictView>> GetListDistrict(string keyWord = "", int? pageNumber = null)
    {
        var districts = await _districtRepository.GetAllDistrictByKeyWord(keyWord, pageNumber);
        return districts;
    }

    public async Task<ResponseEntity> GetMultiDistrictByCondition(int cityId)
    {
        try
        {
            var districts = await _districtRepository.GetMultiByCondition(c => c.CityId == cityId);
            return new ResponseEntity(StatusCodeConstants.Ok, districts, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, ex.Message, MessageConstants.NotFound);
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
            return new ResponseEntity(StatusCodeConstants.Ok, districts, MessageConstants.InsertSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }

    public async Task<ResponseEntity> UpdateDistrict(DistrictViewModel model)
    {
        try
        {
            var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == model.Id);
            if (district == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            district.CityId = model.CityId;
            district.DistrictName = model.DistrictName;
            await _districtRepository.UpdateAsync(district, district);
            return new ResponseEntity(StatusCodeConstants.Ok, district, MessageConstants.UpdateSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }

    public async Task<ResponseEntity> DeleteDistrict(int id)
    {
        try
        {
            var district = await _districtRepository.GetSingleByIdAsync(d => d.Id == id);
            if (district == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            await _districtRepository.DeleteAsync(district);
            return new ResponseEntity(StatusCodeConstants.Ok, district, MessageConstants.DeleteSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.DeleteFailure);
        }
    }
}
