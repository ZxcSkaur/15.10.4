using Foto_EF_Prog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.FolderModel;

namespace WindowsFormsApp1
{
    public partial class Form1Show : Form
    {
        public Form1Show()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Загружаем данные в (таблицу) dataGridView1
            Model1 model = new Model1();
            dataGridView1.DataSource = model.Student.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Переходим на форму 2
            Form2AddData form2 = new Form2AddData();
            form2.Show();
            Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
