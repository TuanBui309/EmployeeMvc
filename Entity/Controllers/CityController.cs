﻿using Entity.Constants;
using Entity.Services.Interface;
using Entity.Services.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Entity.Controllers;

public class CityController : Controller
{
    private readonly ICityService _cityService;
    private readonly IValidator<CityViewModel> _validator;
    public CityController(ICityService cityService, IValidator<CityViewModel> validator)
    {
        _cityService = cityService;
        _validator = validator;
    }

    public async Task<IActionResult> Index(String keyWord="",int? pageNumber=null)
    {
        var result = await _cityService.GetListCity(keyWord,pageNumber); 
        return View(result);
    }

    public async Task<IActionResult> Details(int id)
    {
        var city = await _cityService.GetSingleCity(id);
        if (city.StatusCode == StatusCodeConstants.NOT_FOUND)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(city.Content);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CityViewModel city)
    {
        ValidationResult result = await _validator.ValidateAsync(city);
        if (result.IsValid)
        {
            var employee = await _cityService.InsertCity(city);
            if (employee.StatusCode == StatusCodeConstants.OK)
            {
                TempData["Success"] = employee.Message;
                return RedirectToAction("");
            }
            TempData["Error"] = employee.Message;
            return View(city);
        }
        else
        {
            foreach (var fail in result.Errors)
            {
                ModelState.AddModelError(fail.PropertyName, fail.ErrorMessage);
            }
            return View(city);
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        var result = await _cityService.GetSingleCity(id);
        if (result.StatusCode == StatusCodeConstants.NOT_FOUND)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("");
        }
        return View(result.Content);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CityViewModel model, int id)
    {
        ValidationResult result = await _validator.ValidateAsync(model);
        if (result.IsValid)
        {
            var city = await _cityService.UpdateCity(id, model);
            if (city.StatusCode == StatusCodeConstants.OK)
            {
                TempData["Success"] = city.Message;
                return RedirectToAction("");
            }
            TempData["Error"] = city.Message;
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
        var result = await _cityService.DeleteCity(id);
        if (result.StatusCode == StatusCodeConstants.OK)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("");
        }
        TempData["Error"] = result.Message;
        return RedirectToAction("");
    }

    [HttpGet("GetAllCity")]
    public async Task<IActionResult> GetALLCity()
    {
        var result = await _cityService.GetAllCity();
        return result;
    }

    [HttpGet("GetCityById")]
    public async Task<IActionResult> GetCityById(int CityId)
    {
        return await _cityService.GetSingleCityById(CityId);
    }

    [HttpGet("GetCityByCondition")]
    public async Task<IActionResult> GetCityByCondition(int CityId, string name)
    {
        return await _cityService.GetAllCityByCondition(CityId, name);
    }


}
