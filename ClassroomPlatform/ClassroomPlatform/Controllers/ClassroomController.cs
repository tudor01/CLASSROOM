using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassroomPlatform.ApplicationLogic.Services;
using ClassroomPlatform.VIewModels.Classrooms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomPlatform.Controllers
{
    public class ClassroomController : Controller
    {
        private readonly ClassroomService classroomService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly EndUserService endUserService;

        public ClassroomController(ClassroomService classroomService,
                                   UserManager<IdentityUser> userManager,
                                   EndUserService endUserService)
        {
            this.classroomService = classroomService;
            this.userManager = userManager;
            this.endUserService = endUserService;
        }

        public IActionResult Index()
        {
            try
            {
                var userId = this.userManager.GetUserId(User);
                var viewModel = new ClassroomsForUserViewModel
                {
                    Invitations = this.endUserService.GetAllInvitations(userId),
                    EndUser = this.endUserService.GetByUserId(userId),
                    Classrooms = this.classroomService.GetAllForUser(userId)
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(AddClassroomViewModel viewModel)
        {
            try
            {
                var userId = this.userManager.GetUserId(User);
                this.classroomService.Add(viewModel.Name, userId);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        } 

        public IActionResult Details(Guid id)
        {
            try
            {
                var viewModel = new DetailsClassroomViewModel
                {
                    Classroom = classroomService.GetById(id)
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult People(Guid id)
        {
            try
            {
                var viewModel = new PeopleClassroomViewModel
                {
                    Id = id,
                    Classroom = classroomService.GetById(id),
                    People = classroomService.GetPeopleForClassroom(id)
                };
                return View(viewModel);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Invite(Guid id)
        {
            return View(new InviteParticipantViewModel { Id = id, DoesEmailExists = true });
        }

        [HttpPost]
        public IActionResult Invite(InviteParticipantViewModel viewModel)
        {
            var userToInvite = userManager.FindByEmailAsync(viewModel.Email).GetAwaiter().GetResult();
            if (userToInvite == null)
            {
                viewModel.DoesEmailExists = false;
                return View(viewModel);
            }
            var endUserDb = endUserService.GetByUserId(userToInvite.Id);
            endUserService.ReceiveInvitation(endUserDb.Id, viewModel.Id);
            return RedirectToAction("People", new { Id = viewModel.Id});
        }

        public IActionResult AcceptInvitation(Guid id)
        {
            endUserService.AcceptInvitation(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeclineInvitation(Guid id)
        {
            endUserService.DeclineInvitation(id);
            return RedirectToAction("Index");
        }
    }
}