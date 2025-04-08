using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class GroundChild : ActionTask {
		public BBParameter<Transform> childPos;
		public Transform groundedPos;
		public Transform childGrounded;
		public Transform carryPos;

		//create a delay timer
		public float timer = 2;

		public Renderer rend;
		public Material defaultMaterial;
		public Material material;

		public TextMeshPro yelling;

        public BBParameter<Transform> target;
		public BBParameter<float> speed;
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
			rend.material = material;
			//yell at child
			yelling.text = "YOU ARE GROUNDED!!";
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer -= Time.deltaTime;
            if (timer <= 0)
            {
				//childPos.value.position = groundedPos.position;
				yelling.text = "";

				//lift child up and take them to their room
				childPos.value.position = carryPos.position;
				target.value = groundedPos;
				speed.value = 2;

				//move to kid's room
				Vector3 moveDir = target.value.position - agent.transform.position;
				agent.transform.position += moveDir.normalized * speed.value * Time.deltaTime;

				float targetDist = Vector3.Distance(agent.transform.position, target.value.position);
                if (targetDist < 0.1)
                {
					//carry child to their room and move on
					rend.material = defaultMaterial;
					childPos.value.position = childGrounded.position;
					EndAction(true);
                }
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