
using System.Collections;

namespace Tensor;

internal class Tensor<T>
{
    
    private T[] _arr;

    private int[] _dimensions;

    private bool _isSingleValue = false;

    public int ItemsCount { get; private set; }

    public int ItemsMaxCount { get; private set; }

    public long Rank => _dimensions.Length;


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
        _arr = new T[ItemsMaxCount];
    }

    public bool TryAddItems(object boxedItems) 
    {
        var items = EnumerateObject(boxedItems);
        if(ItemsCount + items.Length > ItemsMaxCount)
        {
            return false;
        }

        items.CopyTo(_arr, ItemsCount);
        ItemsCount += items.Length;
       
        return true;
    }

    public Tensor(object o, params int[] dimensions)
    {
        TensorValidator.ValidateDimensionsLength(dimensions);
        _dimensions = dimensions ?? Array.Empty<int>();
        SetItemsMaxCount();
        _arr = new T[ItemsMaxCount];

        TryAddItems(o);
        TensorValidator.ValidateElementsCount(ItemsMaxCount, ItemsCount);
    }

    public T this[params int[] indexes]
    {
        get
        {

            var index = TransformIndexFrom(indexes);
            return _arr[index];
        }
        set
        {
            var index = TransformIndexFrom(indexes);
            _arr[index] = value;
        }
    }
    private int TransformIndexFrom(int[] indexes)
    {
        if (indexes.Length > Rank)
        {
            throw new ArgumentException("Unreal rank of index");
        }

        int index = indexes[^1];

        for (int i = indexes.Length - 2; i >= 0; i--)
        {
            index += indexes[i] * _dimensions[i];
        }

        TensorValidator.ValidateIndex(_dimensions, index);

        return index;
    }

    public override string ToString()
    {
        string result = "";
        foreach (var item in _arr)
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
            _arr[ItemsCount] = (T)o;
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
