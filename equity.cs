using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Equity equity1 = new Equity(1, 100.69, 1, 0.065, 2.00, 0.10, 0.02);
            Console.WriteLine(equity1.valuation);
        }

    }

    class Equity
    {
        private int ID { get; set; }
        public double price { get; set; }
        public double valuation { get; set; }
        public int number_of_shares { get; set; }
        public double cost_of_equity { get; set; }
        public double dividend_paid { get; set; }
        public double dividend_growth_rate { get; set; }
        public double terminal_value { get; set; }
        public double terminal_growth_rate { get; set; }

        public double[] dividends = new double[20];
        public double[] discount_factor = new double[20];
        public double[] cash_flow = new double[20];


        public Equity(int ID, double price, int number_of_shares, double cost_of_equity, double dividend_paid, double dividend_growth_rate, double terminal_growth_rate)
        {
            this.ID = ID;
            this.price = price;
            this.number_of_shares = number_of_shares;
            this.cost_of_equity = cost_of_equity;
            this.dividend_paid = dividend_paid;
            this.dividend_growth_rate = dividend_growth_rate;
            this.terminal_growth_rate = terminal_growth_rate;
            dividends = calc_dividend(dividend_paid, dividend_growth_rate, terminal_growth_rate);
            discount_factor = calc_discount_factor(cost_of_equity);
            cash_flow = calc_cash_flow(dividends, discount_factor);
            valuation = calc_valuation(terminal_growth_rate, cost_of_equity, cash_flow, number_of_shares);
        }

        public double[] calc_dividend(double dividend_paid, double dividend_growth_rate, double terminal_growth_rate)
        {
            dividends[0] = dividend_paid * (1 + dividend_growth_rate);
            for (int i = 1; i < 10; i++)
            {
                dividends[i] = dividends[i - 1] * (1 + dividend_growth_rate);
            }
            for (int i = 10; i < 20; i++)
            {
                dividends[i] = dividends[i - 1] * (1 + terminal_growth_rate);
            }
            return dividends;
        }

        public double[] calc_discount_factor(double cost_of_equity)
        {
            discount_factor[0] = 1 / (1 + cost_of_equity);
            for (int i = 1; i < 20; i++)
            {
                discount_factor[i] = Math.Pow(discount_factor[0], i+1);
            }
            return discount_factor;

        }
        public double[] calc_cash_flow(double [] dividends, double [] discount_factor)
        {
            for (int i = 0; i < 20; i++)
            {
                cash_flow[i] = dividends[i] * discount_factor[i];
            }
            return cash_flow;
        }
        public double calc_valuation(double terminal_growth_rate, double cost_of_equity, double[] cash_flow, int number_of_shares)
        {
            terminal_value = cash_flow[19] * (1 + terminal_growth_rate) / (cost_of_equity - terminal_growth_rate);
            valuation = (cash_flow.Sum() + terminal_value) * number_of_shares;
            return valuation;
        }




    }
}
