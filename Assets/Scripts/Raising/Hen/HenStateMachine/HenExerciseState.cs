using Raising.Interaction;
using UnityEngine;

namespace Raising
{

    public class HenExerciseState : HenState
    {

        Vector3 beforeExercisingPos;
        Treadmill treadmill;

        public HenExerciseState(HenStateInput input) : base(input) { }

        override public void runOnce()
        {
            treadmill = input.hen.findNearbyItem<Treadmill>();
            // if (target != null) {
            // 	//this scripted movmement can hopefully be replaced by real animations later
            // 	float bathSeekAcceleration = 0.02f; //TODO make this change depending on speed stat?

            // 	input.hen.transform.LookAt(target.transform);
            // 	//TODO keep rotation parallel to ground
            // 	float yRot = input.hen.transform.rotation.eulerAngles.y;
            // 	input.hen.transform.rotation = Quaternion.Euler(0, yRot, 0);

            // 	input.hen.GetComponent<Rigidbody>().velocity += input.hen.transform.forward * bathSeekAcceleration;
            // }

            beforeExercisingPos = input.hen.transform.position;
            input.hen.transform.position = treadmill.gameObject.transform.position + new Vector3(0, 0.5f, 0);
            input.hen.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            input.hen.GetComponent<Animator>().SetTrigger("inWater");
            Object.Instantiate(input.hen.bathingParticles, input.hen.transform.position, input.hen.bathingParticles.transform.rotation, treadmill.gameObject.transform);
            treadmill.setOccupied();
			SoundManager.Instance().PlayAnySFX(SoundManager.SFXv2.Treadmill);
        }

        override public void run()
        {
            if (timeSinceStart() > 3)
            {
                treadmill.setInactive();
                input.hen.finishExercise(treadmill);
                input.hen.transform.position = beforeExercisingPos;
            }
        }


        override public void updateState()
        {
            if (timeSinceStart() > 3)
            {
                input.hen.state = new HenIdleState(input);
            }
        }

    }
}