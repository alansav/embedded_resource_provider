using System.Linq;
using System.Reflection;
using Xunit;

namespace Savage.Providers
{
    public class EmbeddedResourceProviderTests
    {
        private const string EmbeddedResourceName = "Savage.Providers.Resources.EmbeddedResource.txt";
        [Fact]
        public void ListEmbeddedResources_returns_expected_Results()
        {
            var sut = new EmbeddedResourceProvider(Assembly.GetExecutingAssembly());
            var actual = sut.ListEmbeddedResources();

            Assert.True(actual.Count() == 1);
            Assert.Contains(EmbeddedResourceName, actual);
        }

        [Fact]
        public void GetEmbeddedResourceString_returns_expected_value()
        {
            var sut = new EmbeddedResourceProvider(Assembly.GetExecutingAssembly());
            var actual = sut.GetEmbeddedResourceString(EmbeddedResourceName);

            Assert.Equal("Lorem Ipsum...\t...id est laborum", actual);
        }
    }
}
