using ThouShallNotPass.Services.Extensions;
using Xunit;

namespace ThouShallNotPass.Services.Test
{
    public class StringExtensionsTests
    {
        public StringExtensionsTests()
        {

        }

        [Fact]
        public void StringExtension_ToSha256_SholdBe256BitLong()
        {
            var someStringValue = "Some String Value";

            var hash = someStringValue.Tosha256();

            Assert.Equal(32, hash.Length);
        }

        [Fact]
        public void StringExtension_ToSha256_SholdAlwaysBeTheSameByInput()
        {
            var someStringValue = "Some String Value";

            var hash1 = someStringValue.Tosha256();

            var hash2 = someStringValue.Tosha256();

            Assert.Equal(hash1, hash2);
        }
    }
}
