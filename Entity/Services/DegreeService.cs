using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;
using Entity.Util.Utilities;

namespace Entity.Services;

public class DegreeService : IDegreeService
{
    private readonly IDegreeRepository _degreeRepository;

    public DegreeService(IDegreeRepository degreeRepository) : base()
    {
        _degreeRepository = degreeRepository;
    }

    public async Task<ResponseEntity> GetDegreeById(int id)
    {
        try
        {
            var degree = await _degreeRepository.GetSingleByIdAsync(x => x.Id == id);
            if (degree == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }

            return new ResponseEntity(StatusCodeConstants.Ok, degree, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, ex.Message, MessageConstants.NotFound);
        }
    }

    public async Task<ResponseEntity> GetSingleDegree(int id)
    {
        var degree = await _degreeRepository.GetSingleByIdAsync(x => x.Id == id);
        if (degree == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
        }
        var result = new DegreeViewModel
        {
            EmployeeId = degree.EmployeeId,
            DegreeName = degree.DegreeName,
            DateRange = FuncUtilities.ConvertDateToString(degree.DateRange),
            IssuedBy = degree.IssuedBy,
            DateOfExpiry = FuncUtilities.ConvertDateToString(degree.DateOfExpiry)

        };
        return new ResponseEntity(StatusCodeConstants.Ok, result, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetAllDegree()
    {
        var degrees = await _degreeRepository.GetAllAsync();
        return new ResponseEntity(StatusCodeConstants.Ok, degrees, MessageConstants.Success);
    }

    public async Task<IEnumerable<DegreeView>> GetListDegree(string keyWord = "", int? pageNumber = null)
    {
        var degree = await _degreeRepository.GetAllDegreeByKeyWord(keyWord, pageNumber);
        return degree;
    }

    public async Task<ResponseEntity> InsertDegree(DegreeViewModel model)
    {
        try
        {
            Degree degrees = new()
            {
                EmployeeId = model.EmployeeId,
                DegreeName = model.DegreeName,
                DateRange = FuncUtilities.ConvertStringToDate(model.DateRange),
                IssuedBy = model.IssuedBy,
                DateOfExpiry = FuncUtilities.ConvertStringToDate(model.DateOfExpiry)
            };
            await _degreeRepository.InsertAsync(degrees);
            return new ResponseEntity(StatusCodeConstants.Ok, degrees, MessageConstants.InsertSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.InsertFailure);
        }
    }

    public async Task<ResponseEntity> UpdateDegree(DegreeViewModel model)
    {
        try
        {
            var degree = await _degreeRepository.GetSingleByIdAsync(x => x.Id == model.Id);
            if (degree == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            degree.EmployeeId = model.EmployeeId;
            degree.DegreeName = model.DegreeName;
            degree.DateRange = FuncUtilities.ConvertStringToDate(model.DateRange);
            degree.IssuedBy = model.IssuedBy;
            degree.DateOfExpiry = FuncUtilities.ConvertStringToDate(model.DateOfExpiry);
            await _degreeRepository.UpdateAsync(degree, degree);
            return new ResponseEntity(StatusCodeConstants.Ok, degree, MessageConstants.UpdateSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.UpdateFailure);
        }
    }

    public async Task<ResponseEntity> DeleteDegree(int id)
    {
        try
        {
            var degree = await _degreeRepository.GetSingleByIdAsync(x => x.Id == id);
            if (degree == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            await _degreeRepository.DeleteAsync(degree);
            return new ResponseEntity(StatusCodeConstants.Ok, degree, MessageConstants.DeleteSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.DeleteFailure);
        }
    }
}
