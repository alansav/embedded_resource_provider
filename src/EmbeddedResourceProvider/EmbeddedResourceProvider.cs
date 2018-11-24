using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Savage.Providers
{
    public interface IEmbeddedResourceProvider
    {
        IEnumerable<string> ListEmbeddedResources();

        string GetEmbeddedResourceString(string name);
    }

    public class EmbeddedResourceProvider : IEmbeddedResourceProvider
    {
        private readonly Assembly Assembly;
        public EmbeddedResourceProvider(Assembly assembly)
        {
            Assembly = assembly;
        }

        public IEnumerable<string> ListEmbeddedResources()
        {
            return Assembly.GetManifestResourceNames();
        }

        public string GetEmbeddedResourceString(string name)
        {
            using (var reader = new StreamReader(Assembly.GetManifestResourceStream(name)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
