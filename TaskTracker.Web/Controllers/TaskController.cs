using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Web.Controllers
{
    public class TaskController : Controller
    {        
        //private readonly IRepository<TaskEntity> _taskRepository;
        //private readonly INotification _notifyService;

        //public TaskController(IRepository<TaskEntity> taskRepository, INotification notifyService)
        //{
        //    _taskRepository = taskRepository;
        //    _notifyService = notifyService;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //   IEnumerable<TaskEntity> tasks = await _taskRepository.GetAsync();

        //    return View(tasks);
        //}
               
        //[HttpGet]
        //public Task<PartialViewResult> Create()
        //{
        //    return Task.FromResult(PartialView("Create", new TaskEntity()));
        //}
               
        //[HttpGet]
        //public async Task<PartialViewResult> Edit(int id)
        //{
        //    return PartialView("Edit", await _taskRepository.GetByIdAsync(id));
        //}
              
        //[HttpPost]
        //public async Task<IActionResult> Create(TaskEntity model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            IEnumerable<TaskEntity> tasks = await _taskRepository.GetAsync();

        //            await _taskRepository.AddAsync(model);
        //            _notifyService.Success(TextHelper.Created(model.Name));

        //            return Json(new { succeeded = true });
        //        }
        //        catch (Exception)
        //        {
        //            _notifyService.Error(TextHelper.CouldNotCreated(model.Name));

        //            return Json(new { succeeded = true });
        //        }
        //    }
            
        //    return PartialView("Create", model);
        //}
               
        //[HttpPost]
        //public async Task<IActionResult> Edit(TaskEntity model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _taskRepository.UpdateAsync(model);
        //            _notifyService.Success(TextHelper.Updated(model.Name));

        //            return Json(new { succeeded = true });
        //        }
        //        catch (Exception)
        //        {
        //            _notifyService.Error(TextHelper.CouldNotUpdated(model.Name));

        //            return Json(new { succeeded = true });
        //        }
        //    }

        //    return PartialView("Edit", model);
        //}
                
        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        TaskEntity task = await _taskRepository.GetByIdAsync(id);
        //        await _taskRepository.DeleteAsync(task);
        //        _notifyService.Success(TextHelper.Deleted(nameof(TaskEntity)));

        //        return Json(new { succeeded = true });
        //    }
        //    catch (Exception)
        //    {
        //        _notifyService.Error(TextHelper.ErrorDeleting(nameof(TaskEntity)));

        //        return Json(new { succeeded = true });
        //    }
        //}
    }
}
