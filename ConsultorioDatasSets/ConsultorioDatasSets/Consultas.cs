using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultorioDatasSets
{
    public partial class Consultas : Form
    {
        private int? idPaciente;
        public Consultas(int? idPaciente=null)
        {
            InitializeComponent();
            if (idPaciente!=null)
            {
                this.idPaciente = idPaciente;

            }
           
        }

        private void consultasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.consultasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultorioDataSet);

        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'consultorioDataSet.consultas' Puede moverla o quitarla según sea necesario.

            if (this.idPaciente!=null)
            {
                this.consultasTableAdapter.Fill(this.consultorioDataSet.consultas,(int) this.idPaciente);

            }


        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           int f= consultasDataGridView.NewRowIndex;
            consultasDataGridView.Rows[f-1].Cells[2].Value = DateTime.Now;
            consultasDataGridView.Rows[f - 1].Cells[4].Value = this.idPaciente;
        }
    }
}
