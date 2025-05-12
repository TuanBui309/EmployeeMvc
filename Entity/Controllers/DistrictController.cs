using Microsoft.AspNetCore.Mvc;
using Entity.Services.Interface;
using FluentValidation;
using FluentValidation.Results;
using Entity.Constants;
using Entity.Data.Request;

namespace Entity.Controllers;

[Route("[controller]")]
public class DistrictController : Controller
{
    private readonly IValidator<DistrictViewModel> _validator;
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService, IValidator<DistrictViewModel> validator)
    {
        _districtService = districtService;
        _validator = validator;
    }

    public async Task<IActionResult> Index(string keyWord = "", int? pageNumber = null)
    {
        var result = await _districtService.GetListDistrict(keyWord, pageNumber);
        return PartialView(result);
    }

    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _districtService.GetSingleDistrict(id);
        if (result.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(result.Content);
    }

    [HttpGet("Create")]
    public IActionResult Create() => View();

    [HttpPost("Create")]
    public async Task<IActionResult> Create(DistrictViewModel model)
    {
        ValidationResult result = await _validator.ValidateAsync(model);
        if (result.IsValid)
        {
            var employee = await _districtService.InsertDistrict(model);
            if (employee.StatusCode == StatusCodeConstants.Ok)
            {
                TempData["Success"] = employee.Message;
                return RedirectToAction("");
            }
            TempData["Error"] = employee.Message;
            return View(model);
        }
        else
        {
            foreach (var fail in result.Errors)
            {
                ModelState.AddModelError(fail.PropertyName, fail.ErrorMessage);
            }
            return View(model);
        }
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var results = await _districtService.GetSingleDistrict(id);
        if (results.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(results.Content);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(DistrictViewModel model)
    {
        ValidationResult result = await _validator.ValidateAsync(model);
        if (result.IsValid)
        {
            var employee = await _districtService.UpdateDistrict(model);
            if (employee.StatusCode == StatusCodeConstants.Ok)
            {
                TempData["Success"] = employee.Message;
                return RedirectToAction("");
            }
            TempData["Error"] = employee.Message;
            return View(model);
        }
        else
        {
            foreach (var fail in result.Errors)
            {
                ModelState.AddModelError(fail.PropertyName, fail.ErrorMessage);
            }
            return View(model);
        }
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var result = await _districtService.DeleteDistrict(id);
        if (result.StatusCode == StatusCodeConstants.Ok)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("");
        }
        TempData["Error"] = result.Message;
        return RedirectToAction("");
    }

    [HttpGet("GetAllDistrict")]
    public async Task<IActionResult> GetAllDistrict()
    {
        return await _districtService.GetAllDistrict();
    }

    [HttpGet("GetSingleDistrictById/{id}")]
    public async Task<IActionResult> GetSingleDistrictById(int id)
    {
        return await _districtService.GetSingleDistrictById(id);
    }

    [HttpGet("GetMultiDistrictByCondition/{provinceId}")]
    public async Task<IActionResult> GetMultiDistrictByCondition(int provinceId)
    {
        return await _districtService.GetMultiDistrictByCondition(provinceId);
    }
}
