using MDK_02._02_lab3.Interface;

namespace MDK_02._02_lab3.Servises;

public class OpticalIterator : IOpticalIterator
{
    private readonly List<IOpticalElement> _elements;
    private int _currentIndex;

    public OpticalIterator(List<IOpticalElement> elements)
    {
        _elements = elements;
        _currentIndex = -1;
    }

    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _elements.Count;
    }

    public IOpticalElement Current
    {
        get
        {
            if (_currentIndex < 0 || _currentIndex >= _elements.Count)
                return null;
            return _elements[_currentIndex];
        }
    }
    public void Reset()
    {
        _currentIndex = -1;
    }
}