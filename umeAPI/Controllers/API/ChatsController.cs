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
            if (message != null && message.content!=null && message.content != "")
            {
                var resuit= cService.SendMess(message);
                if (resuit != "failt")
                {
                    return "success";
                }
                else return resuit;
            }
            return "failt";
        }
    }
}
