using Moq;
using Xunit;
using YatzyLibrary;
using YatzyLibrary.Interfaces;

namespace YatzyTests
{
    public class GameTests
    {
        [Fact]
        public void print_Scores_Once()
        {
            // Arrange
            var roundMock = new Mock<IRound>();
            var game = new Game(roundMock.Object);

            // Act 
            game.Play();
            
            // Assert
            roundMock.Verify(r => r.PrintScores(), Times.Once);
        }
        
        [Fact]
        public void rolling_how_many_times()
        {
            // Arrange
            var roundMock = new Mock<IRound>();
            var game = new Game(roundMock.Object);

            // Act 
            game.Play();

            // Assert
            roundMock.Verify(r => r.StartRolling(), Times.Exactly(20));
        }
    }
}