using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOPI
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = wrs.mdb";
        private OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "wrsDataSet.emp". При необходимости она может быть перемещена или удалена.
            this.empTableAdapter.Fill(this.wrsDataSet.emp);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int emp_id = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM emp WHERE [emp_id] = " + emp_id;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данный работник уволен");
            this.empTableAdapter.Fill(this.wrsDataSet.emp);
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string Name2 = textBox2.Text;
            string Name3 = textBox3.Text;
            string Name4 = textBox4.Text;
            string Position3 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            string query = "INSERT INTO emp (emp_name, emp_oc, emp_prof, emp_d) VALUES ('" + Name2 + "','" + Name3 + "','" + Name4 + "','" + Position3 + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Работник добавлен");
            this.empTableAdapter.Fill(this.wrsDataSet.emp);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Перевод_Click(object sender, EventArgs e)
        {
            string name2 = Convert.ToString(textBox5.Text);

            string query = "UPDATE emp SET emp_oc ='" + textBox6.Text + "' WHERE [emp_id] = " + name2;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Изменение добавлены");
            this.empTableAdapter.Fill(this.wrsDataSet.emp);
        }
    }
}
