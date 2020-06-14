using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSCrud.Servises;
using Microsoft.AspNetCore.Mvc;
using AWSCrud.Models;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;

namespace AWSCrud.Controllers
{
    [Route("api/list")]
    public class ValuesController : ControllerBase
    {

        private readonly IserListofgoods _serList;
        private readonly IPostsomeItems _postsome;
        public ValuesController(IserListofgoods iserListofgoods, IPostsomeItems postsome) 
        {
            _serList = iserListofgoods;
            _postsome = postsome;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int? id)
        {
            var request = await _serList.GetItem(id);
            return Ok(request);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post( string pairs)
        {
          await _postsome.AddSome(pairs);
            return Ok();
           
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
