using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccount.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    [Route("bank")]
    public class BankController : Controller
    {
        private HomeContext dbContext;
        public BankController(HomeContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("LogOut", "Home");
            }
            User userInDb = dbContext.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            ViewBag.User = userInDb;

            double balance = userInDb.Transactions.Sum(t => t.Amount);

            ViewBag.Balance = balance;
            return View("Index");
        }

        [HttpPost("money")]
        public IActionResult Money(Transaction newTransaction)
        {
            User userInDb = dbContext.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            if (ModelState.IsValid)
            {
                double previous = userInDb.Transactions.Sum(t => t.Amount);
                double calculate = previous + newTransaction.Amount;

                if (calculate < 0)
                {
                    ViewBag.User = userInDb;

                    double balance = userInDb.Transactions.Sum(t => t.Amount);

                    ViewBag.Balance = balance;
                    ModelState.AddModelError("Amount", "Benny Bob took all your money! You broke boi");
                    return View("Index");
                }
                dbContext.Transactions.Add(newTransaction);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.User = userInDb;

                double balance = userInDb.Transactions.Sum(t => t.Amount);

                ViewBag.Balance = balance;
                return View("Index");
            }
        }
    }
}