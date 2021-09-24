using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // LateUpdate is called once per frame after all of the update methods.
    void LateUpdate()
    {
        transform.position = player.transform.position - offset;
    }
}
