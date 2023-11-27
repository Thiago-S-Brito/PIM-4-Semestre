using Microsoft.AspNetCore.Mvc;
using PIM_4.Dao;
using PIM_4.Models;

namespace PIM_4.Controllers
{
    public class AreacomumController : Controller
    {
        public ActionResult Index()
        {
            var areaComumDao = new AreaComumDao();
            var areaComum = areaComumDao.ObterAreaComum();

            return View(areaComum);
        }

        public ActionResult Details(string id)
        {
            var areaComumDao = new AreaComumDao();
            var areaComum = areaComumDao.ObterAreaComum(id);

            return View(areaComum);
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
                var areaComum = new AreaComum
                {
                    NumeroQuarto = Convert.ToInt32(collection["NumeroQuarto"]),
                    Horario = Convert.ToDateTime(collection["Horario"]),
                    Reserva = collection["Reserva"] == "true" ? true : false,
                    Valor = Convert.ToInt32(collection["Valor"]),
                    IdAreaComum = Guid.NewGuid().ToString(),
                    NomeAreaComum = collection["NomeAreaComum"]
                };

                var areaComumDao = new AreaComumDao();
                areaComumDao.CriarAreaComum(areaComum);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var areaComumDao = new AreaComumDao();
            var areaComum = areaComumDao.ObterAreaComum(id);

            return View(areaComum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var areaComum = new AreaComum
                {
                    NumeroQuarto = Convert.ToInt32(collection["NumeroQuarto"]),
                    Horario = Convert.ToDateTime(collection["Horario"]),
                    Reserva = collection["Reserva"] == "true" ? true : false,
                    Valor = Convert.ToInt32(collection["Valor"]),
                    IdAreaComum = collection["IdAreaComum"],
                    NomeAreaComum = collection["NomeAreaComum"]
                };

                var areaComumDao = new AreaComumDao();
                areaComumDao.AtualizarAreaComum(areaComum);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var areaComumDao = new AreaComumDao();
            var areaComum = areaComumDao.ObterAreaComum(id);

            return View(areaComum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var areaComumDao = new AreaComumDao();
                var areaComum = areaComumDao.ObterAreaComum(id);
                areaComumDao.ExcluirAreaComum(areaComum);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

