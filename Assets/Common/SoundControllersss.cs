using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MugitoDokumugi.Common
{
    public class SoundController : MonoBehaviour
    {
        //singleton
        private static SoundController instance;
        private SoundController()
        {
            Debug.Log("instance ");
        }
        public static SoundController Instance
        {
            get
            {
                if (instance == null) instance = new SoundController();
                return instance;
            }
        }
        //init
        private const int SE_CHANNEL = 4; // SE同時にならせる数
        public enum Type
        {
            Bgm,
            Se
        }
        private static GameObject soundobject = null;
        private static AudioSource bgmsource = null;
        private static AudioSource sedefaultsource = null;
        private static AudioSource[] searraysource = null;
        private static Dictionary<string, Data> bgmlist = new Dictionary<string, Data>();   // BGMリスト
        private static Dictionary<string, Data> selist = new Dictionary<string, Data>();    // SEリスト
        //sound database
        private class Data
        {
            public string key;
            public string name;
            public AudioClip clip;
            public Data(string key, string name)
            {
                this.key = key;
                this.name = "Common/Sound/" + name;
                clip = Resources.Load(this.name) as AudioClip;
            }
        }
        private static AudioSource GetAudioSource(Type type, int channel = 1)
        {
            if(soundobject == null)
            {
                soundobject = new GameObject("Sound");
                DontDestroyOnLoad(soundobject);
                bgmsource = soundobject.AddComponent<AudioSource>();
                sedefaultsource = soundobject.AddComponent<AudioSource>();
                for(int i = 0; i < SE_CHANNEL; i++)
                {
                    searraysource[i] = soundobject.AddComponent<AudioSource>();
                }
            }
            if(type == Type.Bgm)
            {
                return bgmsource;
            }
            else
            {
                if (0 <= channel && channel < SE_CHANNEL)
                {
                    return searraysource[channel];
                }
                else
                {
                    return sedefaultsource;
                }
            }
        }
        public static void LoadBgm(string key, string name)
        {
            if (bgmlist.ContainsKey(key))
            {
                bgmlist.Remove(key);
            }
            bgmlist.Add(key, new Data(key, name));
        }
        public static void LoadSe(string key, string name)
        {
            if (selist.ContainsKey(key))
            {
                selist.Remove(key);
            }
            selist.Add(key, new Data(key, name));
        }
        //play & stop
        public static bool PlayBgm(string key)
        {
            if (bgmlist.ContainsKey(key) == false)
            {
                return false;
            }
            StopBgm();
            var data = bgmlist[key];
            var source = GetAudioSource(Type.Bgm);
            source.loop = true;
            source.clip = data.clip;
            source.Play();
            return true;
        }
        public static bool StopBgm()
        {
            GetAudioSource(Type.Bgm).Stop();
            return true;
        }
        public static bool PlaySe(string key, int channel = -1)
        {
            if (selist.ContainsKey(key) == false)
            {
                return false;
            }
            var data = selist[key];
            if (0 <= channel && channel < SE_CHANNEL)
            {
                var source = GetAudioSource(Type.Se, channel);
                source.clip = data.clip;
                source.Play();
            }
            else
            {
                var source = GetAudioSource(Type.Se);
                source.PlayOneShot(data.clip);
            }
            return true;
        }
    }
}