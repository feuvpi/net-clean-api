
using Core.Interfaces;

namespace Tests
{
    public class TestEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
