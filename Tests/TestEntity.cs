
using Core.Interfaces;

namespace Tests
{
    public class TestEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
