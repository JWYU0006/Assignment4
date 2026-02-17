using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;

namespace NodeCanvas.Tasks.Actions
{
    public class AssignActionIndex : ActionTask
    {
        public BBParameter<float> satietyBBP;
        public BBParameter<float> thirstyBBP;
        public BBParameter<float> energyBBP;
        public BBParameter<float> cleanlinessBBP;
        public BBParameter<int> actionIndexBBP;

        protected override void OnExecute()
        {

        }

        protected override void OnUpdate()
        {
            if (satietyBBP.value <= 30f)
            {
                agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", 1);
            }
            else if (thirstyBBP.value <= 30f)
            {
                agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", 2);
            }
            else if (energyBBP.value <= 50f)
            {
                agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", 3);
            }
            else if (cleanlinessBBP.value <= 50f)
            {
                agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", 4);
            }
            else
            {
                agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", 0);
            }
        }
    }
}