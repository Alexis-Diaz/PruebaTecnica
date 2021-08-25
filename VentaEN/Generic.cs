using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaEN
{
    public class Generic<T>
    {
        int i = 0;
        public Generic(int z)
        {
            ClienteArray = new Cliente[z]
;       }

        public void AgregarCliente(Cliente cliente)
        {
            ClienteArray[i] = cliente;
            i++;
        }

        
        public Cliente[] ClienteArray;

    }
}
