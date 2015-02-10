using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Trwalosc_zmeczeniowa
{
    
    
   

    public partial class Form1 : Form
    {

        List<int> tablica = new List<int>();
        List<double> tablica2 = new List<double>();
        List<int> tabx = new List<int>();
        
      

        
        public Form1()
        {
            InitializeComponent();
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
          
            string[] tab = new string[1024];

            

        string [] split = textBox1.Text.Split(new Char [] {' '});

        
            
        foreach (string s in split) {

            if (s.Trim() != "")
            {

               tablica.Add(System.Int32.Parse(s));
                x++;

            }
    }

        for (int i = 0; i < tablica.Count; i++)
        {

            tablica2.Add((300 / 24.4) * (double)tablica[i] - ((7.6 * 300) / 24));
                
        }
        MessageBox.Show("Obliczone", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //Initialize chart

        chart2.ChartAreas.Add("wykres");
        chart2.Series.Add("lokalne ekstrema");
        chart2.Series["lokalne ekstrema"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine; ;
        chart2.Series["lokalne ekstrema"].Color = Color.Blue;
        chart2.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        chart2.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        chart2.ChartAreas[0].AxisX.Minimum = 0;
        chart2.ChartAreas[0].AxisY.Minimum = 0;



        chart1.ChartAreas.Add("area");
        chart1.Series.Add("Naprężenia");
        chart1.Series["Naprężenia"].Color = Color.Blue;
        chart1.Series["Naprężenia"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;


        chart3.ChartAreas.Add("Area");
        chart3.Series.Add("rozpietosc galezi");
        chart3.Series["rozpietosc galezi"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
         chart3.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        chart3.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        chart3.ChartAreas[0].AxisX.Minimum = 0;


        chart4.ChartAreas.Add("Area");
        chart4.Series.Add("Pełnych cykli");
        chart4.Series["Pełnych cykli"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
        chart4.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        chart4.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        chart4.ChartAreas[0].AxisX.Minimum = 0;


        chart5.ChartAreas.Add("Area");
        chart5.Series.Add("Wykres Wohlera");
        chart5.Series["Wykres Wohlera"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        chart5.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
        chart5.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
        chart5.ChartAreas[0].AxisX.Minimum = 0;
        
      //  chart5.ChartAreas[0].AxisY.LogarithmBase = 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        //    char[] charr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //    char[] chartextbox = new char[1024];

        //    int a = 0;
        //    string [] split = textBox1.Text.Split(new Char [] {' ' });

        //    foreach (string s in split )
        //    { 
        //    for(int i=0;i<9;i=i++)
        //    { 
        //        chartextbox[a] = System.Char.Parse(textBox1.Text);

        //        a++;

        //    if(chartextbox[a] != charr[i])
        //    {
        //       Console.WriteLine( charr[1]);
        //        MessageBox.Show("Wprowadzone dane nie są liczbami, podaj liczby", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pelnych cykli

            Console.Clear();

            this.chart1.Visible = false;
            this.chart2.Visible = false;
            this.chart3.Visible = false;
            this.chart4.Visible = true;
            this.chart5.Visible = false;

            List<double> tablicacykli = new List<double>();
            List<double> tablicapelnychacykli = new List<double>();
            List<double> liczbacykli = new List<double>();
            List<double> tablicacykli2 = new List<double>();

            double klasaa = 1;
            double klasaa2 = 0.9;
            int klasawlasciwaa = 1;
            int zmienna=0;
            int x = 0;


            for (int i = 0; i < tablica2.Count; i++)
            {

                tablicacykli.Add(tablica2[i] / tablica2.Max());

            }

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < tablicacykli.Count; i++)
                {

                    if (i == tablicacykli.Count - 1)
                    {
                        klasawlasciwaa++;
                        klasaa2 -= 0.1;
                        klasaa -= 0.1;                                       // umiescowienie naprezen w klasy

                    }

                    if (tablicacykli[i] > klasaa2 && tablicacykli[i] <= klasaa)
                    {
                    
                        tablicacykli[i] = klasawlasciwaa;
                    }

                }

            }

            while (true)
            {
                for (int i = 0; i < tablicacykli.Count() - 2; i = i + 2)
                {

                    if (tablicacykli[zmienna] + tablicacykli[zmienna + 1] > tablicacykli[i + 1] + tablicacykli[i + 2])
                    {
                        zmienna = 0;
                    }

                    else
                    {

                        zmienna = i;
                    }

                    if (i == tablicacykli.Count() - 4)
                    {
                      

                        if (tablicacykli[zmienna] > tablicacykli[zmienna + 1])
                        {
                              
                            tablicapelnychacykli.Add((tablicacykli[zmienna] - tablicacykli[zmienna + 1]) / 2);
                            tablicacykli.RemoveRange(zmienna, 2);
                        }
                        else if (tablicacykli[zmienna] < tablicacykli[zmienna + 1])
                        {
                            tablicapelnychacykli.Add((tablicacykli[zmienna + 1] - tablicacykli[zmienna]) / 2);
                            tablicacykli.RemoveRange(zmienna, 2);
                        }
                    }

                    if (tablicacykli.Count() == 2)
                    {
                        if (tablicacykli[0] > tablicacykli[1])
                        {
                          tablicapelnychacykli.Add((tablicacykli[0] - tablicacykli[1]) / 2);
                            tablicacykli.RemoveRange(0, 2);
                        }

                        else
                        {
                            tablicapelnychacykli.Add((tablicacykli[1] - tablicacykli[0]) / 2);
                            tablicacykli.RemoveRange(0, 2);
                        }
                    }
                   
                }
           

                if (tablicacykli.Count < 2)
                    break;
            }


            //for (int i = 0; i < tablicapelnychacykli.Count(); i++)
            //{

            //    Console.WriteLine(tablicapelnychacykli[i]);
            //}

            


            tablicapelnychacykli.Sort();
            //   cykl_obciazenia1.Add(0);
            liczbacykli.Add(0);
            tablicacykli2.Add(0);

            for (int j = tablicapelnychacykli.Count() - 1; j > 0; j--)
            {

                if (tablicapelnychacykli[j] == tablicapelnychacykli[j - 1])
                {

                    x++;
                }

                if (tablicapelnychacykli[j] != tablicapelnychacykli[j - 1])
                {
                    tablicacykli2.Add(tablicapelnychacykli[j - 1]);
                    liczbacykli.Add(x);
                    x = 1;
                }
            }



            if (tablicapelnychacykli[0] != tablicapelnychacykli[1])
            {

                liczbacykli.Add(1);
            }

            liczbacykli.Add(0);

            tablicacykli2.Add(0);


           

            Console.WriteLine("amplituda - liczba cykli ");
            for (int j = 1; j < tablicacykli2.Count; j++)
            {

                Console.WriteLine(tablicacykli2[j-1] + " = " + liczbacykli[j]);

            }
            for (int j = 1; j < liczbacykli.Count; j++)
            {

                liczbacykli[j] = liczbacykli[j] + liczbacykli[j - 1];

            }


            for (int j = 0; j < tablicacykli2.Count; j++)
            {

                chart4.Series["Pełnych cykli"].Points.AddXY(liczbacykli[j], tablicacykli2[j]);
            
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //<-1,1>

            Console.Clear();
            this.chart2.Visible = false;
            this.chart1.Visible = true;
            this.chart3.Visible = false;
            this.chart4.Visible = false;
            this.chart5.Visible = false;
            
            //Form2 OknoUzytkownika = new Form2();
            //OknoUzytkownika.Show();

    

            for(int i=0;i<tablica2.Count;i++)
            {
                  tabx.Add(i);
           chart1.Series["Naprężenia"].Points.AddXY(tabx[i], (tablica2[i]/tablica2.Max()));
               
            }

            for (int i = 0; i < tablica2.Count; i++)
            {
               Console.WriteLine("Wartosc naprężeń dla "+ tablica[i]+ "= " + (tablica2[i] / tablica2.Max()));
            }


        }

        private void chart1_Click(object sender, EventArgs e)
        {

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //lokalne ekstrema

            Console.Clear();

            this.chart1.Visible = false;
            this.chart2.Visible = true;
            this.chart3.Visible = false;
            this.chart4.Visible = false;
            this.chart5.Visible = false;

            double klasa = 0.0;
            double klasa2=0.1;
            int x=0;
            int x1=0;
            List<float> lokalne_ekstrema = new List<float>();
            double[] osy = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 };
            lokalne_ekstrema.Add(0);

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < tablica2.Count; i++)
                {

                    if (i == tablica2.Count - 1)
                    {
                        lokalne_ekstrema.Add(x);
                        x = 0;
                        klasa = klasa + 0.1;
                        klasa2 = klasa2 + 0.1;


                    }

                    if (tablica2[i] / tablica2.Max() > klasa && tablica2[i] / tablica2.Max() <= klasa2)
                    {
                        x++;
                    }

                }


            }
            for (int i = 0; i < tablica2.Count; i++)
            {
                if ((tablica2[i] / tablica2.Max() > 0.9 ) && (tablica2[i] / tablica2.Max() <= 1))
                {
                    x1++;
                }
            }

            lokalne_ekstrema.Add(x1);
            lokalne_ekstrema.Add(0);

            Console.WriteLine("Klasa - Liczba cykli");
            for (int i = 1; i < lokalne_ekstrema.Count; i++)
            {
                
                Console.WriteLine("Dla "+osy[i-1] +" = " +lokalne_ekstrema[i]);
            }


            for (int i = 1; i < lokalne_ekstrema.Count; i++)
            {
                lokalne_ekstrema[i] = lokalne_ekstrema[i] + lokalne_ekstrema[i-1];
                
                    
            }

                lokalne_ekstrema.Sort();
        
            

            for (int i = 0; i < lokalne_ekstrema.Count; i++)
            {
                
               chart2.Series["lokalne ekstrema"].Points.AddXY(lokalne_ekstrema[i], (osy[i]));
              //chart2.Series["lokalne ekstrema"].Points.AddY(-(osy[i]));
            }

            }

        private void button4_Click(object sender, EventArgs e)
        {
            //rozpietsoci galezi

            Console.Clear();

            this.chart1.Visible = false;
            this.chart2.Visible = false;
            this.chart3.Visible = true;
            this.chart4.Visible = false;
            this.chart5.Visible = false;

            List<double> tablicarozp = new List<double>();
            List<double> rosnace = new List<double>();
            List<double> malejace = new List<double>();
            
            List<double> liczba_cykli = new List<double>();
            List<double> cykl_obciazenia = new List<double>();
            List<double> cykl_obciazenia1 = new List<double>();
            double klasa = 1;
            double klasa2 = 0.9;
            int klasawlasciwa = 1;
            int zmienna = 0;
            int x = 1;
            
           
        
            for (int i = 0; i < tablica2.Count; i++)
            {
                                                                                
               tablicarozp.Add( tablica2[i] / tablica2.Max());

            }

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < tablicarozp.Count; i++)
                {

                    if (i == tablicarozp.Count - 1)
                    {
                        klasawlasciwa++;
                        klasa2 -= 0.1;
                        klasa -= 0.1;                                       // umiescowienie naprezen w klasy

                    }

                    if (tablicarozp[i] > klasa2 && tablicarozp[i] <= klasa)
                    {

                        tablicarozp[i] = klasawlasciwa;
                      
                    }

                }

            }
               

                if (tablicarozp[0] < tablicarozp[1])
                {
                    for(int i=0; i<tablicarozp.Count-1;i++)
                    {
                        
                        if (zmienna == 2)
                        {
                            zmienna = 0;
                        }
                        if (zmienna == 0)
                        {
                            malejace.Add(tablicarozp[i]);
                            malejace.Add(tablicarozp[i + 1]);
                        }
                        else if (zmienna == 1)
                        {
                            rosnace.Add(tablicarozp[i]);
                            rosnace.Add(tablicarozp[i+1]);
                        }

                        zmienna++;
                    }

                }
           
                for (int j = 0; j < rosnace.Count; j=j+2)
                {

                   if (rosnace[j] > rosnace[j + 1])
                    {
                        cykl_obciazenia.Add((rosnace[j] - rosnace[j + 1]) / 2);
                   }

                   else if (rosnace[j] < rosnace[j + 1])
                    {
                        cykl_obciazenia.Add((rosnace[j+1] - rosnace[j ]) /2);
                    }
                    
                }

               cykl_obciazenia.Sort();
            //   cykl_obciazenia1.Add(0);
                cykl_obciazenia1.Add(cykl_obciazenia[cykl_obciazenia.Count-1]);
                liczba_cykli.Add(0);

               for (int j = cykl_obciazenia.Count-1; j> 0; j--)
               {

                   if (cykl_obciazenia[j] == cykl_obciazenia[j-1])
                   {

                       x++;
                   }

                   if (cykl_obciazenia[j] != cykl_obciazenia[j-1])
                   {
                       cykl_obciazenia1.Add(cykl_obciazenia[j - 1]);
                       liczba_cykli.Add(x);
                       x = 1;
                   }
               }

             

               if (cykl_obciazenia[0] != cykl_obciazenia[1])
               {
                 
                   liczba_cykli.Add(1);
               }

               liczba_cykli.Add(0);
             
               cykl_obciazenia1.Add(0);
               Console.WriteLine("amplituda - liczba cykli ");
                    for (int j = 1; j < cykl_obciazenia1.Count; j++)
                {

                    Console.WriteLine(cykl_obciazenia1[j-1]+ " = " +liczba_cykli[j]);

                }      
               for (int j = 1; j < liczba_cykli.Count; j++)
               {

                   liczba_cykli[j]=liczba_cykli[j] + liczba_cykli[j - 1];

               }



                for (int j = 0; j<cykl_obciazenia1.Count; j++)
                {
  
                chart3.Series["rozpietosc galezi"].Points.AddXY(liczba_cykli[j], cykl_obciazenia1[j]);  
              // chart3.Series["rozpietosc galezi"].Points.AddY(-cykl_obciazenia1[j]);
                }
               



        }

        private void chart2_Click(object sender, EventArgs e)
        {
            
        }




        public int i { get; set; }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           // Console.Clear();

           // this.chart1.Visible = false;
           // this.chart2.Visible = false;
           // this.chart3.Visible = false;
           // this.chart4.Visible = false;
           // this.chart5.Visible = true;

           // double m;
           // double a;
           // string m1, b1;
           // double b;
           // double [] tablica10={10, 100, 1000, 10000, 100000, 1000000};
           // List<double> tablicawohlera = new List<double>();



           //m1=(textBox3.Text);
           //b1=textBox4.Text; 

           //m=(System.Double.Parse(m1));
           // b=System.Double.Parse(b1);

           //a = 1.0/m ;

        
           //     Console.WriteLine("Smax-Wohlera");
           //for (int i = 0; i < 6; i++)
           //{

           //    tablicawohlera.Add(Math.Pow(10,a*Math.Log10(tablica10[i])+b));
             
           //}

           




           //for (int i = 0; i < tablica10.Count(); i++)
           //{

           //    Console.WriteLine(tablica10[i]);
           //   // chart5.Series["Wykres Wohlera"].Points.AddY(tablicawohlera[i]);
           //     chart5.ChartAreas[0].AxisX.LogarithmBase = 10;
           //     chart5.ChartAreas[0].AxisY.LogarithmBase = 10;
           //    chart5.Series["Wykres Wohlera"].Points.AddXY(tablica10[i], tablicawohlera[i]);  
               
           //}  

        }
    }
    }

