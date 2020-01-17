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
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;

using Microsoft.VisualBasic;
namespace pharmSoft
{
    public partial class Sales : Form
    {

       
        ConnectionString cs = new ConnectionString();
        
        public Sales()
        {
            InitializeComponent();
            cbopayment.Items.Add("Cash");
            cbopayment.Items.Add("Mpesa");

            try
            {
               
                this.lbldate.Text = DateTime.Now.ToString();
                this.lblsdate.Text = DateTime.Now.ToString();

                timer1.Tick += new EventHandler(timer1_Tick);
                this.timer1.Interval = 1000;
                this.timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        
        public string GetUniqueKey()
        {


            MySqlConnection con = new MySqlConnection(cs.myconnection1);
            con.Open();
            string Query = "select max(sellid) from sells";//selection string
            MySqlCommand mycommand1 = new MySqlCommand(Query, con);



            string prev_value = mycommand1.ExecuteScalar().ToString();
            int current_id = Convert.ToInt32(prev_value) + 1;

            con.Close();
            return Convert.ToString(current_id);

        }
        private void timer1_Tick(Object sender, EventArgs e)
        {
            this.lbldate.Text = DateTime.Now.ToString();
            this.lblsdate.Text = DateTime.Now.ToString();
        }
      

        private void lbtnHome_Click(object sender, EventArgs e)
        {
            // open  the main form and close the sales form
            this.Hide();
            this.Close();
        }

       

        private void Sales_Load(object sender, EventArgs e)
        {   
            txteditprice.Visible = false;
            cbopayment.SelectedIndex = 0;
            txtproductcode.Focus(); 
            


        } 


        private void prinreceipt()
        {
            try
            {
                PrintDialog printdialog = new PrintDialog();
                PrintPreviewDialog PrevieDialog = new PrintPreviewDialog();
                PrintDocument printdocument = new PrintDocument();
              printdialog.Document = printdocument;
                PrevieDialog.Document = printdocument;

                printdocument.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);              
                printdocument.Print();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error");
                return;
            }
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string kk="       ";
            string kidogo = "    ";
            string push = "  ";
            string ssspace = "   ";
            string space = " ";
            string sspace = " ";
            string blankspace = "                                                                                             ";
            string blackspaceshort = "                          ";
            string underline = "---------------------------------------------------------------------------------------------";
            try
            {

                Graphics graphics = e.Graphics;
                Font font = new Font("Constantia", 10);
                float fontHeight = font.GetHeight();
                int startX = 5;
                int startY = 45;
                int Offset = 40;
                StringFormat str = new StringFormat();
                str.Alignment = StringAlignment.Near;
                str.LineAlignment = StringAlignment.Center;
                str.Trimming = StringTrimming.EllipsisCharacter;
                Pen p = new Pen(Color.White, 2.5f);
                graphics.DrawString(" WINNIE bOUTIQUE", new Font("Constantia", 12), new SolidBrush(Color.Black), startX, startY + Offset);
               Offset = Offset + 20;
                graphics.DrawString(kk + "MACHAKOS", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
               Offset = Offset + 20;
               graphics.DrawString(sspace + "P.O BOX:" + "     " + "NAIROBI", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
               Offset = Offset + 20;
               graphics.DrawString(sspace + "TEL NO:" + "          " + "Tel:" + "       " + " ", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
              Offset = Offset + 20;               
                graphics.DrawString(
                    sspace + "DateTime:".PadRight(10) + DateTime.Now.ToShortDateString().PadRight(10) + DateTime.Now.ToShortTimeString(), new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
               Offset = Offset + 20;
               graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(underline, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("PRODUCT " + ssspace + "PRICE" + ssspace + "QTY" + ssspace + "AMOUNT", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {

                    graphics.DrawString(kidogo + ListView1.Items[i].SubItems[1].Text + ssspace + sspace + ListView1.Items[i].SubItems[3].Text + kidogo + "x" + kidogo + ListView1.Items[i].SubItems[4].Text + kidogo + ListView1.Items[i].SubItems[5].Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                    graphics.DrawString(kidogo + ListView1.Items[i].SubItems[2].Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                    Offset = Offset + 20;
                  
                }
                Offset = Offset + 20;
                graphics.DrawString(underline, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("TOTAL:" + blackspaceshort + txtTotal.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Discount:" + blackspaceshort + txtDiscount.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("CASH:" + blackspaceshort + txtcash.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("CHANGE:" + blackspaceshort + txtPaymentDue.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Prices are inclusive of VAT as is applicable", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Good once sold are not refundable", new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("You were served by :" + space + lblFull_Name.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString("Sale No:" + lblsalesid.Text, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(kk + "End of Legal Receipt" + space, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(blankspace, new Font("Constantia", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
              

            }
            catch (Exception er)
            {
                MessageBox.Show("Database Error");
                return;
            }
        }
        public int CheckQuantity()
        {
            int quantity = 0;
            try
            {

                MySqlConnection con = new MySqlConnection(cs.myconnection1);
                con.Open();
               string Query = "";
                MySqlCommand mycommand1 = new MySqlCommand(Query, con);

                string squantinty = mycommand1.ExecuteScalar().ToString();
                quantity = Convert.ToInt32(squantinty);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get Quantity of the selected product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            return quantity;
        }
    

        public double subtot()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }
        public void Calculate()
        {
          
           
            int val2 = 0;
            int val3 = 0;
            int val4 = 0;
            int val5 = 0;          
            int.TryParse(txtSubTotal.Text, out val2);
            int.TryParse(txtTotal.Text, out val4);
            int.TryParse(txtDiscount.Text, out val3);
            int.TryParse(txtcash.Text, out val5);       
             val4 =  val2 - val3;
            txtTotal.Text = val4.ToString();
            lbltotal.Text = val4.ToString();
           
            

        }


        private void Reset()
        {
          
           
            ListView1.Items.Clear();
           

            txtSubTotal.Text = "";           
            txtTotal.Text = "";
            txtcash.Text = "";
            txtPaymentDue.Text = "";
            txteditprice.Visible = false;
            Save.Enabled = true;
            lbltotal.Text = "";
            btnRemove.Enabled = false;           
            ListView1.Enabled = true;
           

        }


      

        

        private void txtTotalPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ListView1.Items.Count == 0)
            {
                MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcash.Text = "";
              
                return;
            }
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int.TryParse(txtTotal.Text, out val1);
            int.TryParse(txtcash.Text, out val2);
            int I = (val1 - val2);
            txtPaymentDue.Text = I.ToString();
        }



       
        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }
      
        
        private void Save_Click(object sender, EventArgs e)
        {

            
            try
            {
                
                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    MySqlConnection conn = new MySqlConnection(cs.myconnection1);
                    conn.Open();
                    string query = "select quantity from stockdetails where 	productcode='" + ListView1.Items[j].SubItems[1].Text + "'";
                    MySqlCommand mycommand1 = new MySqlCommand(query, conn);
                    string prev_value = mycommand1.ExecuteScalar().ToString();

                    if (Convert.ToInt32(prev_value) < 1)
                    {
                        MessageBox.Show(ListView1.Items[j].SubItems[1].Text + " " + "product out of stock");
                        return;
                    }
                    else if (Convert.ToInt32(prev_value) < Convert.ToInt32(ListView1.Items[j].SubItems[4].Text))
                    {
                        MessageBox.Show(ListView1.Items[j].SubItems[1].Text + " " + "The buying quantity outdo the available quantity");
                        return;
                    }
                   
                    }

                    if (txtcash.Text == "")
                    {
                        MessageBox.Show("Please enter Total payment", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtcash.Focus();
                        return;
                    }

                    if (ListView1.Items.Count == 0)
                    {
                        MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }



                    MySqlConnection con = new MySqlConnection(cs.myconnection1);

                    try
                    {
                        con.Open();

                        string Query = "insert into sells(sellid,modeofpayment,total,discount,cash,datetime) VALUES ('" + GetUniqueKey() + "','" + cbopayment.SelectedItem + "','" + Convert.ToDouble(txtTotal.Text) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + Convert.ToDouble(txtcash.Text) + "','" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "')";
                        MySqlCommand mycommand1 = new MySqlCommand(Query, con);
                        MySqlDataReader myreader = mycommand1.ExecuteReader();

                        if (con.State == ConnectionState.Open)
                        {
                            con.Close();
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex+"Error in database: " );
                        return;
                    }

                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {

                        try
                        {
                            
                            con = new MySqlConnection(cs.myconnection1);
                            string Query2 = "insert Into selldetails(sellid,userid,productcode,qty,subtotal,datetime) VALUES ('" + sellid() + "','" + Convert.ToInt32(userid.Text) + "','" + ListView1.Items[i].SubItems[1].Text + "','" + ListView1.Items[i].SubItems[4].Text + "','" + ListView1.Items[i].SubItems[5].Text + "','" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "');"
                                + "INSERT INTO cur_sells(productcode,buyingprice,sellingprice,sellid) VALUES('" + ListView1.Items[i].SubItems[1].Text + "',(SELECT 	buyingprices FROM stockdetails WHERE productcode='" + ListView1.Items[i].SubItems[1].Text + "'),'" + ListView1.Items[i].SubItems[3].Text + "','" + sellid() + "')";
                            con.Open();
                            MySqlCommand mycommand1 = new MySqlCommand(Query2, con);
                            MySqlDataReader myreader1;
                            myreader1 = mycommand1.ExecuteReader();//execution command                          

                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex+"Database Error" );
                            return;
                        }
                    }



                    updatequantity();

                    MessageBox.Show("Successfully Sales", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    try
                    {
                     prinreceipt();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                    Reset();
                   
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                

        }
      /*  void backup()
        {
            try
            {

                string file = "F:\\lifetopdatabse.sql";
                MySqlBackup mb = new MySqlBackup(cs.myconnection1);
                mb.ExportInfo.FileName = file;
                mb.ExportInfo.EnableEncryption = true;
                mb.ExportInfo.EncryptionKey = "danny4702";
                mb.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }*/
        private int settingid()
        {
            MySqlConnection conn = new MySqlConnection(cs.myconnection1);
            conn.Open();
            string query = "select   max(settingid) from  printsetting ";
            MySqlCommand mycommand1 = new MySqlCommand(query, conn);

            string x = mycommand1.ExecuteScalar().ToString();//execution command
            int y = Convert.ToInt32(x);

            return y;
        }

      
       
        private void updatequantity()
        {
            try
            {

                
                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    MySqlConnection conn = new MySqlConnection(cs.myconnection1);
                    conn.Open();
                    string query = "select quantity from stockdetails where 	productcode='" + ListView1.Items[j].SubItems[1].Text + "'";
                    MySqlCommand mycommand1 = new MySqlCommand(query, conn);
                    string prev_value = mycommand1.ExecuteScalar().ToString();
                  
                    int current_id = Convert.ToInt32(prev_value) - Convert.ToInt32(ListView1.Items[j].SubItems[4].Text);
                    conn.Close();
                    conn.Open();
                    string Query = "update stockdetails set quantity='" + current_id + "' where productcode='" + ListView1.Items[j].SubItems[1].Text + "'";
                    MySqlCommand mycommand2 = new MySqlCommand(Query,conn);                  
                    MySqlDataReader myreader = mycommand2.ExecuteReader();
                    conn.Close();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error ! while updating" + " " );
            }
           
        }
      

        private void btnRemove_Click(object sender, EventArgs e)
        {


            try
            {
                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                     txtSubTotal.Text = subtot().ToString();
                    Calculate();
                }

                btnRemove.Enabled = false;
                if (ListView1.Items.Count == 0)
                {
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void NewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

       

        private void cmbDrugName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection con = new MySqlConnection(cs.myconnection1);
                con.Open();
              //  string Query = "SELECT drug_sells_details.Drug_ID,drug_sells_details.Selling_Price from drug_sells_details   INNER JOIN drugs ON drug_sells_details.Drug_ID=drugs.Drug_ID WHERE  drugs.Drug_Name  = '""'";
              //  MySqlCommand mycommand1 = new MySqlCommand(Query, con);

                //MySqlDataReader myreader = mycommand1.ExecuteReader();

              /*  if (myreader.Read())
                {
                    txtDrugID.Text = myreader.GetInt32(0).ToString().Trim();
                 
                }
                if ((myreader != null))
                {
                    myreader.Close();
                }*/
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               

            }

            catch (Exception ex)
            {
                MessageBox.Show("Database Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
            txteditprice.Visible = true;
        }

       
      

        private void txtTotalPayment_TextChanged_1(object sender, EventArgs e)
        {

            int valx=0;
            int valy = 0;
            int.TryParse(txtcash.Text, out valx);
            int.TryParse(txtTotal.Text, out valy);
            int change =valx-valy;

            txtPaymentDue.Text= Convert.ToString(change);
            lblchange.Text = Convert.ToString(change);
        }

       

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            users fr = new users();
            fr.ShowDialog();

        }

      

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            users fr = new users();
            fr.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            Aboutus fr = new Aboutus();
            fr.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {    try
             
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

        private void calendarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void stickyNoteToolStripMenuItem_Click(object sender, EventArgs e)
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

       

        private void txtDrugID_Validating(object sender, CancelEventArgs e)
        {
            /*if (txtDrugID.Text != null)
            {
                char[] chars = e.ToString().ToCharArray();
                foreach (char c in chars)
                {
                    if (char.IsDigit(c) == false)
                    {
                        MessageBox.Show("You have to enter digits only");
                        e.Cancel = true;
                        break;
                    }
                }
            }*/
        }

        private void txtSaleQty_Validating(object sender, CancelEventArgs e)
        {
          /*  if(!System.Text.RegularExpressions.Regex.IsMatch(txtSaleQty,"^[0-9]"))
            {
                MessageBox.Show("Only digits are allowed");
            }*/
        }

        private void txtTotalPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Save.Focus();
                e.Handled = true;
            }
        }

        

        private void cbopayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               if( cbopayment.SelectedIndex == 1)
               {
                   txtcash.Focus();
               }
                e.Handled = true;
            }
        }
        private int sellid()
        {
            MySqlConnection conn = new MySqlConnection(cs.myconnection1);
            conn.Open();
            string query = "select   max(sellid) from  sells ";
            MySqlCommand mycommand1 = new MySqlCommand(query, conn);

            string x = mycommand1.ExecuteScalar().ToString();//execution command
            int y = Convert.ToInt32(x);
           lblsalesid.Text = x;
            return y;
        }
       

      

        private void txtproductcode_KeyDown(object sender, KeyEventArgs e)
        {
            string input = "1";           
            //Write a code to retrive the product code from database
            //this textbox shouldnt accept anyother apart from interger product code
            //this textbox has no auto complete and the user has to know the product code
            //the code once complete is committed by entering the enter key
            //////////////////********************************///////////////////////////
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(cs.myconnection1);

                    string Query2 = "select productcode,productname,sellingprices from stockdetails where productcode='" + txtproductcode.Text + "' or 	barcode='" + txtproductcode.Text + "' ";
                    con.Open();
                    MySqlCommand mycommand1 = new MySqlCommand(Query2, con);
                    MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                    myadapter.SelectCommand = mycommand1;
                    DataSet ds2 = new DataSet();
                    myadapter.Fill(ds2);
                    int s = (myadapter.Fill(ds2));
                    if (s < 1)
                    {

                        MessageBox.Show("No such product", "No such product in Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtproductcode.Clear();
                        txtproductcode.Focus();
                        return;

                    }
                    if (ListView1.Items.Count == 0)
                    {

                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(ds2.Tables[0].Rows[0][0].ToString());
                        item.SubItems.Add(ds2.Tables[0].Rows[0][1].ToString());
                        item.SubItems.Add(ds2.Tables[0].Rows[0][2].ToString());
                        item.SubItems.Add(input);
                        Double x = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                        item.SubItems.Add(Convert.ToString(x));
                        ListView1.Items.Add(item);

                        txtSubTotal.Text = subtot().ToString();
                        lbltotal.Text = subtot().ToString();
                        Calculate();
                        txtproductcode.Text = "";
                        txtproductcode.Focus();

                        return;
                    }
                    /*******************another*************************/
                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        if (ListView1.Items[j].SubItems[1].Text == ds2.Tables[0].Rows[0][0].ToString())
                        {
                            ListView1.Items[j].SubItems[1].Text = ds2.Tables[0].Rows[0][0].ToString();
                            ListView1.Items[j].SubItems[2].Text = ds2.Tables[0].Rows[0][1].ToString();
                            ListView1.Items[j].SubItems[3].Text = ds2.Tables[0].Rows[0][2].ToString();
                            ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(input)).ToString();
                            Double x = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                            ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(x)).ToString();
                            txtSubTotal.Text = subtot().ToString();
                            lbltotal.Text = subtot().ToString();
                            Calculate();
                            txtproductcode.Text = "";
                            txtproductcode.Focus();
                            return;

                        }
                    }
                    /*******************another********************************/
                    ListViewItem lst1 = new ListViewItem();

                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][0].ToString());
                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][1].ToString());
                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][2].ToString());
                    lst1.SubItems.Add(input);
                    Double y = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                    lst1.SubItems.Add(Convert.ToString(y));
                    ListView1.Items.Add(lst1);
                    txtSubTotal.Text = subtot().ToString();
                    lbltotal.Text = subtot().ToString();
                    Calculate();
                    txtproductcode.Text = "";
                    txtproductcode.Focus();
                    return;
                    con.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Database Error");
                }
                e.Handled = true;
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Sale Price", "0", -1, -1);
            ListView1.FocusedItem.SubItems[3].Text = input;
        }

      
        private void txtproductcode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txteditprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcash_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txteditprice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                try
                {
                    if (txteditprice.Text == "")
                    {
                        MessageBox.Show("No price indicated");

                        txteditprice.Focus();
                    }
                    else
                    {

                        ListView1.FocusedItem.SubItems[3].Text = txteditprice.Text;
                        Double x = Convert.ToDouble(ListView1.FocusedItem.SubItems[3].Text) * Convert.ToDouble(ListView1.FocusedItem.SubItems[4].Text);
                        ListView1.FocusedItem.SubItems[5].Text = Convert.ToString(x);
                        txtSubTotal.Text = subtot().ToString();
                        lbltotal.Text = subtot().ToString();
                        Calculate();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
                txteditprice.Clear();              
                txtproductcode.Focus();
                e.Handled = true;
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {            
            try
        {
             txtname.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
             MySqlConnection conn = new MySqlConnection(cs.myconnection1);
              conn.Open();
              string query = "select productname from stockdetails  where productname like'%" + txtname.Text + "%' ";
                    MySqlCommand mycommand1 = new MySqlCommand(query, conn);
                    MySqlDataReader reader = mycommand1.ExecuteReader();

                    while (reader.Read())
            {
                col.Add(reader.GetString(0));
            }
          txtname.AutoCompleteCustomSource = col;
                    conn.Close();

                   
           
        }
        catch
        {
        }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            string input = "1";
            //Write a code to retrive the product code from database
            //this textbox shouldnt accept anyother apart from interger product code
            //this textbox has no auto complete and the user has to know the product code
            //the code once complete is committed by entering the enter key
            //////////////////********************************///////////////////////////
            
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    MySqlConnection con = new MySqlConnection(cs.myconnection1);

                    string Query2 = "select productcode,productname,sellingprices from stockdetails where productname='" + txtname.Text + "'  ";
                    con.Open();
                    MySqlCommand mycommand1 = new MySqlCommand(Query2, con);
                    MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                    myadapter.SelectCommand = mycommand1;
                    DataSet ds2 = new DataSet();
                    myadapter.Fill(ds2);
                    int s = (myadapter.Fill(ds2));
                    if (s < 1)
                    {

                        MessageBox.Show("No such product", "No such product in Database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtproductcode.Clear();
                        txtproductcode.Focus();
                        return;

                    }
                    if (ListView1.Items.Count == 0)
                    {

                        ListViewItem item = new ListViewItem();
                        item.SubItems.Add(ds2.Tables[0].Rows[0][0].ToString());
                        item.SubItems.Add(ds2.Tables[0].Rows[0][1].ToString());
                        item.SubItems.Add(ds2.Tables[0].Rows[0][2].ToString());
                        item.SubItems.Add(input);
                        Double x = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                        item.SubItems.Add(Convert.ToString(x));
                        ListView1.Items.Add(item);

                        txtSubTotal.Text = subtot().ToString();
                        lbltotal.Text = subtot().ToString();
                        Calculate();
                        txtproductcode.Text = "";
                        txtproductcode.Focus();

                        return;
                    }
                    /*******************another*************************/
                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        if (ListView1.Items[j].SubItems[1].Text == ds2.Tables[0].Rows[0][0].ToString())
                        {
                            ListView1.Items[j].SubItems[1].Text = ds2.Tables[0].Rows[0][0].ToString();
                            ListView1.Items[j].SubItems[2].Text = ds2.Tables[0].Rows[0][1].ToString();
                            ListView1.Items[j].SubItems[3].Text = ds2.Tables[0].Rows[0][2].ToString();
                            ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(input)).ToString();
                            Double x = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                            ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(x)).ToString();
                            txtSubTotal.Text = subtot().ToString();
                            lbltotal.Text = subtot().ToString();
                            Calculate();
                            txtproductcode.Text = "";
                            txtproductcode.Focus();
                            return;

                        }
                    }
                    /*******************another********************************/
                    ListViewItem lst1 = new ListViewItem();

                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][0].ToString());
                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][1].ToString());
                    lst1.SubItems.Add(ds2.Tables[0].Rows[0][2].ToString());
                    lst1.SubItems.Add(input);
                    Double y = Convert.ToDouble(ds2.Tables[0].Rows[0][2].ToString()) * Convert.ToDouble(input);
                    lst1.SubItems.Add(Convert.ToString(y));
                    ListView1.Items.Add(lst1);
                    txtSubTotal.Text = subtot().ToString();
                    lbltotal.Text = subtot().ToString();
                    Calculate();
                    txtproductcode.Text = "";
                    txtproductcode.Focus();
                    return;
                    con.Close();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Error" );
                }


                    e.Handled = true;
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                //edit qty of the selected product
                if (ListView1.FocusedItem.Equals(null))
                {
                    MessageBox.Show("Please select an item that you want edit");
                    return;
                }
                else
                {
                    String input = Microsoft.VisualBasic.Interaction.InputBox("Product QTY", "Enter the product quantity", "1", 1, 1);
                    int s = Convert.ToInt32(input);
                    if(s<1)
                    {
                        input =" 1";
                    }


                    ListView1.FocusedItem.SubItems[4].Text = input;
                    Double x = Convert.ToDouble(ListView1.FocusedItem.SubItems[3].Text) * Convert.ToDouble(ListView1.FocusedItem.SubItems[4].Text);
                    ListView1.FocusedItem.SubItems[5].Text = Convert.ToString(x);
                    txtSubTotal.Text = subtot().ToString();
                    lbltotal.Text = subtot().ToString();
                    Calculate();
                }
            }
            catch
            {

            }
                      
        }

       
        

       
        }

       
       

}
