using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Guid guid = Guid.NewGuid();
            // A a1 = new(guid);
            // A a2 = new(guid);
            // Console.WriteLine(a1.Equals(a2));



            BenchmarkRunner.Run<BenchmakService>();
            
        }

    }
    public abstract class Entity
    {
        public Guid Id { get; init; }
        public Entity(Guid id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is not Entity entity) return false;
            if (obj.GetType() != GetType()) return false;

            return entity.Id == Id;
        }
    }
    public sealed class A : Entity
    {
        public A(Guid id) : base(id)
        {
        }
    }
}
