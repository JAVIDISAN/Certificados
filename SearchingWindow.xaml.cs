using AccesoBD.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace AccesoBD
{
    /// <summary>
    /// Lógica de interacción para SearchingWindow.xaml
    /// </summary>
    public partial class SearchingWindow : Window
    {
        MainWindow _mainWindow = null;

        public SearchingWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtAlumnos = DBManager.BuscaNombre(txtPorNombre.Text, txtPorApePaterno.Text, txtPorApeMaterno.Text);

            dgAlumnos.ItemsSource = dtAlumnos.DefaultView;


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Aspirante alumnoSelected;

        private void dgAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAlumnos.SelectedItem != null)
            {
                if (dgAlumnos.SelectedItem.ToString() != "{NewItemPlaceholder}")
                {

                    alumnoSelected = new Aspirante();
                        
                    DataRowView registroSel = (DataRowView) dgAlumnos.SelectedItem;

                    alumnoSelected.AlumnoMatricula =  registroSel.Row.ItemArray[0].ToString();
                    alumnoSelected.AspirantePlantel = registroSel.Row.ItemArray[1].ToString();
                    alumnoSelected.AspiranteNombre = registroSel.Row.ItemArray[2].ToString();
                    alumnoSelected.AspiranteApe1 = registroSel.Row.ItemArray[3].ToString();
                    alumnoSelected.AspiranteApe2 = registroSel.Row.ItemArray[4].ToString();
                    alumnoSelected.CarreraAspira = registroSel.Row.ItemArray[5].ToString();

                    if (alumnoSelected != null)
                    {
                        _mainWindow.AspiranteSel = alumnoSelected;
                    }
                    else
                    {
                        _mainWindow.AspiranteSel = null;
                    }
                }
                
            }
        }
    }
}
