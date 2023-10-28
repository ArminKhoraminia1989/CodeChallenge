using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Handlers.Queries;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries;
using CodeChallenge.Core.Entities.BasicInfo;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;
using Moq;

namespace CodeChallenge.UnitTest
{
    public class DoctorTypeTest
    {
        private readonly Mock<IGenericRepository<DoctorType>> _repository;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IMapper> _mapper;
        public DoctorTypeTest()
        {
            _repository = new Mock<IGenericRepository<DoctorType>>();
            _mediator = new Mock<IMediator>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public void TestGetDoctorType()
        {
            //arrange
            int tempId = 1;
            var request = new ShowDoctorTypeRequest();
            request.Id = tempId;
            var handler = new ShowDoctorTypeRequestHandler(_mapper.Object, _repository.Object);

            //act
            var result = handler.Handle(request, CancellationToken.None);

            //assert
            Assert.NotNull(result);
            Assert.IsType<ShowDoctorTypeDto>(result);
        }


        [Fact]
        public void TestGetAllDoctorType()
        {
            //arrange
            var request = new ShowAllDoctorTypeRequest();
            request.take = 100;
            request.page = 1;
            var handler = new ShowAllDoctorTypeRequestHandler(_mapper.Object, _repository.Object);

            //act
            var result = handler.Handle(request, CancellationToken.None);

            //assert
            Assert.NotNull(result);
            Assert.IsType<ShowAllDoctorTypeDto>(result);
        }
        private DoctorType GetDoctorTypeData()
        {
            DoctorType DoctorType = new DoctorType
            {

                Id = 1,
                DateCreated = DateTime.Now,
                Type = Core.Entities.Enums.EnumDoctorType.General,
                MaxTimeVisit = 5,
                MinTimeVisit = 15
            };
            return DoctorType;
        }

        private List<DoctorType> GetProductsData()
        {
            List<DoctorType> productsData = new List<DoctorType>
        {
            new DoctorType
            {
                Id = 1,
                DateCreated = DateTime.Now,
                Type = Core.Entities.Enums.EnumDoctorType.General,
                MaxTimeVisit = 5,
                MinTimeVisit = 15
            },
             new DoctorType
            {
               Id = 2,
                DateCreated = DateTime.Now,
                Type = Core.Entities.Enums.EnumDoctorType.Specialist,
                MaxTimeVisit = 10,
                MinTimeVisit = 30
            },
             new DoctorType
            {
                Id = 3,
                DateCreated = DateTime.Now,
                Type = Core.Entities.Enums.EnumDoctorType.TopSpecialist,
                MaxTimeVisit = 15,
                MinTimeVisit = 45
            },
        };
            return productsData;
        }

    }
}