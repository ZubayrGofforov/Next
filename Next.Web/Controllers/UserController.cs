using Microsoft.AspNetCore.Mvc;
using Next.Web.Interfaces;
using Next.Web.Models;
using System.Runtime.InteropServices;

namespace Next.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            //var users = _userService.GetAllUser();
            return View();
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            _userService.AddUser(user);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update
        public ActionResult Edit(Guid id)
        {
            User user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            _userService.UpdateUser(user);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public ActionResult Delete(Guid id)
        {
            User user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(User user)
        {
            _userService.DeleteUser(user);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
