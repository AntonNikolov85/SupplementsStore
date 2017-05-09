namespace Store.Web.Areas.Admin.Controllers
{
    using Infrastructure.Mapping;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.Enums;
    using Models.ViewModels.User;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Web.Controllers;

    [RouteArea("admin")]
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        private IUserService userService;

        public UserController(IUserService service)
        {
            this.userService = service;
        }


        // GET: Admin/User
        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<UserViewModel> users = this.userService.GetAll().To<UserViewModel>();

            return View(users);
        }

        // GET: Admin/User/AddRole/5
        [HttpGet]
        [Route("AddRole/{id}")]
        public ActionResult AddRole(object id)
        {
            ApplicationUser user = this.userService.GetById(id);
            AddRoleViewModel viewModel = this.Mapper.Map<AddRoleViewModel>(user);
            //this.userService.PrepareModel(viewModel);

            return View(viewModel);
        }

        // POST: Admin/User/AddRole/5
        [HttpPost]
        [Route("AddRole/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole([Bind(Include = "Id, Name, Username, Email, RoleName")] AddRoleBindingModel bindingModel)
        {
            ApplicationUser user = this.userService.GetById(bindingModel.Id);

            if (ModelState.IsValid && Enum.IsDefined(typeof(RoleType), bindingModel.RoleName))
            {
                this.userService.AddRoleToUser(user, bindingModel.RoleName);
                return this.RedirectToAction("all");
            }

            UserViewModel viewModel = this.Mapper.Map<UserViewModel>(user);
            return View(viewModel);
        }

        // GET: Admin/User/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(object id)
        {
            ApplicationUser userFromDb = this.userService.GetById(id);
            EditUserViewModel userToEdit = this.Mapper.Map<EditUserViewModel>(userFromDb);

            return View(userToEdit);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Username, Email")] EditUserViewModel viewModel)
        {
            ApplicationUser user = this.Mapper.Map<ApplicationUser>(viewModel);

            if (ModelState.IsValid)
            {
                this.userService.Edit(user);
                return this.RedirectToAction("all");
            }

            return View(viewModel);
        }

        // GET: Admin/User/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(object id)
        {
            ApplicationUser userFromDb = this.userService.GetById(id);
            UserViewModel userToDelete = this.Mapper.Map<UserViewModel>(userFromDb);

            return View(userToDelete);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("delete")]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(object id)
        {
            this.userService.Delete(id);

            return RedirectToAction("All");
        }
    }
}
