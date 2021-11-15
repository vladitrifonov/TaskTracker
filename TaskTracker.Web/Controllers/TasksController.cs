using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Application.Core.Projects.Queries;
using TaskTracker.Application.Core.Tasks.Commands;

namespace TaskTracker.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await LoadCollections();
            return View(await _mediator.Send(new GetTasksQuery()));           
        }

        [HttpGet]
        public async Task<PartialViewResult> Create()
        {
            await LoadCollections();
            return PartialView("Create", new CreateTaskCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await LoadCollections();
            TaskViewModel task = await _mediator.Send(new GetTaskQuery { Id = id });
            return PartialView(new UpdateTaskCommand { Id = id, ViewModel = task });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateTaskCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTaskCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCollections()
        {
            List<ProjectViewModel>? projects = await _mediator.Send(new GetProjectsQuery());
            ViewBag.Projects = projects.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
        }
    }
}
