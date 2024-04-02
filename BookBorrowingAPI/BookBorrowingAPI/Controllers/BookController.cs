using BookBorrowingAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Shared;
using BookBorrowingAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interface;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookBorrowingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL _bookBl;


        public BookController(IBookBL bookBl)
        {
            _bookBl = bookBl;

        }

     
        [HttpGet]
        [Route("GetBooks")]
        public ActionResult GetBooks()
        {
            var b = _bookBl.GetBooks();
            if (b.Count() != 0)
            {
                return Ok(b);
            }
            else
            {
                return NoContent();
            }


        }

       
        [HttpGet("{id}")]
        [Route("GetBook/{id}")]
        public ActionResult GetBookById(int id)
        {
            var b = _bookBl.GetBookById(id);
            if (b != null)
            {
                return Ok(b);
            }
            else
            {
                return NoContent();
            }


        }

        [HttpPost]
        [Route("SearchBooks")]
        public ActionResult SearchBooks(SearchBookModel val)
        {
            if (val == null)
            {
                return BadRequest();
            }

            try
            {
                var q = new SearchBookModelToBookHelper().SearchBookToBookMapping(val);
                var b = _bookBl.SearchBooks(q);
                if (b != null)
                {
                    return Ok(b);
                }
                else
                {
                    return NoContent();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [Authorize]
        [HttpPost]
        [Route("ReturnBooks")]
        public ActionResult ReturnBooks(ReturnBookModel val)
        {
            try
            {
                //if (val == null)
                //{
                //    return BadRequest(false);
                //}

                Book b = new ReturnBookModelToBookHelper().ReturnBookModelToBookMapping(val);
                if (_bookBl.ReturnBooks(b))
                {
                    return Accepted(true);
                }
                else
                {
                    return Ok(false);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [Authorize]
        [HttpPost]
        [Route("AddBooks")]
        public ActionResult AddBooks(BookModel val)
        {
            try
            {
                Book b = new BookModelToBookHelper().BookModelToBookMapping(val);
            
            return Ok(_bookBl.AddBooks(b));
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            

        }

        [Authorize]
        [HttpPost]
        [Route("BorrowBooks")]
        public ActionResult BorrowBooks(Book val)
        {
            try
            {
                var sts = _bookBl.BorrowBooks(val);
                if (sts == true)
                    return Accepted(true);
                else
                    return Ok(false);
            }catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
           

        }


        //// GET: api/<BookController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<BookController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<BookController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<BookController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<BookController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
