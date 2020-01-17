using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//mysql data connection namespace reference to .data dll 


namespace pharmSoft
{
    public partial class Login : Form
    {
       
        public Login()
        {
            InitializeComponent();
        }
        ConnectionString cs = new ConnectionString();
        Securitysha1 ss = new Securitysha1();
       
      
        private void Login_Load(object sender, EventArgs e)
        {
           
            timer1.Enabled = true; // Enable the timer.
            timer1.Start();//Strart it
            timer1.Interval = 1000; // The time per tick.
            timer1.Tick += new EventHandler(timer1_Tick);
           
            progressBar1.Maximum = 5;
            try
            {
                string querry = "select username from users";
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                MySqlCommand mycommand1 = new MySqlCommand(querry, myconn1);
                MySqlDataReader myreader1;
                myconn1.Open();//mysql open of session
                myreader1 = mycommand1.ExecuteReader();//execution command
                /*------textbox clearance---*/

                while (myreader1.Read())
                {
                    object item = myreader1["username"];
                    txtusername.Items.Add(item.ToString());
                }
                myconn1.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Possible database error, contact admin");
            }

           
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 5)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                progressBar1.Visible = false;
                groupboxlogin.Visible = true;
                txtusername.Focus();
            }
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            //prompting the ursor to move to the  button after key down event
            if (e.KeyCode == Keys.Enter)
            {
                btnreset.Focus();
                e.Handled = true;
            }
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            //prompting the ursor to move to the  button after key down event
            if (e.KeyCode == Keys.Enter)
            {
                btnok.Focus();
                e.Handled = true;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            //validation
            if(txtusername.SelectedItem=="")
            {
                MessageBox.Show("Select username");
                txtusername.Focus();

            }
            else if(btnreset.Text=="")
            {
                MessageBox.Show("password is Required!");
                btnreset.Focus();
            }
            else
            {
                bool r = validate_login(txtusername.Text,btnreset.Text);
                if (r == true)
                {
                    PharmSoft cs = new PharmSoft();
                    this.Hide();
                   
                    cs.userid.Text =userid;
                    cs.lblUsername.Text = username;
                    cs.lblRole.Text = role;
                    cs.lblFull_Name.Text = fullname;
                    cs.Show();

                    
                }
                
                else
                {
                    MessageBox.Show("incorrect login credentials");
                    txtusername.Text = "";
                    btnreset.Text = "";
                    txtusername.Focus();
          

                    
                }

            }
        }
        string userid = "";
        string username = "";
        string fullname = "";
        string role = "";
           public bool validate_login(string user, string pass)
        {
            string password = ss.GetSHA1(btnreset.Text);
            bool ret = false;
            try
            {
                
               //dbconnection();//reffering to connection function defined above
                DataSet ds2 = new DataSet();
               
                string query = "select username,password,role,userid,fname ,othername from users where username='" + txtusername.SelectedItem + "' and password='" + password + "'";//sql query to select from mysql databse
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                MySqlCommand mycommand1 = new MySqlCommand();
                MySqlDataAdapter myreader1 = new MySqlDataAdapter(query, myconn1);
                int s = (myreader1.Fill(ds2));
                if (s == 1)
                {

                    username = ds2.Tables[0].Rows[0][0].ToString();//assign the first item in the array to user_id
                    role= ds2.Tables[0].Rows[0][2].ToString();//assign the 2nd item in the array to user_id
                   userid = ds2.Tables[0].Rows[0][3].ToString();
                    fullname= ds2.Tables[0].Rows[0][4].ToString() + "  " + ds2.Tables[0].Rows[0][5].ToString();//Get full names
                    ret = true;
                    
                }
                else if (s < 1)
                {
                    ret = false;
                    MessageBox.Show("no  such user found in the system, contact the admin");
                    
                }
                else if (s > 1)
                {
                    ret = false;
                    MessageBox.Show("multiple similar user found in the system contact the admin");
                   
                }
                else
                {
                    ret = false;
                    MessageBox.Show("Invalid Password or Username", "pharmsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                    txtusername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pharmsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return ret;
        }

           
           }    

          

          
          
        

          
    
}
