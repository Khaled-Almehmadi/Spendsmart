using Microsoft.AspNetCore.Mvc;
using Spendsmart.Models;
using System.Diagnostics;

namespace Spendsmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpensesDBContext _expensesDBContext;
        public HomeController(ILogger<HomeController> logger, ExpensesDBContext expensesDBContext)
        {
            _logger = logger;
            _expensesDBContext = expensesDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _expensesDBContext.Expenses.ToList();
            return View(allExpenses);
        }
        public IActionResult Create_Edit(int? id)
        {
            if(id!= null)
            {
                var ExpenseInDb = _expensesDBContext.Expenses.SingleOrDefault(expense => expense.Id == id);
                return View(ExpenseInDb);
            }
            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            var ExpenseInDb = _expensesDBContext.Expenses.SingleOrDefault(expense => expense.Id == id);
            _expensesDBContext.Remove(ExpenseInDb);
            _expensesDBContext.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult Create_Edit_Form(Expense model)
        {

            if (model.Id == 0)
            {

                //create
                _expensesDBContext.Add(model);

            }
            else {
                //edit

                _expensesDBContext.Update(model);
            }
          
            _expensesDBContext.SaveChanges();
            return RedirectToAction("Expenses");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

