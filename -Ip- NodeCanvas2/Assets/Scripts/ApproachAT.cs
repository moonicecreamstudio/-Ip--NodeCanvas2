using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public Transform target;
		private float speed; // can be private now after using blackboard
		public float arrivalDistance;
		public float energyUseRate;

        private Blackboard agentBlackboard;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			agentBlackboard = agent.GetComponent<Blackboard>();
			speed = agentBlackboard.GetVariableValue<float>("speed");

			// agaentBlackboard.SetVariableValue("speed", 1.0f);
			// blackboard.GetVariableValue<>(); lowercase would be the private version? 
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Vector3 moveDirection = (target.position - agent.transform.position).normalized;
			agent.transform.position += moveDirection * speed * Time.deltaTime;

            // Get the value of the energy
            float currentEnergy = agentBlackboard.GetVariableValue<float>("energy");

            //Subtract the use rate
            currentEnergy -= energyUseRate * Time.deltaTime;

            //Set the value of the energy
            agentBlackboard.SetVariableValue("energy", currentEnergy);

            float distanceToTarget = Vector3.Distance(target.position, agent.transform.position);
			if(distanceToTarget < arrivalDistance)
			{
				EndAction(true);
			}

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}