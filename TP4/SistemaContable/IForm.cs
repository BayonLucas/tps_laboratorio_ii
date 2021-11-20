using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable
{
    public interface IForm
    {
        bool ValidarDatosIngresados();
        void Refrescar();
        void MostrarDatosCompra<T>(T t);

    }
}
