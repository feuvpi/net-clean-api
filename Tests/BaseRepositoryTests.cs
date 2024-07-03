using Dapper;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Moq;
using System.Data;


namespace Tests
{
    public class BaseRepositoryTests
    {
        private readonly Mock<IDbConnection> _connectionMock;
        private readonly Mock<DapperContext> _contextMock;
        private readonly BaseRepository<TestEntity> _repository;

        public BaseRepositoryTests()
        {
            _connectionMock = new Mock<IDbConnection>();
            _contextMock = new Mock<DapperContext>();
            _contextMock.Setup(c => c.CreateConnection()).Returns(_connectionMock.Object);
            _repository = new BaseRepository<TestEntity>(_contextMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEntityWithMatchingId()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test Entity" };
            _connectionMock.Setup(c => c.QuerySingleOrDefaultAsync<TestEntity>(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                .ReturnsAsync(entity);

            // Act
            var result = await _repository.GetByIdAsync(entity.Id);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllEntities()
        {
            // Arrange
            var entities = new List<TestEntity>
            {
                new TestEntity { Id = Guid.NewGuid(), Name = "Test Entity 1" },
                new TestEntity { Id = Guid.NewGuid(), Name = "Test Entity 2" }
            };
            _connectionMock.Setup(c => c.QueryAsync<TestEntity>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(entities);

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.Equal(entities, result);
        }


        [Fact]
        public async Task AddAsync_AddsEntityToDatabase()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test Entity" };
            _connectionMock.Setup(c => c.ExecuteAsync(It.IsAny<string>(), entity, null, null, null))
                .ReturnsAsync(1);

            // Act
            var result = await _repository.AddAsync(entity);

            // Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public async Task UpdateAsync_UpdatesEntityInDatabase()
        {
            // Arrange
            var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test Entity" };
            _connectionMock.Setup(c => c.ExecuteAsync(It.IsAny<string>(), entity, null, null, null))
                .ReturnsAsync(1);

            // Act
            var result = await _repository.UpdateAsync(entity);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_DeletesEntityFromDatabase()
        {
            // Arrange
            var entityId = Guid.NewGuid();
            _connectionMock.Setup(c => c.ExecuteAsync(It.IsAny<string>(), new { Id = entityId }, null, null, null))
                .ReturnsAsync(1);

            // Act
            var result = await _repository.DeleteAsync(entityId);

            // Assert
            Assert.True(result);
        }

    }

}
