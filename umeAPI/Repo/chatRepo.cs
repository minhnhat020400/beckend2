using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umeAPI.Data;

namespace umeAPI.Repo
{
    interface chatRepo
    {
        object ShowListMess(int id, int idf);
        string SendMess(Message mess);
        string deteteMess(int idMess);
        object updeteStatus(int idMess);
    }
}
