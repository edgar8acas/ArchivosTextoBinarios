using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchivosTextoBinarios
{
    class Contacto
    {
        private String _nombre;
        public String Nombre
        {
            get { return _nombre; }
        }

        private String _apellido;
        public String Apellido
        {
            get { return _apellido; }
        }

        private String _telefono;
        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private String _correo;
        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private String _pais;
        public String Pais
        {
            get { return _pais; }
        }

        public Contacto(String nombre, String apellido, String telefono, String correo, String pais)
        {
            _nombre = nombre;
            _apellido = apellido;
            _telefono = telefono;
            _correo = correo;
            _pais = pais;
        }

    }
}
