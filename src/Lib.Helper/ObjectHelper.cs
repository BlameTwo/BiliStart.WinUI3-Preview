using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lib.Helper;

public static class ObjectHelper
{
    /// <summary>
    /// List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
    {
        ObservableCollection<T> values = new();
        foreach (var item in list)
        {
            values.Add(item);
        }
        return values;
    }

    public static ObservableCollection<T> ObservableAddRange<T>(
        this ObservableCollection<T> obserlist,
        IEnumerable<T> newlist
    )
    {
        var oldlist = obserlist;
        foreach (var item in newlist)
        {
            oldlist.Add(item);
        }
        return oldlist;
    }

    public static void ObservableRemoveRange<T>(this ObservableCollection<T> list,int start,int end)
    {
        for (int i = start; i < end; i++)
        {
            list.Remove(list[i]);
        }
    }

    /// <summary>
    /// 数组
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static ObservableCollection<T> ToObservableCollection<T>(this T[] list)
    {
        ObservableCollection<T> values = new();
        foreach (var item in list)
        {
            values.Add(item);
        }
        return values;
    }

    public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
    {
        if (list == null)
            return default;
        return new ObservableCollection<T>(list);
    }
}
