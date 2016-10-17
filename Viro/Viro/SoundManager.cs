using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace Viro
{
    class SoundManager
    {
        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        AudioCategory soundCatMusic;
        AudioCategory soundCatFx;

        static SoundManager sound = null;

        public SoundManager(){}
        public string LastCue;

        public void Initialize()
        {
            try
            {
                audioEngine = new AudioEngine("Content\\Sounds\\ViroXact.xgs");
                waveBank = new WaveBank(audioEngine, "Content\\Sounds\\Wave Bank.xwb");
                soundBank = new SoundBank(audioEngine, "Content\\Sounds\\Sound Bank.xsb");
                soundCatMusic = audioEngine.GetCategory("Music");
                soundCatFx = audioEngine.GetCategory("Sounds");
                soundCatMusic.SetVolume(0.5f);
                soundCatFx.SetVolume(0.5f);
            }
            catch
            {
            }
        }

        public void PlaySound(string s)
        {
            try
            {
                LastCue = s;
                //soundBank.PlayCue(s);
            }
            catch { }
        }

        public void StopMusic()
        {
            try
            {
                soundCatMusic.Stop(AudioStopOptions.Immediate);
            }
            catch
            {
            }
        }

        public string GetSound()
        {
            try
            {
                if (soundBank.IsInUse)
                {
                    return LastCue;
                }
                else
                {
                    return "none";
                }
            }
            catch
            {
            }
            return "none";
        }

        public void SetMusicVolume(float volume)
        {
            try
            {
                soundCatMusic.SetVolume(volume);
            }
            catch 
            {
            }
        }

        public void SetFxVolume(float volume)
        {
            try
            {
                soundCatFx.SetVolume(volume);
            }
            catch
            {
            }
        }

        public static SoundManager Sound
        {
            get
            {
                if (sound != null)
                    return sound;
                else
                {
                    sound = new SoundManager();
                    sound.Initialize();
                    return sound;
                }
            }
        }
    }
}
