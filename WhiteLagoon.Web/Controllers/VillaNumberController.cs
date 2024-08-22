using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;
using WhiteLagoon.Web.ViewModels;

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
            //duke shtuar .Include vendos navigation properties dhe shton inner join Villa te deklaruar ne menyre qe te afishoje emrat si liste
            var villaNumbers = _db.VillaNumbers.Include(u=>u.Villa).ToList();
            return View(villaNumbers);
        }

        public IActionResult Create()
        { //eshte modeli i krijaur per view
           
                VillaNumberVM villaNumberVM = new()
                {
                    VillaList = _db.Villas.ToList().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                };
                return View(villaNumberVM);
            
        }

        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            ModelState.Remove("Villa"); //kjo behet sepse kodi vetveiu ben verifkim me villa qe a eshte i duhur ose jo kjo heq ate validation nga villa
            bool villanumberexists = _db.VillaNumbers.Any(u=> u.Villa_Number == obj.VillaNumber.Villa_Number);
            //nje variabel bool e cila verifion nese villa number nga db eshte e barabarte me VillaNumber te view model qe krijuam me pare
            //nese modelstate eshte vaild dhe variabla bool eshte false atehere do krijohet nje entry ne te kunder error
            if (ModelState.IsValid && !villanumberexists) //verifikon qe nese ka marre te dhena ose jo ne menyre qe mos te kete problem ne insertim
            {
                _db.VillaNumbers.Add(obj.VillaNumber); //kjo i thau qe do shtosh kete
                _db.SaveChanges(); //kjo e ruan te databaza
                TempData["success"] = "The villa number has been created succesfully!";
                return RedirectToAction("Index"); //mbasi e ben te con te index villa
            }
            if (villanumberexists)
            {
                TempData["error"] = "The villa number already exists!";
            }
            /* ketu ka dhe nje exception tjeter qe mbasi e krjon ajo nxjerr vetem qe e bera dhe nxjerr obj boshe
             * por duhet te nxjerri listen perseri ndaj duhet te krijoj dhe nje here Villalist qe ja bashkangjis obj
             * dhe e merr automatikisht mbasi mbaron if dhe ta nxjerri tek view
             */
            obj.VillaList = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
          
            return View(obj);
            //obj ketu duhet kur krijon pasi nxjerr exception pasi sepse tek e para e ben si duhet ketu kthen view por cfare do ktheje
            //atehere duhet te ktheje nje objekt ndaj ajo qe krijuam me pare villanumber duhet te ktheje ate
            
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
