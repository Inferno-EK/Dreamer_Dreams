using System.Collections.Generic;

public class SmartList<T>
{
    readonly private List<T> _base;
    readonly private Stack<int> _nextFree;

    public T this[int key]
    {
        get { return _base[key]; }
        set { _base[key] = value; }
    }

    public bool IsValidIndex(int key)
    {
        return !_base[key].Equals(default);
    }

    public int Add(T value)
    {
        if (_nextFree.Count == 0)
        {
            _base.Add(value);
            return _base.Count - 1;
        }

        int newIndex = _nextFree.Pop();
        _base[newIndex] = value;

        return newIndex;

    }

    public int NextValue()
    {
        if (_nextFree.Count == 0)
        {
            return _base.Count - 1;
        }
        return _nextFree.Peek();
    }

    public void Delete(int key)
    {
        _nextFree.Push(key);
        _base[key] = default;
    }
}
