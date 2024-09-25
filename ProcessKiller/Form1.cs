using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessKiller
{ 
    public partial class Form1 : Form 
{
    public Form1() 
    { 
        InitializeComponent();
        UpdateProcessList();
        timer1.Enabled = true;
    }
    private void UpdateProcessList() {
        lstProcesses.Items.Clear();
        lst_id.Items.Clear();
        lst_memoriafisica.Items.Clear();
        lst_memoriavirtual.Items.Clear();
        lst_CPU.Items.Clear();
        int id = 1;
        foreach (Process p in Process.GetProcesses()) 
        {
            lstProcesses.Items.Add(id + ":" + p.ProcessName); // nombre del proceso
            lst_id.Items.Add(id + ": " + p.Id);// id del proceso
            lst_memoriafisica.Items.Add(id + ": " + p.WorkingSet64);// RAM del proceso
            lst_memoriavirtual.Items.Add(id + ": " + p.VirtualMemorySize64); // MEmoria virtual del proceso
            lst_CPU.Items.Add(id + ": " + p.SessionId); // CPU que usa el proceso
           
            id = id + 1;     
        }
        tslProcessCount.Text = "Procesos Actuales: " + lstProcesses.Items.Count.ToString();    //  cant de procesos   
    } 
        
private void btnKill_Click(object sender, EventArgs e) {

    try
    {
        foreach (Process p in Process.GetProcesses())
        {
            string arr = lstProcesses.SelectedItem.ToString(); // proceso seleccionado en el list box
            string[] proceso = arr.Split(':');// divido el contenido del listbox
 

            if (p.ProcessName == proceso[1])
            {
                p.Kill(); // elimina el proceso
            }
           
        }
    }
    catch (Exception x){
        MessageBox.Show("no selecciono nigun proceso " + x,"error al eliminar",MessageBoxButtons.OK);
    }
   
    //UpdateProcessList(); 
} 

        
        private void button1_Click(object sender, EventArgs e) { 
            Close(); 
        } 
        private void button2_Click(object sender, EventArgs e) {
            try
            {
                // Ruta del archivo PDF que quieres abrir
                string rutaPDF = @"C:\Users\genom\OneDrive\Documentos\Cursos\SEXTO CICLO\SISTEMAS OPERATIVOS\ProcessKiller\ManualDeUso\MANUAL DE USO ADMINISTRADOR DE TAREAS EN C#.pdf";

                // Verifica si el archivo PDF existe antes de intentar abrirlo
                if (System.IO.File.Exists(rutaPDF))
                {
                    // Abre el archivo PDF con el visor predeterminado del sistema
                    Process.Start(rutaPDF);
                }
                else
                {
                    // Muestra un mensaje si no se encuentra el archivo
                    MessageBox.Show("El archivo PDF no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de que algo salga mal
                MessageBox.Show("Ocurrió un error al intentar abrir el archivo PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProcessList_Click_1(object sender, EventArgs e)
        {
         UpdateProcessList(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateProcessList(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
