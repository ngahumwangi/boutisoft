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
    public partial class frmavailablestock : Form
    {
        public frmavailablestock()
        {
            InitializeComponent();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void frmavailablestock_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
                {
                    MessageBox.Show("Problem while loading report ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
