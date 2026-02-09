using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class AssignActionIndex : ActionTask
    {
        protected override void OnExecute()
        {
            int index = 1;
            agent.GetComponent<Blackboard>().SetVariableValue("actionIndex", index);
            EndAction(true);
        }
    }
}