using UnityEngine;

namespace Raising.Interaction
{

    public class Treadmill : MonoBehaviour
    {
        public bool active = false;
        void OnMouseDown()
        {
            active = true;
            Debug.Log("clicked");
        }

        public void setInactive()
        {
            active = false;
        }

    }
}