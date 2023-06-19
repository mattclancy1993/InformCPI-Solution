using InformCPISolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace InformCPISolution.Controllers
{

    public class HomeController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public HomeController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            var contacts = _contactRepository.GetAllContacts();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.AddContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.UpdateContact(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _contactRepository.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }

}