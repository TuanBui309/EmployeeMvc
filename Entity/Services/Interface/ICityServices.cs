﻿using Entity.Common;
using Entity.Data.Entity;
using Entity.Data.Request;

namespace Entity.Services.Interface;

public interface ICityService
{
	Task<ResponseEntity> GetAllCity();
	Task<ResponseEntity> GetSingleCityById(int id);
	Task<ResponseEntity> InsertCity(CityViewModel model);
	Task<ResponseEntity> UpdateCity(int id, CityViewModel model);
	Task<ResponseEntity> DeleteCity(int id);
	Task<ResponseEntity> GetAllCityByCondition(int id, string name);
	Task<ResponseEntity> GetSingleCity(int id);
	Task<IEnumerable<City>> GetListCity(string keyWord = "", int? pageNumber = null);
}
