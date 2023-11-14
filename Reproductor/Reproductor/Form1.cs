using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics.Eventing.Reader;

namespace Reproductor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //Lista filtar archivos

        List<string> filtrarArchivo = new List<string>();

        //Abrir Carpeta
        FolderBrowserDialog carpeta = new FolderBrowserDialog();

        //Variables que almacenan el numero del archivo actual
        int archivoActual = 0;


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarCarpetaEvent(object sender, EventArgs e)
        {
            //Media player parar
            videoPlayer.Ctlcontrols.stop();
            //llamar a la variable local
            if(filtrarArchivo.Count > 1 )
            {
                filtrarArchivo.Clear();
                filtrarArchivo = null;
                //llamar list box para limpiar;
                lblListaArchivos.Items.Clear();
                archivoActual = 0;
            }
            DialogResult result=carpeta.ShowDialog();
            if(result == DialogResult.OK) 
            {
                //hace los filtros de los videos a reproducir 
                filtrarArchivo = Directory.GetFiles(carpeta.SelectedPath, "*.*").Where(file=>file.ToLower().EndsWith("mp3")||file.ToLower().EndsWith("mp4")).ToList();
                //cargar archivos
                CargarListaArchivos();
            }
        }

        //Metodo lista archivos
        private void ListaArchivo(string url)
        {

        }

        //metodo para mostrar los archivos
        /*private void MuestraNombreArchivo(Label nombre)
        {
            string file = Path.GetFileName(lblListaArchivos.SelectedItem.ToString());
            nombre.Text = "Reproduccion actual " + file;
        }*/

        //Metodo cargar archivos
        private void CargarListaArchivos()
        {
            //Llamar al reprodutor
            videoPlayer.currentPlaylist = videoPlayer.newPlaylist("Lista de archivos","");
            //foreach que recorre el listado
            foreach (string videos in filtrarArchivo)
            {
                videoPlayer.currentPlaylist.appendItem(videoPlayer.newMedia(videos));
                lblListaArchivos.Items.Add(videos);
            }
            if(filtrarArchivo.Count > 0)
            {
                //Llamada a label que tiene ese nombre 
                lblListaArchivos.Text = "Archivo no encontrado" + filtrarArchivo.Count;
                lblListaArchivos.SelectedIndex = archivoActual;

                //hacer una llamada al metodo listado de archivo
                ListaArchivo(lblListaArchivos.SelectedItems.ToString());
            }
            else
            {
                MessageBox.Show("video no encontrado");
            }
        }
    }
}
