using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Markup;
using System.IO;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using AccesoBD.Models;
using System.Windows.Controls;
using System.Collections;
//21978122

namespace AccesoBD
{
    public static class DBManager
    {
        static SqlConnection dbConn = null;
        static DataTable dataFromTablesFromDB = null;
        static DataTable dataReporteBecas = null;

        public static DataTable DataFromTablesFromDB { get => dataFromTablesFromDB; set => dataFromTablesFromDB = value; }

        public static void Initialize()
        {


            if (dbConn == null)
            {
                //string connectionString = "SERVER=localhost; UID=root; PASSWORD=root; PORT=4407;";  //ConfigurationManager.ConnectionStrings["MySQLCS"].ConnectionString;
                //dbConn = new MySqlConnection(connectionString);
                string connectionString = GetStringConn();
                //string connectionString = "Data Source = DESKTOP-K5SGCUU\\SQLSERVERDEV; Database = upnce; Initial Catalog = upnce;  Trusted_Connection = true; TrustServerCertificate = True;";
                //string connectionString = "Data Source = FI-PC-148488-LA\\GESTIONSERVER; Database = upnce; USER ID = sa; PASSWORD = loganD78x;Initial Catalog = upnce;";

                dbConn = new SqlConnection(connectionString);
                dbConn.Open();

            }
        }

        public static string GetStringConn()
        {
            string line = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Certs\\strconn.txt");
                //Read the first line of text
                line = sr.ReadLine();
                
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            

            return line;
        }


        public static SqlConnection DBConn()
        {
            if (dbConn == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myDBConn"].ConnectionString;
                dbConn = new SqlConnection(connectionString);
            }
            return dbConn;
        }

        public static DataTable GetDatabases()
        {
            DataTable dataBases = null;

            string query = string.Format("SELECT name FROM sys.databases;");

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                dataBases = new DataTable();
                daCats.Fill(dataBases);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return dataBases;
        }

        public static int GetCreditosCarrera(string idCarrera)
        {
            int creditos = 0;




            return creditos;
        }

        public static DataTable GetNiveles(string matricula)
        {
            DataTable tablesFromDB = null;

            string query = string.Format("SELECT nombre_nivel FROM Niveles");

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                tablesFromDB = new DataTable();
                daCats.Fill(tablesFromDB);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return tablesFromDB;
        }

        public static DataTable GetTablesFromDB(string nameDB)
        {
            DataTable tablesFromDB = null;

            string query = string.Format("SHOW TABLES FROM {0}", nameDB);

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                tablesFromDB = new DataTable();
                daCats.Fill(tablesFromDB);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return tablesFromDB;
        }

        public static string[] GetPlantel(string matricula)
        {
            
            string query;
            SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;

            query = @"SELECT DISTINCT aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, aspirante_curp, carrera_aspira, Carreras.Carrera_descripcion, Carreras.Carrera_creditos
                      FROM ASPIRANTES, CARRERAS
                      WHERE alumno_matricula = '" + matricula + "' AND Carrera_id = carrera_aspira;";

            string[] barInfoQuery = new string[8];

            try
            {
                SqlCommand cmd = new SqlCommand(query, dbConn);
                rdr = cmd.ExecuteReader();

                while ((rdr.Read()))
                {
                    barInfoQuery[0] = rdr.GetString(0);
                    barInfoQuery[1] = rdr.GetString(1);
                    barInfoQuery[2] = rdr.GetString(2);
                    barInfoQuery[3] = rdr.GetString(3);
                    if (rdr.GetValue(4) != System.DBNull.Value)
                        barInfoQuery[4] = rdr.GetString(4);
                    else
                        barInfoQuery[4] = "";
                    barInfoQuery[5] = rdr.GetString(5);
                    barInfoQuery[6] = rdr.GetString(6);
                    barInfoQuery[7] = rdr.GetInt16(7).ToString();
                }

                cmd = null/* TODO Change to default(_) if this is not a reference type */;
                rdr.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            // close connection
            finally
            {
            }


            return barInfoQuery;
        }

        public static string GetCarrera(string carreraId)
        {

            string query;
            SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;

            query = $"SELECT carrera_descripcion FROM CARRERAS WHERE Carrera_id = {carreraId};";

            string barInfoQuery = "";

            try
            {
                SqlCommand cmd = new SqlCommand(query, dbConn);
                rdr = cmd.ExecuteReader();

                while ((rdr.Read()))
                {
                    barInfoQuery = rdr.GetString(0);
                }

                cmd = null/* TODO Change to default(_) if this is not a reference type */;
                rdr.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            // close connection
            finally
            {
            }


            return barInfoQuery;
        }

        public static string[] GetPlantel2(string nombreAlumno)
        {

            string query;
            SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;

            query = @"SELECT DISTINCT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, aspirante_curp, carrera_aspira, Carreras.Carrera_descripcion
                      FROM ASPIRANTES, CARRERAS
                      WHERE aspirante_nombre LIKE '" + nombreAlumno + "%' OR aspirante_ape1 LIKE '" + nombreAlumno + "%' OR aspirante_ape1 LIKE '" + nombreAlumno + "%';";

            string[] barInfoQuery = new string[8];

            try
            {
                SqlCommand cmd = new SqlCommand(query, dbConn);
                rdr = cmd.ExecuteReader();

                while ((rdr.Read()))
                {
                    barInfoQuery[0] = rdr.GetString(0);
                    barInfoQuery[1] = rdr.GetString(1);
                    barInfoQuery[2] = rdr.GetString(2);
                    barInfoQuery[3] = rdr.GetString(3);
                    barInfoQuery[4] = rdr.GetString(4);
                    barInfoQuery[5] = rdr.GetString(5);
                    barInfoQuery[6] = rdr.GetString(6);
                    barInfoQuery[7] = rdr.GetString(7);
                }

                cmd = null/* TODO Change to default(_) if this is not a reference type */;
                rdr.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            // close connection
            finally
            {
            }


            return barInfoQuery;
        }

        public static List<MateriasParaPromedio> GetPromedioFinal(string matricula, string carrera, bool showNAS)
        {
            string query = "";
            List<MateriasParaPromedio> infoQuery = new List<MateriasParaPromedio>();

            if (!showNAS)
            {
                if (carrera == "379")
                    //query = @"SELECT COUNT(datos4.Acta_Eval_Materia_ID), SUM(datos4.creditos) AS CreditosTotales, Round(AVG(CAST(datos4.cal AS DECIMAL(10))),2)
                    query = @"SELECT creditos, cal, Acta_Eval_Materia_Id, materia_tipo
                            FROM
                            (SELECT datos3.*, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As CAL_LETRA
                              FROM
                                (SELECT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.materia_tipo 
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS Tipo, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacionMEMS b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + matricula + @"' AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + matricula + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id) datos4;";
                else
                {
                    //query = @"SELECT COUNT(datos2.Acta_Eval_Materia_ID), SUM(datos2.creditos) AS CreditosTotales, Round(AVG(CAST(datos2.cal AS DECIMAL(10))),2)
                    query = @"SELECT creditos, cal, Acta_Eval_Materia_Id, materia_tipo
                        FROM
	                        (SELECT DISTINCT datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, datos.TipoE, datos.Acta_Eval_Materia_ID,
			                        datos.Acta_Eval_grupo_id, datos.Materia_Nombre, CARRERAS_MATERIAS.creditos, datos.cal, datos.Cal_Letra, CARRERAS_MATERIAS.materia_tipo
	                        FROM
		                        (SELECT DISTINCT dbo.EncActaEval.Acta_Eval_grupo_plantel_id, dbo.EncActaEval.Acta_Eval_grupo_periodo_id,  
			                        dbo.GetTipoExamen2(dbo.EncActaEval.Acta_Eval_grupo_tipo) AS TipoE, dbo.EncActaEval.Acta_Eval_Materia_ID,
			                        dbo.EncActaEval.Acta_Eval_grupo_id, dbo.MATERIAS.Materia_Nombre, 
			                        dbo.DetActaEval.cal, dbo.GETCAL_LETRAS3(dbo.DetActaEval.cal) AS Cal_Letra
		                        FROM dbo.EncActaEval, dbo.DetActaEval, dbo.MATERIAS
		                        WHERE(dbo.EncActaEval.Acta_Eval_Id = dbo.DetActaEval.Acta_Eval_Id AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')
			                        AND DetActaEval.Acta_Eval_alumno_matricula IN
				                        (SELECT DISTINCT DetActaEval.Acta_Eval_alumno_matricula FROM DetActaEval
				                        WHERE DetActaEval.Acta_Eval_alumno_matricula = '" + matricula + @"') 
				                        AND dbo.MATERIAS.Materia_ID = EncActaEval.Acta_Eval_Materia_ID) datos, CARRERAS_MATERIAS
	                        WHERE datos.Acta_Eval_Materia_ID = CARRERAS_MATERIAS.Materia_Id) datos2;";
                    //WHERE datos2.cal <> 'A';";
                }
            }
            else 
            {
                if (carrera == "379")
                    //query = @"SELECT COUNT(datos4.Acta_Eval_Materia_ID), SUM(datos4.creditos) AS CreditosTotales, Round(AVG(CAST(datos4.cal AS DECIMAL(10))),2)
                    query = @"SELECT creditos, cal, Acta_Eval_Materia_ID, materia_tipo
                            FROM
                            (SELECT datos3.*, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As CAL_LETRA
                              FROM
                                (SELECT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS Tipo, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacionMEMS b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + matricula + @"' )) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + matricula + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id) datos4;";
                else
                {
                    //query = @"SELECT COUNT(datos2.Acta_Eval_Materia_ID), SUM(datos2.creditos) AS CreditosTotales, Round(AVG(CAST(datos2.cal AS DECIMAL(10))),2)
                    query = @"SELECT creditos, cal, Acta_Eval_Materia_Id, materia_tipo
                        FROM
	                        (SELECT DISTINCT datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, datos.TipoE, datos.Acta_Eval_Materia_ID,
			                        datos.Acta_Eval_grupo_id, datos.Materia_Nombre, CARRERAS_MATERIAS.creditos, datos.cal, datos.Cal_Letra, CARRERAS_MATERIAS.materia_tipo
	                        FROM
		                        (SELECT DISTINCT dbo.EncActaEval.Acta_Eval_grupo_plantel_id, dbo.EncActaEval.Acta_Eval_grupo_periodo_id,  
			                        dbo.GetTipoExamen2(dbo.EncActaEval.Acta_Eval_grupo_tipo) AS TipoE, dbo.EncActaEval.Acta_Eval_Materia_ID,
			                        dbo.EncActaEval.Acta_Eval_grupo_id, dbo.MATERIAS.Materia_Nombre, 
			                        dbo.DetActaEval.cal, dbo.GETCAL_LETRAS3(dbo.DetActaEval.cal) AS Cal_Letra
		                        FROM dbo.EncActaEval, dbo.DetActaEval, dbo.MATERIAS
		                        WHERE(dbo.EncActaEval.Acta_Eval_Id = dbo.DetActaEval.Acta_Eval_Id)
			                        AND DetActaEval.Acta_Eval_alumno_matricula IN
				                        (SELECT DISTINCT DetActaEval.Acta_Eval_alumno_matricula FROM DetActaEval
				                        WHERE DetActaEval.Acta_Eval_alumno_matricula = '" + matricula + @"') 
				                        AND dbo.MATERIAS.Materia_ID = EncActaEval.Acta_Eval_Materia_ID) datos, CARRERAS_MATERIAS
	                        WHERE datos.Acta_Eval_Materia_ID = CARRERAS_MATERIAS.Materia_Id) datos2;";
                    //WHERE datos2.cal <> 'A';";
                }
            }

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);

                DataTable DataForAverage = new DataTable();

                daCats.Fill(DataForAverage);

                DataTable DataAverageado;

                if (showNAS)
                {
                    DataAverageado = DataForAverage.AsEnumerable()
                                        .GroupBy(row => row.Field<string>("Acta_Eval_Materia_ID"))
                                        .Select(grp => grp.Last()).CopyToDataTable();
                }
                else 
                {
                    DataAverageado = DataForAverage;
                }

                

                string[] barInfoQuery = new string[3];
                           
                foreach(DataRow rdr in DataAverageado.Rows)
                {
                    MateriasParaPromedio matPa = new MateriasParaPromedio();
                    matPa.Creditos = int.Parse(rdr.ItemArray[0].ToString());
                    matPa.CaliLetra = rdr.ItemArray[1].ToString();
                    infoQuery.Add(matPa);
                }

                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            // close connection
            finally
            {
            }


            return infoQuery;

        }

        //public static DataTable GetPromedioFinal(string matricula, string carrera)
        //{

        //    string query;
        //    //SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;
        //    if (carrera == "379")
        //        query = @"SELECT COUNT(datos4.Acta_Eval_Materia_ID), SUM(datos4.creditos) AS CreditosTotales, Round(AVG(CAST(datos4.cal AS DECIMAL(10))),2)
        //                    FROM
        //                    (SELECT datos3.*, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As CAL_LETRA
        //                      FROM
        //                        (SELECT datos2.*, CARRERAS_MATERIAS.creditos
        //                         FROM
        //                           (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS Tipo, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
        //                                            Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
        //                            FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
        //                                        b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
        //                                 FROM dbo.EncActaEval b1
        //                                 LEFT JOIN dbo.PrimeraEspecializacionMEMS b2
        //                                 ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
        //                                 WHERE b1.Acta_Eval_Id IN
        //                                     (SELECT dbo.DetActaEval.Acta_Eval_Id 
        //                                      FROM DetActaEval
        //                                      WHERE Acta_Eval_alumno_matricula = '" + matricula + @"')) datos, MATERIAS
        //                            WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
        //                        WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
        //                      WHERE Acta_Eval_alumno_matricula = '" + matricula + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id) datos4;";
        //    else
        //    {
        //        query = @"SELECT COUNT(datos2.Acta_Eval_Materia_ID), SUM(datos2.creditos) AS CreditosTotales, Round(AVG(CAST(datos2.cal AS DECIMAL(10))),2)
        //                FROM
        //                 (SELECT DISTINCT datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, datos.TipoE, datos.Acta_Eval_Materia_ID,
        //                   datos.Acta_Eval_grupo_id, datos.Materia_Nombre, CARRERAS_MATERIAS.creditos, datos.cal, datos.Cal_Letra
        //                 FROM
        //                  (SELECT DISTINCT dbo.EncActaEval.Acta_Eval_grupo_plantel_id, dbo.EncActaEval.Acta_Eval_grupo_periodo_id,  
        //                   dbo.GetTipoExamen2(dbo.EncActaEval.Acta_Eval_grupo_tipo) AS TipoE, dbo.EncActaEval.Acta_Eval_Materia_ID,
        //                   dbo.EncActaEval.Acta_Eval_grupo_id, dbo.MATERIAS.Materia_Nombre, 
        //                   dbo.DetActaEval.cal, dbo.GETCAL_LETRAS3(dbo.DetActaEval.cal) AS Cal_Letra
        //                  FROM dbo.EncActaEval, dbo.DetActaEval, dbo.MATERIAS
        //                  WHERE(dbo.EncActaEval.Acta_Eval_Id = dbo.DetActaEval.Acta_Eval_Id)
        //                   AND DetActaEval.Acta_Eval_alumno_matricula IN
        //                    (SELECT DISTINCT DetActaEval.Acta_Eval_alumno_matricula FROM DetActaEval
        //                    WHERE DetActaEval.Acta_Eval_alumno_matricula = '" + matricula + @"') 
        //                    AND dbo.MATERIAS.Materia_ID = EncActaEval.Acta_Eval_Materia_ID) datos, CARRERAS_MATERIAS
        //                 WHERE datos.Acta_Eval_Materia_ID = CARRERAS_MATERIAS.Materia_Id) datos2;";
        //                    //WHERE datos2.cal <> 'A';";
        //    }

        //    DataTable DataFromTablesFromDB = null;

        //    try
        //    {
        //        SqlCommand mycomand = new SqlCommand(query, dbConn);

        //        SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
        //        DataFromTablesFromDB = new DataTable();
        //        daCats.Fill(DataFromTablesFromDB);

        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.Print(ex.Message);
        //    }

        //    return DataFromTablesFromDB;
        //}

        public static DataTable BuscaNombre(string _nombre, string _ape1, string _ape2)
        {
            DataFromTablesFromDB = null;
            string query = "";

            if(_nombre != "" && _ape1 == "" && _ape2 == "")
            {
                query = $"SELECT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, carrera_Aspira FROM Aspirantes " +
                           $"WHERE aspirante_nombre Like '{_nombre}%';";
            }else if(_nombre != "" && _ape1 != "" && _ape2 == "")
            {
                query = $"SELECT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, carrera_Aspira  FROM Aspirantes " +
                           $"WHERE aspirante_nombre Like '{_nombre}%' AND aspirante_ape1 Like '{_ape1}%';";
            }
            else if(_nombre != "" && _ape1 != "" && _ape2 != "")
            {
                query = $"SELECT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, carrera_Aspira  FROM Aspirantes " +
                           $"WHERE aspirante_nombre Like '{_nombre}%' AND aspirante_ape1 Like '{_ape1}%' AND aspirante_ape2 Like '{_ape2}%';";
            }
            else if(_nombre == "" && _ape1 != "" && _ape2 == "")
            {
                query = $"SELECT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, carrera_Aspira  FROM Aspirantes " +
                           $"WHERE aspirante_ape1 Like '{_ape1}%';";
            }
            else if (_nombre == "" && _ape1 == "" && _ape2 != "")
            {
                query = $"SELECT alumno_matricula, aspirante_plantel, aspirante_nombre, aspirante_ape1, aspirante_ape2, carrera_Aspira  FROM Aspirantes " +
                           $"WHERE aspirante_ape2 Like '{_ape2}%';";
            }

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                DataFromTablesFromDB = new DataTable();
                daCats.Fill(DataFromTablesFromDB);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return DataFromTablesFromDB;
        }

        public static DataTable GetReporteBecas()
        {
            dataReporteBecas = null;
            string query = "";

            query = $"SELECT DISTINCT aspirante_curp as CURP, CONCAT(aspirante_ape1,' ', aspirante_ape2,' ', aspirante_nombre) AS NOMBRE_COMPLETO, '31DUP0001C' AS CLAVE_PLANTEL, 'UNIVERSIDAD PEDAGOGICA DE YUCATAN' AS NOMBRE_PLANTEL, " +
                    "dbo.GET_CLAVE_CARRERA(carrera_aspira) AS CLAVE_CARRERA, UPPER(Carrera_descripcion) AS NOMBRE_CARRERA, Num_Periodos_Duracion AS PERIODOS_DURACION, " +
                    "dbo.GET_TIPO_PERIODO(carreras.Carrera_Periodo_Tipo_Id) AS TIPO_PERIODO, 'SEMESTRE' AS PERIODO ,  alumno_matricula AS MATRICULA, dbo.GET_REGULAR(alumno_matricula) AS REGULAR, dbo.GET_GRADO(carrera_aspira) AS GRADO_ACADEMICO, " +
                    "'1' AS VULNERABILIDAD, dbo.GET_SUBSEDE(aspirante_plantel) AS SUBSEDE " +
                    "FROM ASPIRANTES, CARRERAS " +
                    "WHERE carrera_aspira = Carrera_id AND (carrera_aspira = '002' OR carrera_aspira = '164' OR carrera_aspira = '165' OR carrera_aspira = '174' OR carrera_aspira = '153')" +
                    "ORDER BY CLAVE_CARRERA, alumno_matricula;";
            
            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);
                mycomand.CommandTimeout = 120000;

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                dataReporteBecas = new DataTable();
                daCats.Fill(dataReporteBecas);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return dataReporteBecas;
        }

        public static double GetPromedioGeneralAlumno(string matricula, string carrera)
        {
            double promGen = 0.0;
            int cal = 0;
            int suma = 0;
            int cuentaCals = 0;
            string calstr;
            string materiaID;

            List<string> cals = new List<string>();
            List<string> materias = new List<string>();
            string matID = "";
            int index = -2;


            string query = $"SELECT * FROM DetActaEval, EncActaEval WHERE Acta_Eval_alumno_matricula = '{matricula}' AND DetActaEval.Acta_Eval_Id = EncActaEval.Acta_Eval_Id " +
                $"ORDER BY Acta_Eval_grupo_semestre, Acta_Eval_Materia_ID, Acta_Eval_grupo_tipo DESC;";
            DataTable DTcalificaciones;

            try
            {
                using (var myCommand = new SqlCommand(query, dbConn))
                {
                    using (var daCats = new SqlDataAdapter(myCommand))
                    {

                        DTcalificaciones = new DataTable();
                        daCats.Fill(DTcalificaciones);

                        if (DTcalificaciones.Rows.Count != 0)
                        {

                            foreach (DataRow drCal in DTcalificaciones.Rows)
                            {
                                calstr = drCal.ItemArray[3].ToString();
                                materiaID = drCal.ItemArray[9].ToString();
                                switch(calstr)
                                {
                                    case "NP":
                                    case "NA":
                                        matID = materias.Find(mid => mid.Equals(materiaID));
                                        index = materias.IndexOf(matID);
                                        if(index == -1)
                                        {
                                            cals.Add(calstr);
                                            materias.Add(materiaID);
                                        }
                                        else 
                                        {
                                            cals.RemoveAt(index);
                                            materias.RemoveAt(index);

                                            cals.Add(calstr);
                                            materias.Add(materiaID);
                                        }
                                        break;
                                    default:
                                        if (calstr != "")
                                        {
                                            matID = materias.Find(mid => mid.Equals(materiaID));
                                            index = materias.IndexOf(matID);
                                            if (index == -1)
                                            {
                                                cals.Add(calstr);
                                                materias.Add(materiaID);
                                            }
                                            else 
                                            { 
                                                if(calstr != "NP" && calstr != "NA")
                                                {
                                                    cals.RemoveAt(index);
                                                    materias.RemoveAt(index);

                                                    cals.Add(calstr);
                                                    materias.Add(materiaID);
                                                }

                                            }

                                        }
                                        break;
                                }
                               
                            }

                            foreach(string cali in cals)
                            {
                                switch (cali)
                                {
                                    case "NP":
                                        cal = 0;
                                        break;
                                    case "NA":
                                        if (carrera == "511300009")
                                        {
                                            cal = 7;
                                        }
                                        else
                                        {
                                            cal = 5;
                                        }
                                        break;
                                    default:
                                        if (cali == "")
                                        {
                                            cal = 0;
                                            cuentaCals--;
                                        }
                                        else
                                        {
                                            cal = int.Parse(cali);
                                        }
                                        break;
                                }

                                cuentaCals++;
                                suma += cal;
                            }

                            promGen = (double)suma / (double)cuentaCals;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }



            return promGen;
        }

        public static double GetPromedioUltimoGradoAlumno(string matricula, string carrera)
        {
            double promUG = 0.0;
            int cal = 0;
            int suma = 0;
            int cuentaCals = 0;
            string calstr;

            string query = $"SELECT cal FROM DetActaEval, EncActaEval\r\n\t\tWHERE Acta_Eval_alumno_matricula = '{matricula}' AND DetActaEval.Acta_Eval_Id = EncActaEval.Acta_Eval_Id\r\n\t\tAND Acta_Eval_grupo_semestre IN (SELECT max(Acta_Eval_grupo_semestre) FROM DetActaEval, EncActaEval\r\n\t\t\t\t\t\t\tWHERE Acta_Eval_alumno_matricula = '{matricula}' AND DetActaEval.Acta_Eval_Id = EncActaEval.Acta_Eval_Id)";
            DataTable DTcalificaciones;

            try
            {
                using (var myCommand = new SqlCommand(query, dbConn))
                {
                    using (var daCats = new SqlDataAdapter(myCommand)) 
                    { 
                        DTcalificaciones = new DataTable();
                        daCats.Fill(DTcalificaciones);

                        if (DTcalificaciones.Rows.Count != 0)
                        {


                            foreach (DataRow drCal in DTcalificaciones.Rows)
                            {
                                calstr = drCal.ItemArray[0].ToString();
                                switch (calstr)
                                {
                                    case "NP":
                                        cal = 0;
                                        break;
                                    case "NA":
                                        if (carrera == "511300009")
                                        {
                                            cal = 7;
                                        }
                                        else
                                        {
                                            cal = 5;
                                        }
                                        break;
                                    default:
                                        if (calstr == "")
                                        {
                                            cal = 0;
                                            cuentaCals--;
                                        }
                                        else
                                        {
                                            cal = int.Parse(calstr);
                                        }
                                        break;
                                }

                                cuentaCals++;
                                suma += cal;
                            }

                            promUG = (double)suma / (double)cuentaCals;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }



            return promUG;
        }

        public static int GetUltimoSemestre(string matricula)
        {
            string query;
            SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;

            query = $"SELECT max(Acta_Eval_grupo_semestre) FROM DetActaEval, EncActaEval\r\n\t\t\t\t\t\t\tWHERE Acta_Eval_alumno_matricula = '{matricula}' AND DetActaEval.Acta_Eval_Id = EncActaEval.Acta_Eval_Id";

            int infoQuery = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(query, dbConn);
                rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while ((rdr.Read()))
                    {
                        if(rdr.GetValue(0) != System.DBNull.Value)
                            infoQuery = rdr.GetInt16(0);
                    }
                }

                cmd = null/* TODO Change to default(_) if this is not a reference type */;
                rdr.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            // close connection
            finally
            {
            }


            return infoQuery;
        }

        public static RegistroBaja FindInBajas(string matricula)
        {
            string query;
            //SqlDataReader rdr = null/* TODO Change to default(_) if this is not a reference type */;

            query = $"SELECT * FROM BajasAlumnos WHERE matricula = '{matricula}'";

            RegistroBaja infoQuery = null;

            try
            {
                using (var cmd = new SqlCommand(query, dbConn))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                            infoQuery = new RegistroBaja();

                        while ((rdr.Read()))
                        {
                            infoQuery.Matricula = rdr.ToString();
                            infoQuery.FechaBaja = rdr.GetDateTime(1);
                            infoQuery.Observaciones = rdr.GetString(2);
                            infoQuery.FechaMaxReingreso = rdr.GetDateTime(3);
                            infoQuery.TipoBaja = rdr.GetString(4);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            
            finally
            {
            }


            return infoQuery;
        }


        public static DataTable GetDataFromTablesDB(string nameDB, string maestria, bool showNAS)
        {
            
            DataFromTablesFromDB = null;
            string query = "";

            if (!showNAS)
            {
                switch (maestria)
                {
                    case "273":

                    case "279":
                        query = @"SELECT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.TipoG, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                   datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As  CAL_LETRA, datos3.semestre,
                                                   datos3.materia_tipo
                              FROM
                                (SELECT DISTINCT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS TipoG, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacion b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";

                        break;
                    case "384":
                        query = @"SELECT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.TipoG, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                   datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As  CAL_LETRA, datos3.semestre,
                                                    datos3.materia_tipo
                              FROM
                                (SELECT DISTINCT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS TipoG, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacion b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";

                        break;
                    case "379":
                        query = @"SELECT DISTINCT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.Tipo, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                    datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) AS CAL_LETRA, datos3.semestre,
                                                    datos3.materia_tipo
                              FROM
                                (SELECT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS Tipo, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacionMEMS b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";
                        break;

                    case "316":
                    default:
                        query = @"SELECT DISTINCT datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, datos.TipoE, datos.Acta_Eval_Materia_ID,
		                                datos.Acta_Eval_grupo_id, datos.Materia_Nombre, CARRERAS_MATERIAS.creditos, datos.cal, datos.Cal_Letra, CARRERAS_MATERIAS.semestre,
                                        CARRERAS_MATERIAS.materia_tipo
                                FROM
                                (SELECT DISTINCT dbo.EncActaEval.Acta_Eval_grupo_plantel_id, dbo.EncActaEval.Acta_Eval_grupo_periodo_id,  
                                        dbo.GetTipoExamen2(dbo.EncActaEval.Acta_Eval_grupo_tipo) AS TipoE, dbo.EncActaEval.Acta_Eval_Materia_ID,
                                        dbo.EncActaEval.Acta_Eval_grupo_id, dbo.MATERIAS.Materia_Nombre, 
                                        dbo.DetActaEval.cal, dbo.GETCAL_LETRAS3(dbo.DetActaEval.cal) AS Cal_Letra
                                        FROM dbo.EncActaEval, dbo.DetActaEval, dbo.MATERIAS
                                        WHERE(dbo.EncActaEval.Acta_Eval_Id = dbo.DetActaEval.Acta_Eval_Id AND DetActaEval.cal <> 'NP' AND DetActaEval.cal <> 'NA')
                                        AND DetActaEval.Acta_Eval_alumno_matricula IN
                                        (SELECT DISTINCT DetActaEval.Acta_Eval_alumno_matricula FROM DetActaEval
                                        WHERE DetActaEval.Acta_Eval_alumno_matricula = '" + nameDB + @"') 
                                        AND dbo.MATERIAS.Materia_ID = EncActaEval.Acta_Eval_Materia_ID) datos, CARRERAS_MATERIAS
										WHERE datos.Acta_Eval_Materia_ID = CARRERAS_MATERIAS.Materia_Id
                                        ORDER BY CARRERAS_MATERIAS.semestre, Acta_Eval_Materia_ID;";
                        break;
                }
            }
            else 
            {
                switch (maestria)
                {
                    case "273":

                    case "279":
                        query = @"SELECT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.TipoG, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                   datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos , DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As  CAL_LETRA, datos3.semestre,
                                                datos3.materia_tipo
                              FROM
                                (SELECT DISTINCT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS TipoG, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacion b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";

                        break;
                    case "384":
                        query = @"SELECT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.TipoG, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                   datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos , DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) As  CAL_LETRA, datos3.semestre,
                                        datos3.materia_tipo
                              FROM
                                (SELECT DISTINCT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS TipoG, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacion b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' )) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";

                        break;
                    case "379":
                        query = @"SELECT DISTINCT datos3.Acta_Eval_grupo_plantel_id, datos3.Acta_Eval_grupo_periodo_id, datos3.Tipo, datos3.Acta_Eval_Materia_ID, datos3.Acta_Eval_grupo_id,
                                                    datos3.Materia_Nombre, datos3.Materia_Lic_Id, datos3.Materia_Mas_Id, datos3.creditos, DetActaEval.cal, dbo.GETCAL_LETRAS3(DetActaEval.cal) AS CAL_LETRA, datos3.semestre,
                                                    datos3.materia_tipo
                              FROM
                                (SELECT datos2.*, CARRERAS_MATERIAS.creditos, CARRERAS_MATERIAS.semestre, CARRERAS_MATERIAS.materia_tipo
                                 FROM
                                   (SELECT DISTINCT datos.Acta_Eval_Id, datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, dbo.GetTipoExamen2(datos.Acta_Eval_grupo_tipo) AS Tipo, datos.Acta_Eval_Materia_ID, datos.Acta_Eval_grupo_id,
                                                    Materias.Materia_Nombre, datos.Materia_Lic_Id, datos.Materia_Mas_Id
                                    FROM(SELECT b1.Acta_Eval_Id, b1.Acta_Eval_grupo_id, b1.Acta_Eval_grupo_plantel_id, b1.Acta_Eval_grupo_periodo_id, b1.Acta_Eval_Materia_ID, b1.Acta_Eval_grupo_tipo, b1.Acta_Eval_grupo_semestre,
                                                b2.Materia_Lic_Id, b2.Materia_Mas_Id, b2.Tipo
                                         FROM dbo.EncActaEval b1
                                         LEFT JOIN dbo.PrimeraEspecializacionMEMS b2
                                         ON(b1.Acta_Eval_Materia_ID = b2.Materia_Lic_Id)
                                         WHERE b1.Acta_Eval_Id IN
                                             (SELECT dbo.DetActaEval.Acta_Eval_Id 
                                              FROM DetActaEval
                                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"')) datos, MATERIAS
                                    WHERE MATERIAS.Materia_ID = datos.Acta_Eval_Materia_ID) datos2, CARRERAS_MATERIAS
                                WHERE CARRERAS_MATERIAS.Materia_Id = datos2.Acta_Eval_Materia_ID) datos3, DetActaEval
                              WHERE Acta_Eval_alumno_matricula = '" + nameDB + @"' AND datos3.Acta_Eval_Id = DetActaEval.Acta_Eval_Id
                              ORDER BY datos3.semestre, Acta_Eval_Materia_ID;";
                        break;

                    case "316":
                    default:
                        query = @"SELECT DISTINCT datos.Acta_Eval_grupo_plantel_id, datos.Acta_Eval_grupo_periodo_id, datos.TipoE, datos.Acta_Eval_Materia_ID,
		                                datos.Acta_Eval_grupo_id, datos.Materia_Nombre, CARRERAS_MATERIAS.creditos, datos.cal, datos.Cal_Letra, CARRERAS_MATERIAS.semestre,
                                        CARRERAS_MATERIAS.materia_tipo
                                FROM
                                (SELECT DISTINCT dbo.EncActaEval.Acta_Eval_grupo_plantel_id, dbo.EncActaEval.Acta_Eval_grupo_periodo_id,  
                                        dbo.GetTipoExamen2(dbo.EncActaEval.Acta_Eval_grupo_tipo) AS TipoE, dbo.EncActaEval.Acta_Eval_Materia_ID,
                                        dbo.EncActaEval.Acta_Eval_grupo_id, dbo.MATERIAS.Materia_Nombre, 
                                        dbo.DetActaEval.cal, dbo.GETCAL_LETRAS3(dbo.DetActaEval.cal) AS Cal_Letra
                                        FROM dbo.EncActaEval, dbo.DetActaEval, dbo.MATERIAS
                                        WHERE(dbo.EncActaEval.Acta_Eval_Id = dbo.DetActaEval.Acta_Eval_Id)
                                        AND DetActaEval.Acta_Eval_alumno_matricula IN
                                        (SELECT DISTINCT DetActaEval.Acta_Eval_alumno_matricula FROM DetActaEval
                                        WHERE DetActaEval.Acta_Eval_alumno_matricula = '" + nameDB + @"') 
                                        AND dbo.MATERIAS.Materia_ID = EncActaEval.Acta_Eval_Materia_ID) datos, CARRERAS_MATERIAS
										WHERE datos.Acta_Eval_Materia_ID = CARRERAS_MATERIAS.Materia_Id
                                        ORDER BY CARRERAS_MATERIAS.semestre, Acta_Eval_Materia_ID;";
                        break;
                }
            }

            try
            {
                SqlCommand mycomand = new SqlCommand(query, dbConn);

                SqlDataAdapter daCats = new SqlDataAdapter(mycomand);
                
                DataFromTablesFromDB = new DataTable();

                daCats.Fill(DataFromTablesFromDB);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            return DataFromTablesFromDB;
        }


        public static List<string> ConvertDTtoList(DataTable dt)
        {
            List<string> cadenas = new List<string>();
            var result = (from rw in dt.AsEnumerable()
                          select new
                          {
                              Database = Convert.ToString(rw[0]),
                          }).ToList();

            result.ConvertAll<object>(o => (object)o);

            foreach (object obj in result)
            {
                string cadena = obj.ToString();
                cadenas.Add(cadena.Substring(13, cadena.Length - 15));
            }

            return cadenas;
        }
    }
}
