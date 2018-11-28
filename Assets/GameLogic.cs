// We use this namespace as it is where our GameLogicBehavior was generated
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine;
using UnityEngine.UI;

// We extend GameLogicBehavior which extends NetworkBehavior which extends MonoBehaviour
public class GameLogic : MonoBehaviour
{
    private void Start()
    {
        // This will be called on every client, so each client will essentially instantiate
        // their own player on the network. We also pass in the position we want them to spawn at
        NetworkManager.Instance.InstantiatePlayer(position: new Vector3(0, 5, 0));
    }
}
