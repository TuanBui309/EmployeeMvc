using Microsoft.AspNetCore.Mvc;
using Entity.Services.Interface;
using Entity.Constants;
using Entity.Data.Request;

namespace Entity.Controllers;

[Route("[controller]")]
public class NationController : Controller
{
    private readonly INationService _nationService;

    public NationController(INationService nationService)
    {
        _nationService = nationService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _nationService.GetAllNation();
        return View(result.Content);
    }

    [HttpGet("Create")]
    public IActionResult Create() => View();

    [HttpPost("Create")]
    public async Task<IActionResult> Create(NationViewModel model)
    {
        var result = await _nationService.InsertNation(model);
        if (result.StatusCode == StatusCodeConstants.Ok)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("Index");
        }
        TempData["Error"] = result.Message;
        return View(model);
    }

    [HttpGet("Details/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var nation = await _nationService.GetSingleNation(id);
        if (nation.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("Index");
        }
        return View(nation.Content);
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _nationService.GetSingleNation(id);
        if (result.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("Index");
        }
        return View(result.Content);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(NationViewModel model)
    {
        var result = await _nationService.UpdateNation(model);
        if (result.StatusCode == StatusCodeConstants.Ok)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("Index");
        }
        TempData["Error"] = result.Message;
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var result = await _nationService.DeleteNation(id);
        if (result.StatusCode == StatusCodeConstants.Ok)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("Index");
        }
        TempData["Error"] = result.Message;
        return RedirectToAction("Index");
    }

    [HttpGet("GetAllNation")]
    public async Task<IActionResult> GetAllNation()
    {
        return await _nationService.GetAllNation();
    }

    [HttpGet("GetNationById/{id}")]
    public async Task<IActionResult> GetNationById(int id)
    {
        return await _nationService.GetSingleNationById(id);
    }
}
