using System;
using System.Windows.Forms;

namespace TrainProject
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void junctionEditor1_Load(object sender, EventArgs e)
        {

        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            tbSerializedJunction.Text = junctionEditor.Repository.Serialize();
        }
    }
}
