using Microsoft.AspNetCore.Mvc;

using tarefaproposta.Models;

namespace tarefaproposta.Controllers
{
    public class ProcessoController : Controller
    {
        [HttpPost]
        public ActionResult SalvarProposta(HistoricoPropostaViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the data to the database, send an email, etc.
                // ...
                ViewBag.Proposta = model.ValorPropostaString;
                ViewBag.Canal = model.Canal;
                return View("Confirmation");

                // Redirect to a success page.
            }

            // If the model state is invalid, redisplay the form with validation errors.
            return View("_Proposta", model);

        }
    }
}
