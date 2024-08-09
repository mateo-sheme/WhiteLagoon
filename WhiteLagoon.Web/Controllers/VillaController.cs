using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _db; //therret dbconext me variabel private _db

        public VillaController(ApplicationDbContext db) //konstruktor qe therret si parameter db dhe initcializon dbcontext
        {
            _db = db; //shenoj variablen e deklaruar me lart me db context
        }
        public IActionResult Index()
        {
            var villas = _db.Villas.ToList();
            return View(villas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Villa obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot excatly match the name");
                //ai stringu i pare eshte emri i asp-validation-for nuk eshte case-senesitive dhe nese e vendos do afishoje kete message ne vend te te parit
                    }
            if (ModelState.IsValid) //verifikon qe nese ka marre te dhena ose jo ne menyre qe mos te kete problem ne insertim
            {
                _db.Villas.Add(obj); //kjo i thau qe do shtosh kete
                _db.SaveChanges(); //kjo e ruan te databaza
                return RedirectToAction("Index"); //mbasi e ben te con te index villa
            }
            return View();
        }
    }
}
