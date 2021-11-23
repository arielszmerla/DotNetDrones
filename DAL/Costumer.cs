using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    namespace DO
    {/// <summary>
    ///  customer class data
    /// </summary>
        public struct Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public override string ToString()///toString erased func
            {
                string _result = "";
                _result += $"Id is {Id}\n";
                _result += $"name is {Name}\n";
                _result += $"Phone is {Phone}\n";
                _result += $"longitude is  {printLong(Longitude)}\n";
                _result += $"latitude is {printLat(Latitude)}\n";
                return _result;
            }
            static string printLat(double num)
            {
                char coordin;
                int hours = (int)num;
                if (hours < 0)
                {
                    coordin = 'S';
                    num *= -1;
                    hours *= -1;
                }
                else coordin = 'N';
                double minutes = (num - hours) * 60;
                int minute = (int)minutes;
                double second = (minutes - minute) * 600000;
                int sec = (int)second;
                double secs = sec / 10;
                secs /= 1000;
                return hours + "° " + minute + "' " + secs + (char)34+" "+ coordin;
            }
            static string printLong(double num)
            {
                char coordin;
                int hours = (int)num;
                if (hours < 0)
                {
                    coordin = 'W';
                    num *= -1;
                    hours *= -1;
                }
                else coordin = 'E';
                double minutes = (num - hours) * 60;
                int minute = (int)minutes;
                double second = (minutes - minute) * 600000;
                int sec = (int)second;
                double secs = sec / 10;
                secs /= 1000;
                return hours + "° " + minute + "' " + secs + (char)34 + " " + coordin;
            }
        }
    }
}