namespace TotalCommander
{
    public partial class Form1 : Form
    {
        public void AddAdress()
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var dirInfo in dirs)
            {
                listBox1.Items.Add(dirInfo);
            }
            FileInfo[] files = dir.GetFiles();
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
            if (textBox1.Text == "") textBox1.Text = "C:\\";
            textBox1.Text=Path.Combine(textBox1.Text ,listBox1.SelectedItem.ToString());
            AddAdress();
        }
    }
}
