using FormCenso.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FormCenso.Controllers
{
    public class CensoController : Controller
    {
        private readonly CensoRepository _censoRepository;

        public CensoController(CensoRepository censoRepository)
        {
            _censoRepository = censoRepository;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buscar(string identidad)
        {
            var result = _censoRepository.Search(identidad);
            return Json(result);
        }

        public IActionResult Votar(int id)
        {
            var result = _censoRepository.Voto(id);
            return Json(result);
        }
    }
}
