using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils.Observing.Handlers;
using Utils.Observing.Subscribers;

namespace Utils.Observing.SubjectCollections
{
  public struct ElementAdded<TKey, TValue>
  {
    public TKey Key;
    public TValue Value;

    public override string ToString() =>
      $"Add: [Key: {Key} Value: {Value}]";
  }

  public struct ElementRemoved<TKey, TValue>
  {
    public TKey Key;
    public TValue Value;

    public override string ToString() =>
      $"Remove: [Key: {Key} Value: {Value}]";
  }

  public struct ValueChanged<TKey, TValue>
  {
    public TKey Key;
    public TValue OldValue;
    public TValue NewValue;

    public override string ToString() =>
      $"Changed: [Key: {Key} OldValue: {OldValue} NewValue: {NewValue}]";
  }

  public interface ISubjectDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
  {
    ISubscriber<ElementAdded<TKey, TValue>> OnAdded();
    ISubscriber<ElementRemoved<TKey, TValue>> OnRemoved();
    ISubscriber<ValueChanged<TKey, TValue>> OnReplaced();
    ISubscriber<EmptyEvent> OnClear();
  }

  public class SubjectDictionary<TKey, TValue> : ISubjectDictionary<TKey, TValue>, IDictionary<TKey, TValue>, IDisposable
  {
    private readonly Dictionary<TKey, TValue> _source;

    private readonly Handler<ElementAdded<TKey, TValue>> _onAdded = new();
    private readonly Handler<ElementRemoved<TKey, TValue>> _onRemoved = new();
    private readonly Handler<ValueChanged<TKey, TValue>> _onReplaced = new();
    private readonly Handler<EmptyEvent> _onClear = new();

    public ICollection<TKey> Keys => _source.Keys;
    IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

    IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

    public ICollection<TValue> Values => _source.Values;
    public int Count => _source.Count;
    public bool IsReadOnly => false;

    public TValue this[TKey key]
    {
      get => _source[key];
      set
      {
        if (!_source.ContainsKey(key))
          Add(key, value);

        if (_source[key].Equals(value))
          return;

        TValue oldValue = _source[key];
        _source[key] = value;

        _onReplaced.Raise(new ValueChanged<TKey, TValue>() { Key = key, OldValue = oldValue, NewValue = value });
      }
    }

    public SubjectDictionary() =>
      _source = new Dictionary<TKey, TValue>();

    public SubjectDictionary(int capacity) =>
      _source = new Dictionary<TKey, TValue>(capacity);

    public SubjectDictionary(Dictionary<TKey, TValue> source) =>
      _source = source;

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
      _source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
      GetEnumerator();

    public void Add(KeyValuePair<TKey, TValue> item)
    {
      _source.Add(item.Key, item.Value);
      _onAdded.Raise(new ElementAdded<TKey, TValue> { Key = item.Key, Value = item.Value });
    }

    public void Add(TKey key, TValue value)
    {
      _source.Add(key, value);
      _onAdded.Raise(new ElementAdded<TKey, TValue> { Key = key, Value = value });
    }

    public void Clear()
    {
      foreach (KeyValuePair<TKey, TValue> item in _source)
        _onRemoved.Raise(new ElementRemoved<TKey, TValue> { Key = item.Key, Value = item.Value });

      _source.Clear();
      _onClear.Raise(new EmptyEvent());
    }

    public bool Contains(KeyValuePair<TKey, TValue> item) =>
      _source.Contains(item);

    void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) =>
      ((ICollection<KeyValuePair<TKey, TValue>>) _source).CopyTo(array, arrayIndex);


    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
      bool remove = _source.Remove(item.Key);

      if (remove)
        _onRemoved.Raise(new ElementRemoved<TKey, TValue>() { Key = item.Key, Value = item.Value });

      return remove;
    }

    public bool ContainsKey(TKey key) =>
      _source.ContainsKey(key);

    public bool Remove(TKey key)
    {
      TValue value = _source[key];
      bool remove = _source.Remove(key);

      if (remove)
        _onRemoved.Raise(new ElementRemoved<TKey, TValue>() { Key = key, Value = value });

      return remove;
    }

    public bool TryGetValue(TKey key, out TValue value) =>
      _source.TryGetValue(key, out value);

    public ISubscriber<ElementAdded<TKey, TValue>> OnAdded() =>
      new Subscriber<ElementAdded<TKey, TValue>>(_onAdded);

    public ISubscriber<ElementRemoved<TKey, TValue>> OnRemoved() =>
      new Subscriber<ElementRemoved<TKey, TValue>>(_onRemoved);

    public ISubscriber<ValueChanged<TKey, TValue>> OnReplaced() =>
      new Subscriber<ValueChanged<TKey, TValue>>(_onReplaced);

    public ISubscriber<EmptyEvent> OnClear() =>
      new Subscriber<EmptyEvent>(_onClear);

    public void Dispose()
    {
      _onAdded?.Dispose();
      _onRemoved?.Dispose();
      _onReplaced?.Dispose();
      _onClear?.Dispose();
    }
  }
}