using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace xmlDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Person> p1 = new List<Person>();
        XmlSerializer serial = new XmlSerializer(typeof(List<Person>));

        private void button1_Click(object sender, EventArgs e)
        {
            
            p1.Add(new Person() { Id = "ATR/9578/09", Name = "Tariku W/Michael" });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\tariku.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, p1);
                MessageBox.Show("Created");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Person>));
            
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\tariku.xml", FileMode.Open, FileAccess.Read))
            {
                p1 = serial.Deserialize(fs) as List<Person>;
                dataGridView1.DataSource = p1;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            p1.Add(new Person() { Id = textBox2.Text, Name = textBox1.Text });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\tariku.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, p1);
                MessageBox.Show("user added");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
