using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Web.ViewModels
{
    public class VillaNumberVM
    {
        //per te bere display data, eshte mire qe te krijohet model specifik per view kjo behet qe cfare do lloj gjeje qe akeseson tek view te avaliable gjithashtu tek modeli
        public VillaNumber? VillaNumber { get; set; } //ketu perdor domain.entities qe merr villa number
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; } //krijon list VillaList qe do perdoret me vone
    }
}
