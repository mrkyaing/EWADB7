using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Respostories.Domain;
using HRMS.Web.Services;
using HRMS.Web.UnitOfWorks;
using Moq;

namespace HRMS.UnitTests.Domain.Position {
    public class PositionServiceUnitTest {
        //step 1: create the mock service object 
        public Mock<IPositionService> positionserviceMock = new Mock<IPositionService>();
        //step 2: create the mock repository object 
        public Mock<IPositoryRepository> positoryRepositoryMock = new Mock<IPositoryRepository>();
        //step 3: create the mock unit of work object
        public Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
        [Fact]
        public void ShouldCreatedPosition() {
            //1 ) Arrange
            var expectedPositionViewModel = new PositionViewModel() {
                Code = "P001",
                Description = "Position 1",
                Level = 1
            };
            var expectedPositionEntity = new PositionEntity() {
                Id = Guid.NewGuid().ToString(),
                Code = expectedPositionViewModel.Code,
                Description = expectedPositionViewModel.Description,
                Level = expectedPositionViewModel.Level,
                CreatedAt = DateTime.Now,
                CreatedBy = "system",
                IsActive = true,
                Ip = "127.0.0.1"
            };
            positoryRepositoryMock.Setup(r => r.Create(expectedPositionEntity));
            unitOfWorkMock.Setup(u => u.PositoryRepository).Returns(positoryRepositoryMock.Object);
            // 2 ) Act
            var positonService = new PositionService(unitOfWorkMock.Object);
            // 3  Assert
            Assert.Equal(expectedPositionViewModel.Code, expectedPositionEntity.Code);
        }

        [Fact]
        public void ShouldAllPosition() {
            //1) arrange
            var expactedViewModels = new List<PositionViewModel>() {
                new PositionViewModel() {
                    Code = "P001",
                    Description = "Position 1",
                    Level = 1
                },
                new PositionViewModel() {
                    Code = "P002",
                    Description = "Position 2",
                    Level = 2
                }
            };
            var expextedPositonEntities = new List<PositionEntity>() {
                new PositionEntity {
                    Id= Guid.NewGuid().ToString(),
                    Code = "P001",
                    Description = "Position 1",
                    Level = 1,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    Ip = "127.0.0.1",
                    IsActive = false
                },
                 new PositionEntity {
                    Id= Guid.NewGuid().ToString(),
                    Code = "P002",
                    Description = "Position 2",
                    Level = 2,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    Ip = "127.0.0.1",
                    IsActive = true
                }
            };
            positoryRepositoryMock.Setup(r => r.GetAll(w => w.IsActive)).Returns(expextedPositonEntities);
            unitOfWorkMock.Setup(u => u.PositoryRepository).Returns(positoryRepositoryMock.Object);
            //2) act
            var positionService = new PositionService(unitOfWorkMock.Object);
            var actualResults = positionService.GetAll();
            //3) assert
            for (int i = 0; i < expactedViewModels.Count; i++) {
                var expected = expactedViewModels[i];
                var actual = actualResults.ElementAt(i);
                Assert.Equal(expected.Code, actual.Code);
                Assert.Equal(expected.Description, actual.Description);
                Assert.Equal(expected.Level, actual.Level);
            }
        }
    }
}
