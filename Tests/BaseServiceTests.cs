

using Application.Services;
using Core.Interfaces;
using Moq;

namespace Tests
{
    public class BaseServiceTests
    {
        private readonly Mock<IBaseRepository<TestEntity>> _repositoryMock;
        private readonly BaseService<TestEntity> _service;

        public BaseServiceTests()
        {
            _repositoryMock = new Mock<IBaseRepository<TestEntity>>();
            _service = new TestService(_repositoryMock.Object);
        }

        // -- tests

        [Fact]
        public async Task GetAllAsync_ReturnsAllEntities()
        {
            // Arrange
            var entities = new List<TestEntity>
    {
        new TestEntity { Id = Guid.NewGuid() },
        new TestEntity { Id = Guid.NewGuid() }
    };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entities, result);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEntityWithMatchingId()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid() };
            _repositoryMock.Setup(r => r.GetByIdAsync(entity.Id)).ReturnsAsync(entity);

            // Act
            var result = await _service.GetByIdAsync(entity.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task AddAsync_AddsEntityToRepository()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid() };
            _repositoryMock.Setup(r => r.AddAsync(entity)).ReturnsAsync(entity);

            // Act
            var result = await _service.AddAsync(entity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
            _repositoryMock.Verify(r => r.AddAsync(entity), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesEntityInRepository()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid() };
            _repositoryMock.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(true);

            // Act
            var result = await _service.UpdateAsync(entity);

            // Assert
            Assert.True(result);
            _repositoryMock.Verify(r => r.UpdateAsync(entity), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_DeletesEntityFromRepository()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            _repositoryMock.Setup(r => r.DeleteAsync(entityId)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(entityId);

            // Assert
            Assert.True(result);
            _repositoryMock.Verify(r => r.DeleteAsync(entityId), Times.Once);
        }

    }

    public class TestService : BaseService<TestEntity>
    {
        public TestService(IBaseRepository<TestEntity> repository) : base(repository)
        {
        }
    }
}
