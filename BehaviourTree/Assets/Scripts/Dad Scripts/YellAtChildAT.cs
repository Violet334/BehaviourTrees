using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class YellAtChildAT : ActionTask {
		public BBParameter<bool> callMom;
		public TextMeshPro text;

		public Renderer rend;
		public Material defaultMat;
		public Material angry;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            //turn red
            rend.material = angry;
            //yell for mom
            text.text = "GERTRUDE! GET THE BRAT!!";
			callMom.value = true;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			rend.material = defaultMat;
			text.text = "";
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}