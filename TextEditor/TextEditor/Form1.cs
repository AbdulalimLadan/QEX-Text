using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename = "";

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Form1.ActiveForm.Text ="QEX Text";
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Open a file..";         
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    filename = openFile.FileName;
                    sr.Close();
                }
                Form1.ActiveForm.Text = filename + " - QEX Text";
            }            
            
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save file as..";            
            saveFile.Filter = "Text FIle| *.txt";            
            if (saveFile.ShowDialog() == DialogResult.OK)
            {                                                
                    StreamWriter txtOutput = new StreamWriter(saveFile.FileName);
                    filename = saveFile.FileName;
                    txtOutput.Write(richTextBox1.Text);
                    txtOutput.Close();                                
            }
            Form1.ActiveForm.Text = filename + " - QEX Text";
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void selectAllButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton.PerformClick();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoButton.PerformClick();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoButton.PerformClick();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripButton.PerformClick();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripButton.PerformClick();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton.PerformClick();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectAllButton.PerformClick();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Do something when closing e_e
            MessageBox.Show("Do you want to save changes to \n" + filename + "?", "QEX text", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
        }
    }
}
