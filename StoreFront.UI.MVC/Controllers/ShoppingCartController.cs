using Microsoft.AspNetCore.Mvc;

namespace StoreFront.UI.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        #region Stephs to Implement Session Based Shopping Cart
        /*
         *1) Register Session in program.cs (builder.Services.AddSession... && app.UseSession())
         *2) Create the CartItemViewModel class in [ProjName].UI.MVC/Models folder
         *3) Add the 'Add to Cart' button int he Index and/ or Details view of your Products
         * */
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
