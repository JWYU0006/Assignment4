using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class EatAction : ActionTask
    {
        public BBParameter<Transform> foodTransform;
        public BBParameter<float> speedBBP;

        protected override void OnUpdate()
        {
            agent.transform.position = Vector3.MoveTowards(agent.transform.position, foodTransform.value.position, Time.deltaTime * speedBBP.value);
            if (Vector3.Distance(agent.transform.position, foodTransform.value.position) < 1f)
            {
                EndAction(true);
            }
        }
    }
}