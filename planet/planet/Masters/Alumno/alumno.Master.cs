﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace planet.Masters.alumno
{
    public partial class alumno : System.Web.UI.MasterPage
    {
        public string nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombre = "Karla";
        }
    }
}