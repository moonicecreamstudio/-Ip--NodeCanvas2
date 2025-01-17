using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions
{

    public class KeelyRechargeAT : ActionTask
    {
        public float rechargeRate;
        public float maxChargeValue;
        public float arrivalDistance;
        public Transform target;

        public BBParameter<float> speed;
        public BBParameter<float> energy;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {

        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            float distanceToTarget = Vector3.Distance(target.position, agent.transform.position);
            if (distanceToTarget < arrivalDistance)
            {

                energy.value += rechargeRate * Time.deltaTime;

                if (energy.value > maxChargeValue)
                {
                    EndAction(true);
                }

            }
            else
            {
                Vector3 moveDirection = (target.position - agent.transform.position).normalized;
                agent.transform.position += moveDirection * speed.value * Time.deltaTime;
            }
        }

        //Called when the task is disabled.
        protected override void OnStop()
        {

        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}