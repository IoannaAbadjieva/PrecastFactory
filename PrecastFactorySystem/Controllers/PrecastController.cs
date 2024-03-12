namespace PrecastFactorySystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Precast;
    using PrecastFactorySystem.Core.Services;
    using PrecastFactorySystem.Infrastructure.Data.Common;

    public class PrecastController : BaseController
    {
        private readonly IPrecastService precastService;
        private readonly IBaseService baseService;

        public PrecastController(
            IPrecastService _precastService,
            IBaseService _baseService)
        {
            precastService = _precastService;
            baseService = _baseService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<PrecastInfoViewModel> model = await precastService.GetAllPrecastAsync();
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            PrecastFormViewModel model = new PrecastFormViewModel()
            {
                Projects = await baseService.GetProjectAsync(),
                Types = await baseService.GetPrecastTypeAsync(t => t.Name != "Production Use" && t.Name != "Other"),
                Concrete = await baseService.GetConcreteClassAsync()

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PrecastFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Projects = await baseService.GetProjectAsync();
                model.Types = await baseService.GetPrecastTypeAsync(t => t.Name != "Production Use" && t.Name != "Other");
                model.Concrete = await baseService.GetConcreteClassAsync();

                return View(model);
            }

            await precastService.AddPrecastAsync(model);
            return RedirectToAction(nameof(All));
        }
    }
}
