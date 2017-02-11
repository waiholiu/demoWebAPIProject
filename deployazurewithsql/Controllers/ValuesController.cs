using deployazurewithsql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace deployazurewithsql.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Widget> Get()
        {
            var Model1 = new Model1();

            var widgets = Model1.Widgets.ToList();
            return widgets;
        }

        // GET api/values/5
        public Widget Get(int id)
        {
            var Model1 = new Model1();

            var widget = Model1.Widgets.FirstOrDefault(w => w.id == id);

            if(widget != null)
                return widget;
            else
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
"this item does not exist"));
        }

        // POST api/values
        public void Post([FromBody]Widget value)
        {
            var Model1 = new Model1();

            Model1.Widgets.Add(value);
            Model1.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var Model1 = new Model1();

            var deleteWidget = Model1.Widgets.FirstOrDefault(w => w.id == id);

            if (deleteWidget != null)
            {
                Model1.Widgets.Remove(deleteWidget);
                Model1.SaveChanges();
            }
            else
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
"this item does not exist"));
        }
    }
}
