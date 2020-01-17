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
using OnBarcode.Barcode;//use of mysql namespace to  refer to mysql data   connections

namespace pharmSoft
{
    public partial class Stock : Form
    {
      
        ConnectionString cs = new ConnectionString();
        public Stock()
        {
            InitializeComponent();
            try
            {
                this.lbldate.Text = DateTime.Now.ToString();
              
               
                timer1.Tick += new EventHandler(timer1_Tick);
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timer1_Tick(Object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString();
            //this.lblsdate.Text = DateTime.Now.ToString();
        }
        /*----strat of database connection fuction----*/
  
        /*----end of database connection fuction----*/
        private void lbtnHome_Click(object sender, EventArgs e)
        {
            // open  the main form and close the Stock form
           
            this.Hide();
           
            this.Close();
        }
        //fuction to query the pharmsoft db get the int plus 1
        private void querydb()
        {
                    try
                    {
                        MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                        myconn1.Open();
                string Query = "select max(productcode) from stockdetails";//selection string

                MySqlCommand mycommand1 = new MySqlCommand(Query, myconn1);             

                string prev_value = mycommand1.ExecuteScalar().ToString();
                int current_id = Convert.ToInt32(prev_value) + 1;
               txtproductcode.Text = Convert.ToString(current_id);
                myconn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error querydb");
            }   /*-------code to query the max value in stock add by one and the output itin the textbox----*/
                   
                   
        }
        /*******EAN kKENYA barcode Generation********/
        private Int64 Eangenerate()
        {
            int numeringsystem = 61;
            Int64 manufacturingcode = 10001;
            Int64 productcode =Convert.ToInt64(txtproductcode.Text);
           // Int64 eancode = Convert.ToInt64(61123450001);
            Int64 eancode = Int64.Parse(numeringsystem.ToString() + manufacturingcode.ToString() + productcode.ToString());
            return eancode;
        }
        private void btnsave_Click(object sender, EventArgs e)
                {
       querydb();//return of the fuction that query and add 1 to  
       Eangenerate();//fuction to return the barcode value
                   
            checkemptyness();//a fuction call to refer tothe below fuction validating textbox emptyness
            /*----start of insertion connection code----*/
               
        }
        /*-------start of fuction of checking the emptyness-----*/
      
        private void checkemptyness()
        {
        if (txtproductname.Text=="")
        {
            MessageBox.Show("please provide the product name");
            txtproductname.Focus();
        }
       
       
        else if (txtbuyingprice.Text == "")
        {
            MessageBox.Show("sales unit required");
            txtbuyingprice.Focus();
        }
        else if (txtquantity.Text == "")
        {
           MessageBox.Show("Quantity cannot be empty");
            txtquantity.Focus();
        }
        else if (txtpackage.Text == "")
        {
            MessageBox.Show("package cannot be empty");
            txtpackage.Focus();
        }
        else if(txtbarcode.Text=="")
        {
            MessageBox.Show("package field cannot be empty");
            txtbarcode.Focus();
        }

      
       
        else
        {
            try
            {
                DateTime date = txtexpirydate.Value;
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                myconn1.Open();
                string Query1 = "insert into stockdetails(productcode,productname,batchno,buyingprices,quantity,desctription,manufacturer,barcode,sellingprices,datetime,expirydate) values('" + Convert.ToInt32(txtproductcode.Text) + "','" + txtproductname.Text + "','" + txtbatchno.Text + "','" + Convert.ToDecimal(txtbuyingprice.Text) + "','" + Convert.ToInt64(txtquantity.Text) + "','" + txtpackage.Text + "','" + txtmanufacture.Text + "','" + Convert.ToInt32
                    (txtbarcode.Text) + "','" + Convert.ToDecimal(txtsellingprice.Text) + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + date.ToString("yyyy-MM-dd") + "')";
                           
                MySqlCommand mycommand1 = new MySqlCommand(Query1, myconn1);
                MySqlDataReader myreader1;
             
                myreader1 = mycommand1.ExecuteReader();//execution command
            

                MessageBox.Show("data saved");
                cleartextboxex();
                this.Refresh();
                while (myreader1.Read())
                {

                }
                myconn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error");
            }
           
        }
       

        /*-------end of fuction of checking the emptyness-----*/
        }

        private void Stock_Load(object sender, EventArgs e)
        {

            try
            {
                txtproductname.Focus();
                pstocksearch.Visible = false;
                btnuupdate.Enabled = false;
              
            }
            catch(Exception ex)
            {

            }
           
        }
       

        private void txtmedicinename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbatchno.Focus();
                e.Handled = true;
            }
        }

        private void txtbatchno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbuyingprice.Focus();
                e.Handled = true;
            }
        }

        private void txtunitprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txtquantity.Focus();
                e.Handled = true;
            }
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpackage.Focus();
                e.Handled = true;
            }
        }

        private void txtdescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbarcode.Focus();
                e.Handled = true;
            }
        }

       

        private void txtmanufacture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtbarcode.Focus();
                e.Handled = true;
            }
        }

        private void txtdateofmanucturing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                e.Handled = true;
            }
        }

        private void txtmedicinecode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsave.Focus();
                e.Handled = true;
            }
        }

        private void txtexpirydate_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtbarcode.Focus();
                e.Handled = true;
            }
        }

       

       

        

        private void txtdeliverydate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsave.Focus();
                e.Handled = true;
            }
        }
        private void cleartextboxex()
        {   //clearing of the text after saving of datas
            txtproductcode.Text = "";
            txtproductname.Text = "";
            txtbatchno.Text = "";
            txtbuyingprice.Text = "";
            txtquantity.Text = "";
            txtpackage.Text = "";
           txtmanufacture.Text = "";
           txtexpirydate.ResetText();
           pictureBox1.Image = null;           
            txtbarcode.Text = "";           
            txtsellingprice.Text = "";
            txteditquality.Text = "";           
            txtproductname.Focus();
            this.Refresh();
         
            //code to clear  datagridview
            try
            {
                dgvstock.DataSource = null;
                dgvstock.Rows.Clear();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Cancel again to clear");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            cleartextboxex();

            btnuupdate.Enabled = true;
            pstocksearch.Visible = true;            
            btnview.Visible = false;
            btnsave.Enabled=false;
            rdoid.Checked = true;
            gboxothers.Enabled = true;
            txtstocksearch.Focus();
            txtquantity.Enabled = false;
        }

        private void txtstocksearch_TextChanged(object sender, EventArgs e)
        {    //a  query to search th product for editing
            if (rdoproductname.Checked == true)
            {
                try
                {
                    if (txtstocksearch.Text == null)
                    {
                        MessageBox.Show("NUll DATA!", "NULL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                        myconn1.Open();
                        string query = "select productcode,productname,batchno,buyingprices,quantity,desctription,manufacturer,barcode,sellingprices,expirydate from stockdetails where productname like'%" + txtstocksearch.Text + "%' order by productcode";


                        MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);

                        MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                        myadapter.SelectCommand = mycommand1;
                        DataTable dTable = new DataTable();
                        myadapter.Fill(dTable);
                        int a = dTable.Columns.Count;

                        dgvstock.DataSource = dTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NUll DATA", "STOP!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
                //a  query to search th medicine for editing
            if (rdoid.Checked == true)
            {
                try
                {
                   /* txtstocksearch.KeyPress(object sender, EventArgs e)
                    {

                    }*/
                    if (txtstocksearch.Text == null)
                    {
                        MessageBox.Show("NUll DATA!", "NULL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        Int64 x = Convert.ToInt64(txtstocksearch.Text);
                        MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                        myconn1.Open();
                        string query = "select productcode,productname,batchno,buyingprices,quantity,desctription,manufacturer,barcode,sellingprices,expirydate from stockdetails where productcode like'%" + txtstocksearch.Text + "%' or barcode like'%" + x + "%' order by productcode";

                        MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);

                        MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                        myadapter.SelectCommand = mycommand1;
                        DataTable dTable = new DataTable();
                        myadapter.Fill(dTable);
                        dgvstock.DataSource = dTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("NUll DATA", "STOP!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
               
        }

        private void dgvstock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {

                DataGridViewRow dr = dgvstock.SelectedRows[0];

                txtproductcode.Text = dr.Cells[0].Value.ToString();
                txtproductname.Text = dr.Cells[1].Value.ToString();
                txtbatchno.Text = dr.Cells[2].Value.ToString();
                txtbuyingprice.Text = dr.Cells[3].Value.ToString();
                txtquantity.Text = dr.Cells[4].Value.ToString();
                txtpackage.Text = dr.Cells[5].Value.ToString();
                txtmanufacture.Text = dr.Cells[6].Value.ToString();
                txtbarcode.Text = dr.Cells[7].Value.ToString();
                txtsellingprice.Text = dr.Cells[8].Value.ToString();              
                txtexpirydate.Value = Convert.ToDateTime(dr.Cells[9].Value.ToString());
                /********/
                btnadd.Enabled = true;
               
              


            }
            catch(Exception ex)
            {
                MessageBox.Show("SORRY NO DATA!", "CAUTION!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          

        private void txtmecineid_TextChanged(object sender, EventArgs e)
        {

        }

  
        private void btnuupdate_Click(object sender, EventArgs e)
        {
              try
              {
                  DateTime date1 = txtexpirydate.Value;
                 MySqlConnection myconn2 = new MySqlConnection(cs.myconnection1);
                  myconn2.Open();
                  string query = "update stockdetails set productname='" + txtproductname.Text + "',batchno='" + txtbatchno.Text + "',buyingprices='" + Convert.ToDecimal(txtbuyingprice.Text) + "',quantity='" + Convert.ToInt32(txtquantity.Text) + "',desctription='" + txtpackage.Text + "',manufacturer='" + txtmanufacture.Text + "',barcode='" + Convert.ToInt64(txtbarcode.Text) + "',sellingprices='" + Convert.ToDecimal(txtsellingprice.Text) + "',datetime='" + DateTime.Now.ToString("yyyy-MM-dd") + "',expirydate='" + date1.ToString("yyyy-MM-dd")+ "'where productcode='" + txtproductcode.Text + "'";                     
               
                  MySqlCommand mycommand2 = new MySqlCommand(query, myconn2);
              
                  mycommand2.ExecuteNonQuery();//execution command
                  MessageBox.Show("you succeful updated  the stock");               
                  myconn2.Close();
                  cleartextboxex();
                  btnuupdate.Enabled = true;
                  pstocksearch.Visible = true;
                  btnview.Visible = false;
                  btnsave.Enabled = false;
                  rdoid.Checked = true;                
                  try
                  {
                      dgvstock.DataSource = null;
                      dgvstock.Rows.Clear();

                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("Error");
                  }
                  gboxothers.Enabled = true;
                  txtstocksearch.Focus();
                  txtquantity.Enabled = false;
                  
               
              }
              catch(Exception ex)
              {
                  MessageBox.Show("Database Error");
              }
          }

          private void btnclose_Click(object sender, EventArgs e)
          {    
              this.Hide();
              this.Close();
            
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;//openning of mdi form in a maximised state
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
        }

        private void txtdescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double result = 0.00;
                result = Convert.ToDouble(txtbuyingprice.Text) / Convert.ToDouble(txtquantity.Text);
                txtsellingprice.Text = Convert.ToString(result);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Database Error");
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Aboutus fr = new Aboutus();
            fr.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            catch (Exception ex)
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

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(" Magnify.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                cleartextboxex();
                pstocksearch.Visible = false;
                btnsave.Enabled = true;
                btnuupdate.Enabled = false;
                txtquantity.Enabled = true;
                gboxothers.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while clearing the data:");
            }
        }

        private void txtquantity_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {   

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_MouseHover(object sender, EventArgs e)
        {
            querydb();//return of the fuction that query and add 1 to medicine and supplier id field respectively
        }

        private void txtquantity_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpackage.Focus();
                e.Handled = true;
            }
        }


        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
           
        }

        private void editUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users fr = new users();
            fr.ShowDialog();
        }

        private void availableStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ViewStock frm = new ViewStock();
            frm.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
            frm.ShowDialog();*/
        }

        private void expiryingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Expiryingstock st = new Expiryingstock();
            st.WindowState = FormWindowState.Maximized;//openning of mdi form in a maximised state
            st.ShowDialog();*/
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       private void button3_Click_1(object sender, EventArgs e)
       {
           try
           {
               SaveFileDialog sf = new SaveFileDialog();
               sf.FileName = "EAN13"  + ".png";
               if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
               {
                   return;
               }
               querydb();
               Linear barcode = new Linear();
               barcode.Type = BarcodeType.EAN13;
               barcode.Data = Convert.ToString(Eangenerate());
               barcode.drawBarcode(sf.FileName);
               txtbarcode.Text = Convert.ToString(Eangenerate());
               Image img = Image.FromFile(sf.FileName);
               pictureBox1.Image = img;
           }
           catch(Exception ex)
           {
               MessageBox.Show("Error while generating Barcode");
           }
           
          
       }

       private void txtsellpackage_TextChanged(object sender, EventArgs e)
       {

       }

       private void button3_Click_2(object sender, EventArgs e)
       {
           try
           {
               if(txteditquality.Text!=null)
               {
                  int value = Convert.ToInt32(txteditquality.Text) + Convert.ToInt32(txtquantity.Text);
                  txtquantity.Text = Convert.ToString(value);
                  btnadd.Enabled = false;
                 
               }
               else
               {
                   MessageBox.Show("Check null value ");
                   txteditquality.Focus();
               }

           }
           catch(Exception ex)
           {
               MessageBox.Show("Incorrect update quantity");
               txteditquality.Focus();
           }

       }

      

     

       private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
           {
               e.Handled = false;
           }
           else
           {
               e.Handled = true;
           }
       }

       private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
       }

       private void txtbuyingprice_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               txtsellingprice.Focus();
               e.Handled = true;
           }
       }

       private void txtsellingprice_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               txtexpirydate.Focus();
               e.Handled = true;
           }

       }

       private void txtexpirydate_KeyDown_1(object sender, KeyEventArgs e)
       {

           if (e.KeyCode == Keys.Enter)
           {
               txtquantity.Focus();
               e.Handled = true;
           }
           
       }

       private void txtquantity_KeyDown_2(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               txtpackage.Focus();
               e.Handled = true;
           }

       }

       private void txtpackage_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               txtmanufacture.Focus();
               e.Handled = true;
           }

       }

       private void txtbuyingprice_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
           {
               e.Handled = false;
           }
           else
           {
               e.Handled = true;
           }
       }

       private void txtsellingprice_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
           {
               e.Handled = false;
           }
           else
           {
               e.Handled = true;
           }
       }

      
        
    
    }
}
