using UnityEngine;

namespace Raising.Interaction
{

    public class Treadmill : MonoBehaviour
    {
        public bool active = false;
        public bool occupied = false;
        void OnMouseDown()
        {
            active = true;
            Debug.Log("clicked");
        }

        public void setOccupied()
        {
            occupied = true;
        }

        public void setInactive()
        {
            active = false;
            occupied = false;
        }

    }
}