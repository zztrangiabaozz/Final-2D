using UnityEngine;

public class KickAttack : MonoBehaviour
{
    [SerializeField] public float _lifetime = 0.1f;
    [SerializeField] private Vector3 _kickAmount = Vector3.up;

    // Add a member variable to represent the timer.
    private float _timer;

    // ------------------------------------------------------------------------
    private void OnEnable()
    {
        // Setup timer
        _timer = _lifetime;
        Debug.Log("KICK HITBOX ACTIVATED!");

    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity method that runs every frame...
    // Disable this GameObject when time runs out
    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity collision detection method...
    // Check if the colliding object has a Kickable component-
    //      if so, Kick it!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("KICK HITBOX TOUCHED: " + collision.name);

        Kickable kickable = collision.GetComponent<Kickable>();

        if (kickable == null)
        {
            kickable = collision.GetComponentInParent<Kickable>();
        }

        if (kickable != null)
        {
            Debug.Log("KICKABLE FOUND! APPLYING FORCE!");
            kickable.Kick(_kickAmount);
        }
        else
        {
            Debug.Log("NO KICKABLE COMPONENT FOUND!");
        }
    }
    
}