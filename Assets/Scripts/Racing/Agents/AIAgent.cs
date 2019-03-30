using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents{
    public class AIAgent : Agent
    {
        private Vector3 goal;
        private float Kp = .5f;
        private float Ky = .5f;
        private int layerMask = 1 << 10;
        private List<Transform> obstacles = new List<Transform>();

        private RaycastHit hit;
        public AIAgent(Glider glider, Vector3 goal) : base(glider) {
            this.goal = goal;
        }
        public override Vector3 getInput() {
            // Detect Obstacles
            if (Physics.Raycast(glider.transform.position, glider.transform.forward, out hit, 50, layerMask)) {
                if (!obstacles.Contains(hit.transform)) {
                    obstacles.Add(hit.transform);
                }
            }

            Vector3 r = goal - glider.transform.position;
            float rho = Mathf.Sqrt(Mathf.Pow(r.x,2) + Mathf.Pow(r.z,2));
            float theta = glider.transform.eulerAngles.x;
            float theta_d = Mathf.Rad2Deg*Mathf.Atan2(-r.y, rho);
            

            float psi = glider.transform.eulerAngles.y;
            float psi_d = Mathf.Rad2Deg*Mathf.Atan2(r.x,r.z);

            float psiObs = 0;
            float rhoSum = 0;
            float thetaObs = 0;
            foreach (Transform obs in obstacles) {
                Vector3 rObs = obs.position - glider.transform.position;
                if (Vector3.Dot(rObs.normalized, r.normalized) > 0.85) {
                    psiObs += Mathf.Rad2Deg*Mathf.Atan2(-rObs.x, -rObs.z) / rObs.sqrMagnitude / 100;
                    thetaObs += Mathf.Max(Mathf.Rad2Deg*Mathf.Atan2(rObs.y, Mathf.Sqrt(Mathf.Pow(rObs.x,2) + Mathf.Pow(rObs.z,2))),-30) / rObs.sqrMagnitude / 100;
                    rhoSum += rObs.sqrMagnitude * 100;
                }
            }
            if (rhoSum > 0) {
                psiObs *= rhoSum;
                psi_d = (psi_d + psiObs)/2;
                thetaObs *= rhoSum;
                theta_d = (theta_d + thetaObs)/2;
            }
            float psi_e = psi_d - psi;
            float theta_e = theta_d - theta; // This should probably be wrapped in the future

            float axisH = Ky * psi_e;
            float axisV = Kp * theta_e;
            axisH = Mathf.Min(Mathf.Abs(axisH), 1) * Mathf.Sign(axisH);
            axisV = Mathf.Min(Mathf.Abs(axisV), 1) * Mathf.Sign(axisV);

            
            //Debug.Log(psi_d);
            return new Vector3(axisV * Mde, axisH * Ndr, 0*axisH * Lda);
        }
    }
}
