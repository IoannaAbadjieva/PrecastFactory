namespace PrecastFactorySystem.Controllers
{
    using AspNetCore;

    using Microsoft.AspNetCore.Mvc;

    using PrecastFactorySystem.Core.Contracts;
    using PrecastFactorySystem.Core.Models.Precast;

    public class PrecastController : BaseController
    {
        private readonly IPrecastService precastService;

        public PrecastController(IPrecastService _precastService)
        {
            precastService = _precastService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<PrecastInfoViewModel> model = await precastService.GetAllPrecastAsync();
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            PrecastFormViewModel model = await precastService.GetNewPrecastFormViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PrecastFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Projects = await precastService.GetProjectAsync();
                model.Types = await precastService.GetPrecastTypeAsync();
                model.Concrete = await precastService.GetConcreteClassAsync();

                return View(model);
            }

            await precastService.AddPrecastAsync(model);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                PrecastFormViewModel model = await precastService.GetPrecastByIdAsync(id);
                return View(model);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(PrecastFormViewModel model, int id)
        {
            int reinforced = await precastService.GetReinforcedPrecastCount(id);

            if (model.Count < reinforced)
            {
                ModelState.AddModelError(nameof(model.Count), $"You can not change precast count to less than {reinforced}");
            }

            if (!ModelState.IsValid)
            {
                model.Projects = await precastService.GetProjectAsync();
                model.Types = await precastService.GetPrecastTypeAsync();
                model.Concrete = await precastService.GetConcreteClassAsync();

                return View(model);
            }

            try
            {
                await precastService.EditPrecastAsync(id, model);
                return RedirectToAction(nameof(All));
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }


        public async Task<IActionResult> Details(int id)
        {
            try
            {
                PrecastDetailsViewModel model = await precastService.GetPrecastDetailsAsync(id);
                return View(model);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

        }

		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				PrecastDeleteViewModel model = await precastService.GetPrecastToDeleteByIdAsync(id);
				return View(model);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
			catch (InvalidOperationException)
			{
                return View(nameof(Views_Shared_DeleteError));
            }

		}

		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				await precastService.DeletePrecastAsync(id);
			}
			catch (ArgumentException)
			{
				return BadRequest();
			}
			catch (InvalidOperationException)
			{
				return View(nameof(Views_Shared_DeleteError));
			}

			return RedirectToAction(nameof(All));

		}
	}
}
