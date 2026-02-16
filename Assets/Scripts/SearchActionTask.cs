using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    public class SearchActionTask : ActionTask
    {
        public float randomPositionDistance;
        public float arrivalDistance;

        private NavMeshAgent navmeshAgent;
        private Vector3 destination;

        protected override string OnInit()
        {
            navmeshAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

        protected override void OnExecute()
        {
            Vector3 randomPosition = randomPositionDistance * Random.insideUnitSphere + agent.transform.position;
            NavMeshHit navMeshHit = new NavMeshHit();
            //Choose a random destination
            if (!NavMesh.SamplePosition(randomPosition, out navMeshHit, randomPositionDistance * 2, NavMesh.AllAreas))
            {
                Debug.Log("Could not generate a path.");

                EndAction(false);
            }
            else
            {
                //Set the path
                destination = navMeshHit.position;

                navmeshAgent.SetDestination(destination);
            }

        }

        protected override void OnUpdate()
        {
            float distanceToTarget = Vector3.Distance(destination, agent.transform.position);
            if (navmeshAgent.pathStatus == NavMeshPathStatus.PathComplete &&
                 distanceToTarget < arrivalDistance)
            {
                EndAction(true);
            }
        }
    }
}