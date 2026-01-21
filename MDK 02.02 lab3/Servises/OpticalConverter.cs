using MDK_02._02_lab3.Interface;

namespace MDK_02._02_lab3.Servises;

public class OpticalConverter : IOpticalElement
{
    public string Name { get; }
    public string Type => "Преобразователь";

    public OpticalConverter(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return $"{Type}: {Name}";
    }
}