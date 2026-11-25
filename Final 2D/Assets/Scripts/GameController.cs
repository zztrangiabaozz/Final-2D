using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private HUD _hud;
    [SerializeField] private StartGameUI _startGameUI;
    [SerializeField] private GameOverUI _gameOverUI;
    [SerializeField] private Player _player;
    [SerializeField] private float _maxTimeSeconds;
    // Add a member variable that's a LIST (or ARRAY) of all of the objects
    //      that the player is required to kick.
    // This variable should be editable from the inspector.
    [SerializeField] private List<GameObject> _requiredItems;

    private int _commonPoints;
    private int _uncommonPoints;
    private int _rarePoints;
    private float _timeRemaining;
    private bool _runGame;

    // ------------------------------------------------------------------------
    private void Start()
    {
        SetGameEnabled(false);

        // Tell the HUD what the required items are.
        _hud.SetRequiredItems(_requiredItems);
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    private void Update()
    {
        if (_runGame)
        {
            _timeRemaining -= Time.deltaTime;
            _hud.UpdateTimerText(_timeRemaining);

            if (_timeRemaining <= 0)
            {
                EndGame();
            }
        }
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    public void StartGame()
    {
        _startGameUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(false);

        SetGameEnabled(true);

        _commonPoints = 0;
        _uncommonPoints = 0;
        _rarePoints = 0;
        _hud.UpdatePointsText(_commonPoints, _uncommonPoints, _rarePoints);

        _timeRemaining = _maxTimeSeconds;
        _hud.UpdateTimerText(_timeRemaining);
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // ------------------------------------------------------------------------
    private void EndGame()
    {
        SetGameEnabled(false);

    // Calculate the player's total points.
        int totalPoints = _commonPoints + _uncommonPoints + _rarePoints;

    // Tell the GameOverUI.
        _gameOverUI.Activate(_commonPoints, _uncommonPoints, _rarePoints, totalPoints);
    }

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    private void SetGameEnabled(bool enabled)
    {
        _player.enabled = enabled;
        _runGame = enabled;
    }

    // ------------------------------------------------------------------------
    // You will need to ADD PARAMETERS to this method to represent the GameObject
    //  kicked and the rarity of that object.
    public void Kicked(GameObject item, ItemRarity rarity)
    {
        // Use a switch statement.
        // Based on the rarity of the object kicked, change the number of points
        //      for that rarity category.
        

        // Tell the HUD what item was kicked, and how many points we now have.
        switch (rarity)
        {
            case ItemRarity.Common:
                _commonPoints += 1;
                break;
            case ItemRarity.Uncommon:
                _uncommonPoints += 2;
                break;
            case ItemRarity.Rare:
                _rarePoints += 3;
                break;
        }

    // Tell the HUD what item was kicked, and how many points we now have.
        _hud.KickedItem(item);                          // CHECK name
        _hud.UpdatePointsText(_commonPoints, _uncommonPoints, _rarePoints);
    }
}