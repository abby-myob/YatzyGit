
using System;
using System.Collections.Generic;
using Moq;
using Moq.Language.Flow;
using Xunit;
using YatzyLibrary;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    public class RoundTests
    {
        private Mock<IPlayer> _playerMock;
        private Mock<IRoll> _rollMock;
        private Mock<IScoring> _scoringMock;
        private Mock<IResponseThingy> _ioMock;
        private Mock<ICategories> _categoriesMock;

        public RoundTests()
        {
            _playerMock = new Mock<IPlayer>();
            _rollMock = new Mock<IRoll>();
            _scoringMock = new Mock<IScoring>();
            _ioMock = new Mock<IResponseThingy>();
            _categoriesMock = new Mock<ICategories>();
        }

        [Fact]
        public void ReRollOnlyTwice()
        {
            //Arrange 

            _ioMock.Setup(io => io.RollAgainQuestion()).Returns(true);

            var round = new Round(_playerMock.Object, _rollMock.Object, _scoringMock.Object, _ioMock.Object);
            

            //Act
            round.StartRolling(); 
            //Assert 
            _ioMock.Verify(io => io.RollAgainQuestion(), Times.Exactly(2));
        }
        
        [Fact]
        public void Category_been_used_false()
        {
            //Arrange 
            var playerMock2 = new Mock<IPlayer>();
            playerMock2.Setup(io => io.HasCategoryBeenUsed(It.IsAny<string>())).Returns(false);
            playerMock2.Setup(p => p.ReturnCategories()).Returns(_categoriesMock.Object);

            var round = new Round(playerMock2.Object, _rollMock.Object, _scoringMock.Object, _ioMock.Object);

            //Act
            round.Scoring(); 
            
            //Assert 
            playerMock2.Verify(io => io.RemoveCategory(It.IsAny<string>()), Times.Once);
        }
        
        [Fact]
        public void Category_pair_return_false()
        {
            //Arrange 
            var playerMock2 = new Mock<IPlayer>();
            var ioMock2 = new Mock<IResponseThingy>();
            ioMock2.Setup(io => io.ChooseCategory()).Returns("pair");
            playerMock2.Setup(p => p.ReturnCategories()).Returns(_categoriesMock.Object);

            var round = new Round(playerMock2.Object, _rollMock.Object, _scoringMock.Object, ioMock2.Object);

            //Act
            round.Scoring(); 
            
            //Assert 
            playerMock2.Verify(io => io.RemoveCategory("pair"), Times.Once);
        }
        
        [Fact]
        public void Category_are_empty()
        {
            //Arrange 
            var playerMock2 = new Mock<IPlayer>(); 
            playerMock2.Setup(p => p.IsAllOutOfCategories()).Returns(false);

            var round = new Round(playerMock2.Object, _rollMock.Object, _scoringMock.Object, _ioMock.Object);

            //Act
            var areEmpty = round.AreCategoriesEmpty(); 
            
            //Assert 
            Assert.False(areEmpty);
        }
        
        [Fact]
        public void PrintScores()
        {
            //Arrange  

            var round = new Round(_playerMock.Object, _rollMock.Object, _scoringMock.Object, _ioMock.Object);

            //Act
            round.PrintScores(); 
            
            //Assert 
            _ioMock.Verify(io => io.PrintScore(_playerMock.Object), Times.Once);
        }
        
        [Fact]
        public void StartRolling()
        {
            //Arrange  
            var ioMock2 = new Mock<IResponseThingy>();
            ioMock2.Setup(io => io.RollAgainQuestion()).Returns(true);
            
            var round = new Round(_playerMock.Object, _rollMock.Object, _scoringMock.Object, ioMock2.Object);

            //Act
            round.StartRolling(); 
            
            //Assert 
            ioMock2.Verify(io => io.PrintDice(It.IsAny<int[]>()), Times.Exactly(3));
        }
        
        [Fact]
        public void StartRollingOnlyOnce()
        {
            //Arrange  
            var ioMock2 = new Mock<IResponseThingy>();
            ioMock2.Setup(io => io.RollAgainQuestion()).Returns(false);
            
            var round = new Round(_playerMock.Object, _rollMock.Object, _scoringMock.Object, ioMock2.Object);

            //Act
            round.StartRolling(); 
            
            //Assert 
            ioMock2.Verify(io => io.PrintDice(It.IsAny<int[]>()), Times.Exactly(2));
        }
    }
}