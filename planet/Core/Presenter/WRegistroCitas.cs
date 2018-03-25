﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Model;
using Core.View;
using System.Data;
using System.Data.SqlClient;

namespace Core.Presenter
{
    public class WRegistroCitas
    {

        ManagerBD Manager;
        IRegistroCitas ViewRegistroCitas;
        CRegistroCitas objRegistroCitas;
        public WRegistroCitas(IRegistroCitas InterfazRegistroCitas)
        {
            objRegistroCitas = new CRegistroCitas();
            Manager = new ManagerBD();
            ViewRegistroCitas = InterfazRegistroCitas;
        }
        public bool ExisteConexion()
        {
            bool ConexcionAvierta = false;
            SqlConnection sqlCon = Manager.GetConnection();
            if (sqlCon.State == ConnectionState.Open)
            {
                ConexcionAvierta = true;
            }
            return ConexcionAvierta;
        }
        public void ListadoDeCitas(CRegistroCitas objCita, int opcion)
        {
            DataSet dtsDatos = new DataSet();
            CRegistroCitas objaux = new CRegistroCitas();
            bool BolRegistro = false;
            if (ExisteConexion())
            {
                BolRegistro = objaux.ListarCitas(opcion, objCita, ref dtsDatos);

                if (BolRegistro == true)
                {
                    ViewRegistroCitas.ListadoDt = dtsDatos;
                    ViewRegistroCitas.Mensaje("Listado correcto", 1);
                }
                else
                {
                    ViewRegistroCitas.Mensaje("Error no se pudieron listas ", 2);
                }
            }
        }

        public void RegistroCita(CRegistroCitas objCita, int opcion)
        {
            DataSet dtsDatos = new DataSet();
            CRegistroCitas objaux = new CRegistroCitas();
            bool BolRegistro = false;
            if (ExisteConexion())
            {
                
                BolRegistro = objaux.InsertarReservacion(opcion, objCita); 
                if (BolRegistro == true)
                {
                    
                      ViewRegistroCitas.Mensaje("Correcto", 4); 
                  
                }
                else
                {
                    ViewRegistroCitas.Mensaje("Error", 5);
                }
            }
        }
        public void FaltasDeAlumno(CRegistroCitas objCita, int opcion)
        {
            DataSet dtsDatos = new DataSet();
            CRegistroCitas objaux = new CRegistroCitas();
            bool BolRegistro = false;
            if (ExisteConexion())
            {
                BolRegistro = objaux.ListarCitas(opcion, objCita, ref dtsDatos);

                if (BolRegistro == true)
                {
                   // ViewRegistroCitas.ListadoDt = dtsDatos;

                    ViewRegistroCitas.Mensaje(dtsDatos.Tables[0].Rows[0][0].ToString(),5);
                }
                else
                {
                    ViewRegistroCitas.Mensaje("Error no se pudo obtener faltas", 6);
                }
            }
        }
    }
}