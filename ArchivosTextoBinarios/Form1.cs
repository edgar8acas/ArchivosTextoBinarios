using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ArchivosTextoBinarios
{
    public partial class Form1 : Form
    {

        private List<Contacto> Agenda = new List<Contacto>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrirBMP_Click(object sender, EventArgs e)
        {
            ofd1.ShowDialog();
            FileStream archivo = new 
                FileStream(ofd1.FileName, FileMode.Open);
            txtInfo.Text = obtenerDatosBMP(archivo);
        }

        private string obtenerDatosBMP(FileStream archivo)
        {
            BinaryReader br = new BinaryReader(archivo);
            String bmCheck = new String(br.ReadChars(2));

            int tamanio = 0;
            tamanio = br.ReadInt32();

            int ancho = 0;
            archivo.Seek(18, SeekOrigin.Begin);
            ancho = br.ReadInt32();

            int alto = 0;
            alto = br.ReadInt32();

            Int16 bpixel = 0;
            archivo.Seek(28, SeekOrigin.Begin);
            bpixel = br.ReadInt16();
            

            return formarCadena(bmCheck, tamanio, ancho, alto, bpixel);
        }

        private string formarCadena(string bm, int t, int a, int h, short bpixel)
        {
            string bmpInfo = "";
            if(bm == "BM")
            {
                bmpInfo += "Si es BMP | ";
            }
            else
            {
                return null;
            }
            bmpInfo += "Tamaño: " + t/1000 + "KB | Ancho: " + a + "px | Alto: " + h + "px | Bits por píxel: " + bpixel + " bits.";
            return bmpInfo;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Contacto c = new Contacto(txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCorreo.Text, txtPais.Text);
            agregarContacto(c);
            lblNoContactos.Text = "No. Contactos " + Agenda.Count;
        }

        void agregarContacto(Contacto c)
        {
            Agenda.Add(c);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            SaveFile(generateXMLString());
        }        

        public String generateXMLString()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

            xml += "<Agenda>\n";
            foreach (Contacto c in Agenda)
            {
                xml += "<Contacto>\n"
                    + "<Nombre>" + c.Nombre + "</Nombre>\n"
                    + "<Apellido>" + c.Apellido + "</Apellido>\n"
                    + "<Telefono>" + c.Telefono + "</Telefono>\n"
                    + "<Correo>" + c.Correo + "</Correo>\n"
                    + "<Pais>" + c.Pais + "</Pais>\n"
                    + "</Contacto>\n";


            }
            xml += "</Agenda>\n";

            return xml;
        }

        public void SaveFile(String xml)
        {
            sfd1.ShowDialog();
            StreamWriter archivo = new StreamWriter(sfd1.FileName);
            archivo.WriteLine(xml);

            archivo.Flush();
            archivo.Close();
        }
    }
}
