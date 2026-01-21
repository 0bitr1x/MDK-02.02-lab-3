namespace MDK_02._02_lab3.Interface;

public interface IOpticalIterator
{
    bool MoveNext();
    IOpticalElement Current { get; }

    void Reset();
}