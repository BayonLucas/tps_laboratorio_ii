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


        public RegistroContable() : this(null, null, null) //No es necesario
        { }
        public RegistroContable(Ente usuario) : this(usuario, null, null) //No es necesario
        { }
        public RegistroContable(Ente usuario, List<Factura> ventas, List<Compra> compras)
        {
            this.Usuario = usuario;
            this.Ventas = ventas;
            this.Compras = compras;
        }



        /* Primeros constructores
        public RegistroContable()
        {
            this.Ventas = new List<Factura>();
            this.Compras = new List<Compra>();
        }
        public RegistroContable(Ente usuario) : this()
        {
            this.Usuario = usuario;
        }
        public RegistroContable(Ente usuario, List<Factura> ventas, List<Compra> compras) : this(usuario)
        {
            this.Ventas = ventas;
            this.Compras = compras;
        }
        */


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
        public static bool operator !=(RegistroContable rc, Compra c)
        {
            return !(rc == c);
        }
        public static RegistroContable operator +(RegistroContable rc, Compra c)
        {
            if (rc is not null && c is not null)
            {
                if (rc != c)
                {
                    rc.Compras.Add(c);
                    //return true;
                }
            }
            return rc;
        }
        public static RegistroContable operator -(RegistroContable rc, Compra c)
        {
            if (rc is not null && c is not null)
            {
                if (rc == c)
                {
                    rc.Compras.Remove(c);
                    //return true;
                }
            }
            return rc;
        }
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
        public static bool operator !=(RegistroContable rc, Factura f)
        {
            return !(rc == f);
        }
        public static RegistroContable operator +(RegistroContable rc, Factura f)
        { 
            if(rc is not null && f is not null)
            {
                if(rc != f)
                {
                    rc.Ventas.Add(f);
                    //return true;
                }
            }
            return rc;
        }
        public static RegistroContable operator -(RegistroContable rc, Factura f)
        {
            if (rc is not null && f is not null)
            {
                if (rc == f)
                {
                    rc.Ventas.Remove(f);
                    //return true;
                }
            }
            return rc;
        }




    }
}
