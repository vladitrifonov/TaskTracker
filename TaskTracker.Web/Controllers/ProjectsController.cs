using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.Application.Projects.Commands;
using TaskTracker.Application.Projects.Queries;
using TaskTracker.Application.Common.ViewModels;

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

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProjectViewModel project = await _mediator.Send(new GetProjectQuery { Id = id });

            return PartialView(new UpdateProjectCommand { Id = id, ProjectViewModel = project });
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateProjectCommand command)
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
            await _mediator.Send(new DeleteProjectCommand { Id = id });

            return RedirectToAction(nameof(Index));
        }
    }
}
