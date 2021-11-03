using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using umeAPI.Data;
using umeAPI.Repo;

namespace umeAPI.Service
{
    public class chatsService : chatRepo
    {
        ChatUmeDTBEntities data = new ChatUmeDTBEntities();
        public string deteteMess(int idMess)
        {
            throw new NotImplementedException();
        }

        public string SendMess(Message mess)
        {
            
            if (mess != null)
            { 
                SqlParameter idUser = new SqlParameter("@idUser", mess.idUser);
                SqlParameter idf = new SqlParameter("@idf", mess.toUserId);
                SqlParameter sendOn = new SqlParameter("@sendon",DateTime.Now);
                SqlParameter message = new SqlParameter("@content", mess.content);
                SqlParameter[] parameters = new SqlParameter[] {idUser,idf,sendOn,message };

                int result = data.Database.ExecuteSqlCommand("insert into Message " +
                    "(idUser,toUserId,createOn, content ) values (@idUser,@idf," +
                    "@sendon,@content)", parameters);
                if (result == 1) {
                    updatef(mess.idUser, mess.toUserId);
                    return "thêm thành công";
                }
                    
                else return "failt";
            }
            return "failt";


             
        }
        void updatef(int id,int idf )
        {
            SqlParameter idU = new SqlParameter("@idU", id);
            SqlParameter idF = new SqlParameter("@idF", idf);
            SqlParameter[] parameters = new SqlParameter[] { idU, idF };
            var resui =data.Database.ExecuteSqlCommand("update Friends set isActive=0 where (idUser=@idU and idFriend =@idF ) or (idUser=@idF and idFriend =@idU)", parameters);
        }

        public object ShowListMess(int id, int idf)
        {

            SqlParameter idU = new SqlParameter("@idU", id);
            SqlParameter idF = new SqlParameter("@idF", idf);
            SqlParameter[] parameters = new SqlParameter[] { idU, idF };

            try
            {
                var resuit = data.Messages.SqlQuery("select * from Message where (idUser=@idU and toUserId =@idF ) or (idUser=@idF and toUserId =@idU) ", parameters);
                    if (resuit != null)
                {
                    return resuit;
                }
                else return resuit;
            }
            catch {
                return null;
            }
            
        }

        public object updeteStatus(int idMess)
        {
            throw new NotImplementedException();
        }
    }
}