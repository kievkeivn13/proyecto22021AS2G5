using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace PrototipoLaboratorio
{
    
    class Bitacora
    {
        Conexion cn = new Conexion();
        string now = DateTime.Now.ToString("hh:mm:ss");
        String today = DateTime.Today.ToString("yyyy/MM/dd");
        public void insertar(string usuario,string boton)
        {
            //Registro de insercion
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                string cadena = "INSERT INTO" +
                " BITACORA (id_usuario, descripcion_bitacora, fecha_bitacora,hora_bitacora,ip_bitacora) VALUES (" + "'" + usuario + "', '" + boton + "','" + today + "' , '" + now + "', '" + localIP + "' ); ";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                
            }
        }
    }
    }

