using System;

namespace project1
{
    class CDs
    {
        private int fv = 0;
        private double interest_rate = 0;
        private double time_period = 0;
        private DateTime start_time;

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
        public DateTime Start_time
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

        public void display()
        {
            Console.WriteLine("info: fv is {0}, interest rate is {1}, time period is {2}", FV, Interest_rate, Time_period);
        }

        public double calc_CDs()
        {
            double CDs = 0;
            if (time_period < 1)
            {
                CDs = fv * (1 + interest_rate * time_period);
            }
            else
            {
                CDs = fv * Math.Pow((1 + interest_rate), time_period);
            }

            int days = 0;
            days = start_time.Subtract(DateTime.Now).Days;
         

            double pv = 0;
            pv = CDs * Math.Exp(-interest_rate * days/365);
            Console.WriteLine("the present value is {0}", pv);

            return pv;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            CDs test = new CDs();
            Console.WriteLine("what is the face value");
            test.FV = int.Parse(Console.ReadLine());
            Console.WriteLine("what is the interest rate?(e.g. 0.05 for 5%)");
            test.Interest_rate = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the time period in years?(e.g. 0.5 for six months)");
            test.Time_period = double.Parse(Console.ReadLine());
            Console.WriteLine("what is the start date?(e.g. 20180505)");
            test.Start_time = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            test.display();
            double testtest = test.calc_CDs();
            Console.WriteLine(testtest);



            Console.ReadLine();
        }
    }
}