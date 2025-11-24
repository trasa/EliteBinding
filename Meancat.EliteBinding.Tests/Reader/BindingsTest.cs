using Meancat.EliteBinding.Reader;
using Xunit.Abstractions;

namespace Meancat.EliteBinding.Tests.Reader;

public class BindingsTest
{
    public ITestOutputHelper Output { get; }
    private Bindings Bindings { get; }

    public BindingsTest(ITestOutputHelper output)
    {
        Output = output;
        var doc = BindingFileReader.LoadBindingFile("Custom.4.2.binds");
        Bindings = new Bindings(doc);
    }

    [Fact]
    public void NoDevice()
    {
        foreach (var name in Bindings.NoDevice)
        {
            Output.WriteLine(name);
        }
    }

    [Fact]
    public void BindingsForDevice()
    {
        foreach(var binding in Bindings.ForDevice("044FB352"))
        {
            Output.WriteLine(binding.ToString());
        }
    }
}
