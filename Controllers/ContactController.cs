using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MICLifePortal.Models;
using X.PagedList;

namespace MICLifePortal.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;

            var contacts = from c in _context.Contacts
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(c => c.Name.Contains(searchString) || c.NationalID.ToString().Contains(searchString));
            }

            contacts = contacts.Include(c => c.ContractorType);
            var pagedList = await contacts.ToPagedListAsync(pageNumber, pageSize);
            return View(pagedList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ContractorType)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        public IActionResult Create()
        {
            var contractorTypes = _context.ContractorTypes.ToList();
            ViewBag.ContractorTypes = new SelectList(contractorTypes, "ID", "SName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,NationalID,ContactType")] Contact contact)
        {
            if (_context.Contacts.Any(c => c.NationalID == contact.NationalID))
            {
                ModelState.AddModelError("NationalID", "A National ID already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var contractorTypes = _context.ContractorTypes.ToList();
            ViewBag.ContractorTypes = new SelectList(contractorTypes, "ID", "SName");

            return View(contact);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            ViewBag.ContractorTypes = new SelectList(_context.ContractorTypes, "ID", "SName");

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,NationalID,ContactType")] Contact contact)
        {
            if (_context.Contacts.Any(c => c.NationalID == contact.NationalID && c.ID != contact.ID))
            {
                ModelState.AddModelError("NationalID", "A National ID already exists.");
            }

            if (id != contact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.ContractorTypes = new SelectList(_context.ContractorTypes, "ID", "SName");

            return View(contact);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.ContractorType)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.ID == id);
        }

        private void PopulateContractorTypesDropDownList(object selectedContractorType = null)
        {
            var contractorTypeQuery = from ct in _context.ContractorTypes
                                      orderby ct.SName
                                      select ct;
            ViewBag.ContactType = new SelectList(contractorTypeQuery, "ID", "SName", selectedContractorType);
        }
    }
}
