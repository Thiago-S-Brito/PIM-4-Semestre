using Microsoft.AspNetCore.Mvc;
using PIM_4.Dao;
using PIM_4.Models;

namespace PIM_4.Controllers
{
    public class ReservarQuartoController : Controller
    {
        public ActionResult Index()
        {
            var reservaQuartoDao = new ReservarQuartoDao();
            var reserva = reservaQuartoDao.ObterReserva();

            return View(reserva);
        }

        public ActionResult Details(string id)
        {
            var reservaQuartoDao = new ReservarQuartoDao();
            var reserva = reservaQuartoDao.ObterQuarto(id);

            return View(reserva);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var reserva = new ReservarQuarto
                {
                    Disponibilidade = collection["Disponibilidade"] == "true" ? true : false,
                    NumeroQuarto = Convert.ToInt32(collection["NumeroQuarto"]),
                    Valor = Convert.ToDouble(collection["Valor"]),
                    TipoQuarto = collection["TipoQuarto"],
                    ServicoQuarto = collection["ServicoQuarto"] == "true" ? true : false,
                    IdQuarto = Guid.NewGuid().ToString()
                };

                var reservaQuartoDao = new ReservarQuartoDao();
                reservaQuartoDao.CriarReserva(reserva);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var reservaQuartoDao = new ReservarQuartoDao();
            var reserva = reservaQuartoDao.ObterQuarto(id);

            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var reserva = new ReservarQuarto
                {
                    Disponibilidade = collection["Disponibilidade"] == "true" ? true : false,
                    NumeroQuarto = Convert.ToInt32(collection["NumeroQuarto"]),
                    Valor = Convert.ToDouble(collection["Valor"]),
                    TipoQuarto = collection["TipoQuarto"],
                    ServicoQuarto = collection["ServicoQuarto"] == "true" ? true : false,
                    IdQuarto = collection["IdQuarto"]
                };

                var reservaQuartoDao = new ReservarQuartoDao();
                reservaQuartoDao.AtualizarReserva(reserva);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var reservaQuartoDao = new ReservarQuartoDao();
            var reserva = reservaQuartoDao.ObterQuarto(id);

            return View(reserva);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var reservaQuartoDao = new ReservarQuartoDao();
                var reserva = reservaQuartoDao.ObterQuarto(id);
                reservaQuartoDao.ExcluirReserva(reserva);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
