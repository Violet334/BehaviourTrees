using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class GroundChild : ActionTask {
		public BBParameter<Transform> childPos;
		public Transform groundedPos;

		//create a delay timer
		public float timer = 2;

		public Renderer rend;
		public Material defaultMaterial;
		public Material material;

		public TextMeshPro yelling;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			rend.material = material;
			yelling.text = "YOU ARE GROUNDED!!";
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer -= Time.deltaTime;
            if (timer <= 0)
            {
				childPos.value.position = groundedPos.position;
				yelling.text = "";
				rend.material = defaultMaterial;
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