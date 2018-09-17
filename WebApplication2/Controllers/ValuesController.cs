using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("api/FileAPI/GetFile")]
        public HttpResponseMessage GetFile()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            byte[] data = System.Text.Encoding.ASCII.GetBytes("This is a sample string");
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms.Write(data, 0, data.Length);
            ms.Close();

            //Set the File Path.
            string filePath = @"D:\Faris\Projects\Bulletin.pdf";

            ////Check whether File exists.
            //if (!File.Exists(filePath))
            //{
            //    //Throw 404 (Not Found) exception if File not found.
            //    response.StatusCode = HttpStatusCode.NotFound;
            //    response.ReasonPhrase = string.Format("File not found: {0} .", fileName);
            //    throw new HttpResponseException(response);
            //}


            //Read the File into a Byte Array.
            byte[] bytes = File.ReadAllBytes(filePath);

            //Set the Response Content.
            response.Content = new ByteArrayContent(bytes);

            //Set the Response Content Length.
            response.Content.Headers.ContentLength = bytes.LongLength;

            //Set the Content Disposition Header Value and FileName.
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "Bulletin.pdf";

            //Set the File Content Type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping("Bulletin.pdf"));
            return response;
        }
    }
}
