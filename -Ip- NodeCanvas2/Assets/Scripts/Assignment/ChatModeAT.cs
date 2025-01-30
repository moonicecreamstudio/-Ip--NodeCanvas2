using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class ChatModeAT : ActionTask {

		ConditionTask chatModeIsOnAT;
		public Text friendshipPoints;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
            friendshipPoints = GameObject.Find("FP").GetComponent<Text>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            friendshipPoints.text = "1";
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//chatModeIsOnAT.chatModeOn == true; Not sure how to access another Condition Task
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}