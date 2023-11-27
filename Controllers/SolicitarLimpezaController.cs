using Microsoft.AspNetCore.Mvc;
using PIM_4.Dao;
using PIM_4.Models;

namespace PIM_4.Controllers
{
    public class SolicitarLimpezaController : Controller
    {

        public ActionResult Index()
        {
            var solicitarLimpezaDao = new SolicitarLimpezaDao();
            var solicitarLimpesa = solicitarLimpezaDao.ObterLimpeza();

            return View(solicitarLimpesa);
        }

        public ActionResult Details(string id)
        {
            var solicitarLimpezaDao = new SolicitarLimpezaDao();
            var solicitarLimpesa = solicitarLimpezaDao.ObterLimpeza(id);

            return View(solicitarLimpesa);
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
                var solicitarLimpesa = new SolicitarLimpeza
                {
                    NomeFuncionario = collection["NomeFuncionario"],
                    Quarto = Convert.ToInt32(collection["Quarto"]),
                    TipoLimpeza = collection["TipoLimpeza"],
                    TempoLimpeza = Convert.ToDateTime(collection["TempoLimpeza"]),
                    Finalizado = collection["Finalizado"] == "true" ? true : false,
                    IdLimpeza = Guid.NewGuid().ToString()
                };

                var solicitarLimpezaDao = new SolicitarLimpezaDao();
                solicitarLimpezaDao.CriarLimpeza(solicitarLimpesa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var solicitarLimpezaDao = new SolicitarLimpezaDao();
            var solicitarLimpesa = solicitarLimpezaDao.ObterLimpeza(id);

            return View(solicitarLimpesa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var solicitarLimpesa = new SolicitarLimpeza
                {
                    NomeFuncionario = collection["NomeFuncionario"],
                    Quarto = Convert.ToInt32(collection["Quarto"]),
                    TipoLimpeza = collection["TipoLimpeza"],
                    TempoLimpeza = Convert.ToDateTime(collection["TempoLimpeza"]),
                    Finalizado = collection["Finalizado"] == "true" ? true : false,
                    IdLimpeza = collection ["IdLimpeza"]
                };

                var solicitarLimpezaDao = new SolicitarLimpezaDao();
                solicitarLimpezaDao.AtualizarLimpeza(solicitarLimpesa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var solicitarLimpezaDao = new SolicitarLimpezaDao();
            var solicitarLimpesa = solicitarLimpezaDao.ObterLimpeza(id);

            return View(solicitarLimpesa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var solicitarLimpezaDao = new SolicitarLimpezaDao();
                var solicitarLimpesa = solicitarLimpezaDao.ObterLimpeza(id);
                solicitarLimpezaDao.ExcluirLimpeza(solicitarLimpesa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
