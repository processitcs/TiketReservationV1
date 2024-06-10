using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RezervariBilete.Application.Rezervation.Delete;
using RezervariBilete.Application.Rezervation.GetById;
using RezervariBilete.Application.Rezervation.GetRow;
using RezervariBilete.Application.Rezervation.Save;
using RezervariBilete.Application.Rezervation.Update;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Controllers
{
    public class RezervationController : Controller
    {
        private readonly ISender _sender;
        private readonly ILogger<RezervationController> _logger;

        public RezervationController(ISender sender, ILogger<RezervationController> logger)
        {
            _sender = sender;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _sender.Send(new GetRezervationRowQuery());
            return View(response);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null && id != Guid.Empty)
            {
                var response = await _sender.Send(new GetRezervationByIdQuery(id.Value));
                return View(response.Data);
            }
            TempData["ErrorMessage"] = "Erroare";
            return View();
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditRezervationDto model)
        {
            var response = model.Id.HasValue && model.Id.Value != Guid.Empty
                ? await _sender.Send(new UpdateRezervationCommand(model))
                : await _sender.Send(new SaveRezervationCommand(model));
            if (response.Succes)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

        // GET: Rezervation/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _sender.Send(new GetRezervationByIdQuery(id));
            if (response == null)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        // POST: Rezervation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _sender.Send(new DeleteRezervationCommand(id));
            if (response.Succes)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = response.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}