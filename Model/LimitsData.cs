using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PC_Rul_Tests
{
    public class LimitsData : IEquatable<LimitsData>, IComparable<LimitsData>
    {
      
        public string FirstLimit_Min { get; set; }
        public string FirstLimit_Max { get; set; }
        public string SecondLimit_Min { get; set; }
        public string SecondLimit_Max { get; set; }
        public string TherdLimit_Min { get; set; }
        public string TheardLimit_Max { get; set; }

        public int CompareTo(LimitsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstLimit_Min.CompareTo(other.FirstLimit_Min);
        }

        public bool Equals(LimitsData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstLimit_Min == other.FirstLimit_Min;
        }
    }
}
