using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoBD.Models
{
    public static class Conversores
    {
        public static string MesALetras(double _kmes)
        {
            string mes = "nada";

            switch(_kmes)
            {
                case 1:
                    mes = "enero";
                    break;
                case 2:
                    mes = "febrero";
                    break;
                case 3:
                    mes = "marzo";
                    break;
                case 4:
                    mes = "abril";
                    break;
                case 5:
                    mes = "mayo";
                    break;
                case 6:
                    mes = "junio";
                    break;
                case 7:
                    mes = "julio";
                    break;
                case 8:
                    mes = "agosto";
                    break;
                case 9:
                    mes = "septiembre";
                    break;
                case 100:
                    mes = "octubre";
                    break;
                case 11:
                    mes = "noviembre";
                    break;
                case 12:
                    mes = "diciembre";
                    break;

            }

            return mes;

        }


        public static string NumeroALetras(this decimal numberAsString)
        {
            string dec;

            var entero = Convert.ToInt64(Math.Truncate(numberAsString));
            //var decimales = Convert.ToInt32(Math.Round((numberAsString - entero) * 100, 2));
            //if (decimales > 0)
            //{
            //    //dec = " PESOS CON " + decimales.ToString() + "/100";
            //    dec = $" PESOS {decimales:0,0} /100";
            //}
            ////Código agregado por mí
            //else
            //{
            //    //dec = " PESOS CON " + decimales.ToString() + "/100";
            //    dec = $" PESOS {decimales:0,0} /100";
            //}
            var res = NumeroALetras(Convert.ToDouble(entero)); //+ dec;
            return res;
        }
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        private static string NumeroALetras(double value)
        {
            string num2Text; value = Math.Truncate(value);
            if (value == 0) num2Text = "cero";
            else if (value == 1) num2Text = "uno";
            else if (value == 2) num2Text = "dos";
            else if (value == 3) num2Text = "tres";
            else if (value == 4) num2Text = "cuatro";
            else if (value == 5) num2Text = "cinco";
            else if (value == 6) num2Text = "seis";
            else if (value == 7) num2Text = "siete";
            else if (value == 8) num2Text = "ocho";
            else if (value == 9) num2Text = "nueve";
            else if (value == 10) num2Text = "diez";
            else if (value == 11) num2Text = "once";
            else if (value == 12) num2Text = "doce";
            else if (value == 13) num2Text = "trece";
            else if (value == 14) num2Text = "catorce";
            else if (value == 15) num2Text = "quince";
            else if (value == 16) num2Text = "dieciéis";
            else if (value == 17) num2Text = "diecisiete";
            else if (value == 18) num2Text = "dieciocho";
            else if (value == 19) num2Text = "diecinueve";
            else if (value == 20) num2Text = "veinte";
            else if (value == 21) num2Text = "veintiuno";
            else if (value == 22) num2Text = "veintidos";
            else if (value == 23) num2Text = "veintitrés";
            else if (value == 24) num2Text = "veinticuatro";
            else if (value == 25) num2Text = "veinticinco";
            else if (value == 26) num2Text = "veintiséis";
            else if (value == 27) num2Text = "veintisiete"   ;
            else if (value == 28) num2Text = "veintiocho";
            else if (value == 29) num2Text = "veintinueve";
            else if (value == 30) num2Text = "treinta";
            else if (value == 31) num2Text = "treinta y un";
            else if (value == 40) num2Text = "CUARENTA";
            else if (value == 50) num2Text = "CINCUENTA";
            else if (value == 60) num2Text = "SESENTA";
            else if (value == 70) num2Text = "SETENTA";
            else if (value == 80) num2Text = "OCHENTA";
            else if (value == 90) num2Text = "NOVENTA";
            else if (value < 100) num2Text = NumeroALetras(Math.Truncate(value / 10) * 10) + " Y " + NumeroALetras(value % 10);
            else if (value == 100) num2Text = "CIEN";
            else if (value < 200) num2Text = "CIENTO " + NumeroALetras(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) num2Text = NumeroALetras(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) num2Text = "QUINIENTOS";
            else if (value == 700) num2Text = "SETECIENTOS";
            else if (value == 900) num2Text = "NOVECIENTOS";
            else if (value < 1000) num2Text = NumeroALetras(Math.Truncate(value / 100) * 100) + " " + NumeroALetras(value % 100);
            else if (value == 1000) num2Text = "mil";
            else if (value < 2000) num2Text = "mil " + NumeroALetras(value % 1000);
            else if (value < 1000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000)) + " mil";
                if ((value % 1000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value % 1000);
                }
            }
            else if (value == 1000000)
            {
                num2Text = "UN MILLON";
            }
            else if (value < 2000000)
            {
                num2Text = "UN MILLON " + NumeroALetras(value % 1000000);
            }
            else if (value < 1000000000000)
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000) * 1000000);
                }
            }
            else if (value == 1000000000000) num2Text = "UN BILLON";
            else if (value < 2000000000000) num2Text = "UN BILLON " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                num2Text = NumeroALetras(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0)
                {
                    num2Text = num2Text + " " + NumeroALetras(value - Math.Truncate(value / 1000000000000) * 1000000000000);
                }
            }
            return num2Text;
        }
    }
}
