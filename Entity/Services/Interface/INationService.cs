using Entity.Constants;
using Entity.Data.Request;

namespace Entity.Services.Interface;

public interface INationService
{
	Task<ResponseEntity> GetAllNation();
	Task<ResponseEntity> GetSingleNationById(int id);
	Task<ResponseEntity> InsertNation(NationViewModel model);
	Task<ResponseEntity> UpdateNation(NationViewModel model);
	Task<ResponseEntity> DeleteNation(int id);
	Task<ResponseEntity> GetSingleNation(int id);
}
