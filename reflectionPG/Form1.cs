using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace reflectionPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public void ListVariousStats(Type t)
        {
          textBox4.Text += t.BaseType;
            textBox4.Text += "Is type abstract? {0}" +  t.IsAbstract.ToString()+",";
            textBox4.Text += "Is type sealed? {0} " + t.IsSealed.ToString() + ",";
            textBox4.Text += "Is type generic? {0}" + t.IsGenericTypeDefinition.ToString() + ",";
            textBox4.Text += "Is type a class type? {0}" + t.IsClass.ToString() + "\r\n";
           
        }

        public void ListProps(Type t)
        {
            
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
            {
                textBox4.Text += name + "\r\n";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Type ts = typeof(Form);
            label1.Text = ts.ToString();
            
            
            MethodInfo[] m = ts.GetMethods();
            foreach (MethodInfo mi in m)
            {
                textBox1.Text += mi.Name + "\r\n";
            }

            var fieldNames = from f in ts.GetFields() select f.Name;
            foreach (var name in fieldNames)
            {
                textBox2.Text += name + "\r\n";
            }
            var ifaces = from i in ts.GetInterfaces() select i;
            foreach (Type i in ifaces)
            {
                textBox3.Text += i.Name + "\r\n";
            }
            ListVariousStats(ts);
            ListProps(ts);
        }
    }
}
