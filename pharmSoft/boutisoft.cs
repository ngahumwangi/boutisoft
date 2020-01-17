using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace pharmSoft
{
    public partial class PharmSoft : Form
    {   
        Timer timer1 = new Timer();
        string myconnection1 = "";
        ConnectionString cs = new ConnectionString();
        public PharmSoft()
        {
            
            InitializeComponent();
            /*--------start of time fuction to run the current time------*/
            try
            {
                this.lbltime.Text = DateTime.Now.ToString();
                this.lbldatetime.Text = DateTime.Now.ToString();
                timer1.Tick += new EventHandler(timer1_Tick);
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*--------end of time fuction to run the current time------*/


        }

       
       private void timer1_Tick(Object sender,EventArgs e)
        {
            this.lbltime.Text = DateTime.Now.ToString();
            this.lbldatetime.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
       
        private void lbtnSales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            try
            { 
                //onClick open form sales
            
            Sales sls = new Sales();
            sls.WindowState = FormWindowState.Maximized;
           
            sls.userid.Text = this.userid.Text;
            sls.lblUsername.Text = this.lblUsername.Text;
            sls.lblRole.Text = this.lblRole.Text;
            sls.lblFull_Name.Text = this.lblFull_Name.Text;
            sls.Show();
            }
            catch(Exception ex)
            {
                
            }
        }
      
        private void lbtnAddStock_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {// open  the main form and close the sales form

                Stock stk = new Stock();
                stk.WindowState = FormWindowState.Maximized;

                stk.userid.Text = this.userid.Text;
                stk.lblUsername.Text = this.lblUsername.Text;
                stk.lblRole.Text = this.lblRole.Text;
                stk.lblFull_Name.Text = this.lblFull_Name.Text;
                stk.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ");
            }
           
            //frmstock.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
            
        
        }

        private void lbtnAddUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // open  the main form and close the sales form
            users frmuser = new users();           
            frmuser.ShowDialog();
          
        }

        private void availableStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ViewStock frm = new ViewStock();
           frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
          frm.ShowDialog();*/
        }

        private void PharmSoft_Load(object sender, EventArgs e)
        {
            try
            {
                string Query = "select role from users where username='" + lblUsername.Text + "' ";
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                MySqlCommand mycommand1 = new MySqlCommand(Query, myconn1);
                myconn1.Open();
                MySqlDataReader myreader = mycommand1.ExecuteReader();
                if (myreader.Read())
                {
                    String Role = myreader.GetString("role");
                    if (Role == "custom user")
                    {
                        lbtnAddUser.Enabled = false;
                        lbtnAddStock.Enabled = false;                     
                        lbtnSalesReport.Enabled = false;
                        toolStripMenuItem4.Enabled = false;
                        reportsToolStripMenuItem.Enabled = false;
                        usersToolStripMenuItem.Enabled = false;
                        toolStripMenuItem5.Enabled = false;
                        

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
           
        }
       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Aboutus fr = new Aboutus();
            fr.ShowDialog();
        }

        private void expiryingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Expiryingstock st = new Expiryingstock();
            st.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
            st.ShowDialog();*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            users fr = new users();
            fr.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void editUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users fr = new users();           
            fr.ShowDialog();
        }

        private void stickyNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("StikyNot.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                System.Diagnostics.Process.Start(" WINWORD.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(timer1.Tag) == true)
            {
              lbltitle.ForeColor = Color.Aqua;
            
                timer1.Tag = false;

            }

            else
            {
                lbltitle.ForeColor = Color.DarkGreen;

                timer1.Tag = true;
            }
        }
        Login lgn =new Login();
        private void btnPauseSession_Click(object sender, EventArgs e)
        {
           
        }
      

        private void btnEnd_Session_Click(object sender, EventArgs e)
        {
          
        }

        private void PharmSoft_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnResume_session_Click(object sender, EventArgs e)
        {
           
        }
      
       

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {


            Login f = new Login();
            this.Hide();
            this.Close();         
           
            f.ShowDialog();

        }

        private void lblsrpt_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {

                frmavailablestock frm = new frmavailablestock();
           frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state*/
           frm.ShowDialog();
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
             try
            {

            
           frmsalesrpt frm = new frmsalesrpt();
           frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
          frm.ShowDialog();
                }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void lblerpt_Click(object sender, EventArgs e)
        {

            try
            {

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblasrpt_Click(object sender, EventArgs e)
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

        private void lbtnSalesReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmreports g = new frmreports();
                g.lbluser.Text = this.userid.Text;
                g.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

      

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            try
            {


                btnview2 frm = new btnview2();
                frm.userid.Text = this.userid.Text;
                frm.lblUsername.Text = this.lblUsername.Text;
                frm.lblFull_Name.Text = this.lblFull_Name.Text;
               
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

       
    }
}
