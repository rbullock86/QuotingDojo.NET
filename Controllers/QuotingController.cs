using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class QuotingController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Console.WriteLine("Hitting Index");


            return View("Index");
        }

        [HttpGet("/Quotes")]
        public IActionResult Quotes()
        {
            Console.WriteLine("Hitting Quotes");
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query($"SELECT * FROM quotes");
            ViewBag.AllQuotes = AllQuotes;
            return View("Quotes");
        }

        [HttpPost("NewQuote")]
        public IActionResult NewQuote(Quote NewQuote)
        {
            if(ModelState.IsValid){
                string query = $"INSERT INTO quotes (name, quotedata) VALUES ('{NewQuote.Name}', '{NewQuote.QuoteData}')";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            } else {
                return View("Index");
            }
        }
    }
}