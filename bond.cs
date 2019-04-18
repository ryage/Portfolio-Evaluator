using System;
using System.Collections;

namespace project1
{
    class Bond
    {
        private double coupon_rate = 0;
        private double coupon_frenquency = 0;
        private int fv = 0;
        private double interest_rate = 0;
        private double time_period = 0;
        private DateTime start_time;
        private int j = 0;
        //private ArrayList effcd;
        //private ArrayList effcf;


        public double Coupon_rate
        {
            get
            {
                return coupon_rate ;
            }
            set
            {
                coupon_rate  = value;
            }
        }
        public double Coupon_frenquency
        {
            get
            {
                return coupon_frenquency;
            }
            set
            {
                coupon_frenquency = value;
            }
        }
        public int FV
        {
            get
            {
                return fv;
            }
            set
            {
                fv = value;
            }
        }
        public double Interest_rate
        {
            get
            {
                return interest_rate;
            }
            set
            {
                interest_rate = value;
            }
        }
        public double Time_period
        {
            get
            {
                return time_period;
            }
            set
            {
                time_period = value;
            }
        }
        public DateTime  Start_time
        {
            get
            {
                return start_time;
            }
            set
            {
                start_time = value;
            }
        }
        public void getinfo()
        {
            Console.WriteLine("what is the coupon rate? (e.g. 0.05 for 5%)");
            Coupon_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the coupon frenquency?(e.g. 0.5 for every half year)");
            Coupon_frenquency = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the face value in thousands?(e.g. 100 for 100K)");
            FV = int.Parse(Console.ReadLine());
            Console.WriteLine("what is the interest rate?(e.g. 0.05 for 5%)");
            Interest_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the time period in years?(e.g. 0.5 for six months)");
            Time_period = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the start date?(e.g. 20180505)");
            Start_time = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
        }
        public void display()
        {
            Console.WriteLine( "info: coupon rate is {0}, coupon frenquency is {1}, fv is {2}, interest rate is {3}, time period is {4}",Coupon_rate,Coupon_frenquency ,FV ,Interest_rate ,Time_period );
        }
        public double[]  cashflow()
        {
            int couponflow = (int) (Time_period / Coupon_frenquency);
            double[] cf = new double[couponflow ];
            DateTime[] couponday = new DateTime[couponflow];
            couponday[0] = Start_time.AddMonths((int)(12 * Coupon_frenquency));

            for(int i=0;i<couponflow-1;i++)
            {
                couponday[i + 1] = couponday[i].AddMonths((int)(12 * Coupon_frenquency));
                cf[i] = Coupon_rate * Coupon_frenquency * FV;
            }
            cf[couponflow - 1] = FV+ Coupon_rate * Coupon_frenquency * FV;
            while (couponday[j].Subtract (DateTime.Now).Days <0)
                {
                    j++;
                }

            double[] effcf = new double[couponflow - j];
            DateTime [] effcd = new DateTime[couponflow - j];

            for (int i = 0; i < couponflow - j; i++)
            {
                effcf[i]=cf[i + j];
                effcd[i]=couponday[i + j];
            }
            
            return (effcf);
        }
        public double pv()
        {
            int couponflow = (int)(Time_period / Coupon_frenquency);
            double[] cf = new double[couponflow];
            DateTime[] couponday = new DateTime[couponflow];
            couponday[0] = Start_time;

            for (int i = 0; i < couponflow - 1; i++)
            {
                couponday[i + 1] = couponday[i].AddMonths((int)(12 * Coupon_frenquency));
                cf[i] = Coupon_rate * Coupon_frenquency * FV;
            }
            cf[couponflow - 1] += FV;
            double[] effcf = new double[couponflow - j];
            DateTime[] effcd = new DateTime[couponflow - j];
            for (int i = 0; i < couponflow - j; i++)
            {
                effcf[i] = cf[i + j];
                effcd[i] = couponday[i + j];
            }
            double PV = 0;
            for (int i = 0; i < couponflow - j; i++)
            {
                PV += effcf[i] * Math.Exp(-Interest_rate * effcd[i].Subtract(DateTime.Now).Days / 365);
            }
            return (PV);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Bond test = new Bond();
            test.getinfo();
            test.display();
            double[] testtest=test.cashflow();
            for(int i=0;i<testtest.Length;++i)
            {
                Console.WriteLine(testtest[i]);
            }
            
            Console.WriteLine("the present value is {0}", test.pv());
            Console.ReadLine();
        }
    }
}
