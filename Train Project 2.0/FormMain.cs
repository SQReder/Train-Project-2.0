using System;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private void btnLoadNodes_Click(object sender, EventArgs e)
        {
            var jr = junctionEditor.Repository;
            var nodes = jr.ListNodes();
            var titles = nodes.Select(n => n.Title).ToArray();

            cbStartNode.Items.Clear();
            cbEndNode.Items.Clear();

            cbStartNode.Items.AddRange(titles);
            cbEndNode.Items.AddRange(titles);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            var jr = junctionEditor.Repository;
            var pf = new PathFinder(jr);

            var startNode = cbStartNode.Text;
            var endNode = cbEndNode.Text;

            lPath.Items.Clear();
            var list  = pf.FindAllPaths(startNode, endNode);
            foreach (var path in list)
            {
                foreach (var link in path)
                {
                    var text = link.From.Title + " > " + link.To.Title;
                    lPath.Items.Add(text);
                }
                lPath.Items.Add(" === ");
            }
        }
    }
}
