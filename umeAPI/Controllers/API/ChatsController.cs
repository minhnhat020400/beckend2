using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using umeAPI.Data;
using umeAPI.Service;

namespace umeAPI.Controllers.API
{
    public class ChatsController : ApiController
    {
        chatsService cService = new chatsService();
        [Route("api/Chats/sendsms")]
        [HttpPost]
        public string PostMess(Message message)
        {
            if (message != null && message.content != null && message.content != "")
            {
                var resuit = cService.SendMess(message);
                if (resuit != "failt")
                {
                    return "success";
                }
                else return resuit;
            }
            return "failt";
        }


        ///load tin nham
        [HttpGet]
        public object Getmess(int id, int idf)
        {
            if (id != null && idf != null)
            { 
                var resuit = cService.ShowListMess(id, idf);
                if (resuit != null)
                {
                   return Json(new
                       {
                           Message = "success",
                           Data = resuit
                       }     
                   );
                }
                else return Json(new
                {
                    Message = "failt",
                }
                  );
            }
            else return Json(new
            {
                Message = "failt",
            }
                  );


        }
        // GET: api/Chats
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Chats/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Chats
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Chats/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Chats/5
        //public void Delete(int id)
        //{
        //}
    }
}
