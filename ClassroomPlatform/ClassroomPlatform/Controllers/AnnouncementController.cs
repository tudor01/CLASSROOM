using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomPlatform.ApplicationLogic.Services;
using ClassroomPlatform.VIewModels.Announcements;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomPlatform.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ClassroomService classroomService;
        private readonly UserManager<IdentityUser> userManager;

        public AnnouncementController(ClassroomService classroomService,
                                      UserManager<IdentityUser> userManager)
        {
            this.classroomService = classroomService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Add([FromForm]AddAnnouncementViewModel viewModel, Guid classroomId)
        {
            try
            {
                var userId = this.userManager.GetUserId(User);
                this.classroomService.AddAnnouncement(userId, classroomId, viewModel.Content);
                return RedirectToAction("Details", "Classroom", new { id = classroomId });
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}