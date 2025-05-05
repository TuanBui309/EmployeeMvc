using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;

namespace Entity.Services;

public class NationService : INationService
{
    private readonly INationRepository _nationRepository;
    public NationService(INationRepository nationRepository) : base()
    {
        _nationRepository = nationRepository;
    }

    public async Task<ResponseEntity> GetSingleNation(int id)
    {
        var nation = await _nationRepository.GetSingleByIdAsync(x => x.Id == id);
        if (nation == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
        }
        var result = new NationViewModel { Id = nation.Id, NationName = nation.NationName };
        return new ResponseEntity(StatusCodeConstants.Ok, result, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetSingleNationById(int id)
    {
        try
        {
            var nation = await _nationRepository.GetSingleByIdAsync(x => x.Id == id);
            if (nation == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            return new ResponseEntity(StatusCodeConstants.Ok, nation, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.NotFound);
        }
    }

    public async Task<ResponseEntity> GetAllNation()
    {
        var nations = await _nationRepository.GetAllAsync();
        return new ResponseEntity(StatusCodeConstants.Ok, nations, MessageConstants.Success);
    }

    public async Task<ResponseEntity> InsertNation(NationViewModel model)
    {
        try
        {
            Nation nations = new()
            {
                NationName = model.NationName
            };
            await _nationRepository.InsertAsync(nations);
            return new ResponseEntity(StatusCodeConstants.Ok, nations, MessageConstants.InsertSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.InsertFailure);
        }
    }

    public async Task<ResponseEntity> UpdateNation(NationViewModel model)
    {
        try
        {
            var nation = await _nationRepository.GetSingleByIdAsync(c => c.Id == model.Id);
            if (nation == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            nation.Id = model.Id;
            nation.NationName = model.NationName;
            await _nationRepository.UpdateAsync(nation, nation);
            return new ResponseEntity(StatusCodeConstants.Ok, model, MessageConstants.UpdateFailure);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.UpdateFailure);
        }
    }

    public async Task<ResponseEntity> DeleteNation(int id)
    {
        try
        {
            var nation = await _nationRepository.GetSingleByIdAsync(c => c.Id == id);
            if (nation == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            await _nationRepository.DeleteAsync(nation);
            return new ResponseEntity(StatusCodeConstants.Ok, nation, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.DeleteFailure);
        }
    }
}
