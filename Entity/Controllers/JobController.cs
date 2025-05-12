using Microsoft.AspNetCore.Mvc;
using Entity.Services.Interface;
using Entity.Constants;
using Entity.Data.Request;

namespace Entity.Controllers;

[Route("[controller]")]
public class JobController : Controller
{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _jobService.GetAllJob();
        return View(result.Content);
    }

    [HttpGet("Create")]
    public IActionResult Create() => View();

    [HttpPost("Create")]
    public async Task<IActionResult> Create(JobViewModel model)
    {
        var result = await _jobService.InsertJob(model);
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
        var job = await _jobService.GetSingleJob(id);
        if (job.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("Index");
        }
        return View(job.Content);
    }

    [HttpGet("Edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var result = await _jobService.GetSingleJob(id);
        if (result.StatusCode == StatusCodeConstants.NotFound)
        {
            TempData["Error"] = "Not found";
            return RedirectToAction("Index");
        }
        return View(result.Content);
    }

    [HttpPost("Edit")]
    public async Task<IActionResult> Edit(JobViewModel model)
    {
        var result = await _jobService.UpdateJob(model);
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
        var result = await _jobService.DeleteJob(id);
        if (result.StatusCode == StatusCodeConstants.Ok)
        {
            TempData["Success"] = result.Message;
            return RedirectToAction("Index");
        }
        TempData["Error"] = result.Message;
        return RedirectToAction("Index");
    }

    [HttpGet("GetAllJob")]
    public async Task<IActionResult> GetAllJob()
    {
        return await _jobService.GetAllJob();
    }

    [HttpGet("GetJobById/{id}")]
    public async Task<IActionResult> GetJobById(int id)
    {
        return await _jobService.GetSingleJobById(id);
    }
}
