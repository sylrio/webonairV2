using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace lireecrire1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Nouveau DataSet webonair
            DataSet ds = new DataSet();
            ds.DataSetName = "webonair";
            // Nouvelle Table page
            DataTable dt = new DataTable();
            dt.TableName = ("page");
            // Ajout des colonnes dans la table page
            dt.Columns.Add("titre");
            dt.Columns.Add("lien1");

            // Creation de la Table page dans le DataSet webonair
            ds.Tables.Add(dt);

            // Recuperation de chaque ligne du DataGridView1 et Ajout dans la Table page 
            // des 9 derniere ligne
            // (1 ligne= 1 Table page)
            for (int i = 0; i < 9; i++)
            {
                DataRow row = ds.Tables["page"].NewRow();
                row["titre"] = dataGridView1.Rows[i].Cells["titre"].Value;
                row["lien1"] = dataGridView1.Rows[i].Cells["lien1"].Value;
                ds.Tables["page"].Rows.Add(row);

            }

            //Supression des donnees du DataGridView1
            dataGridView1.Rows.Clear();

            // Ajout de la saisie dans dataGridView1
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = richTextBox1.Text;
            dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;


            // Ajout de la table page(9 lignes) dans datagriedview1
            foreach (DataRow item in ds.Tables["page"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();

            }

            //Supression des donnees de la table page
            ds.Tables["page"].Clear();

            // Recuperation de chaque ligne du DataGridView1 et Ajout dans la Table page 
            // des 10 lignes
            // (1 ligne= 1 Table page)

            for (int i = 0; i < 10; i++)
            {
                DataRow row = ds.Tables["page"].NewRow();
                row["titre"] = dataGridView1.Rows[i].Cells["titre"].Value;
                row["lien1"] = dataGridView1.Rows[i].Cells["lien1"].Value;
                ds.Tables["page"].Rows.Add(row);

            }

            // Ecriture du DataGridView1 (DataSet webonair) dans Xml
            ds.WriteXml("data.xml");



            //suppression de la saisie dans les box
            richTextBox1.Text = null;
            textBox1.Text = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                string valeur1 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                try
                {
                    System.Diagnostics.Process.Start(valeur1);

                }
                catch { MessageBox.Show("Le lien n'est pas valide"); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Supression de DataGridView1
            dataGridView1.Rows.Clear();

            // Nouveau DataSet des donnees du Xml
            DataSet ds = new DataSet();
            ds.ReadXml("data.xml");

            // Creation de chaque ligne de DataGridView1 avec chaque Table page du Xml
            foreach (DataRow item in ds.Tables["page"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                // Nouveau DataSet des donnees du Xml
                DataSet ds = new DataSet();
                ds.ReadXml("data.xml");

                // Creation de chaque ligne de DataGridView1 avec chaque Table page du Xml
                foreach (DataRow item in ds.Tables["page"].Rows)
                {

                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();

                }
            }

            else
            {
                // Nouveau DataSet webonair
                DataSet ds = new DataSet();
                ds.DataSetName = "webonair";
                // Nouvelle Table page
                DataTable dt = new DataTable();
                dt.TableName = ("page");
                // Ajout des colonnes dans la table page
                dt.Columns.Add("titre");
                dt.Columns.Add("lien1");

                // Creation de la Table page dans le DataSet webonair
                ds.Tables.Add(dt);
                // Creation des lignes
                for (int i = 0; i < 9; i++)
                {
                    dt.Rows.Add("", "");
                }
                // Ecriture du DataGridView1 (DataSet webonair) dans Xml
                ds.WriteXml("data.xml");

                // Nouveau DataSet des donnees du Xml
                ds.ReadXml("data.xml");

                // Creation de chaque ligne de DataGridView1 avec chaque Table page du Xml
                foreach (DataRow item in ds.Tables["page"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                }
            }
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://managerv3.viewsurf.com/tv_interface");

            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://maps.coyotesystems.com/bfmtv/index.php");

            }
            catch { MessageBox.Show("Le lien n'est pas valide"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://twitter.com/login");

            }
            catch { }
        }

    }
}