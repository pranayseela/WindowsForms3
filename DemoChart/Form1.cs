using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DemoChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillChart();
        }
        //fillChart method
        private void fillChart()
        {
            ////AddXY value in chart1 in series named as Salary
            //chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
            //chart1.Series["Salary"].Points.AddXY("Ramesh", "8000");
            //chart1.Series["Salary"].Points.AddXY("Ankit", "7000");
            //chart1.Series["Salary"].Points.AddXY("Gurmeet", "10000");
            //chart1.Series["Salary"].Points.AddXY("Suresh", "8500");
            ////chart title
            //chart1.Titles.Add("Salary Chart");


            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=true;");
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select Name,Salary from tbl_EmpSalary", con);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            //set the member of the chart data source used to data bind to the X-values of the series
            chart1.Series["Salary"].XValueMember = "Name";
            //set the member columns of the chart data source used to data bind to the X-values of the series
            chart1.Series["Salary"].YValueMembers = "Salary";
            chart1.Titles.Add("Salary Chart");
            con.Close();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
