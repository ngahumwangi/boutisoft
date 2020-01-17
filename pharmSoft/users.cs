

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
    public partial class users : Form
    {
        int minlenth=4;
       
        string myconnection1 = "";
        Securitysha1 ss = new Securitysha1();
        ConnectionString cs = new ConnectionString();
        public users()
        {
            InitializeComponent();
            CboUsers.Items.Add("Admin");
            CboUsers.Items.Add("custom user");
        }

        private void lbtnHome_Click(object sender, EventArgs e)
        {
            PharmSoft frmpharm = new PharmSoft();
            this.Hide();
            frmpharm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
            frmpharm.ShowDialog();
            this.Close();
        }

        private void btnClose_Users_Click(object sender, EventArgs e)
        {

        }
        private string gender()
        {
            string sex = "";
            if (rdoMale.Checked)
                sex = "male";
            if (rdoFemale.Checked)
                sex = "female";
            return sex;
        }
        private int curid()
        {
            MySqlConnection conn = new MySqlConnection(cs.myconnection1);
            conn.Open();
            string query = "select   max(userid) from   sers";
            MySqlCommand mycommand1 = new MySqlCommand(query, conn);

            string x = mycommand1.ExecuteScalar().ToString();//execution command
            int y = Convert.ToInt32(x) + 1;
            return y;
        }
       
	   
	           private string returndata(string middle,string final)
        {
            MySqlConnection conn = new MySqlConnection(cs.myconnection1);
            conn.Open();
            string query = "select  '"+middle+"' from   '"+final+"'";
            MySqlCommand mycommand1 = new MySqlCommand(query, conn);            
            
            return  mycommand1.ExecuteScalar().ToString();//execution command
        }
		
        private void lbtnStock_Save_Click(object sender, EventArgs e)
        {
          


            string passresult = ss.GetSHA1(txtpassword.Text);
            if (txtfname.Text == "")
            {
                MessageBox.Show("First Name is required");
                txtfname.Focus();
            }

            else if (txtothername.Text == "")
            {
                MessageBox.Show("Either your middle or lastname is required");
                txtothername.Focus();
            }
    
            else if (txtnid.Text == "")
            {
                MessageBox.Show("Your national id no is required");
                txtnid.Focus();
            }
           
           
            else if (txtusername.Text == "")
            {
                MessageBox.Show("please enter your username");
                txtusername.Focus();
            }
            else if (txtusername.TextLength < 3)
            {

                MessageBox.Show("Invalid username, valid length is 4-8 characters");
                txtpassword.Focus();
            }
            else if (txtpassword.Text == "" && cornfirmpassword.Text == "")
            {
                MessageBox.Show("your passwords are required");
                txtpassword.Focus();
            }

            else if (txtusername.Text.Length < minlenth)
            {

                MessageBox.Show("Invalid password, valid length is 4-8 characters");
                txtpassword.Focus();
            }

            else
            {
                try
                {

                    if (txtpassword.Text != cornfirmpassword.Text)
                    {
                        MessageBox.Show("Your password donot match");
                    }

              

                    MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                    myconn1.Open();
                    string Query1 = "insert into users(userid,fname,othername,idno,email,telno,gender,role,username,password,dateofregistration) values('" + curid() + "','" + txtfname.Text + "','" + txtothername.Text + "','" + Convert.ToInt64(txtnid.Text) + "','" + txtaddress.Text + "','" + txttelephone.Text + "','" + gender() + "','" + CboUsers.SelectedItem + "','" + txtusername.Text + "','" + passresult + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                  
                    MySqlCommand mycommand1 = new MySqlCommand(Query1, myconn1);
                    MySqlDataReader myreader1;
                   

                    myreader1 = mycommand1.ExecuteReader();//execution command
                    /*------textbox clearance---*/

                    MessageBox.Show("User saved");
                    clear();
                    Application.Exit();
                    myconn1.Close();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!", "Duplicate Users", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }
      


        private void users_Load(object sender, EventArgs e)
        {
            grpboxuser.Visible = false;
            lbtnRemove_User.Visible = false;
            lbtnUpdate_User.Visible = false;
            rdouserid.Checked = true;
        }
        private void clear()
        {
           
            txtfname.Text = "";
            txtothername.Text = "";
            txttelephone.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtaddress.Text = "";
            txtnid.Text = "";           
            CboUsers.SelectedIndex = -1;
            cornfirmpassword.Text = "";
            dgvusers.DataSource = null;
            dgvusers.Rows.Clear();
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
            txtPsearch.Text = "";
            
            
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            clear();
            grpboxuser.Visible = false;
            lbtnStock_Save.Visible = true;
            lbtnUpdate_User.Visible = true;

        }

        private void lbtnEdit_User_Click(object sender, EventArgs e)
        {
            txtPsearch.Focus();
            rdousername.Checked = true;
            lbtnStock_Save.Visible = false;
            grpboxuser.Visible = true;
            lbtnUpdate_User.Visible = true;
            lbtnRemove_User.Visible = true;
        }

       

       

       

        private void lbtnRemove_User_Click(object sender, EventArgs e)
        {
           
            try
            {
               
              
                MySqlConnection conn = new MySqlConnection(cs.myconnection1);
              
                var result = MessageBox.Show("Do you really want to remove this system user", "Remove User", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch(result)
                {
                    case DialogResult.Yes:
               
               // string query = "delete from users where userid='" ;
              
               // MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader1;
                conn.Open();//mysql open of session
                //myreader1 = cmd.ExecuteReader();//execution command
                conn.Close();
                clear();
                break;
                 }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error");
            }

        }

        private void lbtnUpdate_User_Click(object sender, EventArgs e)
        {

            string result = ss.GetSHA1(txtpassword.Text);
            if (txtfname.Text == "")
            {
                MessageBox.Show("Your First Name is required");
                txtfname.Focus();
            }

            else if (txtothername.Text == "")
            {
                MessageBox.Show("Your lastname is required");
                txtothername.Focus();
            }
         
            else if (txtnid.Text == "")
            {
                MessageBox.Show("Your NatioanalID is required");
                txtnid.Focus();
            }
            else if (txtaddress.Text == "")
            {
                MessageBox.Show("Your address is required");
                txtaddress.Focus();
            }
            else if (txttelephone.Text == "")
            {
                MessageBox.Show("Your Telephone Number  is required!");
                txttelephone.Focus();
            }
            else if (txtusername.Text == "")
            {
                MessageBox.Show("please enter your username");
                txtusername.Focus();
            }
            else if (txtpassword.Text == "" && cornfirmpassword.Text == "")
            {
                MessageBox.Show("your passwords are required");
                txtpassword.Focus();
            }
            else
            {
                try
                {

                    if (txtpassword.Text != cornfirmpassword.Text)
                    {
                        MessageBox.Show("Your password donot match");
                    }
                 
                    MySqlConnection conn3 = new MySqlConnection(cs.myconnection1);
                    conn3.Open();
                    string query3 = "update users set fname='" + txtfname.Text + "',othername='" + txtothername.Text + "',idno='" + Convert.ToInt64(txtnid.Text) + "',email='" + txtaddress.Text + "',telno='" + Convert.ToInt64(txttelephone.Text) + "',gender='" + gender() + "',role='" + CboUsers.SelectedItem + "',username='" + txtusername.Text + "',password='" + result + "'  where userid='"+Convert.ToInt64(txtuserid.Text)+"'";
                   
                    MySqlCommand cmd = new MySqlCommand(query3, conn3);
                    MySqlDataReader myreader1;
                    
                    myreader1 = cmd.ExecuteReader();//execution command
                    conn3.Close();
                    MessageBox.Show("you succefully updated  the user details");
                    clear();
                   Application.Exit();
                                     
                }
                catch (Exception ex)
                {
                    MessageBox.Show("database Error");
                }
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            var result= MessageBox.Show("Do you really want toclose this user form", "Close Form", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            switch (result)
            {

             case DialogResult.Yes:
                    PharmSoft fr = new PharmSoft();
                    this.Hide();
                  fr.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
                  this.Close();
                  fr.ShowDialog();
                 
                    break;
            }
             
        }

       
        private void txtPsearch_TextChanged(object sender, EventArgs e)
        {
            if(rdouserid.Checked==true)
        {
            try
            {
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                myconn1.Open();
                string query = "select userid,fname,othername,username from users where userid like'%" + txtPsearch.Text + "%' order by userid";
                MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);
                MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                myadapter.SelectCommand = mycommand1;
                DataTable dTable = new DataTable();
                myadapter.Fill(dTable);
                dgvusers.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error");
            }
        }
        if (rdousername.Checked == true)
        {
            try
            {
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                myconn1.Open();
                string query = "select userid,fname,othername,username from users where username like'%" + txtPsearch.Text + "%' order by userid";
                MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);
                MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                myadapter.SelectCommand = mycommand1;
                DataTable dTable = new DataTable();
                myadapter.Fill(dTable);
                dgvusers.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error");
            }
        }
        }

       

        private void dgvusers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                MySqlConnection myconn2 = new MySqlConnection(cs.myconnection1);

                string query2 = "select  	userid,fname,othername,idno,email,telno,gender,role ,username from users where userid='" + dgvusers.CurrentRow.Cells[0].FormattedValue + "' ";

                MySqlCommand mycommand2 = new MySqlCommand(query2, myconn2);
                MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                myadapter.SelectCommand = mycommand2;
                DataSet ds2 = new DataSet();
                myadapter.Fill(ds2);
                txtuserid.Text = ds2.Tables[0].Rows[0][0].ToString();
                txtfname.Text = ds2.Tables[0].Rows[0][1].ToString();
                txtothername.Text = ds2.Tables[0].Rows[0][2].ToString();
                txtnid.Text = ds2.Tables[0].Rows[0][3].ToString();
                txtaddress.Text = ds2.Tables[0].Rows[0][4].ToString();
                txttelephone.Text = ds2.Tables[0].Rows[0][5].ToString();
                string x = ds2.Tables[0].Rows[0][6].ToString();
                string g = ds2.Tables[0].Rows[0][7].ToString();
                if (x == "male")
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }
                if (g == "Admin")
                {
                    CboUsers.SelectedIndex = 0;
                }
                else
                {
                    CboUsers.SelectedIndex = 1;
                }
                txtusername.Text= ds2.Tables[0].Rows[0][8].ToString();
               

            }
            catch(Exception ex)
            {
                MessageBox.Show("SORRY NO DATA!", "CAUTION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void txtanswer_Click(object sender, EventArgs e)
        {

        }

      

     
       
    }
}
