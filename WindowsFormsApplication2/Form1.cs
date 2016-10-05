using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication2.RiksbankenService;
using Exception = System.Exception;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RiksbankenService.SweaWebServicePortTypeClient client = new SweaWebServicePortTypeClient();
            string je = client.State.ToString();

            try
            {
                client.Open();

                int dateCurrentMonth = DateTime.Today.Month;
                int dateCurrentYear = DateTime.Today.Year;
                 
                var respons = client.getMonthlyAverageExchangeRates(dateCurrentYear, dateCurrentMonth, LanguageType.sv);
                client.Close();

                string getExchangeCountryName = respons.groups[0].series[14].seriesname;


            }
            catch (CommunicationException error)
            {

                client.Abort();
                MessageBox.Show(error.ToString());
            }
        }
    }
}
