using JetBrains.Annotations;
using UnityEngine;

public class SimpleBrujula : MonoBehaviour
{
    public Transform player;

    private void OnDrawGizmos()
    {
        Vector3 direction = Vector3.Normalize(player.transform.position - transform.position);

        /*We take the direction of the forward axis of the player to check if its looking
         * in the right direction of the target.
        */
        float dotProduct = Vector3.Dot(direction, Vector3.Normalize(player.transform.forward));

        if(dotProduct < -0.5f )
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color= Color.red;
        }

        Gizmos.DrawRay(transform.position, direction * 5);
        Gizmos.DrawRay(player.position, player.transform.forward * 5);
    }
}
