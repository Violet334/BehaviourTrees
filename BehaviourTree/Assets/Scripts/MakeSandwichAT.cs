using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class MakeSandwichAT : ActionTask {
		public TextMeshPro text;
		float timer = 0;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Debug.Log(timer);
			timer += Time.deltaTime;
			if(timer <= 1)
			{
                text.text = "Sandwich in progress...";
			}
			else
			{
				text.text = "";
			}
			if (timer >= 2)
			{
				timer = 0;
			}
            
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			text.text = "";
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}