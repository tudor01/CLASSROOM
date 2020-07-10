using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomPlatform.ApplicationLogic.Services;
using ClassroomPlatform.VIewModels.Assigments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomPlatform.Controllers
{
    public class AssigmentController : Controller
    {
        private readonly ClassroomService classroomService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly EndUserService endUserService;

        public AssigmentController(ClassroomService classroomService,
                                      UserManager<IdentityUser> userManager,
                                      EndUserService endUserService)
        {
            this.classroomService = classroomService;
            this.userManager = userManager;
            this.endUserService = endUserService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Add([FromForm]AddAssigmentViewModel viewModel, Guid classroomId)
        {
            try
            {
                var userId = this.userManager.GetUserId(User);
                this.classroomService.AddAssigment(userId, classroomId, viewModel.Deadline, DateTime.UtcNow, viewModel.Content, viewModel.Title);
                return RedirectToAction("Details", "Classroom", new { id = classroomId });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult Details(Guid classroomId, Guid assigmentId)
        {
            var userId = userManager.GetUserId(User);
            if (User.IsInRole("Student"))
            {
                var viewModelStudent = new AssigmentViewModel
                {
                    ClassroomId = classroomId,
                    Assigment = classroomService.GetAssigment(classroomId, assigmentId),
                    EndUserGrade = endUserService.GetEndUserGrade(assigmentId, userId)
                };
                return View(viewModelStudent);
            }
            var viewModelTeacher = new AssigmentViewModel
            {
                ClassroomId = classroomId,
                Assigment = classroomService.GetAssigment(classroomId, assigmentId),
                Students = endUserService.GetStudents(assigmentId)
            };
            return View(viewModelTeacher);
        }

        [HttpGet]
        public IActionResult AddWork()
        {
            return PartialView("_AddWork");
        }

        [HttpPost]
        public IActionResult AddWork(AddWorkAssigmentViewModel viewModel, Guid assigmentId, Guid classroomId)
        {
            var userId = userManager.GetUserId(User);
            classroomService.AddWorkForAssigment(viewModel.Work, assigmentId, userId);
            return RedirectToAction("Details", new { ClassroomId = classroomId, AssigmentId = assigmentId });
        }
    }
}