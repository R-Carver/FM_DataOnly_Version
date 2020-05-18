using UnityEngine;
using System.Collections;

public interface IPropertyListener<T>
{
    void OnPropertyChanged(T changedObject);
}