// We use this namespace as it is where our PlayerBehavior was generated using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

// We extend PlayerBehavior which extends NetworkBehavior which extends MonoBehaviour
public class Player : PlayerBehavior
{
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsOwner)
        {
            // Don't render through a camera that is not ours
            // Don't listen to audio through a listener that is not ours
            transform.GetChild(0).gameObject.SetActive(false);

            // Don't accept inputs from objects that are not ours
            GetComponent<FirstPersonController>().enabled = false;

            // There is no reason to try and simulate physics since the position is
            // being sent across the network anyway
            Destroy(GetComponent<Rigidbody>());
        }
    }
    // Default Unity update method
    private void Update()
    {
        // Check to see if we are the owner of this player
        if (!networkObject.IsOwner)
        {
            // If we are not the owner then we set the position to the
            // position that is syndicated across the network for this player
            transform.position = networkObject.position;
            return;
        }

        // When our position changes the networkObject.position will detect the
        // change based on this assignment automatically, this data will then be
        // syndicated across the network on the next update pass for this networkObject
        networkObject.position = transform.position;
    }
}