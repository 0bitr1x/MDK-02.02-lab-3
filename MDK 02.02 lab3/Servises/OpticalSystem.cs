using MDK_02._02_lab3.Interface;

namespace MDK_02._02_lab3.Servises;

public class OpticalSystem
{
    private readonly List<IOpticalElement> _elements;
    public OpticalSystem()
    {
        _elements = new List<IOpticalElement>();
    }
    public void AddElement(IOpticalElement element)
    {
        _elements.Add(element);
    }
    public IOpticalIterator CreateIterator()
    {
        return new OpticalIterator(_elements);
    }
    public int Count => _elements.Count;
}