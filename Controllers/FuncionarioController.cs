using Microsoft.AspNetCore.Mvc;
using PIM_4.Dao;
using PIM_4.Models;

namespace PIM_4.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Index()
        {
            var funcionarioDao = new FuncionarioDao();
            var funcionarios = funcionarioDao.ObterFuncionarios();

            return View(funcionarios);
        }

        public ActionResult Details(string id)
        {
            var funcionarioDao = new FuncionarioDao();
            var funcionario = funcionarioDao.ObterFuncionario(id);

            return View(funcionario);
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
                var funcionario = new Funcionario
                {
                    Cargo = collection["Cargo"],
                    CPF = Convert.ToInt32(collection["CPF"]),
                    DataNascimento = Convert.ToDateTime(collection["DataNascimento"]),
                    Email = collection["Email"],
                    Nome = collection["Nome"],
                    IdFuncionario = Guid.NewGuid().ToString()
                };

                var funcionarioDao = new FuncionarioDao();
                funcionarioDao.CriarFuncionario(funcionario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var funcionarioDao = new FuncionarioDao();
            var funcionario = funcionarioDao.ObterFuncionario(id);

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var funcionario = new Funcionario
                {
                    Cargo = collection["Cargo"],
                    CPF = Convert.ToInt32(collection["CPF"]),
                    DataNascimento = Convert.ToDateTime(collection["DataNascimento"]),
                    Email = collection["Email"],
                    Nome = collection["Nome"],
                    IdFuncionario = collection["id"]
                };

                var funcionarioDao = new FuncionarioDao();
                funcionarioDao.AtualizarFuncionario(funcionario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var funcionarioDao = new FuncionarioDao();
            var funcionario = funcionarioDao.ObterFuncionario(id);

            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var funcionarioDao = new FuncionarioDao();
                var funcionario = funcionarioDao.ObterFuncionario(id);
                funcionarioDao.ExcluirFuncionario(funcionario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
