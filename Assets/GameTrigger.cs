using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    private void Update()
    {
        // If the game started we will remove this trigger from the scene
        if (FindObjectOfType<GameBall>() != null)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider c)
    {
        // Only allow the server player to start the game so that the
        // server is the owner of the ball, otherwise if a client is the
        // owner of the ball, if they disconnect, the ball will be destroyed
        if (!NetworkManager.Instance.IsServer)
            return;

        Player player = c.GetComponent<Player>();

        if (player == null)
            return;

        // We need to create the ball on the network
        GameBall ball = NetworkManager.Instance.InstantiateGameBall() as GameBall;

        // We no longer need this trigger, the game has started
        Destroy(gameObject);
    }
}