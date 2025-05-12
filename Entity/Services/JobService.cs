using Entity.Constants;
using Entity.Data.Entity;
using Entity.Data.Request;
using Entity.Repository.Repositories;
using Entity.Services.Interface;
namespace Entity.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    public JobService(IJobRepository jobRepository) : base()
    {
        _jobRepository = jobRepository;
    }

    public async Task<ResponseEntity> GetSingleJob(int id)
    {
        var job = await _jobRepository.GetSingleByIdAsync(x => x.Id == id);
        if (job == null)
        {
            return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
        }
        var result = new JobViewModel { Id = job.Id, JobName = job.JobName };
        return new ResponseEntity(StatusCodeConstants.Ok, result, MessageConstants.Success);
    }

    public async Task<ResponseEntity> GetSingleJobById(int id)
    {
        try
        {
            var job = await _jobRepository.GetSingleByIdAsync(c => c.Id == id);
            if (job == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            return new ResponseEntity(StatusCodeConstants.Ok, job, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.BadRequest);
        }
    }

    public async Task<ResponseEntity> GetAllJob()
    {
        var jobs = await _jobRepository.GetAllAsync();
        return new ResponseEntity(StatusCodeConstants.Ok, jobs, MessageConstants.Success);
    }

    public async Task<ResponseEntity> InsertJob(JobViewModel model)
    {
        try
        {
            Job jobs = new()
            {
                JobName = model.JobName
            };
            await _jobRepository.InsertAsync(jobs);
            return new ResponseEntity(StatusCodeConstants.Ok, jobs, MessageConstants.InsertSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.InsertFailure);
        }
    }

    public async Task<ResponseEntity> UpdateJob(JobViewModel model)
    {
        try
        {
            var job = await _jobRepository.GetSingleByIdAsync(c => c.Id == model.Id);
            if (job == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            job.Id = model.Id;
            job.JobName = model.JobName;
            await _jobRepository.UpdateAsync(job, job);
            return new ResponseEntity(StatusCodeConstants.Ok, model, MessageConstants.Success);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.UpdateFailure);
        }
    }

    public async Task<ResponseEntity> DeleteJob(int id)
    {
        try
        {
            var job = await _jobRepository.GetSingleByIdAsync(c => c.Id == id);
            if (job == null)
            {
                return new ResponseEntity(StatusCodeConstants.NotFound, "", MessageConstants.NotFound);
            }
            await _jobRepository.DeleteAsync(job);
            return new ResponseEntity(StatusCodeConstants.Ok, job, MessageConstants.DeleteSuccess);
        }
        catch (Exception ex)
        {
            return new ResponseEntity(StatusCodeConstants.BadRequest, ex.Message, MessageConstants.DeleteFailure);
        }
    }
}
