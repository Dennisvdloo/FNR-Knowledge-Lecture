// We use this namespace as it is where our BallBehavior was generated
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

// We extend BallBehavior which extends NetworkBehavior which extends MonoBehaviour
public class GameBall : GameBallBehavior
{
    private Rigidbody rigidbodyRef;
    private GameLogic gameLogic;

    private void Awake()
    {
        rigidbodyRef = GetComponent<Rigidbody>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    // Default Unity update method
    private void Update()
    {
        // Check to see if we are the owner of this ball
        if (!networkObject.IsOwner)
        {
            // If we are not the owner then we set the position to the
            // position that is syndicated across the network for this ball
            transform.position = networkObject.position;
            return;
        }

        // When our position changes the networkObject.position will detect the
        // change based on this assignment automatically, this data will then be
        // syndicated across the network on the next update pass for this networkObject
        networkObject.position = transform.position;
    }
}