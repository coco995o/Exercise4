using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe4
{
    public class ClockHand
    {
        public int value { get; set; }
        public int limit { get; set; }

        public ClockHand(int limit)
        {
            this.limit = limit;
            this.value = 0;
        }

        public void Advance()
        {
            this.value = this.value + 1;

            if (this.value >= this.limit)
            {
                this.value = 0;
            }
        }

        public override string ToString()
        {
            if (this.value < 10)
            {
                return "0" + this.value;
            }

            return "" + this.value;
        }
    }
    public class Timer 
    {
        private ClockHand hundredOfSeconds;
        private ClockHand seconds;

        public Timer() 
        {
            this.hundredOfSeconds = new ClockHand(100);
            this.seconds = new ClockHand(60);
        }
        public void Advance() 
        {
            this.hundredOfSeconds.Advance();
            if (this.hundredOfSeconds.value==0) 
            { 
                this.seconds.Advance();
            }
        }
        public override string ToString()
        {
            return seconds + ":" + hundredOfSeconds;
        }

    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            var timer = new Timer();

            while (true) 
            {
                Console.WriteLine(timer);
                timer.Advance();
                try
                {
                    System.Threading.Thread.Sleep(10);
                }
                catch (Exception e) 
                {
                    Console.WriteLine("Error happened: +"+e);
                }
            }
        }
    }
}
