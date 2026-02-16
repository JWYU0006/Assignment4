using System.Collections;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public void PlaySoundEffect(AudioClip clip, AudioSource source = null)
    {
        if (source != null)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            source = gameObject.AddComponent<AudioSource>();
            source.PlayOneShot(clip);

            StartCoroutine(RemoveAudioSourceAfterPlayback(source, clip.length));
        }
    }

    private IEnumerator RemoveAudioSourceAfterPlayback(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(source);
    }
}
