
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    float smoothSpeed => Configs.FollowCamera.speed;

    private void LateUpdate()
    {
        transform.position = Player.position + offset;
    }
}
