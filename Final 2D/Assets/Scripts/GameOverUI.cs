using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private TMP_Text _commonText;
    [SerializeField] private TMP_Text _uncommonText;
    [SerializeField] private TMP_Text _rareText;
    [SerializeField] private TMP_Text _finalText;
    // Add member variables to store references to the Text Components for the
    //      various points texts.

    private string _itemString = "Final score: ";

    // ------------------------------------------------------------------------
    public void Activate(int commonPoints, int uncommonPoints, int rarePoints, int finalPoints)
    {
        gameObject.SetActive(true);
        _commonText.text = "Common: " + commonPoints;
        _uncommonText.text = "Uncommon: " + uncommonPoints;
        _rareText.text = "Rare: " + rarePoints;
        _finalText.text = _itemString + finalPoints;

        // Update the points text with the final scores.
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    public void RestartButton()
    {
        _gameController.RestartGame();
    }
}   
