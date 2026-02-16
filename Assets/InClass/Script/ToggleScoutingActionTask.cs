using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class ToggleScoutingActionTask : ActionTask
    {
        public BBParameter<bool> scoutingBBP;
        public AudioSource source;
        public AudioClip clip;

        protected override void OnExecute()
        {
            scoutingBBP.value = !scoutingBBP.value;
            AudioManager.Instance.PlaySoundEffect(clip, source);
            EndAction(true);
        }
    }
}