﻿using Entity.Common;
using Entity.Data.Request;

namespace Entity.Services.Interface;

public interface IDegreeService
{
	Task<ResponseEntity> GetAllDegree();
	Task<ResponseEntity> GetDegreeById(int id);
	Task<ResponseEntity> InsertDegree(DegreeViewModel model);
	Task<ResponseEntity> UpdateDegree(DegreeViewModel model);
	Task<ResponseEntity> DeleteDegree(int id);
	Task<IEnumerable<DegreeView>> GetListDegree(string keyWord = "", int? pageNumber = null);
	Task<ResponseEntity> GetSingleDegree(int id);
}
