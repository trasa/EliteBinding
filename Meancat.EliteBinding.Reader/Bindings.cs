using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Meancat.EliteBinding.Reader
{
    public class Binding
    {
        public string Name { get; set; }
        public string Device { get; set; }
        public string Key { get; set; }

        public Binding(string name, string device, string key)
        {
            Name = name;
            Device = device;
            Key = key;
        }

    }


    public class Bindings
    {
        public static class Attributes
        {
            public static readonly string Device = nameof(Device);
            public static readonly string Key = nameof(Key);
        }

        public XDocument Document { get; }
        public XElement Root => Document.Root!;

        public Bindings(XDocument bindingsDocument)
        {
            Document = bindingsDocument;
        }


        public IEnumerable<XElement> NoDeviceElements => DeviceElements(Device.None);

        public IEnumerable<XElement> DeviceElements(string deviceName) => Root.Descendants()
            .Where(e => e.Attribute(Attributes.Device)?.Value == deviceName);

        public IEnumerable<Binding> ForDevice(string deviceName) => DeviceElements(deviceName)
            .Select(e => new Binding(
                e.Parent?.Name.LocalName ?? "UNKNOWN",
                e.Attribute(Attributes.Device)?.Value ?? Device.None,
                e.Attribute(Attributes.Key)?.Value ?? "UNKNOWN"
            ));

        public IEnumerable<string> NoDevice => NoDeviceElements
            .Select(e => e.Parent?.Name.LocalName ?? "UNKNOWN")
            .Distinct();


    }
}
