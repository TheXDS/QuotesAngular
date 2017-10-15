using Microsoft.AspNetCore.Mvc;
using AngularTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AngularTest2.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : Controller
    {
        QuotesContext q = new QuotesContext();
        [HttpGet("[action]")]
        public IEnumerable<Quote> Recent(int count = 10)
        {
            
            try
            {
                // FIXME: esta operación aún no está soportada en EF Core.
                // return q.Quotes.TakeLast(count);

                List<Quote> l = new List<Quote>();
                List<Quote> s = q.Quotes.ToList();
                for (int j = q.Quotes.Count() - 1; l.Count < count && j >= 0; j--)
                {
                    l.Add(s.ElementAt(j));
                }
                return l;
            }
            catch
            {
                return new Quote[] { };
            }
        }

        [HttpGet("[action]")]
        public Quote Index(int index)
        {
            try
            {
                return q.Quotes.ElementAt(index);
            }
            catch// (IndexOutOfRangeException)
            {
                return null;
            }
            //catch
            //{
            //    return View("Error");
            //}
        }

        [HttpGet("[action]")]
        public Quote Latest()
        {
            try { return q.Quotes.Last(); }
            catch { return null; }
        }


        [HttpPost("[action]")]
        public IActionResult SaveQuote(string text, string author = "Desconocido")
        {
            try
            {
                //if (q.Quotes is null) q.Quotes = new List<Quote>();
                q.Quotes.Add(new Quote { Text = text, Author = author, TimeStamp=DateTime.Now });
                q.SaveChanges();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(503);
            }
        }

        #region Helpers de prueba
#if DEBUG
        [HttpGet("[action]")]
        public Quote DummyQuote()
        {
            return new Quote
            {
                Text = "Esta cita es únicamente una prueba, mas no una cita real.",
                Author = "Servidor web",
                TimeStamp = DateTime.Now
            };
        }
        [HttpGet("[action]")]
        public IEnumerable<Quote> TestQuotes()
        {
            return new[]
            {
                new Quote{ Text="Una cita inspiradora", Author="César Morgan", TimeStamp=new DateTime(1991,11,12) },
                new Quote{ Text="Otra cita aún más inspiradora.", Author="Iris Carrillos" ,TimeStamp=new DateTime(1991,6,12)},
                new Quote{ Text="Y otra, todavía más inspiradora que las dos anteriores.", Author="Lupita Baide", TimeStamp=new DateTime(1989,7,18) }
            };
        }
#endif
        #endregion
    }
}