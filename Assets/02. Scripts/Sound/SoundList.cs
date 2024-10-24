﻿using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    [CreateAssetMenu(fileName = "SoundList", menuName = "ScriptableObject/SoundList", order = int.MaxValue)]
    public class SoundList : ScriptableObject
    {
        public List<AudioClip> m_AudioClipList;

        private Dictionary<string, AudioClip> m_AudioClipDictionary;

        public Dictionary<string, AudioClip> AudioClips
        {
            get
            {
                if (m_AudioClipDictionary == null || m_AudioClipList.Count != m_AudioClipDictionary.Count)
                    m_AudioClipDictionary = GetSoundList();

                return m_AudioClipDictionary;
            }
        }

        private Dictionary<string, AudioClip> GetSoundList()
        {
            var audioDictionary = new Dictionary<string, AudioClip>();

            foreach (var item in m_AudioClipList)
            {
                if (!audioDictionary.TryAdd(item.name, item))
                    continue;
            }

            return audioDictionary;
        }
    }
}