using System.Text.Json;
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
    public void BindingsForDeviceOutputAsJson()
    {
        var dict = Bindings.ForDevice("044FB352").ToDictionary(binding => binding.Name, binding => "");
        foreach (var binding in Bindings.ForDevice("044FB351"))
        {
            dict.Add(binding.Name, "");
        }

        dict = dict.OrderBy(kv => kv.Key).ToDictionary();

        var json = System.Text.Json.JsonSerializer.Serialize(dict,new JsonSerializerOptions(){WriteIndented = true});

        Output.WriteLine(json);

    }
    [Fact]
    public void BindingsForDevice()
    {
        foreach(var binding in Bindings.ForDevice("044FB352").OrderBy(b => b.Key))
        {
            Output.WriteLine(binding.ToString());
        }
/*
        foreach (var binding in Bindings.ForDevice("044FB351"))
        {
            Output.WriteLine(binding.ToString());
        }*/
    }
}
