using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions
{

    public class MoveToDestination : ActionTask
    {
        public BBParameter<int> actionIndexBBP;
        private Transform destination;
        public BBParameter<float> speedBBP;
        public BBParameter<NavMeshAgent> navMeshAgentBBP;

        protected override void OnExecute()
        {
            if (actionIndexBBP.value == 1)
            {
                destination = agent.GetComponent<Blackboard>().GetVariableValue<Transform>("foodTransform");
            }
            else if (actionIndexBBP.value == 2)
            {
                destination = agent.GetComponent<Blackboard>().GetVariableValue<Transform>("waterTransform");
            }
            else if (actionIndexBBP.value == 3)
            {
                destination = agent.GetComponent<Blackboard>().GetVariableValue<Transform>("bedTransform");
            }
            else if (actionIndexBBP.value == 4)
            {
                destination = agent.transform;
            }
        }

        protected override void OnUpdate()
        {
            navMeshAgentBBP.value.SetDestination(destination.position);
            if (Vector3.Distance(agent.transform.position, destination.position) <= 1.5f)
            {
                EndAction(true);
            }
        }
    }
}