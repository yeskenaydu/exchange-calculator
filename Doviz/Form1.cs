using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;   

namespace Doviz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoc = new XmlDocument();
            xmldoc.Load(bugun);
            string USDal = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteBuying").InnerXml;
            label5.Text = USDal;
            string EURal = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteBuying").InnerXml;
            label4.Text = EURal;
            string GBPal = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteBuying").InnerXml;
            label6.Text = GBPal;
            string USDsat = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='USD']/BanknoteSelling").InnerXml;
            label10.Text = USDsat;
            string EURsat = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='EUR']/BanknoteSelling").InnerXml;
            label9.Text = EURsat;
            string GBPsat = xmldoc.SelectSingleNode("Tarih_Date/Currency [@Kod='GBP']/BanknoteSelling").InnerXml;
            label11.Text = GBPsat;
            decimal giren = Convert.ToDecimal(textBox1.Text);
            //label12.Text = Convert.ToString(giren);
            int secim1 = comboBox2.SelectedIndex;
            int secim2 = comboBox1.SelectedIndex;
            Console.WriteLine(secim1 + " " + secim2 );
            if (secim1==0)
            {
                if(secim2==0)
                {
                    decimal Bolum = Convert.ToDecimal(EURal.Replace(".",","));
                    decimal Sonuc = giren / Bolum;
                    label12.Text = Sonuc.ToString();
                }
                else if (secim2 == 1)
                {
                    decimal Bolum = Convert.ToDecimal(USDal.Replace(".", ","));
                    decimal Sonuc = giren / Bolum;
                    label12.Text = Sonuc.ToString();
                }
                else if (secim2 == 2)
                {
                    decimal Bolum = Convert.ToDecimal(GBPal.Replace(".", ","));
                    decimal Sonuc = giren / Bolum;
                    label12.Text = Sonuc.ToString();
                }
            }
            else if (secim1 == 1)
            {
                if (secim2 == 0)
                {
                    decimal Bolum = Convert.ToDecimal(EURsat.Replace(".", ","));
                    decimal Sonuc = giren * Bolum;
                    label12.Text = Sonuc.ToString();
                }
                else if (secim2 == 1)
                {
                    decimal Bolum = Convert.ToDecimal(USDsat.Replace(".", ","));
                    decimal Sonuc = giren * Bolum;
                    label12.Text = Sonuc.ToString();
                }
                else if (secim2 == 2)
                {
                    decimal Bolum = Convert.ToDecimal(GBPsat.Replace(".", ","));
                    decimal Sonuc = giren * Bolum;
                    label12.Text = Sonuc.ToString();
                }
            }



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
