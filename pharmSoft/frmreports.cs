using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmSoft
{
    public partial class frmreports : Form
    {

         ConnectionString cs = new ConnectionString();
        public frmreports()
        {
            InitializeComponent();
        }

      

        private void btnsimpleoverall_Click(object sender, EventArgs e)
        {
            try
            {

                frmsalesrpt f = new frmsalesrpt();
            f.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state*/
            f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                complexsalereport frm = new complexsalereport();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            try
            {

                frmavailablestock frm = new frmavailablestock();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state*/
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {

                Form2 frm = new Form2();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                frmexpiryreport frm = new frmexpiryreport();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                frmsalesrpt frm = new frmsalesrpt();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                complexsalereport frm = new complexsalereport();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnexpense_Click(object sender, EventArgs e)
        {
            try
            {
               
                 if (txtamounting.Text == "")
                {
                    MessageBox.Show("Expense amount empty");
                    txtamounting.Focus();
                }
                else
                {
                    DateTime date = dateTimePicker1.Value;
                    string Query = "insert into expense_cost(expense_id,expense_cost,datetime,user_id)values((select expense_id from expense where expense_type='" + cboexpense.SelectedItem + "'),'" + Convert.ToDouble(txtamounting.Text) + "','" + date.ToString("yyyy-MM-dd") + "','"+Convert.ToInt64(lbluser.Text)+"')  ";
                    MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                    MySqlCommand mycommand1 = new MySqlCommand(Query, myconn1);
                    myconn1.Open();
                    MySqlDataReader myreader = mycommand1.ExecuteReader();
                    MessageBox.Show("Saved");
                    cboexpense.SelectedIndex = -1;
                    txtamounting.Text = "";
                    dateTimePicker1.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!"+ex);

            }

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtexpenses.Text == "")
                {
                    MessageBox.Show("Empty  textbox!", "Fill in the expense ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                string Query = "insert into expense(expense_type) values('" + txtexpenses.Text + "') ";
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                MySqlCommand mycommand1 = new MySqlCommand(Query, myconn1);
                myconn1.Open();
                MySqlDataReader myreader = mycommand1.ExecuteReader();
                MessageBox.Show("Expense registered");
                txtexpenses.Text = "";
                groupBox1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to add expense");
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            try
            {
                string querry = "select expense_type from expense";
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                MySqlCommand mycommand1 = new MySqlCommand(querry, myconn1);
                MySqlDataReader myreader1;
                myconn1.Open();//mysql open of session
                myreader1 = mycommand1.ExecuteReader();//execution command
                /*------textbox clearance---*/

                while (myreader1.Read())
                {
                    object item = myreader1["expense_type"];
                    cboexpense.Items.Add(item.ToString());
                }
                myconn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

            txtamounting.Text = "";
            cboexpense.SelectedIndex = -1;
            dateTimePicker1.ResetText();
            groupBox1.Enabled = true;
            txtexpenses.Focus();
        }

        private void cboexpense_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

      

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {

                Form3 frm = new Form3();
                frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
  
}
