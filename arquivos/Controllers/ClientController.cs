using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arquivos.Data;

namespace arquivos.Controllers
{
    public class ClientController
    {
        public int GetNextId()
        {
            return DataSet.clients.Max(i => i.Id) + 1;
        }
    }
}