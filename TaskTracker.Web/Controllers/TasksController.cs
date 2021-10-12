using MediatR;
using Microsoft.AspNetCore.Mvc;
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
           return View(await _mediator.Send(new GetTasksQuery()));           
        }

        [HttpGet]
        public PartialViewResult Create()
        {
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
    }
}
