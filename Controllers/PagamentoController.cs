using Microsoft.AspNetCore.Mvc;
using PIM_4.Dao;
using PIM_4.Models;

namespace PIM_4.Controllers
{
    public class PagamentoController : Controller
    {
        public ActionResult Index()
        {
            var pagamentoDao = new PagamentoDao();
            var pagamento = pagamentoDao.ObterPagamento();

            return View(pagamento);
        }

        public ActionResult Details(string id)
        {
            var pagamentoDao = new PagamentoDao();
            var pagamento = pagamentoDao.ObterPagamento(id);

            return View(pagamento);
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
                var pagamento = new Pagamento
                {
                    FormaDePagamento = collection["FormaDePagamento"],
                    Valor = Convert.ToDouble(collection["Valor"]),
                    Nome = collection["Nome"],
                    Comanda = collection["Comanda"],
                    IdPagamento = Guid.NewGuid().ToString()

                };

                var pagamentoDao = new PagamentoDao();
                pagamentoDao.CriarPagamento(pagamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var pagamentoDao = new PagamentoDao();
            var pagamento = pagamentoDao.ObterPagamento(id);

            return View(pagamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var pagamento = new Pagamento
                {
                    FormaDePagamento = collection["FormaDePagamento"],
                    Valor = Convert.ToDouble(collection["Valor"]),
                    Nome = collection["Nome"],
                    Comanda = collection["Comanda"],
                    IdPagamento = collection["IdPagamento"]
                };

                var pagamentoDao = new PagamentoDao();
                pagamentoDao.AtualizarPagamento(pagamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var pagamentoDao = new PagamentoDao();
            var pagamento = pagamentoDao.ObterPagamento(id);

            return View(pagamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var pagamentoDao = new PagamentoDao();
                var pagamento = pagamentoDao.ObterPagamento(id);
                pagamentoDao.ExcluirPagamento(pagamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
