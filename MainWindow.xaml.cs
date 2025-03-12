using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Windows.Media.TextFormatting;
using System.Data;
using AccesoBD.Models;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Imaging;
using static System.Windows.Forms.LinkLabel;

//311242F72724MEMST 21978122 0 9
//311242F66437MST   21978122 0 9

namespace AccesoBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        SearchingWindow searchWin;

        private Aspirante aspiranteSel;
        public Aspirante AspiranteSel { get => aspiranteSel; set => aspiranteSel = value; }

        bool tieneNA = false;

        private int creditosCarrera = 0;

        int leftMatricula = 0;
        int topMatricula = 0;

        int leftUnidad = 0;
        int topUnidad = 0;

        int leftNombre = 0;
        int topNombre = 0;

        int leftNivel = 0;
        int topNivel = 0;

        int leftCarrera = 0;
        int topCarrera = 0;

        int leftCurp = 0;
        int topCurp = 0;

        int leftNumCertificado = 0;
        int topNumCertificado = 0;

        int leftFecha = 0;
        int topFecha = 0;

        int leftCreditos = 0;
        int topCreditos = 0;

        int leftNumMaterias = 0;
        int topNumMaterias = 0;

        int leftLeyendaPromedio = 0;
        int topLeyendaPromedio = 0;

        int leftPromedio = 0;
        int topPromedio = 0;

        int leftLeyendaTerminal = 0;
        int topLeyendaTerminal = 0;

        int leftDirector = 0;
        int topDirector = 0;

        //Materias
        int margenIzq = 0;
        int margenTop = 0;
        int esp12 = 0;
        int esp23 = 0;
        int esp34 = 0;
        int esp45 = 0;
        int esp56 = 0;
        int esp67 = 0;
        int esp78 = 0;
        int esp89 = 0;
        int DGV_ALTOV = 0;

        string fuenteSel = "";
        int fuenteTam = 0;

        int letrasMaterias = 0;
        int numAsteriscos = 0;



        public MainWindow()
        {
            InitializeComponent();
            GetMarEsp();
            
        }

        private void GetMarEsp()
        {
            // Read file using StreamReader. Reads file line by line
            using (StreamReader file = new StreamReader("marg_esp.dat"))
            {
                string[] ln;
                ln = file.ReadLine().Split('=');
                leftMatricula = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topMatricula = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftUnidad = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topUnidad = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftNombre = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topNombre = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftNivel = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topNivel = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftCarrera = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topCarrera = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftCurp = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topCurp = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftNumCertificado = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topNumCertificado = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftFecha = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topFecha = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftCreditos = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topCreditos = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftNumMaterias = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topNumMaterias = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftLeyendaPromedio = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topLeyendaPromedio = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftPromedio = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topPromedio = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftLeyendaTerminal = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topLeyendaTerminal = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                leftDirector = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                topDirector = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                margenIzq = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                margenTop = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                esp12 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp23 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp34 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp45 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp56 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp67 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp78 = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                esp89 = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                DGV_ALTOV = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                fuenteSel = ln[1];
                ln = file.ReadLine().Split('=');
                fuenteTam = int.Parse(ln[1]);

                ln = file.ReadLine().Split('=');
                letrasMaterias = int.Parse(ln[1]);
                ln = file.ReadLine().Split('=');
                numAsteriscos = int.Parse(ln[1]);

                file.Close();
            }
        }

        string content;
        string[] datos;
        bool chNAs = false;
        private void btnNombreBD_Click(object sender, RoutedEventArgs e)
        {
            content = cmbNombreBD.Text;
            string[] masdatos = null;
            //if (content != null)
            List<MateriasParaPromedio> califs = new System.Collections.Generic.List<MateriasParaPromedio>();


            datos = DBManager.GetPlantel(content);

            if (datos[0] == null)
            {
                System.Windows.MessageBox.Show("Alumno no encontrado en la base de datos");
                return;
            }

            //comentario para checar los cambios en git

            if (datos.Length > 0 )
            {
                if (datos[5] == "379" || datos[5] == "316" || datos[5] == "384" || datos[5] == "279" || datos[5] == "273" )
                {
                    cmbNivel.SelectedIndex = 1;
                }
                else
                {
                    cmbNivel.SelectedIndex = 0;
                }

                creditosCarrera = int.Parse(datos[7]);
                txtPlantelAlumno.Text = "311 MERIDA";

                

                if (chkNAS.IsChecked == true)
                {
                    chNAs = true;


                    DataTable rawData = DBManager.GetDataFromTablesDB(content, datos[5], chNAs).AsEnumerable()
                                        .GroupBy(row => row.Field<string>("Acta_Eval_Materia_ID"))
                                        .Select(grp => grp.Last()).CopyToDataTable();

                    dgAccesoBD.ItemsSource = rawData.DefaultView;
                }
                else
                {
                    chNAs = false;

                    dgAccesoBD.ItemsSource = DBManager.GetDataFromTablesDB(content, datos[5], chNAs).DefaultView;
                }

                califs = DBManager.GetPromedioFinal(content, datos[5],chNAs);
                

                txtNombreAlumno.Text = $"{datos[2]} {datos[3]} {datos[1]}";

                txtCURPAlumno.Text = datos[4];

                txtCarreraAlumno.Text = $"{datos[5]} {datos[6]}";
            }
            //19971751
            int credTot = 0;
            float promeFin = 0.0f;
            float suma = 0.0f;
            foreach (MateriasParaPromedio matProm in califs)
            {
                credTot += matProm.Creditos;
                if (matProm.CaliLetra == "A")
                {
                    matProm.CaliLetra = "10";
                }

                if (matProm.CaliLetra == "NP" || matProm.CaliLetra == "NA")
                {
                    matProm.CaliLetra = "0";
                    tieneNA = true;
                }


                suma += int.Parse(matProm.CaliLetra);

            }

            promeFin = suma / califs.Count;

            //if (masdatos != null)
            //{
            txtMaterias.Text = califs.Count.ToString();
            txtCreditosTotales.Text = credTot.ToString();
            txtPromedioFinal.Text = promeFin.ToString("#.00");
            //}

        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            DBManager.Initialize();
            CargarImpresoras();
            //MessageBox.Show("Hola Mundo","Aviso",MessageBoxButton.OK);
            cmbNivel.ItemsSource = DBManager.GetNiveles("").DefaultView;
            cmbNivel.DisplayMemberPath = "nombre_nivel";
            cmbNivel.SelectedIndex = 0;

            dtpFechaEmision.SelectedDate = DateTime.Now;

            List<string> fuentes = new List<string>();

            foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
            {
                fuentes.Add(font.Name);
            }

            cmbFonts.ItemsSource = fuentes;
            cmbFonts.SelectedItem = fuenteSel;

            List<string> fuentesTamaño = new List<string>();

            fuentesTamaño.Add("8");
            fuentesTamaño.Add("9");
            fuentesTamaño.Add("10");
            fuentesTamaño.Add("11");
            fuentesTamaño.Add("12");
            fuentesTamaño.Add("13");
            fuentesTamaño.Add("14");
            fuentesTamaño.Add("15");
            fuentesTamaño.Add("16");
            fuentesTamaño.Add("17");
            fuentesTamaño.Add("18");
            fuentesTamaño.Add("19");
            fuentesTamaño.Add("20");
            fuentesTamaño.Add("21");
            fuentesTamaño.Add("22");
            fuentesTamaño.Add("23");
            fuentesTamaño.Add("24");

            cmbFonts.ItemsSource = fuentes;
            cmbFontSize.ItemsSource = fuentesTamaño;
            cmbFontSize.SelectedItem = fuenteTam.ToString();

        }

        private void CargarImpresoras()
        {
            try
            {
                foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cmbPrinter.Items.Add(item);
                }

                cmbPrinter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbNombreTabla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public IEnumerable<System.Windows.Controls.DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as System.Windows.Controls.DataGridRow;
                if (null != row) yield return row;
            }
        }

        public static readonly DependencyProperty MyFontFamilyProperty =
        DependencyProperty.Register("MyFontFamily",
        typeof(System.Drawing.FontFamily), typeof(MainWindow), new UIPropertyMetadata(null));

       
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            DataTable rawData = null;

            List<string> datosGrid = null; //DBManager.ConvertDTtoList(DBManager.DataFromTablesFromDB);

            if (chkNAS.IsChecked == true)
            {
                chNAs = true;


                 rawData = DBManager.GetDataFromTablesDB(content, datos[5], chNAs).AsEnumerable()
                                        .GroupBy(row => row.Field<string>("Acta_Eval_Materia_ID"))
                                        .Select(grp => grp.Last())
                                        .CopyToDataTable();

                datosGrid = DBManager.ConvertDTtoList(rawData);
            }
            else
            {
                rawData = DBManager.DataFromTablesFromDB;

                datosGrid = DBManager.ConvertDTtoList(rawData);
            }



            string materiaNombre = "";
            
            PrintDocument doc = new PrintDocument();
            //PaperKind ppk = new PaperKind();
            //ppk = new PaperKind();
            //ppk = PaperKind.A4;

            doc.DefaultPageSettings.Landscape = false;
            //doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter",816, 1056);
            doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
            //doc.DefaultPageSettings.PaperSize.RawKind = (int)ppk;
            //doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            //doc.PrinterSettings.PrinterName = "EPSON L555 Series";
            if (cmbPrinter.Text != "")
            {
                doc.PrinterSettings.PrinterName = cmbPrinter.Text;
            }
            else
            {
                System.Windows.MessageBox.Show("Seleccione una impresora");
                return;
            }

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                int ancho = ep.PageBounds.Width;
                int alto = ep.PageBounds.Height;


                 int DGV_ALTO = DGV_ALTOV;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                left = leftMatricula;
                top = topMatricula;
                ep.Graphics.DrawString(cmbNombreBD.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftUnidad;
                top = topUnidad;
                ep.Graphics.DrawString(txtPlantelAlumno.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftNombre;
                top = topNombre;
                ep.Graphics.DrawString(txtNombreAlumno.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftNivel;
                top = topNivel;
                ep.Graphics.DrawString(cmbNivel.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftCurp;
                top = topCurp;
                ep.Graphics.DrawString($"CURP: {txtCURPAlumno.Text}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftCarrera;
                top = topCarrera;
                ep.Graphics.DrawString(txtCarreraAlumno.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftFecha;
                top = topFecha;
                ep.Graphics.DrawString(dtpFechaEmision.SelectedDate.Value.ToString("dd/MM/yyyy"), new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftNumCertificado;
                top = topNumCertificado;
                ep.Graphics.DrawString(txtNumCertificado.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);

                
                top = margenTop;

                object[] elementos = new object[9];
 
                int countRow = 0;
                foreach (System.Data.DataRow row in rawData.Rows)//DBManager.DataFromTablesFromDB.Rows)
                {
                    if (countRow == DBManager.DataFromTablesFromDB.Rows.Count + 1) break;
                    left = margenIzq;
                    int countCol = 0;

                    if(row.ItemArray.Count() == 13)
                    {
                        elementos[0] = (object)"311";
                        elementos[1] = row.ItemArray[1];
                        elementos[2] = row.ItemArray[2];
                        if (row.ItemArray[7] != System.DBNull.Value)
                            elementos[3] = row.ItemArray[7];
                        else
                            elementos[3] = row.ItemArray[3];
                        elementos[4] = row.ItemArray[4];
                        elementos[5] = row.ItemArray[5];
                        elementos[6] = row.ItemArray[8];
                        elementos[7] = row.ItemArray[9];
                        elementos[8] = row.ItemArray[10];
                    }
                    else if(row.ItemArray.Count() == 11)
                    {
                        elementos[0] = (object)"311";
                        elementos[1] = row.ItemArray[1];
                        elementos[2] = row.ItemArray[2];
                        elementos[3] = row.ItemArray[3];
                        elementos[4] = row.ItemArray[4];
                        elementos[5] = row.ItemArray[5];
                        elementos[6] = row.ItemArray[6];
                        elementos[7] = row.ItemArray[7];
                        elementos[8] = row.ItemArray[8];
                    }

                    if (chkFolioActa.IsChecked == false)
                    {
                        foreach (object item in elementos)
                        {
                            if (countCol == 9)
                                break;

                            materiaNombre = Convert.ToString(item);
                            if (materiaNombre.Length >= letrasMaterias)
                                materiaNombre = materiaNombre.Substring(0, letrasMaterias);
                            ep.Graphics.DrawString(materiaNombre, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);

                            switch (countCol)
                            {
                                case 0:
                                    left += esp12;
                                    break;
                                case 1:
                                    left += esp23;
                                    break;
                                case 2:
                                    left += esp34;
                                    break;
                                case 3:
                                    left += esp45;
                                    break;
                                case 4:
                                    left += esp56;
                                    break;
                                case 5:
                                    left += esp67;
                                    break;
                                case 6:
                                    left += esp78;
                                    break;
                                case 7:
                                    left += esp89;
                                    break;


                            }



                            countCol++;
                        }
                        top += DGV_ALTO + 1;
                        //ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                        countRow++;
                    }
                    else
                    {
                        foreach (object item in elementos)
                        {
                            if (countCol == 9)
                                break;

                            materiaNombre = Convert.ToString(item);
                            if (materiaNombre.Length >= letrasMaterias)
                                materiaNombre = materiaNombre.Substring(0, letrasMaterias);
                            ep.Graphics.DrawString(materiaNombre, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);

                            switch (countCol)
                            {
                                case 0:
                                    left += 20;
                                    break;
                                case 1:
                                    left += 20;
                                    break;
                                case 2:
                                    left += 6;
                                    break;
                                case 3:
                                    left += 26;
                                    break;
                                case 4:
                                    left += esp56;
                                    break;
                                case 5:
                                    left += esp67;
                                    break;
                                case 6:
                                    left += esp78;
                                    break;
                                case 7:
                                    left += esp89;
                                    break;


                            }



                            countCol++;
                        }
                        top += DGV_ALTO + 1;
                        //ep.Graphics.DrawLine(Pens.Gray, ep.MarginBounds.Left, top, ep.MarginBounds.Right, top);
                        countRow++;
                    }
                }

                switch(numAsteriscos)
                {
                    case 90:
                        ep.Graphics.DrawString("******************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 91:
                        ep.Graphics.DrawString("*******************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 92:
                        ep.Graphics.DrawString("********************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 93:
                        ep.Graphics.DrawString("*********************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 94:
                        ep.Graphics.DrawString("**********************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 95:
                        ep.Graphics.DrawString("***********************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 96:
                        ep.Graphics.DrawString("************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 97:
                        ep.Graphics.DrawString("*************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 98:
                        ep.Graphics.DrawString("**************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 99:
                        ep.Graphics.DrawString("***************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 100:
                        ep.Graphics.DrawString("****************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 101:
                        ep.Graphics.DrawString("*****************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 102:
                        ep.Graphics.DrawString("******************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 103:
                        ep.Graphics.DrawString("*******************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 104:
                        ep.Graphics.DrawString("********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 105:
                        ep.Graphics.DrawString("*********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 106:
                        ep.Graphics.DrawString("**********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 107:
                        ep.Graphics.DrawString("***********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 108:
                        ep.Graphics.DrawString("************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 109:
                        ep.Graphics.DrawString("*************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 110:
                        ep.Graphics.DrawString("**************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 111:
                        ep.Graphics.DrawString("******************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 112:
                        ep.Graphics.DrawString("*******************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 113:
                        ep.Graphics.DrawString("********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 114:
                        ep.Graphics.DrawString("*********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 115:
                        ep.Graphics.DrawString("**********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 116:
                        ep.Graphics.DrawString("***********************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 117:
                        ep.Graphics.DrawString("************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 118:
                        ep.Graphics.DrawString("*************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 119:
                        ep.Graphics.DrawString("**************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 120:
                        ep.Graphics.DrawString("***************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 121:
                        ep.Graphics.DrawString("****************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 122:
                        ep.Graphics.DrawString("*****************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 123:
                        ep.Graphics.DrawString("******************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 124:
                        ep.Graphics.DrawString("*******************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 125:
                        ep.Graphics.DrawString("********************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 126:
                        ep.Graphics.DrawString("*********************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 127:
                        ep.Graphics.DrawString("**********************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 128:
                        ep.Graphics.DrawString("***********************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 129:
                        ep.Graphics.DrawString("************************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    case 130:
                        ep.Graphics.DrawString("*************************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                    default:
                        ep.Graphics.DrawString("**************************************************************************************************************************", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, 30, top);
                        break;
                }

                
                
                if(txtCarreraAlumno.Text.Contains("Licenciatura en Intervención Educativa"))
                {
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black,300, top +20, 255, 90);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black,385, top + 20, 85, 90);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black,300, top + 45, 255, 40); //875
                    ep.Graphics.DrawString("Calificación", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 310, top + 25); //855
                    ep.Graphics.DrawString("Significado", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 390, top + 25);
                    ep.Graphics.DrawString("10", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 45); //875
                    ep.Graphics.DrawString("9", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 57); //887
                    ep.Graphics.DrawString("8", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 69);//899
                    ep.Graphics.DrawString("7", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 87);//917
                    ep.Graphics.DrawString("Excelente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 45); //875
                    ep.Graphics.DrawString("Muy Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 57);
                    ep.Graphics.DrawString("Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 69);
                    ep.Graphics.DrawString("No suficiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 87);
                    ep.Graphics.DrawString("Calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 470, top + 46);
                    ep.Graphics.DrawString("Aprobatorias", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 470, top + 64);
                    
                    ep.Graphics.DrawString("Para la Licenciatura en", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 42);//872
                    ep.Graphics.DrawString("Intervención Educativa la", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 54); //872
                    ep.Graphics.DrawString("escala de calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 66); //872
                    ep.Graphics.DrawString("es la siguiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 78); //872
                }

                if (txtCarreraAlumno.Text.Contains("316"))
                {
                    left = leftNumMaterias - 70;
                    top = topNumMaterias - 110;

                    int credTott = int.Parse(txtCreditosTotales.Text);

                    ep.Graphics.DrawString("EL TOTAL DE CRÉDITOS QUE INTEGRA EL", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, left, top + 25); //855
                    ep.Graphics.DrawString("PLAN DE ESTUDIOS ES: 92; CORRESPONDEN A", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, left, top + 37);
                    ep.Graphics.DrawString("CURSOS 72; CORRESPONDEN AL TRABAJO;", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, left, top + 49); //875
                    ep.Graphics.DrawString($"FINAL 20. EL ALUMNO HA ACREDITADO {credTott}", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, left, top + 61); //887
                    ep.Graphics.DrawString($"RESTANDOLE {92-credTott} PARA SER EGRESADO.", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, left, top + 73);//899
                }


                if (txtCarreraAlumno.Text.Contains("384") && chkAntiguo.IsChecked == true) 
                {
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 340, 255, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 435, top + 340, 85, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 365, 255, 52); //875
                    ep.Graphics.DrawString("Calificación", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 360, top + 345); //855
                    ep.Graphics.DrawString("Significado", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 440, top + 345);
                    ep.Graphics.DrawString("10", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 365); //875
                    ep.Graphics.DrawString("9", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 377); //887
                    ep.Graphics.DrawString("8", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 389);//899
                    ep.Graphics.DrawString("7", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 401);//917
                    ep.Graphics.DrawString("6", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 423);//917
                    ep.Graphics.DrawString("Excelente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 365); //875
                    ep.Graphics.DrawString("Muy Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 377);
                    ep.Graphics.DrawString("Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 389);
                    ep.Graphics.DrawString("Regular", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 401);
                    ep.Graphics.DrawString("No suficiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 423);
                    ep.Graphics.DrawString("Calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 370);
                    ep.Graphics.DrawString("Aprobatorias", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 388);

                    ep.Graphics.DrawString("PARA LA MAESTRÍA EN", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 362);//872
                    ep.Graphics.DrawString("EDUCACIÓN BÁSICA LA", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 374); //872
                    ep.Graphics.DrawString("ESCALA DE CALIFICACIONES", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 386); //872
                    ep.Graphics.DrawString("ES LA SIGUIENTE", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 398); //872

                   // ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 300, top + 20, 255, 100);
                    //ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 385, top + 20, 85, 100);
                    //ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 300, top + 45, 255, 52); //875
                    //ep.Graphics.DrawString("Calificación", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 310, top + 25); //855
                    //ep.Graphics.DrawString("Significado", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 390, top + 25);
                    //ep.Graphics.DrawString("10", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 45); //875
                    //ep.Graphics.DrawString("9", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 57); //887
                    //ep.Graphics.DrawString("8", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 69);//899
                    //ep.Graphics.DrawString("7", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 81);//917
                    //ep.Graphics.DrawString("6", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 335, top + 103);//917
                    //ep.Graphics.DrawString("Excelente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 45); //875
                    //ep.Graphics.DrawString("Muy Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 57);
                    //ep.Graphics.DrawString("Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 69);
                    //ep.Graphics.DrawString("Regular", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 81);
                    //ep.Graphics.DrawString("No suficiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 387, top + 103);
                    //ep.Graphics.DrawString("Calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 473, top + 50);
                    //ep.Graphics.DrawString("Aprobatorias", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 473, top + 68);

                    //ep.Graphics.DrawString("PARA LA MAESTRÍA EN", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 42);//872
                   // ep.Graphics.DrawString("EDUCACIÓN BáSICA LA", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 54); //872
                    //ep.Graphics.DrawString("ESCALA DE CALIFICACIONES", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 66); //872
                    //ep.Graphics.DrawString("ES LA SIGUIENTE", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 78); //872

                }

                if (txtCarreraAlumno.Text.Contains("379") && chkAntiguo.IsChecked == true)
                {
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 340, 255, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 435, top + 340, 85, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 365, 255, 52); //875
                    ep.Graphics.DrawString("Calificación", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 360, top + 345); //855
                    ep.Graphics.DrawString("Significado", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 440, top + 345);
                    ep.Graphics.DrawString("10", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 365); //875
                    ep.Graphics.DrawString("9", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 377); //887
                    ep.Graphics.DrawString("8", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 389);//899
                    ep.Graphics.DrawString("7", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 401);//917
                    ep.Graphics.DrawString("6", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 423);//917
                    ep.Graphics.DrawString("Excelente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 365); //875
                    ep.Graphics.DrawString("Muy Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 377);
                    ep.Graphics.DrawString("Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 389);
                    ep.Graphics.DrawString("Regular", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 401);
                    ep.Graphics.DrawString("No suficiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top +423);
                    ep.Graphics.DrawString("Calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 370);
                    ep.Graphics.DrawString("Aprobatorias", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 388);

                    ep.Graphics.DrawString("PARA LA MAESTRÍA EN", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 362);//872
                    ep.Graphics.DrawString("EDUCACIÓN MEDIA SUPERIOR LA", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 374); //872
                    ep.Graphics.DrawString("ESCALA DE CALIFICACIONES", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 386); //872
                    ep.Graphics.DrawString("ES LA SIGUIENTE", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 398); //872

                }

                if (txtCarreraAlumno.Text.Contains("279") && chkAntiguo.IsChecked == true)
                {
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 340, 255, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 435, top + 340, 85, 100);
                    ep.Graphics.DrawRectangle(System.Drawing.Pens.Black, 350, top + 365, 255, 52); //875
                    ep.Graphics.DrawString("Calificación", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 360, top + 345); //855
                    ep.Graphics.DrawString("Significado", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 440, top + 345);
                    ep.Graphics.DrawString("10", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 365); //875
                    ep.Graphics.DrawString("9", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 377); //887
                    ep.Graphics.DrawString("8", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 389);//899
                    ep.Graphics.DrawString("7", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 401);//917
                    ep.Graphics.DrawString("6", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 385, top + 423);//917
                    ep.Graphics.DrawString("Excelente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 365); //875
                    ep.Graphics.DrawString("Muy Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 377);
                    ep.Graphics.DrawString("Bien", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 389);
                    ep.Graphics.DrawString("Regular", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 401);
                    ep.Graphics.DrawString("No suficiente", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 437, top + 423);
                    ep.Graphics.DrawString("Calificaciones", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 370);
                    ep.Graphics.DrawString("Aprobatorias", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 523, top + 388);

                    ep.Graphics.DrawString("PARA LA MAESTRÍA EN", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 362);//872
                    ep.Graphics.DrawString("EDUCACIÓN MEDIA SUPERIOR LA", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 374); //872
                    ep.Graphics.DrawString("ESCALA DE CALIFICACIONES", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 386); //872
                    ep.Graphics.DrawString("ES LA SIGUIENTE", new Font(cmbFonts.Text, 9), System.Drawing.Brushes.Black, 135, top + 398); //872

                }
                left = leftNumMaterias;
                top = topNumMaterias;
                ep.Graphics.DrawString(txtMaterias.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftCreditos;
                top = topCreditos;
                ep.Graphics.DrawString(txtCreditosTotales.Text, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftLeyendaPromedio;
                top = topLeyendaPromedio;
                ep.Graphics.DrawString($"UN PROMEDIO EN MATERIAS APROBADAS DE:", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftPromedio;
                top = topPromedio;
                ep.Graphics.DrawString($"{txtPromedioFinal.Text}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftLeyendaTerminal;
                top = topLeyendaTerminal;
                if(creditosCarrera > int.Parse(txtCreditosTotales.Text) || tieneNA)
                    ep.Graphics.DrawString("*****CERTIFICADO PARCIAL*****", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                else
                    ep.Graphics.DrawString("*****CERTIFICADO TERMINAL*****", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
                left = leftDirector;
                top = topDirector;
                ep.Graphics.DrawString("MTRO. JUAN RAMÓN\r\nMANZANILLA DORANTES", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, left, top);
               
               



            };
            ppd.ShowDialog();
        }

        private void btnUpMarIzq_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownMarIzq_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp12_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp23_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp34_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp45_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp45_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp56_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp56_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp67_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp67_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp78_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp78_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpEsp89_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDownEsp89_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void btnBuscaNombre_Click(object sender, RoutedEventArgs e)
        {
            string content = txtNombreAlumno.Text;

            searchWin = new SearchingWindow(this);
            
            searchWin.ShowDialog();

            if (aspiranteSel != null)
            {
                txtNombreAlumno.Text = $"{aspiranteSel.AspiranteNombre} {aspiranteSel.AspiranteApe1} {aspiranteSel.AspiranteApe2}";
                cmbNombreBD.Text = aspiranteSel.AlumnoMatricula;
                txtPlantelAlumno.Text = aspiranteSel.AspirantePlantel;
            }
            
        }

        private void btnCarta_Click(object sender, RoutedEventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            //PaperKind ppk = new PaperKind();
            //ppk = new PaperKind();
            //ppk = PaperKind.A4;

            doc.DefaultPageSettings.Landscape = false;
            //doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter",816, 1056);
            doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
            //doc.DefaultPageSettings.PaperSize.RawKind = (int)ppk;
            //doc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            //doc.PrinterSettings.PrinterName = "EPSON L555 Series";
            if (cmbPrinter.Text != "")
            {
                doc.PrinterSettings.PrinterName = cmbPrinter.Text;
            }
            else
            {
                System.Windows.MessageBox.Show("Seleccione una impresora");
                return;
            }

            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                int ancho = ep.PageBounds.Width;
                int alto = ep.PageBounds.Height;
                int mitadH = ancho / 2;
                int mitadV = alto / 2;


                int DGV_ALTO = DGV_ALTOV;
                int left = ep.MarginBounds.Left, top = ep.MarginBounds.Top;

                string carreraId = txtCarreraAlumno.Text.Substring(0, 3);

                //ep.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), mitadH, 0, mitadH, 1000);
                //ep.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), 0, mitadV, 552, mitadV);


                System.Drawing.Image img = System.Drawing.Image.FromFile($"{System.Windows.Forms.Application.StartupPath}\\escudo_yucatan.jpg");
                ep.Graphics.DrawImage(img, 30.0f, 40.0f, 120.0f, 120.0f);
                System.Drawing.Image img2 = System.Drawing.Image.FromFile($"{System.Windows.Forms.Application.StartupPath}\\706px-Logo_Upn_Oficial.png");
                ep.Graphics.DrawImage(img2, ancho - 175.0f, 40.0f, 115.0f, 105.0f);

                

                float anchoPalabra = ep.Graphics.MeasureString("GOBIERNO DEL ESTADO DE YUCATÁN", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("GOBIERNO DEL ESTADO DE YUCATÁN", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra/2), 40);
                anchoPalabra = ep.Graphics.MeasureString("SECRETARÍA DE INVESTIGACIÓN,", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("SECRETARÍA DE INVESTIGACIÓN,", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 60);
                anchoPalabra = ep.Graphics.MeasureString("INNOVACIÓN Y EDUCACIÓN SUPERIOR", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("INNOVACIÓN Y EDUCACIÓN SUPERIOR", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 80);
                anchoPalabra = ep.Graphics.MeasureString("UNIVERSIDAD PEDAGÓGICA NACIONAL", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("UNIVERSIDAD PEDAGÓGICA NACIONAL", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.DarkBlue, mitadH - (anchoPalabra / 2), 100);
                anchoPalabra = ep.Graphics.MeasureString("UNIDAD 31-A", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("UNIDAD 31-A", new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 120);

                if (carreraId == "153" || carreraId == "154" || carreraId == "164" || carreraId == "165" || carreraId == "174")
                {
                    mitadH += 60;
                }
                

                anchoPalabra = ep.Graphics.MeasureString("EXPIDE LA PRESENTE", new System.Drawing.Font("Times New Roman", 16, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("EXPIDE LA PRESENTE", new System.Drawing.Font("Times New Roman", 16, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 175);

                if (carreraId == "153" || carreraId == "154" || carreraId == "164" || carreraId == "165" || carreraId == "174")
                {
                    anchoPalabra = ep.Graphics.MeasureString("CARTA DE PASANTE", new System.Drawing.Font("Algerian", 40)).Width;
                    ep.Graphics.DrawString("CARTA DE PASANTE", new System.Drawing.Font("Algerian", 40), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 225);
                }
                else
                {
                    if (carreraId == "384" || carreraId == "316")
                    {
                        anchoPalabra = ep.Graphics.MeasureString("CONSTANCIA", new System.Drawing.Font("Algerian", 40)).Width;
                        ep.Graphics.DrawString("CONSTANCIA", new System.Drawing.Font("Algerian", 40), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 225);

                        //using (var src = new Bitmap)
                        //using (var png = new Bitmap(500, 400, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                        //using (var gr = Graphics.FromImage(png))
                        //{
                            System.Drawing.Image img3 = System.Drawing.Image.FromFile($"{System.Windows.Forms.Application.StartupPath}\\706px-Logo_Upn_Oficial_tr.png");
                            //ep.Graphics.Clear(System.Drawing.Color.Transparent);
                            ep.Graphics.DrawImage(img3, mitadH - 250.0f, mitadV - 200.0f, 500.0f, 400.0f);
                        //}
                    }
                    else 
                    {
                        anchoPalabra = ep.Graphics.MeasureString("DIPLOMA", new System.Drawing.Font("Algerian", 40)).Width;
                        ep.Graphics.DrawString("DIPLOMA", new System.Drawing.Font("Algerian", 40), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 225);

                        System.Drawing.Image img3 = System.Drawing.Image.FromFile($"{System.Windows.Forms.Application.StartupPath}\\706px-Logo_Upn_Oficial_tr.png");
                        //ep.Graphics.Clear(System.Drawing.Color.Transparent);
                        ep.Graphics.DrawImage(img3, mitadH - 250.0f, mitadV - 200.0f, 500.0f, 400.0f);
                    }
                }

                anchoPalabra = ep.Graphics.MeasureString($"A: {txtNombreAlumno.Text}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold)).Width;

                if(anchoPalabra >= 650)
                {
                    string[] nombres = txtNombreAlumno.Text.Split();
                    string nom1 = "", nom2 = "";

                    
                    switch(nombres.Length)
                    {
                        case 3:
                            nom1 = nombres[0];
                            nom2 = nombres[1] + " " + nombres[2];
                            break;
                        case 4:
                            nom1 = nombres[0] + " " + nombres[1];
                            nom2 = nombres[2] + " " + nombres[3];
                            break;
                        case 5:
                            nom1 = nombres[0] + " " + nombres[1];
                            nom2 = nombres[2] + " " + nombres[3] + " " + nombres[4];
                            break;
                        case 6:
                            nom1 = nombres[0] + " " + nombres[1] + " " + nombres[2];
                            nom2 = nombres[3] + " " + nombres[4] + " " + nombres[5];
                            break;
                        default:
                            nom1 = nombres[0];
                            nom2 = nombres[1];
                            break;

                    }


                    anchoPalabra = ep.Graphics.MeasureString($"A: {nom1}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold)).Width;
                    ep.Graphics.DrawString($"A: {nom1}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 315);
                    anchoPalabra = ep.Graphics.MeasureString($"{nom2}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold)).Width;
                    ep.Graphics.DrawString($"{nom2}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 345);

                }
                else
                {
                    ep.Graphics.DrawString($"A: {txtNombreAlumno.Text}", new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 330);
                }



                anchoPalabra = ep.Graphics.MeasureString($"todas las asignaturas correspondientes al Plan de Estudios", new System.Drawing.Font("Times New Roman", 16)).Width;
                //ep.Graphics.DrawString($"Por haber cursado y aprobado en el período {txtIniPeriodo.Text} - {txtFinPeriodo.Text}", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - 290, 410);
                DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)), 410, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, $"Por haber cursado y aprobado en el período {txtIniPeriodo.Text} - {txtFinPeriodo.Text}");
                if (carreraId == "153" || carreraId == "154" || carreraId == "164" || carreraId == "165" || carreraId == "174")
                {
                    //ep.Graphics.DrawString("todas las asignaturas correspondientes al Plan de Estudios", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - 290, 440);
                    DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)), 440, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, "todas las asignaturas correspondientes al Plan de Estudios");
                }
                else 
                {
                    //ep.Graphics.DrawString("las asignaturas correspondientes al Plan de Estudios", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - 290, 440);
                    DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)), 440, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, "las asignaturas correspondientes al Plan de Estudios");
                }

                ep.Graphics.DrawString("de la:", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black,mitadH - (anchoPalabra / 2), 470);


                string carrera = DBManager.GetCarrera(carreraId);
                string[] wordsCarrera = carrera.Split();

                switch (carreraId)
                {
                    case "153":
                        anchoPalabra = ep.Graphics.MeasureString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                        ep.Graphics.DrawString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                        break;

                    case "154":
                        anchoPalabra = ep.Graphics.MeasureString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                        ep.Graphics.DrawString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                        break;

                    case "164":
                    case "165":
                        if (wordsCarrera.Length == 8)
                        {
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[4]} {wordsCarrera[5]} {wordsCarrera[6]} {wordsCarrera[7]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[4]} {wordsCarrera[5]} {wordsCarrera[6]} {wordsCarrera[7]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                        }
                        else
                        {
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[4]} {wordsCarrera[5]} {wordsCarrera[6]} {wordsCarrera[7]} {wordsCarrera[8]} {wordsCarrera[9]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[4]} {wordsCarrera[5]} {wordsCarrera[6]} {wordsCarrera[7]} {wordsCarrera[8]} {wordsCarrera[9]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                        }
                        break;
                            

                    case "174":
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[0]} {wordsCarrera[1]} {wordsCarrera[2]} {wordsCarrera[3]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"{wordsCarrera[4]} {wordsCarrera[5]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"{wordsCarrera[4]} {wordsCarrera[5]}", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                            break;

                    case "273":
                            anchoPalabra = ep.Graphics.MeasureString($"ESPECIALIZACIÓN LÍNEA DE", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"ESPECIALIZACIÓN LÍNEA DE", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"COMPETENCIAS DOCENTES", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"COMPETENCIAS DOCENTES", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                            break;

                        case "279":
                            anchoPalabra = ep.Graphics.MeasureString($"Especialidad: Competencias Profesionales para la", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"Especialidad: Competencias Profesionales para la", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"Práctica Pedagógica en la Educación Básica.", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"Práctica Pedagógica en la Educación Básica.", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                            break;

                        case "316":
                            anchoPalabra = ep.Graphics.MeasureString($"Maestría en Educación,", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"Maestría en Educación,", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            anchoPalabra = ep.Graphics.MeasureString($"Campo: Desarrollo Curricular", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString($"Campo: Desarrollo Curricular", new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 550);
                            break;

                        case "379":
                            anchoPalabra = ep.Graphics.MeasureString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            break;

                        case "384":
                            anchoPalabra = ep.Graphics.MeasureString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text))).Width;
                            ep.Graphics.DrawString(carrera, new Font(cmbFonts.Text, int.Parse(cmbFontSize.Text)), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 520);
                            break;

                    }

                anchoPalabra = ep.Graphics.MeasureString($"todas las asignaturas correspondientes al Plan de Estudios", new System.Drawing.Font("Times New Roman", 16)).Width;
                DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)),600, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, $"Se extiende la presente en la ciudad de Mérida, estado de");
                //ep.Graphics.DrawString($"Se extiende la presente en la ciudad de Mérida, estado de", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - 290, 600);
                DateTime fechaExpide = DateTime.Now;
                DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)), 630, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, $"Yucatán, a los {Conversores.NumeroALetras(fechaExpide.Day)} días del mes de {Conversores.MesALetras(fechaExpide.Month)} del año");
                //ep.Graphics.DrawString($"Yucatán, a los {Conversores.NumeroALetras(fechaExpide.Day)} días del mes de {Conversores.MesALetras(fechaExpide.Month)} del año", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - 290, 630);
                //DrawJustifiedLine(ep.Graphics, new System.Drawing.Rectangle((int)(mitadH - (anchoPalabra / 2)), 660, (int)anchoPalabra, 30), new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, $"{Conversores.NumeroALetras(fechaExpide.Year)}.");
                ep.Graphics.DrawString($"{Conversores.NumeroALetras(fechaExpide.Year)}.", new System.Drawing.Font("Times New Roman", 16), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 660);

                anchoPalabra = ep.Graphics.MeasureString("A T E N T A M E N T E", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("A T E N T A M E N T E", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 770);
                anchoPalabra = ep.Graphics.MeasureString("\"EDUCAR PARA TRANSFORMAR\"", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("\"EDUCAR PARA TRANSFORMAR\"", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.DarkBlue, mitadH - (anchoPalabra / 2), 795);
                anchoPalabra = ep.Graphics.MeasureString("MTRO. JUAN RAMÓN MANZANILLA DORANTES", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("MTRO. JUAN RAMÓN MANZANILLA DORANTES", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 915);
                anchoPalabra = ep.Graphics.MeasureString("DIRECTOR DE LA UPN UNIDAD 31-A", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold)).Width;
                ep.Graphics.DrawString("DIRECTOR DE LA UPN UNIDAD 31-A", new System.Drawing.Font("Times New Roman", 14, System.Drawing.FontStyle.Bold), System.Drawing.Brushes.Black, mitadH - (anchoPalabra / 2), 940);
                


            };
            ppd.ShowDialog();
        }

        // Draw justified text on the Graphics object
        // in the indicated Rectangle.
        private void DrawJustifiedLine(Graphics gr, RectangleF rect,
            Font font, System.Drawing.Brush brush, string text)
        {
            // Break the text into words.
            string[] words = text.Split(' ');

            // Add a space to each word and get their lengths.
            float[] word_width = new float[words.Length];
            float total_width = 0;
            for (int i = 0; i < words.Length; i++)
            {
                // See how wide this word is.
                SizeF size = gr.MeasureString(words[i], font);
                word_width[i] = size.Width;
                total_width += word_width[i];
            }

            // Get the additional spacing between words.
            float extra_space = rect.Width - total_width;
            int num_spaces = words.Length - 1;
            if (words.Length > 1) extra_space /= num_spaces;

            // Draw the words.
            float x = rect.Left;
            float y = rect.Top;
            for (int i = 0; i < words.Length; i++)
            {
                // Draw the word.
                gr.DrawString(words[i], font, brush, x, y);

                // Move right to draw the next word.
                x += word_width[i] + extra_space;
            }
        }

        private void btnReporteBecas_Click(object sender, RoutedEventArgs e)
        {
            List<float> promediosGenerales = new List<float>();
            List<float> promediosGradoAnterior = new List<float>();

            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Reporte"; // Default file name
            dialog.DefaultExt = ".csv"; // Default file extension
            dialog.Filter = "CSV Files (.csv)|*.csv"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            DataTable dtReporteBecas = DBManager.GetReporteBecas();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dialog.FileName;

                
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(filename, false,Encoding.Unicode))
                    {
                        outputFile.WriteLine("CURP, NOMBRE_COMPLETO, CLAVE_PLANTEL, NOMBRE_PLANTEL, CLAVE_CARRERA, NOMBRE_CARRERA, TOTAL_PERIODOS, TIPO_PERIODO, PERIODO_ACTUAL, PROMEDIO_CICLO_ANTERIOR, PROMEDIO_GENERAL, MATRICULA, REGULAR, ESTATUS, GRADO_ACADEMICO, VULNERABILIDAD, SUBSEDE");
                        System.Diagnostics.Debug.Print(DateTime.Now.ToString());
                        foreach (DataRow drAlumno in dtReporteBecas.Rows)
                        {
                            double promGen = 0.0;
                            double promGA = 0.0;
                            string linea = "";

                            string curp;
                            string nombre_completo;
                            string clave_plantel;
                            string nombre_plantel;
                            string clave_carrera;
                            string nombre_carrera;
                            string total_periodos;
                            string tipo_periodo;
                            string periodo_actual;
                            string matricula;
                            string regular;
                            string estatus = "";
                            string grado;
                            string vulnerabilidad;
                            string subsede;

                            matricula = drAlumno["MATRICULA"].ToString();
                            curp = drAlumno["curp"].ToString();
                            nombre_completo = drAlumno["nombre_completo"].ToString();
                            clave_plantel = drAlumno["clave_plantel"].ToString();
                            nombre_plantel = drAlumno["nombre_plantel"].ToString();
                            clave_carrera = drAlumno["clave_carrera"].ToString();
                            nombre_carrera = drAlumno["nombre_carrera"].ToString();
                            total_periodos = drAlumno["periodos_duracion"].ToString();
                            tipo_periodo = drAlumno["tipo_periodo"].ToString();
                            promGen = DBManager.GetPromedioGeneralAlumno(matricula, drAlumno["CLAVE_CARRERA"].ToString());
                            promGA = DBManager.GetPromedioUltimoGradoAlumno(drAlumno["MATRICULA"].ToString(), drAlumno["CLAVE_CARRERA"].ToString());

                            int lastSemestre = DBManager.GetUltimoSemestre(drAlumno["MATRICULA"].ToString());

                            if (lastSemestre != 0)
                            {

                                if (lastSemestre < int.Parse(total_periodos))
                                {
                                    periodo_actual = (lastSemestre + 1).ToString();
                                    RegistroBaja rbXAlumno = DBManager.FindInBajas(drAlumno["MATRICULA"].ToString());

                                    if (rbXAlumno == null)
                                    {
                                        estatus = 1.ToString();
                                    }
                                    else
                                    {
                                        if (rbXAlumno.TipoBaja == "TEMPORAL")
                                        {
                                            if (rbXAlumno.FechaMaxReingreso.Year < DateTime.Now.Year)
                                            {
                                                estatus = 4.ToString();
                                            }
                                            else
                                            {
                                                estatus = 3.ToString();
                                            }
                                        }

                                        if (rbXAlumno.TipoBaja == "DEFINITIVA")
                                        {
                                            estatus = 4.ToString();
                                        }


                                    }

                                }
                                else
                                {
                                    periodo_actual = lastSemestre.ToString();
                                    estatus = 2.ToString();
                                }

                                
                                regular = drAlumno["REGULAR"].ToString();
                                grado = drAlumno["GRADO_ACADEMICO"].ToString();
                                vulnerabilidad = drAlumno["VULNERABILIDAD"].ToString();
                                subsede = drAlumno["SUBSEDE"].ToString();

                                if (Double.IsNaN(promGen) || Double.IsNaN(promGA))
                                {
                                    System.Diagnostics.Debug.Print($"{drAlumno["matricula"]} SIN MATERIAS");
                                }
                                else
                                {
                                    //System.Diagnostics.Debug.Print($"{drAlumno["matricula"]} {promGen} {promGA}");

                                    linea = $"{curp},{nombre_completo},{clave_plantel},{nombre_plantel}, {clave_carrera}, {nombre_carrera}, {total_periodos}, {tipo_periodo}, {periodo_actual}, {promGA}, {promGen}," +
                                        $" {matricula}, {regular}, {estatus} ,{grado}, {vulnerabilidad}, {subsede}";
                                    outputFile.WriteLine(linea);
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.Print("SIN MATERIAS");
                            }
                        }
                    }
                }
                finally
                {
                    Mouse.OverrideCursor = null;
                    System.Diagnostics.Debug.Print(DateTime.Now.ToString());
                }
            }
        }
    }
}



