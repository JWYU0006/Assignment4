using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{

    public class NavigationTask : ActionTask
    {
        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<bool> isMovingBBP;

        public float samplingRateInSeconds;
        public float sampleRadiusInUnits;

        private Vector3 lastTargetPosition;
        private NavMeshAgent navMeshAgent;

        protected override string OnInit()
        {
            navMeshAgent = agent.GetComponent<NavMeshAgent>();

            if (navMeshAgent == null) return $"{agent.name} - NavigationTask: Unable to get NavMesh Agent Reference!";
            else return null;
        }

        protected override void OnUpdate()
        {
            timeSinceLastSampleBBP.value += Time.deltaTime;
            if (timeSinceLastSampleBBP.value > samplingRateInSeconds)
            {
                timeSinceLastSampleBBP.value = 0;

                if (lastTargetPosition != targetPositionBBP.value)
                {
                    lastTargetPosition = targetPositionBBP.value;
                    if (NavMesh.SamplePosition(targetPositionBBP.value, out NavMeshHit hitinfo, sampleRadiusInUnits, NavMesh.AllAreas))
                    {
                        navMeshAgent.SetDestination(hitinfo.position);
                    }
                }

                isMovingBBP.value =
                    navMeshAgent.remainingDistance != 0 &&
                    navMeshAgent.remainingDistance != Mathf.Infinity ||
                    navMeshAgent.pathPending;
            }
        }
    }
}