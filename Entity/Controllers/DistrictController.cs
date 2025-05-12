﻿using Microsoft.AspNetCore.Mvc;
using Entity.Services.Interface;
using FluentValidation;
using FluentValidation.Results;
using Entity.Constants;
using Entity.Data.Request;

namespace Entity.Controllers;

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

    public async Task<IActionResult> Details(int id)
    {
        var result = await _districtService.GetSingleDistrict(id);
        if (result.StatusCode == StatusCodeConstants.NOT_FOUND)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(result.Content);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(DistrictViewModel model)
    {
        ValidationResult result = await _validator.ValidateAsync(model);
        if (result.IsValid)
        {
            var employee = await _districtService.InsertDistrict(model);
            if (employee.StatusCode == StatusCodeConstants.OK)
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

    public async Task<IActionResult> Edit(int id)
    {
        var results = await _districtService.GetSingleDistrict(id);
        if (results.StatusCode == StatusCodeConstants.NOT_FOUND)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(results.Content);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DistrictViewModel model)
    {
        ValidationResult result = await _validator.ValidateAsync(model);
        if (result.IsValid)
        {
            var employee = await _districtService.UpdateDistrict(model);
            if (employee.StatusCode == StatusCodeConstants.OK)
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
        if (result.StatusCode == StatusCodeConstants.OK)
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

    [HttpGet("GetSingleDistrictById")]
    public async Task<IActionResult> GetSingleDistrictById(int id)
    {
        return await _districtService.GetSingleDistrictById(id);
    }

    [HttpGet("GetMultiDistrictByCondition")]
    public async Task<IActionResult> GetMultiDistrictByCondition(int provinceId)
    {
        return await _districtService.GetMultiDistrictByCondition(provinceId);
    }
}
