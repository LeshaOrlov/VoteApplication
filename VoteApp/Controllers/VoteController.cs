using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VoteApp.Models.Entities;
using VoteApp.ViewModels;

namespace VoteApp.Controllers
{
    public class VoteController : Controller
    {
        private IVoteRepository _voteRep;
        private IOptionRepository _opRep;
        public VoteController(IVoteRepository voteRep, IOptionRepository optionRep)
        {
            _voteRep = voteRep;
            _opRep = optionRep;
        }
        public IActionResult Index()
        {
            var result = _voteRep.GetVoteResult();
            return View(result);

        }

        public IActionResult Create()
        {
            ViewBag.Options = new SelectList(_opRep.GetOptions(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVoteViewModel vote)
        {
            if (ModelState.IsValid)
            {
                Vote model = new Vote();
                model.Name = vote.Name;
                model.OptionId = vote.OptionId;
                _voteRep.Create(model);
                return RedirectToAction(nameof(Index));
            }
            
            return View("Index.cshtml");
        }

    }
}
