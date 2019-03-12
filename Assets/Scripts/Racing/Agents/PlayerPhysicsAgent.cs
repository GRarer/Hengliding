using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents{
    public class PlayerPhysicsAgent : PhysicsAgent
    {
        public PlayerPhysicsAgent(float dMda, float dNde, float dLdr, Glider glider) : base(dMda, dNde, dLdr, glider) {}
        public override Vector3 getInput() {
            float axisH = 2*(Input.mousePosition.x - Screen.width/2)/Screen.width;
            float axisV = 2*(Input.mousePosition.y - Screen.height/2)/Screen.height;
            axisH = Mathf.Min(Mathf.Abs(axisH), 1) * Mathf.Sign(axisH);
            axisV = Mathf.Min(Mathf.Abs(axisV), 1) * Mathf.Sign(axisV);
            // Debug.Log(axisV * dNde);
            return new Vector3(axisV * dNde, axisH * dLdr, axisH * dMda);
        }
    }
}
