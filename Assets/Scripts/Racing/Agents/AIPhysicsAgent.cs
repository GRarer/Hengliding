using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents{
    public class AIPhysicsAgent : PhysicsAgent
    {
        private Vector3 goal;
        private float Kp = .5f;
        private float Ky = .5f;
        public AIPhysicsAgent(float dMda, float dNde, float dLdr, Glider glider, Vector3 goal) : base(dMda, dNde, dLdr, glider) {
            this.goal = goal;
        }
        public override Vector3 getInput() {
            Vector3 r = goal - glider.transform.position;
            float rho = Mathf.Sqrt(Mathf.Pow(r.x,2) + Mathf.Pow(r.z,2));
            float theta = glider.transform.eulerAngles.x;
            float theta_d = Mathf.Rad2Deg*Mathf.Atan2(-r.y, rho);
            float theta_e = theta_d - theta; // This should probably be wrapped in the future

            float psi = glider.transform.eulerAngles.y;
            float psi_d = Mathf.Rad2Deg*Mathf.Atan2(r.x,r.z);
            float psi_e = psi_d - psi;

            float axisH = Ky * psi_e;
            float axisV = Kp * theta_e;
            axisH = Mathf.Min(Mathf.Abs(axisH), 1) * Mathf.Sign(axisH);
            axisV = Mathf.Min(Mathf.Abs(axisV), 1) * Mathf.Sign(axisV);
            Debug.Log(psi_d);
            return new Vector3(axisV * dNde, axisH * dLdr, 0*axisH * dMda);
        }
    }
}
