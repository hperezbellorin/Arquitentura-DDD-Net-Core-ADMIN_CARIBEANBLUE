using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace InfraestructuraTransversal.General.Utilitarios
{
    public static class General
    {


        public static T ObtenerValor<T>(string valor)
        {
            // Ajuste realizado para tratar el (.) decimal del excel. 
            CultureInfo cultura = CultureInfo.CreateSpecificCulture("en-US");
            NumberStyles estiloNumero = NumberStyles.Number;

            object resultado = null;

            Type tipo = typeof(T);
            var convertible = false;

            switch (Type.GetTypeCode(tipo))
            {
                case TypeCode.Int32:
                    int entero;
                    convertible = Int32.TryParse(valor, out entero);
                    resultado = entero;
                    break;
                case TypeCode.Int64:
                    long enteroLargo;
                    convertible = Int64.TryParse(valor, out enteroLargo);
                    resultado = enteroLargo;
                    break;
                case TypeCode.Decimal:
                    decimal numero;
                    convertible = decimal.TryParse(valor, estiloNumero, cultura, out numero);
                    resultado = numero;
                    break;
                case TypeCode.String:
                    resultado = valor;
                    convertible = true;
                    break;
            }

            if (!convertible)
            {
                throw new FormatException("El tipo de dato no es valido para la conversion: " + tipo.Name + ".");
            }

            return (T)resultado;
        }

        public static string dvmod13(Int64 NumDoc)
        {
            if (NumDoc > 0)
            {
                string nd = NumDoc.ToString().PadLeft(13, '0');
                int total, Digito_ver;
                total = (int.Parse(nd.Substring(12, 1)) * 2) + (int.Parse(nd.Substring(11, 1)) * 3) + (int.Parse(nd.Substring(10, 1)) * 4) + (int.Parse(nd.Substring(9, 1)) * 5) + (int.Parse(nd.Substring(8, 1)) * 6) + (int.Parse(nd.Substring(7, 1)) * 7);
                total = total + (int.Parse(nd.Substring(6, 1)) * 2) + (int.Parse(nd.Substring(5, 1)) * 3) + (int.Parse(nd.Substring(4, 1)) * 4) + (int.Parse(nd.Substring(3, 1)) * 5) + (int.Parse(nd.Substring(2, 1)) * 6) + (int.Parse(nd.Substring(1, 1)) * 7) + (int.Parse(nd.Substring(0, 1)) * 2);
                int residuo = total % 11;
                if (residuo > 1)
                    Digito_ver = 11 - residuo;
                else
                    Digito_ver = 0;
                //return string.Concat(nd, "-", Digito_ver);
                return string.Concat(nd, Digito_ver);
            }
            else
                return "";
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static string ValidateNullorEmptySTRING(string strField) // this subroutine is used to validate data null or empty when the field is a string
        {
            if (string.IsNullOrEmpty(strField))
            {
                return "";
            }

            if (strField == null)
            {

                return "";
            }
            else if (strField == "")
            {
                return "";

            }
            else
            {

                return strField;

            }
        }
    }
}
