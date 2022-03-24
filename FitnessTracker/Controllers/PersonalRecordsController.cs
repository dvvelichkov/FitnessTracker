using FitnessTracker.Models.PersonalRecords;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class PersonalRecordsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddPersonalRecordViewModel personalRecord)
        {
            return View();
        }
    }
}
