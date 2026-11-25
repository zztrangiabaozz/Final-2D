using UnityEngine;

// Add an enum to represent an item's rarity.
public enum ItemRarity
{
    Common,
    Uncommon,
    Rare
}

public class Kickable : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _explosionVfxPrefab;
    // Add a member variable to represent this item's rarity.
    [SerializeField] private ItemRarity _rarity;

    private bool _wasKicked;
    private GameController _gameController;

    // ------------------------------------------------------------------------
    // You don't need to code in this method :)
    private void Start ()
    {
        _gameController = GameObject.FindFirstObjectByType<GameController>();
    }

    // ------------------------------------------------------------------------
    public void Kick(Vector3 force)
    {
        // Ignore repeat kicks so an item can't be checked off twice.
        if (_wasKicked) return;

        _wasKicked = true;

        _rigidbody.AddForce(new Vector2(force.x, force.y), ForceMode2D.Impulse);
    }

    // ------------------------------------------------------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If this object was kicked, explode.
        if (_wasKicked)
        {
            Explode();
        }
    }

    // ------------------------------------------------------------------------
    private void Explode()
    {
        // Create the explosion VFX.

        // Destroy this item.
        if (_explosionVfxPrefab != null)
        {
            Instantiate(_explosionVfxPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
