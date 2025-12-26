using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BenchmakService
    {
        private bool result;
        [Benchmark(Baseline = true)]
        public void Equals()
        {
            int id = 1;
            Test1 test1 = new()
            { 
                Id = id,
            };
            Test1 test2 = new()
            {
                Id = id,
            };

            result = test1.Equals(test2);
        }
        [Benchmark]
        public void IEquatable()
        {
            int id = 1;
            Test2 test1 = new()
            {
                Id = id,
            };
            Test2 test2 = new()
            {
                Id = id,
            };

            result = test1.Equals(test2);
        }
    }
    public class Test1
    {
        public int Id { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Test1 test1) return false;
            if (obj.GetType() != GetType()) return false;

            return test1.Id == Id;
        }
    }
    public class Test2 : IEquatable<Test2>
    {
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Test2); // Temiz kod
        }

        public bool Equals(Test2? other)
        {
            if (other is null) return false;
            return other.Id == Id; // Basit ve yeterli
        }
    }
}
