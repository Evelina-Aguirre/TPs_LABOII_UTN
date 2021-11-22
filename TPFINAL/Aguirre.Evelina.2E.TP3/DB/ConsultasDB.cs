using System.Data.SqlClient;
using EstadisticasEntidades;
using Excepciones;

namespace EstadisticasEntidades
{
    public delegate void CeroRegistrosEvento();
    public static class ConsultasDB
    {
        
        public static event CeroRegistrosEvento ceroRegistrosEvento;

        public static string consultaDBComienzo = $"Select * from [dbo].[Argentina$] ";
        public static string where = " WHERE ";
        public static string consultaFinal = " order by Argentina$.SALARIO_BRUTO desc";
        public static string consultaCantidadRegistros = " SELECT count(SE_IDENTIFICA) FROM [dbo].[Argentina$] WHERE ";
        public static string conexion = @" Data Source=localhost\sqlexpress;Database=RESULTADO_ENCUESTAS;Trusted_Connection=True;";


        /// <summary>
        /// Cuenta registros de una consulta.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static int CuentaRegistrosDeUnaConsulta(string consulta)
        {

            int totalRegistrosSegunConsulta = 0;

            string cunsultaDB = consultaCantidadRegistros + consulta;
            SqlConnection sqlConnection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(cunsultaDB, sqlConnection);


            try
            {
                sqlConnection.Open();
                totalRegistrosSegunConsulta = (int)command.ExecuteScalar();
                if (totalRegistrosSegunConsulta == 0)
                {
                    ceroRegistrosEvento.Invoke();
                }
            }
            catch
            {
                totalRegistrosSegunConsulta = 0;
            }
            finally
            {
                sqlConnection.Close();
            }


            return totalRegistrosSegunConsulta;
        }

        //Select AVG(CAST(SALARIO_BRUTO AS DECIMAL(12,2)))  AS SQLAVG FROM [dbo].[Argentina$]
        /// <summary>
        /// Calcula el promedio de la columna sueldo de una consulta.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static decimal PromedioSueldoDeLaConsulta(string consulta)
        {

            decimal totalRegistrosSegunConsulta = 0;

            string cunsultaDB = "Select AVG(CAST(SALARIO_BRUTO AS DECIMAL(12,2)))  AS SQLAVG FROM [dbo].[Argentina$] WHERE " + consulta;
            SqlConnection sqlConnection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(cunsultaDB, sqlConnection);


            try
            {
                sqlConnection.Open();
                totalRegistrosSegunConsulta = (decimal)command.ExecuteScalar();
            }
            catch
            {
                totalRegistrosSegunConsulta = 0;
            }
            finally
            {
                sqlConnection.Close();
            }


            return totalRegistrosSegunConsulta;
        }

        /// <summary>
        /// Calcula el promedio de la columna sueldo del total de los registros.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static decimal PromedioSueldoDeLaConsulta()
        {

            decimal totalRegistrosSegunConsulta = 0;

            string cunsultaDB = "Select AVG(CAST(SALARIO_BRUTO AS DECIMAL(12,2)))  AS SQLAVG FROM [dbo].[Argentina$] ";
            SqlConnection sqlConnection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(cunsultaDB, sqlConnection);


            try
            {
                sqlConnection.Open();
                totalRegistrosSegunConsulta = (decimal)command.ExecuteScalar();
            }
            finally
            {
                sqlConnection.Close();
            }


            return totalRegistrosSegunConsulta;
        }

        /// <summary>
        /// Cuenta registros de una consulta.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns>numero de registros</returns>
        public static int CuentaRegistrosDeUnaConsulta()
        {

            int totalRegistros = 0;

            string cunsultaDB = "SELECT count(SE_IDENTIFICA) FROM [dbo].[Argentina$]";
            SqlConnection sqlConnection = new SqlConnection(conexion);
            SqlCommand command = new SqlCommand(cunsultaDB, sqlConnection);


            try
            {
                sqlConnection.Open();
                totalRegistros = (int)command.ExecuteScalar();
               
            }
            finally
            {
                sqlConnection.Close();
            }

            return totalRegistros;
        }
        /// <summary>
        /// Arma una consulta select, agregando el string recibido por parámetro.
        /// </summary>
        /// <param name="aux1"></param>
        /// <returns>string con consulta select</returns>
        public static string DevuelveStringConsultaBasicaADB(string aux1)
        {
            string consulta = "";
            if (string.IsNullOrEmpty(aux1) ||string.IsNullOrWhiteSpace(aux1))
            {
                consulta = consultaDBComienzo + consultaFinal;
            }
            else
            {
                consulta = consultaDBComienzo + where + aux1 + consultaFinal;

            }
            return consulta;
        }


        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.ESexo opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.ESexo.Mujer:
                    consulta += " SE_IDENTIFICA LIKE 'Mujer'";
                    break;
                case Enumerados.ESexo.Hombre:
                    consulta += "  SE_IDENTIFICA LIKE 'Hombre' ";
                    break;
                case Enumerados.ESexo.Otro:
                    consulta += "  SE_IDENTIFICA LIKE 'Otro' ";
                    break;
              
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EEdad opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.EEdad.Hasta_30_años:
                    consulta += "  [EDAD] between 0 and 30 ";
                    break;
                case Enumerados.EEdad.De_30_a_50_años:
                    consulta += "  [EDAD] between 30 and 50 ";
                    break;
                case Enumerados.EEdad.Superior_a_50_años:
                    consulta += "  [EDAD] >50 ";
                    break;
               
            }
            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EProvincia opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.EProvincia.Catamarca:
                    consulta = " [PROVINCIA] like 'Catam%' ";
                    break;
                case Enumerados.EProvincia.Chaco:
                    consulta = " [PROVINCIA] like 'chaco'  ";
                    break;
                case Enumerados.EProvincia.Chubut:
                    consulta = " [PROVINCIA] like 'chubut'  ";
                    break;
                case Enumerados.EProvincia.CABA:
                    consulta = " [PROVINCIA] like 'Ciudad Autónoma %'  ";
                    break;
                case Enumerados.EProvincia.Córdoba:
                    consulta = " [PROVINCIA] like 'Córdoba' ";
                    break;
                case Enumerados.EProvincia.Corrientes:
                    consulta = " [PROVINCIA] like 'Corrientes'  ";
                    break;
                case Enumerados.EProvincia.EntreRíos:
                    consulta = " [PROVINCIA] like 'Entre Ríos'  ";
                    break;
                case Enumerados.EProvincia.Formosa:
                    consulta = " [PROVINCIA] like 'Formosa'  ";
                    break;
                case Enumerados.EProvincia.Gran_Buenos_Aires:
                    consulta = " [PROVINCIA] like 'Gran Buenos Aires'  ";
                    break;
                case Enumerados.EProvincia.Jujuy:
                    consulta = " [PROVINCIA] like 'Jujuy'  ";
                    break;
                case Enumerados.EProvincia.LaPampa:
                    consulta = "  [PROVINCIA] like 'La Pampa'  ";
                    break;
                case Enumerados.EProvincia.LaRioja:
                    consulta = " [PROVINCIA] like 'La Rioja'  ";
                    break;
                case Enumerados.EProvincia.Misiones:
                    consulta = "  [PROVINCIA] like 'Misiones' ";
                    break;
                case Enumerados.EProvincia.Neuquén:
                    consulta = " [PROVINCIA] like 'Neuquén'  ";
                    break;
                case Enumerados.EProvincia.RíoNegro:
                    consulta = " [PROVINCIA] like 'Río Negro' ";
                    break;
                case Enumerados.EProvincia.Salta:
                    consulta = " [PROVINCIA] like 'Salta'  ";
                    break;
                case Enumerados.EProvincia.SanJuan:
                    consulta = "  [PROVINCIA] like 'San Juan' ";
                    break;
                case Enumerados.EProvincia.SanLuis:
                    consulta = "  [PROVINCIA] like 'San Luis'  ";
                    break;
                case Enumerados.EProvincia.SantaCruz:
                    consulta = "  [PROVINCIA] like 'Santa Cruz'  ";
                    break;
                case Enumerados.EProvincia.SantaFe:
                    consulta = " [PROVINCIA] like 'Santa Fe'  ";
                    break;
                case Enumerados.EProvincia.SantiagoDelEstero:
                    consulta = " [PROVINCIA] like 'Santiago del estero' ";
                    break;
                case Enumerados.EProvincia.TierraDelFuego:
                    consulta = "  [PROVINCIA] like 'Tierra del Fuego' ";
                    break;
                case Enumerados.EProvincia.Tucumán:
                    consulta = " [PROVINCIA] like 'Tucumán' ";
                    break;
             
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EExperiencia opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.EExperiencia.Hasta_10:
                    consulta = " [AÑOS_EXPERIENCIA] between 0 and 10  ";
                    break;
                case Enumerados.EExperiencia.Más_de_10:
                    consulta = " [AÑOS_EXPERIENCIA] > 10 ";
                    break;
            
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EPersonasaACargo opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.EPersonasaACargo._0:
                    consulta = " [PERSONAL_A_CARGO] = 0  ";
                    break;
                case Enumerados.EPersonasaACargo.Hasta_10:
                    consulta = " [PERSONAL_A_CARGO] between 0 and 10  ";
                    break;
                case Enumerados.EPersonasaACargo.Mas_De_10:
                    consulta = "[PERSONAL_A_CARGO] >10   ";
                    break;
                
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EEstudios opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.EEstudios.Doctorado:
                    consulta = " NIVEL_ESTUDIOS like 'DOCTORADO' ";
                    break;
                case Enumerados.EEstudios.Posdoctorado:
                    consulta = " NIVEL_ESTUDIOS like 'POSDOCTORADO' ";
                    break;
                case Enumerados.EEstudios.Posgrado:
                    consulta = "  NIVEL_ESTUDIOS like 'POSGRADO'  ";
                    break;
                case Enumerados.EEstudios.Primario:
                    consulta = " NIVEL_ESTUDIOS like 'PRIMARIO'  ";
                    break;
                case Enumerados.EEstudios.Secundario:
                    consulta = " NIVEL_ESTUDIOS like 'SECUNDARIO' ";
                    break;
                case Enumerados.EEstudios.Universitario:
                    consulta = " NIVEL_ESTUDIOS like 'UNIVERSITARIO'  ";
                    break;
                
            }

            return consulta;
        }


        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EPuesto opcionElegida)
        {

            string consulta = " ";

            switch (opcionElegida)
            {
                case Enumerados.EPuesto.Help_Desk:
                    consulta = " PUESTO like 'HELP%'  ";
                    break;
                case Enumerados.EPuesto.Administrativo:
                    consulta = " PUESTO like 'ADMIN%'   ";
                    break;
                case Enumerados.EPuesto.Arquitectura:
                    consulta = " PUESTO like 'AR%'  ";
                    break;
                case Enumerados.EPuesto.Developer:
                    consulta = " PUESTO like 'DEV%' ";
                    break;
                case Enumerados.EPuesto.Networking:
                    consulta = " PUESTO like 'NET%%'  ";
                    break;
                case Enumerados.EPuesto.QA_Tester:
                    consulta = " PUESTO like 'Q%'  ";
                    break;
                case Enumerados.EPuesto.SysAdmin:
                    consulta = " PUESTO like 'SYS%'  ";
                    break;
                case Enumerados.EPuesto.ProjectManager:
                    consulta = " PUESTO like 'PROYECT%'  ";
                    break;
                case Enumerados.EPuesto.Consultor:
                    consulta = " PUESTO like 'CO%'  ";
                    break;
                case Enumerados.EPuesto.Bi_Analist:
                    consulta = " PUESTO like 'BI%'  ";
                    break;
                case Enumerados.EPuesto.Analista_Datos:
                    consulta = " PUESTO like 'ANA%'  ";
                    break;
                case Enumerados.EPuesto.UX_Developer:
                    consulta = "PUESTO like 'UX%' ";
                    break;
                case Enumerados.EPuesto.Dba_Administrator:
                    consulta = " PUESTO like 'DB%'";
                    break;
                case Enumerados.EPuesto.FreeLance:
                    consulta = "PUESTO like 'FREE%'  ";
                    break;
               

            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.EJornada opcionElegida)
        {

            string consulta = " ";

            switch (opcionElegida)
            {
                case Enumerados.EJornada.Full_Time:
                    consulta = " JORNADA like 'FULL%' ";
                    break;
                case Enumerados.EJornada.Part_Time:
                    consulta = " JORNADA like 'PART%'";
                    break;
                case Enumerados.EJornada.FreeLanca:
                    consulta = " JORNADA like 'free%' ";
                    break;
                case Enumerados.EJornada.Remoto_Empresa_otro_País:
                    consulta = " JORNADA like 'remoto%' ";
                    break;
                
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.ESalario opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.ESalario.Hasta_50000:
                    consulta = "  [SALARIO_BRUTO] between 0 and 50000 ";
                    break;
                case Enumerados.ESalario.De_50000_a_150000:
                    consulta = "  [SALARIO_BRUTO] between 50000 and 150000 ";
                    break;
                case Enumerados.ESalario.Más_de_150000:
                    consulta = " [SALARIO_BRUTO] > 150000 ";
                    break;
              
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.ERubro opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.ERubro.Otras_Industrias:
                    consulta = " RUBRO like 'OTR%'  ";
                    break;
                case Enumerados.ERubro.Producto_Basado_En_Software:
                    consulta = " RUBRO like 'PROD%'  ";
                    break;
                case Enumerados.ERubro.Servicios_Consultoria_De_Software_Digital:
                    consulta = " RUBRO like 'SER%'  ";
                    break;
               
            }

            return consulta;
        }

        /// <summary>
        /// genera un string con fragmento de consulta select a la db  de a cuerdo a la opción elegida. 
        /// </summary>
        /// <param name="opcionElegida"></param>
        /// <returns></returns>
        public static string OpcionElegida(Enumerados.ERecomienda opcionElegida)
        {

            string consulta = "";

            switch (opcionElegida)
            {
                case Enumerados.ERecomienda.Puntajes_de_0_a_3:
                    consulta = " RECOMIENDA_EMPRESA between 0 and 3  ";
                    break;
                case Enumerados.ERecomienda.Puntajes_de_3_a_7:
                    consulta = "  RECOMIENDA_EMPRESA between 3 and 7  ";
                    break;
                case Enumerados.ERecomienda.Superior_a_7:
                    consulta = " RECOMIENDA_EMPRESA > 7 ";
                    break;
                

            }

            return consulta;
        }

    }
}
