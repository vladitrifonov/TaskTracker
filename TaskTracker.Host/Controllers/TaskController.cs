using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Contracts.Contracts;
using TaskTracker.Host.Common;

namespace TaskTracker.Host.Controllers
{
    public class TaskController : Controller
    {        
        private readonly IRepository<Contracts.DataTypes.Task> _taskRepository;
        private readonly INotification _notifyService;

        public TaskController(IRepository<Contracts.DataTypes.Task> taskRepository, INotification notifyService)
        {
            _taskRepository = taskRepository;
            _notifyService = notifyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           List<Contracts.DataTypes.Task> tasks = await _taskRepository.ListAsync();

            return View(tasks);
        }
               
        [HttpGet]
        public Task<PartialViewResult> Create()
        {
            return System.Threading.Tasks.Task.FromResult(PartialView("Create", new Contracts.DataTypes.Task()));
        }
               
        [HttpGet]
        public async Task<PartialViewResult> Edit(int id)
        {
            return PartialView("Edit", await _taskRepository.GetByIdAsync(id));
        }
              
        [HttpPost]
        public async Task<IActionResult> Create(Contracts.DataTypes.Task model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<Contracts.DataTypes.Task> tasks = await _taskRepository.ListAsync();

                    await _taskRepository.AddAsync(model);
                    _notifyService.Success(TextHelper.Created(model.Name));

                    return Json(new { succeeded = true });
                }
                catch (Exception)
                {
                    _notifyService.Error(TextHelper.CouldNotCreated(model.Name));

                    return Json(new { succeeded = true });
                }
            }
            
            return PartialView("Create", model);
        }
               
        [HttpPost]
        public async Task<IActionResult> Edit(Contracts.DataTypes.Task model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _taskRepository.UpdateAsync(model);
                    _notifyService.Success(TextHelper.Updated(model.Name));

                    return Json(new { succeeded = true });
                }
                catch (Exception)
                {
                    _notifyService.Error(TextHelper.CouldNotUpdated(model.Name));

                    return Json(new { succeeded = true });
                }
            }

            return PartialView("Edit", model);
        }
                
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _taskRepository.DeleteAsync(id);
                _notifyService.Success(TextHelper.Deleted(nameof(Contracts.DataTypes.Task)));

                return Json(new { succeeded = true });
            }
            catch (Exception)
            {
                _notifyService.Error(TextHelper.ErrorDeleting(nameof(Contracts.DataTypes.Task)));

                return Json(new { succeeded = true });
            }
        }
    }
}
