using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasEntidades
{
    public static class Enumerados
    {
        public enum EProvincia
        {
            Catamarca,
            Chaco,
            Chubut,
            CABA,
            Córdoba,
            Corrientes,
            EntreRíos,
            Formosa,
            Gran_Buenos_Aires,
            Jujuy,
            LaPampa,
            LaRioja,
            Misiones,
            Neuquén,
            RíoNegro,
            Salta,
            SanJuan,
            SanLuis,
            SantaCruz,
            SantaFe,
            SantiagoDelEstero,
            TierraDelFuego,
            Tucumán

        }

        public enum ESexo
        {
            Mujer,
            Hombre,
            Otro
        }

        public enum EEstudios
        {
            Doctorado,
            Posdoctorado,
            Posgrado,
            Primario,
            Secundario,
            Terciario,
            Universitario
        }

        public enum EEstadoEstudios
        {
            Completado,
            Encurso,
            Incompleto
        }

        public enum EPuesto
        {
            Help_Desk,
            Administrativo,
            Arquitectura,
            Developer,
            Networking,
            QA_Tester,
            SysAdmin,
            ProjectManager,
            Consultor,
            Bi_Analist,
            Analista_Datos,
            UX_Developer,
            Dba_Administrator,
            FreeLance,
            Consultoria

        }

        public enum EPersonasaACargo
        {
            _0,
            Hasta_10,
            Mas_De_10

        }

        public enum ERecomienda
        {
            Puntajes_de_0_a_3,
            Puntajes_de_3_a_7,
            Superior_a_7
        }

        public enum ESalario
        {
            Hasta_50000,
            De_50000_a_150000,
            Más_de_150000
        }

        public enum EEdad
        {
            Hasta_30_años,
            De_30_a_50_años,
            Superior_a_50_años,
            No_informa

        }

        public enum EJornada
        {
            Full_Time,
            Part_Time,
            FreeLanca,
            Remoto_Empresa_otro_País

        }

        public enum EExperiencia
        {
            _0,
            Hasta_10,
            Más_de_10

        }

        public enum ERubro
        {
            Otras_Industrias,
            Servicios_Consultoria_De_Software_Digital,
            Producto_Basado_En_Software
        }
       
    }
}
