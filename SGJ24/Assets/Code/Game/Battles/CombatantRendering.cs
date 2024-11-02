using UnityEngine;

namespace Game.Battles
{
  public class CombatantRendering : MonoBehaviour
  {
    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private GameObject _defaultView;

    [SerializeField]
    private GameObject _deadView;

    public void SetToFront() =>
      _renderer.sortingOrder = 1;

    public void SetToBack() =>
      _renderer.sortingOrder = 0;

    public void Dead()
    {
      _defaultView.SetActive(false);
      _deadView.SetActive(true);
    }
  }
}