using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegistroContable
    {
        private Ente usuario;
        private List<Factura> ventas;
        private List<Compra> compras;

        public List<Compra> Compras { get => compras; set => compras = value; }
        public List<Factura> Ventas { get => ventas; set => ventas = value; }
        public Ente Usuario { get => usuario; set => usuario = value; }


        public RegistroContable() : this(null)
        { }
        public RegistroContable(Ente usuario) : this(usuario, new List<Factura>(), new List<Compra>())
        { }
        public RegistroContable(Ente usuario, List<Factura> ventas, List<Compra> compras)
        {
            this.Usuario = usuario;
            this.Ventas = ventas;
            this.Compras = compras;
        }

        /// <summary>
        /// Retorna true en caso de que la compra este incluida en la lista Compras
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool operator ==(RegistroContable rc, Compra c)
        {
            if (rc is not null && c is not null)
            {
                foreach (Compra item in rc.Compras)
                {
                    if (item == c)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna true en caso de que la compra este no incluida en la lista Compras
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool operator !=(RegistroContable rc, Compra c)
        {
            return !(rc == c);
        }
       
        /// <summary>
        /// Agrega a la lista Compras el objeto pasado por parametro en caso de no estar ya incorporada
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static RegistroContable operator +(RegistroContable rc, Compra c)
        {
            if (rc is not null && c is not null)
            {
                if (rc != c)
                {
                    rc.Compras.Add(c);
                }
            }
            return rc;
        }

        /// <summary>
        /// Elimina de la lista Compras el objeto pasado por parametro en caso de estar ya incorporada
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static RegistroContable operator -(RegistroContable rc, Compra c)
        {
            if (rc is not null && c is not null)
            {
                if (rc == c)
                {
                    rc.Compras.Remove(c);
                }
            }
            return rc;
        }

        /// <summary>
        /// Retorna true en caso de que la Factura este incluida en la lista Ventas
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool operator ==(RegistroContable rc, Factura f)
        {
            if (rc is not null && f is not null)
            {
                foreach (Factura item in rc.Ventas)
                {
                    if(item == f)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Retorna true en caso de que la Factura no este incluida en la lista Ventas
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static bool operator !=(RegistroContable rc, Factura f)
        {
            return !(rc == f);
        }

        /// <summary>
        /// Agrega a la lista Ventas el objeto pasado por parametro en caso de no estar ya incorporado
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static RegistroContable operator +(RegistroContable rc, Factura f)
        { 
            if(rc is not null && f is not null)
            {
                if(rc != f)
                {
                    rc.Ventas.Add(f);
                }
            }
            return rc;
        }

        /// <summary>
        /// Elimina de la lista Ventas el objeto pasado por parametro en caso de estar ya incorporada
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        public static RegistroContable operator -(RegistroContable rc, Factura f)
        {
            if (rc is not null && f is not null)
            {
                if (rc == f)
                {
                    foreach(Factura item in rc.Ventas)
                    {
                        if(item == f)
                        {
                            item.Anulado = true;
                        }
                    }
                }
            }
            return rc;
        }




    }
}
