using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WordleAPI.CQRS.Query;
using WordleAPI.CQRS.QueryHandler;
using WordleAPI.Repositories.Interfaces;
using WordleAPI.Services.Interfaces;
using Xunit;

namespace WordleAPI.UnitTests.CQRS
{
    public class WordleQueryHandlerUnitTests
    {
        private readonly Mock<IWordleQueryValidator> _validator;
        private readonly Mock<IWordleService> _service;
        private readonly Mock<IWordleRepo> _repo;
        private WordleQueryHandler handler;

        public WordleQueryHandlerUnitTests()
        {
            _validator = new Mock<IWordleQueryValidator>();
            _service = new Mock<IWordleService>();
            _repo = new Mock<IWordleRepo>();

            handler = new WordleQueryHandler(
                _validator.Object,
                _service.Object,
                _repo.Object
            );
        }

        [Fact]
        public async void Handle_ValidatorFails_ReturnErrorObject()
        {
            //Arrange
            WordleQuery query = new WordleQuery();
            _validator.Setup(v => v.Validate(query)).Returns(false);

            //Act
            var result = handler.Handle(query, default);

            //Assert
            _validator.Verify(v => v.Validate(query), Times.Once);
            Assert.False(result.Result.Result);
            Assert.Equal(WordleErrorCode.InvalidRequest, result.Result.ErrorCode);
        }
    }
}
