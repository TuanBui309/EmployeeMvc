using Entity.Common;
using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;

namespace Entity.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository) : base()
    {
        _cityRepository = cityRepository;
    }

    public async Task<ResponseEntity> GetSingleCityById(int id)
    {
        var city = await _cityRepository.GetSingleByIdAsync(c => c.Id == id);
        if (city == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
        }
        return new ResponseEntity(StatusCodeConstants.Ok, city, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetSingleCity(int id)
    {
        var city = await _cityRepository.GetSingleByIdAsync(x => x.Id == id);
        if (city == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
        }
        var result = new CityViewModel
        {
            Id = city.Id,
            CityName = city.CityName,
        };
        return new ResponseEntity(StatusCodeConstants.Ok, result, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetAllCityByCondition(int id, string name)
    {
        try
        {
            var cities = await _cityRepository.GetMultiByCondition(c => c.Id == id && c.CityName == name);
            return new ResponseEntity(StatusCodeConstants.Ok, cities, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, ex.Message, MessageConstants.NotFound);
        }
    }

    public async Task<IEnumerable<City>> GetListCity(string keyWord = "", int? pageNumber = null)
    {
        var cities = await _cityRepository.GetAllCityByKeWord(keyWord, pageNumber);
        return cities;
    }
    public async Task<ResponseEntity> GetAllCity()
    {
        var cities = await _cityRepository.GetAllAsync();
        return new ResponseEntity(StatusCodeConstants.Ok, cities, MessageConstants.Success);
    }

    public async Task<ResponseEntity> InsertCity(CityViewModel model)
    {

        try
        {
            City Cities = new()
            {
                CityName = model.CityName
            };
            await _cityRepository.InsertAsync(Cities);
            return new ResponseEntity(StatusCodeConstants.Ok, Cities, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }

    public async Task<ResponseEntity> UpdateCity(int id, CityViewModel model)
    {
        try
        {
            var singleCity = await _cityRepository.GetSingleByIdAsync(c => c.Id == id);
            if (singleCity == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "aaa", MessageConstants.NotFound);
            }
            singleCity.CityName = model.CityName;
            await _cityRepository.UpdateAsync(singleCity, singleCity);
            return new ResponseEntity(StatusCodeConstants.Ok, model, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }

    public async Task<ResponseEntity> DeleteCity(int id)
    {
        try
        {
            var singleCity = await _cityRepository.GetSingleByIdAsync(c => c.Id == id);
            if (singleCity == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            await _cityRepository.DeleteAsync(singleCity);
            return new ResponseEntity(StatusCodeConstants.Ok, singleCity, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }
}
