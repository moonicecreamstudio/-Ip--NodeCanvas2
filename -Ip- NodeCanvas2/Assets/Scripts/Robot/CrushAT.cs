using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CrushAT : ActionTask {
		public Compactor compactor;
		public float crushDuration;
        public float energyUseRate;

        private float timeCompacting = 0f;
		private Blackboard agentBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            //Get acces to the blackboard
            agentBlackboard = agent.GetComponent<Blackboard>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timeCompacting = 0f;
			compactor.Crush();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timeCompacting += Time.deltaTime;

			//Change the value of the energy

			// Get the value of the energy
			float currentEnergy = agentBlackboard.GetVariableValue<float>("energy");

			//Subtract the use rate
			currentEnergy -= energyUseRate * Time.deltaTime;

			//Set the value of the energy
			agentBlackboard.SetVariableValue("energy", currentEnergy);

			if(timeCompacting > crushDuration)
			{
				EndAction(true); //Can still run the bottom one because it's not a return
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            compactor.Stop();
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}