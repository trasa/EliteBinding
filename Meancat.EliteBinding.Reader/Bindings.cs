using System.Xml.Linq;

namespace Meancat.EliteBinding.Reader
{
    public class Bindings
    {
        public XDocument Document { get; }
        public XElement Root => Document.Root!;

        public Bindings(XDocument bindingsDocument)
        {
            Document = bindingsDocument;
        }
    }
}
