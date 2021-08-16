using System;
using System.Collections.Generic;
using System.Text;

namespace PrototipoLaboratorio.Ventanas
{
    class clsFactura
    {
        private string examen;
        private float precio;

        public string Examen { get => examen; set => examen = value; }
        public float Precio { get => precio; set => precio = value; }

        public clsFactura (string pExamen, float pPrecio)
        {
            examen = pExamen;
            precio = pPrecio;
        }

    }
}
