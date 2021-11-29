using EstadisticasEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnalyticsEntidades
{
    public static class ConexionDB
    {
        static SqlConnection conexion;
        static SqlCommand comando;
        static SqlDataReader reader;
        static string conexionString = @" Data Source=localhost\sqlexpress;Database=RESULTADO_ENCUESTAS;Trusted_Connection=True;";
        static ConexionDB()
        {
            conexion = new SqlConnection(conexionString);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;

        }


        public static void InsertarRegistro(Encuesta auxEncuesta)
        {
            string cunsulta = $"Select * from [dbo].[Argentina$]";
            SqlConnection sqlConnection = new SqlConnection(conexionString);
            SqlCommand command = new SqlCommand(cunsulta, sqlConnection);



            command.CommandText = $"insert into [dbo].[Argentina$] (SE_IDENTIFICA,EDAD,PROVINCIA,	AÑOS_EXPERIENCIA,	PERSONAL_A_CARGO," +
                $"	NIVEL_ESTUDIOS,	ESTADO,	PUESTO,	JORNADA,	SALARIO_BRUTO,	RUBRO,	RECOMIENDA_EMPRESA)" +
                $" values ('{auxEncuesta.Se_Identifica}', '{auxEncuesta.Edad}', '{auxEncuesta.Provincia}', '{auxEncuesta.Experiencia}'" +
                $", '{auxEncuesta.Personal_a_Cargo}', '{auxEncuesta.Nivel_Estudios}', '{auxEncuesta.Estado_Estudios}', '{auxEncuesta.Puesto}'," +
                $" '{auxEncuesta.Jornada}', '{auxEncuesta.Salario_Bruto}', '{auxEncuesta.Rubro}', '{auxEncuesta.Recomienda_Empresa}' )";
            command.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                sqlConnection.Close();
            }


        }

        /// <summary>
        /// Recupera todos los registros que hay actualmente en la base;
        /// </summary>
        /// <returns></returns>
        public static List<Encuesta> TraerResultadoEncuestas()
        {

            string cunsulta = $"Select * from [dbo].[Argentina$]";
            SqlConnection sqlConnection = new SqlConnection(conexionString);
            SqlCommand command = new SqlCommand(cunsulta, sqlConnection);


            List<Encuesta> auxLista = null;
            Encuesta auxEncuesta = null;

            try
            {
                auxLista = new List<Encuesta>();


                sqlConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    auxEncuesta = new Encuesta();
                    auxEncuesta.Se_Identifica = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["SE_IDENTIFICA"]);
                    auxEncuesta.Edad = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["EDAD"]);
                    auxEncuesta.Provincia = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["PROVINCIA"]);
                    auxEncuesta.Experiencia = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["AÑOS_EXPERIENCIA"]);
                    auxEncuesta.Personal_a_Cargo = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["PERSONAL_A_CARGO"]);
                    auxEncuesta.Nivel_Estudios = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["NIVEL_ESTUDIOS"]);
                    auxEncuesta.Estado_Estudios = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["ESTADO"]);
                    auxEncuesta.Puesto = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["PUESTO"]);
                    auxEncuesta.Jornada = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["JORNADA"]);
                    auxEncuesta.Salario_Bruto = ClaseGenerica<double>.ValidarDatoNoNulloDB<double>(dataReader["SALARIO_BRUTO"]);
                    auxEncuesta.Rubro = dataReader["RUBRO"].ToString();
                    auxEncuesta.Recomienda_Empresa = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["RECOMIENDA_EMPRESA"]);
                    auxLista.Add(auxEncuesta);
                }
            }
            finally
            {
                sqlConnection.Close();
            }


            return auxLista;
        }

        /// <summary>
        /// Ejecuta consulta a al DB.
        /// </summary>
        /// <param name="consulta">consulta formato string que se hará a la base</param>
        /// <returns>retorna una lista con los datos recuperados</returns>
        public static List<Encuesta> TraeResultadoEncuestas(string consulta)
        {

            SqlConnection sqlConnection = new SqlConnection(conexionString);
            SqlCommand command = new SqlCommand(consulta, sqlConnection);


            List<Encuesta> auxLista = null;
            Encuesta auxEncuesta = null;
            try
            {
                
                auxLista = new List<Encuesta>();

                sqlConnection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    auxEncuesta = new Encuesta();
                    auxEncuesta.Se_Identifica = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["SE_IDENTIFICA"]);
                    auxEncuesta.Edad = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["EDAD"]);
                    auxEncuesta.Provincia = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["PROVINCIA"]);
                    auxEncuesta.Experiencia = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["AÑOS_EXPERIENCIA"]);
                    auxEncuesta.Personal_a_Cargo = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["PERSONAL_A_CARGO"]);
                    auxEncuesta.Nivel_Estudios = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["NIVEL_ESTUDIOS"]);
                    auxEncuesta.Estado_Estudios = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["ESTADO"]);
                    auxEncuesta.Puesto = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["PUESTO"]);
                    auxEncuesta.Jornada = ClaseGenerica<string>.ValidarDatoNoNulloDB<string>(dataReader["JORNADA"]);
                    auxEncuesta.Salario_Bruto = ClaseGenerica<double>.ValidarDatoNoNulloDB<double>(dataReader["SALARIO_BRUTO"]);
                    auxEncuesta.Rubro = dataReader["RUBRO"].ToString();
                    auxEncuesta.Recomienda_Empresa = ClaseGenerica<int>.ValidarDatoNoNulloDB<int>((int)(double)dataReader["RECOMIENDA_EMPRESA"]);
                    auxLista.Add(auxEncuesta);
                }
            }
            finally
            {
                sqlConnection.Close();
            }


            return auxLista;
        }



    }


}



