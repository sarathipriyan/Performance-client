using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlockTEST
{
    public partial class Form1 : Form
    {
        public static List<modelproperty> listvalue = new List<modelproperty>();
        KYC_VALUE value = new KYC_VALUE();
        modelproperty value1 = new modelproperty();
        static readonly object _object = new object();
        public Form1()
        {
            InitializeComponent();
        }
        public static List<Task> TaskList = new List<Task>();
        private void button1_Click(object sender, EventArgs e)
        {
            GETTOKEN();
        }
        public void GETTOKEN()
        {
            try
            {
                string webAddr = "http://10.6.5.15:8080/auth/token";

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{ \"password\":" + "\"" + textBox3.Text + "\", \"username\":" + "\"" + textBox2.Text + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine(responseText);
                    dynamic data = JObject.Parse(responseText);
                    //Now you have your response.
                    //or false depending on information in the response    
                    string value = "Bearer";

                    string title = data.bearerToken;

                    textBox1.Text = value + " " + " " + title;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch1 = new Stopwatch();
            //ist value2 = new List();
            int norquest = Convert.ToInt16(textBox5.Text);
            stopWatch1.Start();
            POSTUID(norquest);
            stopWatch1.Stop();
            TimeSpan ts = stopWatch1.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            textBox6.Text = elapsedTime;


        }

        private void POSTUID(int norquest)
        {


            for (int i = 1; i <= norquest; i++)
            {
                string NAME = textBox4.Text + i;
                value.Kycreason = comboBox1.Text;
                value.Kycresult = comboBox2.Text;
                Task fooWrappedInTask = Task.Run(() => RunMe(NAME));
                TaskList.Add(fooWrappedInTask);
            }
            Task.WaitAll(TaskList.ToArray());
            // Get the elapsed time as a TimeSpan value.

            //listvalue.Add(value1);
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("NAME");
            dataTable.Columns.Add("/ident/{identId}");
            dataTable.Columns.Add("/ident/{identId}/result");
            dataTable.Columns.Add("TaskStart_Time");
            dataTable.Columns.Add("TaskEnd_Time");
            //dataTable.Columns.Add("Total_Time");
            DataRow row = null;
            //listvalue.Add(value1);
            foreach (var rowObj in listvalue)
            {
                row = dataTable.NewRow();
                dataTable.Rows.Add(rowObj.name, rowObj.API1_Status, rowObj.API2_Status, rowObj.TaskStart, rowObj.TaskEnd);
                dataGridView1.DataSource = dataTable;
            }
        }
        public Task<string> RunMe(string NAME)
        {
            modelproperty value1 = new modelproperty();
            value1.name = NAME;
            Stopwatch stopWatch = new Stopwatch();
            value1.TaskStart = DateTime.Now.ToString("HH:mm:ss");
            stopWatch.Start();
            string webAddr = "http://10.6.5.15:8080/ident/" + NAME;
            string status = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{ \"birthday\": \"string\", \"birthplace\": \"string\", \"city\": \"string\", \"country\": \"string\", \"email\": \"string\", \"firstname\": \"string\", \"gender\": \"string\", \"lastname\": \"string\", \"mobilephone\": \"string\", \"nationality\": \"string\", \"street\": \"string\", \"zipcode\": \"string\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                status = httpResponse.StatusCode.ToString();
                value1.API1_Status = status;

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine(responseText);
                }
                httpResponse.Close();
                if (status == "OK")
                {

                    string webAddr1 = "http://10.6.5.15:8080/ident/" + NAME + "/result";
                    string status1 = string.Empty;
                    var httpWebRequest1 = (HttpWebRequest)WebRequest.Create(webAddr1);
                    httpWebRequest1.ContentType = "application/json; charset=utf-8";
                    httpWebRequest1.Method = "POST";
                    httpWebRequest1.Headers.Add("Authorization", "dcmGV25hZFzc3VudDM6cGzdCdvQ=");


                    using (var streamWriter1 = new StreamWriter(httpWebRequest1.GetRequestStream()))
                    {
                        string json = "{ \"kycReason\":" + "\"" + value.Kycreason + "\", \"kycResult\":" + "\"" + value.Kycresult + "\", \"personSearchInfo\": { \"Address\": \"salem\", \"City\": \"salem\", \"Country\": \"india\", \"County\": \"india\", \"DateOfBirth\": \"sep5\", \"Forename\": \"TEST\", \"Middlename\": \"string\", \"Postcode\": \"636030\", \"Surname\": \"TEST2\", \"YearOfBirth\": \"1992\" }}";

                        streamWriter1.Write(json);
                        streamWriter1.Flush();
                    }
                    var httpResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();
                    status1 = httpResponse1.StatusCode.ToString();
                    value1.API2_Status = status1;
                }
                stopWatch.Stop();
                value1.TaskEnd = DateTime.Now.ToString("HH:mm:ss");


            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nThe following Exception was raised : {0}", e.Message);
            }
            lock (_object)
            {
                listvalue.Add(value1);
            }
            return Task.FromResult(value1.name);
        }

    }


    public class modelproperty
        {
            public string API1_Status = string.Empty;
            public string API2_Status = string.Empty;
            public string Totaltime = string.Empty;
            public string TaskStart = string.Empty;
            public string TaskEnd = string.Empty;
            public string name = string.Empty;
        }
        public class KYC_VALUE
        {
            public string Kycreason = string.Empty;
            public string Kycresult = string.Empty;
        }
    }

