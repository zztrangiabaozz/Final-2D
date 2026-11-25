using UnityEngine;
using UnityEngine.UI;

public class ChecklistItemUI : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _checkImage;
    [SerializeField] private Sprite _filledCheckSprite;

    public GameObject _requiredItem;

    // ------------------------------------------------------------------------
    public void SetItem (GameObject itemObject)
    {
        // Store the required itemObject in _requiredItem.
        _requiredItem = itemObject;
        SpriteRenderer itemRenderer = itemObject.GetComponent<SpriteRenderer>();
        if (itemRenderer != null)
        {
            _itemImage.sprite = itemRenderer.sprite;
        }
        // Change our item sprite to the itemObject's SpriteRenderer's sprite.
    }

    // ------------------------------------------------------------------------
    public void FoundItem ()
    {
        // Change our checkbox sprite to the filled checkbox version.
        _checkImage.sprite = _filledCheckSprite;
    }

}