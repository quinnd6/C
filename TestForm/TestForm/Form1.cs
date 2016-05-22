﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Information info = new Information();
                info.Data1 = textBoxData1.Text;
                info.Data2 = textBoxData2.Text;
                info.Data3 = textBoxData3.Text;
                SaveXML.SaveData(info, "data.xml");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                textBoxData1.Text = info.Data1;
                textBoxData2.Text = info.Data2;
                textBoxData3.Text = info.Data3;


            }
        }
    }
}
