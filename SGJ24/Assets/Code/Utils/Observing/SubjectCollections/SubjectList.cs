using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Observing.Handlers;
using Utils.Observing.SubjectProperties;
using Utils.Observing.Subscribers;

namespace Utils.Observing.SubjectCollections
{
  public interface ISubjectList<T> : IReadOnlyList<T>
  {
    ISubscriber<T> OnAdded();
    ISubscriber<T> OnRemoved();
    ISubscriber<ValueChanged<T>> OnReplaced();
    ISubscriber<EmptyEvent> OnClear();
    int IndexOf(T item);
    public bool Contains(T item);
  }

  [Serializable]
  public class SubjectList<T> : IList<T>, ISubjectList<T>, IDisposable
  {
    private readonly Handler<T> _onAdd = new();
    private readonly Handler<T> _onRemoved = new();
    private readonly Handler<ValueChanged<T>> _onReplaced = new();
    private readonly Handler<EmptyEvent> _onClear = new();

    [SerializeField]
    private List<T> _source;

    public int Count => _source.Count;

    public bool IsReadOnly => false;

    public T this[int index]
    {
      get => _source[index];
      set
      {
        if (_source[index].Equals(value))
          return;

        T oldValue = _source[index];
        _source[index] = value;

        _onReplaced.Raise(new ValueChanged<T> { OldValue = oldValue, NewValue = value });
      }
    }

    public SubjectList() =>
      _source = new List<T>();

    public SubjectList(int capacity) =>
      _source = new List<T>(capacity);

    public SubjectList(List<T> source) =>
      _source = source;

    public IEnumerator<T> GetEnumerator() =>
      _source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
      GetEnumerator();

    public void Add(T item)
    {
      _source.Add(item);
      _onAdd.Raise(item);
    }

    public void Clear()
    {
      foreach (T element in _source)
        _onRemoved.Raise(element);

      _source.Clear();
      _onClear.Raise(new EmptyEvent());
    }

    public bool Contains(T item) =>
      _source.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) =>
      _source.CopyTo(array, arrayIndex);


    public bool Remove(T item)
    {
      bool remove = _source.Remove(item);

      if (remove)
        _onRemoved.Raise(item);

      return remove;
    }

    public int IndexOf(T item) =>
      _source.IndexOf(item);

    public void Insert(int index, T item)
    {
      _source.Insert(index, item);
      _onAdd.Raise(item);
    }

    public void RemoveAt(int index)
    {
      T item = _source[index];
      _source.RemoveAt(index);
      _onRemoved.Raise(item);
    }

    public ISubscriber<T> OnAdded() =>
      new Subscriber<T>(_onAdd);

    public ISubscriber<T> OnRemoved() =>
      new Subscriber<T>(_onRemoved);

    public ISubscriber<ValueChanged<T>> OnReplaced() =>
      new Subscriber<ValueChanged<T>>(_onReplaced);

    public ISubscriber<EmptyEvent> OnClear() =>
      new Subscriber<EmptyEvent>(_onClear);

    public void Dispose()
    {
      _onAdd?.Dispose();
      _onRemoved?.Dispose();
      _onReplaced?.Dispose();
      _onClear?.Dispose();
    }
  }
}