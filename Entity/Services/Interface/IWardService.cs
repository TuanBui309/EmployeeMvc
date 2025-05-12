﻿using Entity.Constants;
using Entity.Services.ViewModels;

namespace Entity.Services.Interface;

public interface IWardService
{
	Task<ResponseEntity> GetAllWard();
	Task<ResponseEntity> GetSingleWardById(int id);
	Task<ResponseEntity> GetMultiWardByCondition(int DistrictId);
	Task<ResponseEntity> InsertWard(WardViewModel model);
	Task<ResponseEntity> UpdateWard(WardViewModel model);
	Task<ResponseEntity> DeleteWard(int id);
	Task<ResponseEntity> GetSingleWard(int id);
	Task<IEnumerable<WardViewModel>> GetListWard(string keyWord = "", int? pageNumber = null);
}
