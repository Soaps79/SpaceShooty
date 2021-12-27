using QGame;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScreenWrap : QScript
    {
        void OnBecameInvisible()
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x * -1, transform.position.y * -1, transform.position.z), transform.rotation);
        }
    }
}