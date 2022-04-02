using UnityEngine;

namespace Assets.Background
{
    public class CircleScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider coll) {
            Debug.Log(coll);
        }
    }
}
