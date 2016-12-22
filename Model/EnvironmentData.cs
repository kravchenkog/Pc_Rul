using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PC_Rul_Tests
{
    public class EnvironmentData : IEquatable<EnvironmentData>, IComparable<EnvironmentData>
    {
        public string English { get; set; }
        public string Italy { get; set; }
        public string Spain { get; set; }
        public string Germany { get; set; }
       

        public int CompareTo(EnvironmentData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return English.CompareTo(other.English);

        }

        public bool Equals(EnvironmentData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return English == other.English;
        }
    }
}
