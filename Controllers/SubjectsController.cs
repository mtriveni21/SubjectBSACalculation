using SubjectBSACalculation.Data;
using SubjectBSACalculation.Models;
using SubjectBSACalculation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SubjectBSACalculation.Controllers;

public class SubjectsController : Controller
{
    private readonly ISubjectDispensationService _calculator;
    private readonly AppDbContext _db;

    public SubjectsController(ISubjectDispensationService calculator, AppDbContext db)
    {
        _calculator = calculator;
        _db = db;
    }

    // GET: list all the saved subjects
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var subjects = await _db.Subjects.OrderBy(s => s.SubjectId).ToListAsync();
        return View(subjects);
    }

    // GET: no id -> empty editable form; id ("001", "002", ...) -> read-only view of the saved record
    [HttpGet]
    public async Task<IActionResult> CreateSubject(string id)
    {
        if (int.TryParse(id, out var subjectId))
        {
            var saved = await _db.Subjects.FindAsync(subjectId);
            if (saved != null)
            {
                ViewBag.IsReadOnly = true;
                return View(saved);
            }
        }

        ViewBag.IsReadOnly = false;
        return View(new Subject());
    }

    // POST: validate -> calculate -> persist -> Post/Redirect/Get (to the read-only view)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSubject(Subject Subject)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.IsReadOnly = false;
            return View(Subject);
        }

        Subject.BsaResult = _calculator.CalculateDispensingBSA(
            Subject.BsaFormulaType, Subject.WeightKg, Subject.HeightCm);
        Subject.CreatedUtc = DateTime.UtcNow;

        _db.Subjects.Add(Subject);
        await _db.SaveChangesAsync();

        return RedirectToAction(nameof(CreateSubject), new { id = Subject.SubjectCode });
    }
}
