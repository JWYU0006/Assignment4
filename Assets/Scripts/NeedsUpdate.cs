using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    public class NeedsUpdate : ActionTask
    {
        public BBParameter<float> satietyBBP = 100f;
        public BBParameter<float> thirstyBBP = 100f;
        public BBParameter<float> energyBBP = 100f;
        public BBParameter<float> cleanlinessBBP = 100f;
        public BBParameter<float> satietySpeedBBP = 4f;
        public BBParameter<float> thirstySpeedBBP = 2f;
        public BBParameter<float> energySpeedBBP = 1f;
        public BBParameter<float> cleanlinessSpeedBBP = 4f;

        protected override void OnUpdate()
        {
            NeedsUpdateFunction();
            Wander();
            if (navMeshAgent == null) Debug.Log($"{agent.name} - NavigationTask: Unable to get NavMesh Agent Reference!");
        }

        public void NeedsUpdateFunction()
        {
            float satiety = satietyBBP.value;
            float thirsty = thirstyBBP.value;
            float energy = energyBBP.value;
            float cleanliness = cleanlinessBBP.value;

            satiety = UpdateAndConstrain(satiety, "satiety");
            satietyBBP.value = satiety;
            thirsty = UpdateAndConstrain(thirsty, "thirsty");
            thirstyBBP.value = thirsty;
            energy = UpdateAndConstrain(energy, "energy");
            energyBBP.value = energy;
            cleanliness = UpdateAndConstrain(cleanliness, "cleanliness");
            cleanlinessBBP.value = cleanliness;
        }

        private float UpdateAndConstrain(float need, string needName)
        {
            if (needName == "satiety")
                need -= satietySpeedBBP.value * Time.deltaTime;
            else if (needName == "thirsty")
                need -= thirstySpeedBBP.value * Time.deltaTime;
            else if (needName == "energy")
                need -= energySpeedBBP.value * Time.deltaTime;
            else if (needName == "cleanliness")
                need -= cleanlinessSpeedBBP.value * Time.deltaTime;

            return Mathf.Clamp(need, 0f, 100f);
        }

        private float timeSinceLastSample = 0f;
        private Vector3 lastTargetPosition = Vector3.zero;
        private Vector3 targetPosition = Vector3.zero;
        private bool isMoving = false;

        private float wanderDistance = 4f;
        private float wanderRadius = 3f;

        public BBParameter<NavMeshAgent> navMeshAgent;

        private void Wander()
        {
            timeSinceLastSample += Time.deltaTime;
            if (timeSinceLastSample > 3)
            {
                timeSinceLastSample = 0;

                if (lastTargetPosition != targetPosition)
                {
                    lastTargetPosition = targetPosition;
                    if (NavMesh.SamplePosition(targetPosition, out NavMeshHit hitinfo, 3, NavMesh.AllAreas))
                    {
                        navMeshAgent.value.SetDestination(hitinfo.position);
                    }
                }

                isMoving =
                    navMeshAgent.value.remainingDistance != 0 &&
                    navMeshAgent.value.remainingDistance != Mathf.Infinity ||
                    navMeshAgent.value.pathPending;
            }
            if (timeSinceLastSample == 0 && isMoving == false)
            {
                Vector3 destination = CalculateTargetPosition();
                if (NavMesh.SamplePosition(destination, out NavMeshHit hitInfo, wanderDistance + wanderRadius, NavMesh.AllAreas))
                {
                    targetPosition = hitInfo.position;
                }
            }
        }
        private Vector3 CalculateTargetPosition()
        {
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderDistance;
            Vector3 randomPoint = Random.insideUnitSphere.normalized * wanderRadius;

            Vector3 destination = circleCenter + randomPoint;

            return destination;
        }
    }
}