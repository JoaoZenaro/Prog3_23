using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arquivos.Data;
using Arquivos.Models;

namespace Arquivos.Utils
{
    public class Bootstrapper
    {
        public static void ChargeClients()
        {
            var c1 = new Client(1, "Joao", "Zenaro", "111.111.111-11", "joaoz@email.com");
            DataSet.Clients.Add(c1);

            DataSet.Clients.Add(new Client(2,"John","Doe","222.222.222-22","email@email.com"));
            DataSet.Clients.Add(new Client(3,"Jane","Doe","333.333.333-33","outlook@hotmail.com"));
        }
    }
}