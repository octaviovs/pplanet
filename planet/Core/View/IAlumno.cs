﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Core.Model;

namespace Core.View
{
    public interface IAlumno
    {
        void MensajeAlumno(string Mensaje, int tipo);

        CAlumno UsuarioLogeado { set; get; }
        CAlumno UsuarioActulizar { set; get; }
        DataSet UsuariosDt { set; get; }

    }
}
