using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform _checklistParent;
    [SerializeField] private ChecklistItemUI _checklistItemPrefab;
    // Add member variables for all of the Text you'll need to update.
    [SerializeField] private TMP_Text _commonText;
    [SerializeField] private TMP_Text _uncommonText;
    [SerializeField] private TMP_Text _rareText;
    [SerializeField] private TMP_Text _timerText;

    private List<ChecklistItemUI> _checklistItems;

    // ------------------------------------------------------------------------
    public void SetRequiredItems (List<GameObject> items)
    {
        // For every entry in 'items',
        //      create a new ChecklistItemUI GameObject.
        // Set its parent to _checklistParent.
        // Use the correct method in ChecklistItemUI to setup its required item.
        foreach (GameObject item in items)
        {
            ChecklistItemUI row = Instantiate(_checklistItemPrefab, _checklistParent);
            row.SetItem(item);
            _checklistItems.Add(row);
        }
    }

    // ------------------------------------------------------------------------
    public void KickedItem(GameObject item)
    {
        // Find the ChecklistItem in _checklistItems whose required item is the
        //      'item' input for this method.
        // Tell that item we found it!
        foreach (ChecklistItemUI row in _checklistItems)
        {
            if (row._requiredItem == item)
            {
                row.FoundItem();
            }
        }
    }

    // ------------------------------------------------------------------------
    public void UpdatePointsText (int commonPoints, int uncommonPoints, int rarePoints)
    {
        // Update all of the text.
        _commonText.text = "Common: " + commonPoints;
        _uncommonText.text = "Uncommon: " + uncommonPoints;
        _rareText.text = "Rare: " + rarePoints;
    }

    // ------------------------------------------------------------------------
    public void UpdateTimerText (float timeLeft)
    {
        // Update the timer text.
        _timerText.text = "Time: " + Mathf.CeilToInt(Mathf.Max(timeLeft, 0f));

    }
}