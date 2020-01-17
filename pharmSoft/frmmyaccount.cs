using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmSoft
{
    public partial class btnview2 : Form
    {

        ConnectionString cs = new ConnectionString();
        public btnview2()
        {
            InitializeComponent();
        }

        

        private void btnexpense_Click(object sender, EventArgs e)
        {
           try {
               
                 if (txtexpense.Text == "")
                {
                    MessageBox.Show("Expense amount empty");
                   txtexpense.Focus();
                }
                else
                {
                    DateTime date = dateTimePicker3.Value;
                    string Query = "insert into expense_cost(expense_id,expense_cost,datetime,user_id)values((select expense_id from expense where expense_type='" + cboexpense.SelectedItem + "'),'" + Convert.ToDouble(txtexpense.Text) + "','" + date.ToString("yyyy-MM-dd") + "','"+Convert.ToInt64(userid.Text)+"')  ";
                    MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                    MySqlCommand mycommand1 = new MySqlCommand(Query, myconn1);
                    myconn1.Open();
                    MySqlDataReader myreader = mycommand1.ExecuteReader();
                    MessageBox.Show("Saved");
                    cboexpense.SelectedIndex = -1;
                     txtexpense.Text = "";
                    dateTimePicker1.ResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!"+ex);

            }
        }

        private void btnview_Click_1(object sender, EventArgs e)
        {

            try
            {
                DateTime date = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                MySqlConnection myconn1 = new MySqlConnection(cs.myconnection1);
                myconn1.Open();
                string query = "select sellid,total from sells where datetime>='" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' and datetime<='" + date2.ToString("yyyy-MM-dd  HH:mm:ss ") + "'  ";


                MySqlCommand mycommand1 = new MySqlCommand(query, myconn1);

                MySqlDataAdapter myadapter = new MySqlDataAdapter();//for offline connection we use mysqldataadapter
                myadapter.SelectCommand = mycommand1;
                DataTable dTable = new DataTable();
                myadapter.Fill(dTable);
                int a = dTable.Columns.Count;

                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        private void cboexpense_MouseClick(object sender, MouseEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            Double total=dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t=>Convert.ToDouble(t.Cells[1].Value));
            txtview.Text = Convert.ToString(total);
           
            }
            catch
            {
                MessageBox.Show("error while getting the total try again");
            }


        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string kk = "       ";
           
            string sspace = " ";
                              
            string underline = "---------------------------------------------------------------------------------------------";
            try
            {

                Graphics graphics = e.Graphics;
                Font font = new Font("Courier New", 10);
                float fontHeight = font.GetHeight();
                int startX = 5;
                int startY = 45;
                int Offset = 40;
                StringFormat str = new StringFormat();
                str.Alignment = StringAlignment.Near;
                str.LineAlignment = StringAlignment.Center;
                str.Trimming = StringTrimming.EllipsisCharacter;
                Pen p = new Pen(Color.White, 2.5f);
                graphics.DrawString(" TOP LIFE  COSMETICS CENTRE", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(kk + "MACHAKOS", new Font("Courier New", 12), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(sspace + "P.O BOX:" + " 17433-00100 " + "NAIROBI", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(sspace + "TEL NO:" + " 0720309086 " + "Tel:" + "0722363094 " + " ", new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(
                    sspace + "DateTime:".PadRight(10) + DateTime.Now.ToShortDateString().PadRight(10) + DateTime.Now.ToShortTimeString(), new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
                graphics.DrawString(lblFull_Name.Text + "  " + "sales amounted :" + "  " + txtview.Text, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;

                graphics.DrawString(underline, new Font("Courier New", 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
               

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
        private void printtotalreceipt()
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
                MessageBox.Show(ex.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printtotalreceipt();

        }

        private void txtview_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
