namespace MarsRoverTest
{
    using MarsRover;
    using MarsRover.Exceptions;
    using NUnit.Framework;

    [TestFixture]
    public class MovementMessageHandlerTests
    {
        private readonly MovementMessageHandler _sut;

        public MovementMessageHandlerTests()
        {
            _sut = new MovementMessageHandler();
        }

        [TestCase("1 2 N///LFLFLFLFF", "1-3-N")]
        [TestCase("1 2 N///RBRBRBRBB", "1-1-N")]
        [TestCase("0 0 N///FFFFFF", "0-6-N")]
        [TestCase("0 0 W///BBBBBB", "6-0-W")]
        [TestCase("0 0 W///BBBBBBR", "6-0-N")]
        [TestCase("1 1 S///FBRLFB", "1-1-S")]
        public void WhenMessageIsValid_ReturnsFinalPosition(string input, string expected)
        {
            var output = _sut.HandleMessage(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        [TestCase("1 2 N")]
        [TestCase("LFLBRBLB")]
        [TestCase("1 2 N///L FLBRBLB")]
        public void WhenMessageIsNotValid_ReturnsInvalidMessageException(string input)
        {
            Assert.Throws<MessageNotValidException>(() => _sut.HandleMessage(input));
        }

        [TestCase("1 -1 S///LFBR")]
        [TestCase("-1 1 S///LFBR")]
        [TestCase("1 1 S///FFFFFFF")]
        [TestCase("0 0 E///RRF")]
        public void WhenMessageHasNegativeNumber_ReturnsOutOfBoundsException(string input)
        {
            Assert.Throws<OutOfBoundsException>(() => _sut.HandleMessage(input));
        }

        [TestCase("1 2 F///LFB")]
        public void WhenInvalidDirection_ReturnsInvalidDirectionException(string input)
        {
            Assert.Throws<InvalidDirectionException>(() => _sut.HandleMessage(input));
        }

        [TestCase("2 2 N///LMLMRMLM")]
        public void WhenInvalidMovement_ReturnsInvalidDirectionException(string input)
        {
            Assert.Throws<InvalidMovementException>(() => _sut.HandleMessage(input));
        }

        [TestCase("A 2 N///LMLMRMLM")]
        [TestCase("2 A N///LMLMRMLM")]
        public void WhenInvalidPosition_ReturnsInvalidPositionException(string input)
        {
            Assert.Throws<InvalidPositionException>(() => _sut.HandleMessage(input));
        }
    }
}