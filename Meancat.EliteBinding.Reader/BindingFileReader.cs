using System.Xml.Linq;

namespace Meancat.EliteBinding.Reader
{
    public class BindingFileReader
    {
        public static XDocument LoadBindingFile(string filePath)
        {
            return XDocument.Load(filePath);
        }
    }
}
