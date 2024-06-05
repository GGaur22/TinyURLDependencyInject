using TinyURLConversion;

namespace TestTinyURL
{
    public class UnitTestTinyURL
    {
        [Fact]
        public void TestAddingTinyURLs()
        {
            //Arrange
            URL yahooURL = new URL("yahoo.com", "yahoo");
            yahooURL.SaveShortURL("yah");
            yahooURL.SaveShortURL("yaah");

            //Act
            string? yahooTinyURLs = yahooURL.getShortURLs();

            //Assert
            string? yahooTinyURLExpected = "yahoo,yah,yaah";
            Assert.Equal(yahooTinyURLExpected, yahooTinyURLs);
        }

        [Fact]
        public void TestDeletingTinyURLs()
        {
            //Arrange
            URL yahooURL = new URL("yahoo.com", "yahoo");
            yahooURL.SaveShortURL("yah");
            yahooURL.SaveShortURL("yaah");

            //Act
            yahooURL.DeleteShortURL("yahoo");
            string? yahooTinyURLs = yahooURL.getShortURLs();

            //Assert
            string? yahooTinyURLExpected = "yah,yaah,";
            Assert.Equal(yahooTinyURLExpected, yahooTinyURLs);
        }
    }
}