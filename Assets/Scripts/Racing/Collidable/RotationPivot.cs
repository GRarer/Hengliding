using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Racing.Collidables {
    public class RotationPivot : MonoBehaviour
    {

        public float rotationSpeed = 10000f;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        
        }
    }

}
