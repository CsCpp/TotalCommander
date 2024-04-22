using System.Diagnostics;

namespace TotalCommander
{
    public partial class Form1 : Form
    {
        public void AddAdress()
        {
            listBox1.Items.Clear();
            //listBox1.ForeColor = Color.Blue;
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var dirInfo in dirs)
            {
                listBox1.Items.Add(dirInfo);
            }
            FileInfo[] files = dir.GetFiles();
            // listBox1.BackColor = Color.Black; 
           // listBox1.ForeColor = Color.Black;
            foreach (var file in files)
            {
                listBox1.Items.Add(file);
               
            }

        }
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "C:\\";
            AddAdress();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "") textBox1.Text = "C:\\";
                AddAdress();
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()))== "")
            {
                if (textBox1.Text == "") textBox1.Text = "C:\\";
                try
                {
                    textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                }
                catch (Exception)
                {

                }
                AddAdress();
            }
            else
            {
                string str;
                str = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());
                Process.Start(str);
            }
          

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length-1]=='\\')
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length-1);   
                while(textBox1.Text[textBox1.Text.Length - 1] != '\\' )
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }

            }
            else if(textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
            }
            if (textBox1.Text == "") textBox1.Text = "C:\\";
            AddAdress();
        }
    }
}
