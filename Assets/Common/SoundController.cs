using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MugitoDokumugi.Common
{
    [System.Serializable]
    public class SoundVolume
    {
        public float bgm = 1.0f;
        public float se = 1.0f;
        public bool mute = false;
        public void Reset()
        {
            bgm = 1.0f;
            se = 1.0f;
            mute = false;
        }
    }
    public class SoundController : SingletonMonoBehaviour<SoundController>
    {
        public SoundVolume volume = new SoundVolume();
        [SerializeField] private AudioClip[] seclips;
        [SerializeField] private AudioClip[] bgmclips;
        private Dictionary<string, int> seindexes = new Dictionary<string, int>();
        private Dictionary<string, int> bgmindexes = new Dictionary<string, int>();
        const int channelnum = 16;
        private AudioSource bgmsource;
        private AudioSource[] sesources = new AudioSource[channelnum];
        Queue<int> serequestqueue = new Queue<int>();
        void Awake()
        {
            DontDestroyOnLoad(this);
            if (this != Instance)
            {
                Destroy(this);
                return;
            }
            
            bgmsource = gameObject.AddComponent<AudioSource>();
            bgmsource.loop = true;
            for (int i = 0; i < sesources.Length; i++)
            {
                sesources[i] = gameObject.AddComponent<AudioSource>();
            }
            seclips = Resources.LoadAll<AudioClip>("Common/Sound/Se");
            bgmclips = Resources.LoadAll<AudioClip>("Common/Sound/Bgm");
            for (int i = 0; i < seclips.Length; ++i)
            {
                seindexes[seclips[i].name] = i;
            }
            for (int i = 0; i < bgmclips.Length; ++i)
            {
                bgmindexes[bgmclips[i].name] = i;
            }
        }
        void Update()
        {
            //set mute
            bgmsource.mute = volume.mute;
            foreach(var source in sesources)
            {
                source.mute = volume.mute;
            }
            //set volume
            bgmsource.volume = volume.bgm;
            foreach(var source in sesources)
            {
                source.volume = volume.se;
            }
            //channel
            int count = serequestqueue.Count;
            if (count != 0)
            {
                int se_index = serequestqueue.Dequeue();
                PlaySeImpl(se_index);
            }
        }
        private void PlaySeImpl(int index)
        {
            if (0 > index || seclips.Length <= index)
            {
                return;
            }
            foreach (AudioSource source in sesources)
            {
                if (source.isPlaying == false)
                {
                    source.clip = seclips[index];
                    source.Play();
                    return;
                }
            }
        }
        public int GetSeIndex(string name)
        {
            return seindexes[name];
        }
        public int GetBgmIndex(string name)
        {
            return bgmindexes[name];
        }
        public void PlayBgm(string name)
        {
            int index = bgmindexes[name];
            PlayBgm(index);
        }
        public void PlayBgm(int index)
        {
            if (0 > index || bgmclips.Length <= index)
            {
                return;
            }
            if (bgmsource.clip == bgmclips[index])
            {
                return;
            }
            bgmsource.Stop();
            bgmsource.clip = bgmclips[index];
            bgmsource.Play();
        }
        public void StopBgm()
        {
            bgmsource.Stop();
            bgmsource.clip = null;
        }
        public void PlaySe(string name)
        {
            PlaySe(GetSeIndex(name));
        }
        public void PlaySe(int index)
        {
            if (!serequestqueue.Contains(index))
            {
                serequestqueue.Enqueue(index);
            }
        }
        public void StopSe()
        {
            ClearAllSeRequest();
            foreach (AudioSource source in sesources)
            {
                source.Stop();
                source.clip = null;
            }
        }
        public void ClearAllSeRequest()
        {
            serequestqueue.Clear();
        }
    }
}