using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Application.Core.Projects.Queries;

namespace TaskTracker.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetProjectsQuery()));
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView("Create", new CreateProjectCommand());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            await _mediator.Send(command);

            return Json(new { succeeded = true });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProjectViewModel project = await _mediator.Send(new GetProjectQuery { Id = id });

            return PartialView(new UpdateProjectCommand { Id = id, ViewModel = project });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return Json(new { succeeded = true });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProjectCommand { Id = id });

            return Json(new { succeeded = true });
        }
    }
}
