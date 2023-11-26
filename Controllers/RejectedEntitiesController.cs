using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using MICLifePortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MICLifePortal.Common;
using Newtonsoft.Json;

namespace MICLifePortal.Controllers
{
    public class RejectedEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        //private readonly IHttpClientFactory _httpClientFactory;

        public RejectedEntitiesController(ApplicationDbContext context/*, IHttpClientFactory httpClientFactory*/ , ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            //_httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(string searchString, int? page)
        {
            //await _tokenService.GetAccessToken();

            int pageNumber = page ?? 1;
            int pageSize = 6;

            var rejectedEntities = await _context.RejectedEntities
                .Include(r => r.Contractor)
                .Include(r => r.Reasons)
                .Include(r => r.Customer)
                .Include(r => r.BeneficiaryTIDContact)
                .Include(r => r.RefuseType)
                .Include(r => r.EntityType)
                .Include(r => r.BenefeciaryType)
                .Where(r => string.IsNullOrEmpty(searchString) || r.Contractor.Name.Contains(searchString) || r.Customer.NationalID.ToString().Contains(searchString))
                .ToPagedListAsync(pageNumber, pageSize);

            ViewBag.SearchString = searchString;

            return View(rejectedEntities);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejectedEntity = await _context.RejectedEntities
                .Include(r => r.Contractor)
                .Include(r => r.Reasons)
                .Include(r => r.Customer)
                .Include(r => r.BeneficiaryTIDContact)
                .Include(r => r.RefuseType)
                .Include(r => r.EntityType)
                .Include(r => r.BenefeciaryType)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (rejectedEntity == null)
            {
                return NotFound();
            }

            return View(rejectedEntity);
        }

        public IActionResult Create()
        {
            ViewBag.RefuseTIDList = new SelectList(_context.ReasonsTypes, "ID", "Name");
            ViewBag.RejectedEntityTypeList = new SelectList(_context.EntityTypes, "ID", "Name");
            ViewBag.ContractorList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.BeneficiaryTypeList = new SelectList(_context.BenefeciaryTypes, "ID", "Name");
            ViewBag.BeneficiaryTIDList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.ReasonList = new SelectList(_context.Reasons, "ReasonsID", "Name");
            ViewBag.CustomerList = new SelectList(_context.Contacts, "ID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RefuseTID,RejectedEntityType,ContractorID,CustomerID,BeneficiaryType,CustomerCountry,DocumentNo,ProductCode,BeneficiaryTID,RepaymentNo,PremiumValue,RefuseDate,ReasonId,OtherReasons")] RejectedEntity rejectedEntity)
        {

            if (_context.RejectedEntities.Any(e => e.CustomerID == rejectedEntity.CustomerID))
            {
                ModelState.AddModelError("CustomerID", "A RejectedEntity with the same customer name already exists.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(rejectedEntity);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.RefuseTIDList = new SelectList(_context.ReasonsTypes, "ID", "Name");
            ViewBag.RejectedEntityTypeList = new SelectList(_context.EntityTypes, "ID", "Name");
            ViewBag.ContractorList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.BeneficiaryTypeList = new SelectList(_context.BenefeciaryTypes, "ID", "Name");
            ViewBag.BeneficiaryTIDList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.ReasonList = new SelectList(_context.Reasons, "ReasonsID", "Name");
            ViewBag.CustomerList = new SelectList(_context.Contacts, "ID", "Name");

            return View(rejectedEntity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejectedEntity = await _context.RejectedEntities.FindAsync(id);
            if (rejectedEntity == null)
            {
                return NotFound();
            }

            ViewBag.RefuseTIDList = new SelectList(_context.ReasonsTypes, "ID", "Name");
            ViewBag.RejectedEntityTypeList = new SelectList(_context.EntityTypes, "ID", "Name");
            ViewBag.ContractorList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.BeneficiaryTypeList = new SelectList(_context.BenefeciaryTypes, "ID", "Name");
            ViewBag.BeneficiaryTIDList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.ReasonList = new SelectList(_context.Reasons, "ReasonsID", "Name");
            ViewBag.CustomerList = new SelectList(_context.Contacts, "ID", "Name");

            return View(rejectedEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RefuseTID,RejectedEntityType,ContractorID,CustomerID,BeneficiaryType,CustomerCountry,DocumentNo,ProductCode,BeneficiaryTID,RepaymentNo,PremiumValue,RefuseDate,ReasonId,OtherReasons")] RejectedEntity rejectedEntity)
        {
            if (id != rejectedEntity.ID)
            {
                return NotFound();
            }

            if (_context.RejectedEntities.Any(e => e.CustomerID == rejectedEntity.CustomerID && e.ID != id))
            {
                ModelState.AddModelError("CustomerID", "A RejectedEntity with the same customer name already exists.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rejectedEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RejectedEntityExists(rejectedEntity.ID))
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

            ViewBag.RefuseTIDList = new SelectList(_context.ReasonsTypes, "ID", "Name");
            ViewBag.RejectedEntityTypeList = new SelectList(_context.EntityTypes, "ID", "Name");
            ViewBag.ContractorList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.BeneficiaryTypeList = new SelectList(_context.BenefeciaryTypes, "ID", "Name");
            ViewBag.BeneficiaryTIDList = new SelectList(_context.Contacts, "ID", "Name");
            ViewBag.ReasonList = new SelectList(_context.Reasons, "ReasonsID", "Name");
            ViewBag.CustomerList = new SelectList(_context.Contacts, "ID", "Name");

            return View(rejectedEntity);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rejectedEntity = await _context.RejectedEntities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rejectedEntity == null)
            {
                return NotFound();
            }

            return View(rejectedEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rejectedEntity = await _context.RejectedEntities.FindAsync(id);
            _context.RejectedEntities.Remove(rejectedEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RejectedEntityExists(int id)
        {
            return _context.RejectedEntities.Any(e => e.ID == id);
        }
    }
}
