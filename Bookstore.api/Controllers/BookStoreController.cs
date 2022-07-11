using Bookstore.Models.ModelData;
using Bookstore.Models.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.api.Controllers
{
    [Route("api/bookstore")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
       
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _repository.Login(model);
            if (user == null)
                return NotFound();

            UserModel userModel = new UserModel(user);
            return Ok(userModel);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);
            UserModel userModel = new UserModel(user);
            return Ok(userModel);
        }
    }

}
