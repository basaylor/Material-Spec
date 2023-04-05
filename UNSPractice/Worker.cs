using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace UNSPractice
{

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger_;

        public Worker(ILogger<Worker> logger)
        {
            logger_ = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger_.LogInformation("Worker is running at: {time}", DateTimeOffset.Now);
                await leeDataosAsync();
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async Task leeDataosAsync()
        {
            DataSet1 sp = new DataSet1();
            DataSet1TableAdapters.sp_MaterialSpecToMQTTTableAdapter maxmin = new DataSet1TableAdapters.sp_MaterialSpecToMQTTTableAdapter();
            DataSet1TableAdapters.QueriesTableAdapter status = new DataSet1TableAdapters.QueriesTableAdapter();

            List<data2> data2 = new List<data2>();
            maxmin.Fill(sp.sp_MaterialSpecToMQTT);
            List<data> data = new List<data>();
            List<data3> data3 = new List<data3>();

            if (sp.sp_MaterialSpecToMQTT.Rows.Count > 0)
            {
                for (int i = 0; i < sp.sp_MaterialSpecToMQTT.Rows.Count; i++)
                {
                    data2 p = new data2();
                    data3 m = new data3();
                    m.matnr = sp.sp_MaterialSpecToMQTT.Rows[i][0].ToString();
                    List<propertys> properties = new List<propertys>();
                    propertys c = new propertys();
                    
                    m.coiln = sp.sp_MaterialSpecToMQTT.Rows[i][1].ToString();
                    c.property = "width";

                    //converts floating-point number to a string that returns as a string or combination
                    try
                    {
                        c.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][2].ToString());
                    }
                    catch (Exception)
                    {
                        c.max = null;
                    }
                    try
                    {
                        c.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][3].ToString());
                    }
                    catch (Exception)
                    {
                        c.min = null;
                    }
                    c.uom = "mm";
                    properties.Add(c);

                    propertys t = new propertys();
                    t.property = "thickness";
                    t.uom = "mm";

                    try
                    {
                        t.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][4].ToString());
                    }
                    catch (Exception)
                    {
                        t.max = null;
                    }
                    try
                    {
                        t.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][5].ToString());
                    }
                    catch (Exception)
                    {
                        t.min = null;
                    }
                    properties.Add(t);

                    propertys w = new propertys();
                    w.property = "weight";
                    w.uom = "kg";
                    try
                    {
                        w.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][6].ToString());
                    }
                    catch (Exception)
                    {
                        w.max = null;
                    }
                    try
                    {
                        w.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][7].ToString());
                    }
                    catch (Exception)
                    {
                        w.min = null;
                    }
                    properties.Add(w);

                    propertys ys = new propertys();
                    ys.property = "yeild_strength";
                    ys.uom = "Mpa";
                    try
                    {
                        ys.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][8].ToString());
                    }
                    catch
                    {
                        ys.max = null;
                    }
                    try
                    {
                        ys.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][9].ToString());
                    }
                    catch (Exception)
                    {
                        ys.min = null;
                    }
                    properties.Add(ys);

                    propertys ts = new propertys();
                    ts.property = "tensile_strength";
                    ts.uom = "Mpa";
                    try
                    {
                        ts.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][10].ToString());
                    }
                    catch (Exception)
                    {
                        ts.max = null;
                    }
                    try
                    {
                        ts.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][11].ToString());
                    }
                    catch (Exception)
                    {
                        ts.min = null;
                    }
                    properties.Add(ts);

                    propertys e = new propertys();
                    e.property = "elongation";
                    e.uom = "%";
                    try
                    {
                        e.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][12].ToString());
                    }
                    catch (Exception)
                    {
                        e.max = null;
                    }
                    try
                    {
                        e.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][13].ToString());
                    }
                    catch (Exception)
                    {
                        e.min = null;
                    }
                    properties.Add(e);

                    propertys nv = new propertys();
                    nv.property = "n value";
                    nv.uom = "%";
                    try
                    {
                        nv.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][14].ToString());
                    }
                    catch (Exception)
                    {
                        nv.max = null;
                    }
                    try
                    {
                        nv.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][15].ToString());
                    }
                    catch (Exception)
                    {
                        nv.min = null;
                    }
                    properties.Add(nv);

                    propertys rv = new propertys();
                    rv.property = "r value";
                    rv.uom = "mm";
                    try
                    {
                        rv.max = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][16].ToString());
                    }
                    catch (Exception)
                    {
                        rv.max = null;
                    }
                    try
                    {
                        rv.min = Convert.ToDouble(sp.sp_MaterialSpecToMQTT.Rows[i][17].ToString());
                    }
                    catch (Exception)
                    {
                        rv.min = null;
                    }
                    properties.Add(rv);

                    m.mat_props_minmax = properties;
                    data3.Add(m);
                }
                //suspends the evaluation of the enclosing async method
                await enviaUNSAsync2("m/kmk/receiving/materialcert", data3);
            }
        }

        public async Task enviaUNSAsync2(string topic, List<data3> data)
        {
            var mqttFactory = new MqttFactory();

            var mensaje = DateTime.UtcNow;
            json2 js = new json2();
            js.Timestamp = mensaje.ToString("s");
            js.minmax = data;
            var json = JsonSerializer.Serialize(js);

            //creates a new mqtt server
            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                //creates connection options for the mqtt broker
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithCredentials("kmk_863_MaterialCert", "WhyQu@l1ty2023").WithConnectionUri("mqtt://kmkuns01srv:1883")
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                //the mqtt broker publishes the messages received from the SQL database
                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(json)//shows how to compose the information 
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                Console.WriteLine("MQTT application message is published to the UNS.");

            }
        }
    }
}



// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");