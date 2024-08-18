using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db; //therret dbconext me variabel private _db

        public VillaNumberController(ApplicationDbContext db) //konstruktor qe therret si parameter db dhe initcializon dbcontext
        {
            _db = db; //shenoj variablen e deklaruar me lart me db context
        }
        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {
         
            if (ModelState.IsValid) //verifikon qe nese ka marre te dhena ose jo ne menyre qe mos te kete problem ne insertim
            {
                _db.VillaNumbers.Add(obj); //kjo i thau qe do shtosh kete
                _db.SaveChanges(); //kjo e ruan te databaza
                TempData["success"] = "The villa number has been created succesfully!";
                return RedirectToAction("Index"); //mbasi e ben te con te index villa
            }
            TempData["error"] = "The villa couldn't be created!";
            return View();
        }
        public IActionResult Update(int villaId) /*per te bere update deklaron si metode me nje parameter variabel per villa id
            pastaj Villa? shikon nese ka row te deklaraur e shenon si obj
            pastaj therret _db qe eshte controlleri dhe tek tb Villas
            dhe ben fileter me past me parametrin firstordefault
            u ku eshte idja e villes dhe e barazon me villa id
            nese ovj eshte bosh kthen not found ne te kunder therret view to obj
            */
        {
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);

            /*Villa? obj = _db.Villas.Find(villaId);
             * var VillaList = _db.Villas.Where(u => u.Price > 50 && u.Occupancy > 0
             * nje shembul sesi mund te besh retireve data nga db bazuar ne kusht
              */
            if (obj == null)
            {
                return NotFound();
            }
                return View(obj);
            }
       
    [HttpPost]
    public IActionResult Update(Villa obj)
    {
        if (ModelState.IsValid && obj.Id > 0) 
        {
            _db.Villas.Update(obj); //kjo i thau qe do shtosh kete
            _db.SaveChanges(); //kjo e ruan te databaza
                TempData["success"] = "The villa has been updated succesfully!";
            return RedirectToAction("Index"); //mbasi e ben te con te index villa
        }
            TempData["error"] = "The villa couldn't be updated!";
            return View();
    }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.FirstOrDefault(u => u.Id == villaId);  
            if (obj is null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            Villa? objFromDb = _db.Villas.FirstOrDefault(u =>u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _db.Villas.Remove(objFromDb); //kjo i thau qe do shtosh kete
                _db.SaveChanges(); //kjo e ruan te databaza
                TempData["success"] = "The villa has been deleted succesfully!";
                return RedirectToAction("Index"); //mbasi e ben te con te index villa
            }
            TempData["error"] = "The villa couldn't be deleted!";
            return View();
        }
    }
}
