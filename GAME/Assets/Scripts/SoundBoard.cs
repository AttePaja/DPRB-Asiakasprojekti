using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SoundBoard : MonoBehaviour
    {

        public List<AudioClip> audioClips;
        public AudioSource audioSource;

        public void PlayAudioClip(int i)
        {
            AudioClip _clip = audioClips[i];
            audioSource.clip = _clip;
            audioSource.Play();
        }
    }
}