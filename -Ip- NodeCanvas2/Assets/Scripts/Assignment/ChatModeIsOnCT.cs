using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ChatModeIsOnCT : ConditionTask {

		public bool chatModeOn; // This bool will be changed by ChatModeAT in the player's blackboard

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			chatModeOn = false;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            return chatModeOn == true;
        }
	}
}