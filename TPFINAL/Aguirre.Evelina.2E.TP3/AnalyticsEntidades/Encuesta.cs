

using EstadisticasEntidades;
using Excepciones;
using System;
using System.Text;

namespace AnalyticsEntidades
{
    [Serializable]
    public class Encuesta
    {
        private string seIdentifica;
        private int edad;
        private string provincia;
        private int aniosExperiencia;
        private int personalACargo;
        private string nivelEstudios;
        private string estadoEstudios;
        private string puesto;
        private string jornada;
        private double salarioBruto;
        private string rubro;
        private int cuantoRecomiendaEmpresa;

        public double Salario_Bruto
        {
            get
            {
                return this.salarioBruto;
            }
            set
            {
                if (ValidarSalario(value))
                    this.salarioBruto = value;
            }
        }
        public string Se_Identifica
        {
            get
            {
                return this.seIdentifica;
            }
            set
            {
                this.seIdentifica = value;
            }
        }
        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                if (ValidarEdad(value))
                {
                    this.edad = value;
                }
            }
        }

        public int Experiencia
        {
            get
            {
                return this.aniosExperiencia;
            }
            set
            {
                if (validarAniosPuesto(value))
                    this.aniosExperiencia = value;
            }

        }
       
        public int Personal_a_Cargo
        {
            get
            {
                return this.personalACargo;
            }
            set
            {
                if(validarNumeroPersonalACargo(value))
                this.personalACargo = value;
            }
        }

        public string Nivel_Estudios
        {
            get
            {
                return this.nivelEstudios;
            }
            set
            {
                this.nivelEstudios = value;
            }
        }

        public string Estado_Estudios
        {
            get
            {
                return this.estadoEstudios;
            }
            set
            {
                this.estadoEstudios = value;
            }
        }

        public string Puesto
        {
            get
            {
                return this.puesto;
            }
            set
            {
                this.puesto = value;
            }
        }

        public string Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public string Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value;
            }
        }

        public string Provincia
        {
            get
            {
                return this.provincia;
            }
            set
            {
                this.provincia = value;
            }
        }

        public int Recomienda_Empresa
        {
            get
            {
                return this.cuantoRecomiendaEmpresa;
            }
            set
            {
                if (ValidaNumeroDelUnoAlDiez(value))
                    this.cuantoRecomiendaEmpresa = value;
            }
        }

        public Encuesta()
        {
            
        }

        public Encuesta(string seIdentifica, int edad, string provincia, int aniosExperiencia, 
            int personalACargo, string nivelEstudios,
            string estadoEstudios, string puesto, string jornada, double salarioBruto,
            string rubro, int cuantoRecomiendaEmpresa)
            :this()
        {
            
            this.seIdentifica = seIdentifica;
            this.Edad = edad;
            this.provincia = provincia;
            this.Experiencia = aniosExperiencia;
            this.Personal_a_Cargo = personalACargo;
            this.nivelEstudios = nivelEstudios;
            this.estadoEstudios = estadoEstudios;
            this.puesto = puesto;
            this.jornada = jornada;
            this.Salario_Bruto = salarioBruto;
            this.rubro = rubro;
            this.Recomienda_Empresa = cuantoRecomiendaEmpresa;
        }

        /// <summary>
        /// Valida numero del 0 al 10.
        /// </summary>
        /// <param name="auxNumero"></param>
        /// <returns></returns>
        public bool ValidaNumeroDelUnoAlDiez(int auxNumero)
        {
            if (auxNumero < 0 || auxNumero > 10)
            {
                throw new DatoInvalido();
            }
            return true;
        }


        /// <summary>
        /// Valida salario
        /// </summary>
        /// <param name="auxSalario"></param>
        /// <returns></returns>
        public bool ValidarSalario(double auxSalario)
        {

            if (auxSalario < 0 || auxSalario > 99999999)
            {
                throw new DatoInvalido();
            }
            return true;

        }

        /// <summary>
        /// Valida que un string esté compuesto sólo por carácteres alfabéticos.
        /// </summary>
        /// <param name="auxString"></param>
        /// <returns></returns>
        public bool ValidarStringAlfabetico(string auxString)
        {
            if (!string.IsNullOrEmpty(auxString))
            {
                auxString.Trim();

                for (int i = 0; i < auxString.Length; i++)
                {
                    if (!char.IsLetter(auxString[i]))
                    {
                        throw new DatoInvalido();
                    }
                }
                return true;
            }
            throw new DatoInvalido();
        }

        /// <summary>
        /// Devuelve string validado.
        /// </summary>
        /// <param name="auxString"></param>
        /// <returns>cadena validada o excepcion de DatoInvalido</returns>
        public string ValidarStringAlfabeticoYDevolverlo(string auxString)
        {
            if (!ValidarStringAlfabetico(auxString))
            {
                throw new DatoInvalido();
            } 
            return auxString;
        }


        /// <summary>
        /// Valida que el dato recibido esté compuesto por carácteres numéricos.
        /// </summary>
        /// <param name="auxString"></param>
        /// <returns></returns>
        public string ValidarStringNumerico(string auxString)
        {
            if (!string.IsNullOrEmpty(auxString))
            {
                for (int i = 0; i < auxString.Length; i++)
                {
                    if (!char.IsDigit(auxString[0]))
                    {
                        throw new DatoInvalido();
                    }
                }
                return auxString;
            }
            throw new DatoInvalido();

        }

        /// <summary>
        /// Valida rango real de años que una persona puede estar en un puesto/Empresa.
        /// </summary>
        /// <param name="auxIdString"></param>
        /// <returns></returns>
        public bool validarAniosPuesto(int auxAniosEnPuesto)
        {
            if (auxAniosEnPuesto < 0 || auxAniosEnPuesto > 60)
            {
                throw new DatoInvalido();
            }
            return true;
        }


        /// <summary>
        /// Valida rango real de años que una persona puede estar en un puesto/Empresa.
        /// </summary>
        /// <param name="auxIdString"></param>
        /// <returns></returns>
        public bool validarNumeroPersonalACargo(int auxIntPersonalACargo)
        {
            if (auxIntPersonalACargo < 0 || auxIntPersonalACargo > 9999999)
            {
                throw new DatoInvalido();
            }
            return true;
        }

        /// <summary>
        /// Valida edad.
        /// </summary>
        /// <param name="auxEdad"></param>
        /// <returns></returns>
        public bool ValidarEdad(float auxEdad)
        {
            if (edad < 0 || edad > 140)
            {
                throw new DatoInvalido();
            }
            return true;
        }

        /// <summary>
        /// Calcula porcentaje que representa un valor comparado con el total.
        /// </summary>
        /// <param name="cantidadConsulta"></param>
        /// <param name="cantidadTotal"></param>
        /// <returns></returns>
        public static float CalculoPorcentaje(int cantidadConsulta, int cantidadTotal )
        {
            return (cantidadConsulta * 100) / cantidadTotal; 
        }


        /// <summary>
        /// Devuelve datos de la persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

        StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***************************************************\n");
            sb.AppendLine($"Se Identifica : {this.seIdentifica}\n");
            sb.AppendLine($"Edad : {this.edad}\n");
            sb.AppendLine($"Años de Experiencia: {this.aniosExperiencia}\n");
            sb.AppendLine($"Cantidad de personas a cargo: {this.personalACargo}\n");
            sb.AppendLine($"Nivel de Estudios : {this.nivelEstudios}, Estado: {this.estadoEstudios}\n");
            sb.AppendLine($"Puesto: {this.puesto}\n");
            sb.AppendLine($"Jornada: {this.jornada}\n");
            sb.AppendLine($"Salario Bruto: {this.salarioBruto}\n");
            sb.AppendLine($"Nivel conformidad empresa actual: {this.jornada}\n");
            sb.AppendLine($"Recibe Bono: {this.jornada}\n");
            sb.AppendLine($"Rubro: {this.jornada}\n");
            sb.AppendLine($"Cuanto recomendaría la empresa: {this.jornada}\n");
            sb.AppendLine($"***************************************************\n\n");

            return sb.ToString();
        }

    }
}
