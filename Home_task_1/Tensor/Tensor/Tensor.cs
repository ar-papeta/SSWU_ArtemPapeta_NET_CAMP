
using System.Collections;

namespace Tensor;

internal class Tensor<T>
{
    

    private T[] _data;

    private int[] _dimensions;

    private bool _isSingleValue = false;

    public int ItemsCount { get; private set; }

    public int ItemsMaxCount { get; private set; }

    public long DimensionsCount => _dimensions.Length;


    private void SetItemsMaxCount()
    {
        ItemsMaxCount = 1;
        if (!_isSingleValue)
        {
            foreach (var d in _dimensions)
            {
                ItemsMaxCount *= d;
            }
        }    
    }

    public Tensor(params int[] dimensions)
    {
        TensorValidator.ValidateDimensionsLength(dimensions);
        _dimensions = dimensions ?? Array.Empty<int>();
        SetItemsMaxCount();
        _data = new T[ItemsMaxCount];
    }

    public bool TryAddItems(object boxedItems) 
    {
        if(ItemsCount == ItemsMaxCount)
        {
            return false;
        }

        var items = EnumerateObject(boxedItems);

        if (ItemsCount + items.Length > ItemsMaxCount)
        {
            return false;
        }

        items.CopyTo(_data, ItemsCount);
        ItemsCount += items.Length;
       
        return true;
    }

    public Tensor(object o, params int[] dimensions)
    {
        TensorValidator.ValidateDimensionsLength(dimensions);
        _dimensions = dimensions ?? Array.Empty<int>();
        SetItemsMaxCount();
        _data = new T[ItemsMaxCount];

        TryAddItems(o);
        TensorValidator.ValidateElementsCount(ItemsMaxCount, ItemsCount);
    }

    public T this[params int[] indexes]
    {
        get
        {

            var index = TransformIndexFrom(indexes);
            return _data[index];
        }
        set
        {
            var index = TransformIndexFrom(indexes);
            _data[index] = value;
        }
    }
    private int TransformIndexFrom(int[] indexes)
    {
        if (indexes.Length > DimensionsCount)
        {
            throw new ArgumentException("Unreal rank of index");
        }

        int index = indexes[^1];
        int extraElements = _dimensions[^1];

        for (int i = indexes.Length - 2; i >= 0; i--)
        {
            index += indexes[i] * extraElements;
            extraElements *= _dimensions[i];
        }

        TensorValidator.ValidateIndex(_dimensions, index);

        return index;
    }

    public override string ToString()
    {
        string result = "";
        foreach (var item in _data)
        {
            result += $" {item}";
        }
        return result;
    }

    private T[] EnumerateObject(object o)
    {
        var checkSingle = o as IEnumerable;
        T[] values = Array.Empty<T>();
        if (checkSingle is null)
        {
            _isSingleValue = true;
            _data[ItemsCount] = (T)o;
            return new T[] { (T)o };
        }
        try
        {
            values = ((IEnumerable)o).Cast<T>().ToArray()!;
        }
        catch(InvalidCastException e)
        {
            //TO DO: handle invalid cast exception in correct way
            throw e;
        }

        return values;
        
    }
}
