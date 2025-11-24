using Meancat.EliteBinding.Reader;

namespace Meancat.EliteBinding.Tests.Reader;

public class BindingFileReaderTest
{
    [Fact]
    public void ParseFile()
    {
        var doc = BindingFileReader.LoadBindingFile("Custom.4.2.binds");
        Assert.NotNull(doc);
        Assert.NotNull(doc.Root);
    }
}
