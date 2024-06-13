using UnityEngine;
using UnityEngine.Audio;
using VContainer;
using Audio = _Project.Code.Core.Util.Constants.Audio;

namespace _Project.Code.Services.SoundService
{
    public sealed class SoundService
    {
        [Inject] private readonly AudioMixerGroup _audioMixerGroup;
        [Inject] private readonly AudioSource _musicAudioSource;

        public bool IsMusicMuted { get; private set; }
        public bool IsSfxMuted { get; private set; }
        
        public void SetMusicVolume(float volume) => 
            _audioMixerGroup.audioMixer.SetFloat(Audio.Music, Mathf.Log10(volume) * Audio.MaxValue);

        public void SetSfxVolume(float volume) => 
            _audioMixerGroup.audioMixer.SetFloat(Audio.SFX, Mathf.Log10(volume) * Audio.MaxValue);

        public void MuteMusic()
        {
            IsMusicMuted = !IsMusicMuted;
            _audioMixerGroup.audioMixer.SetFloat(Audio.Music, IsMusicMuted ? Audio.MuteValue : 0f);
        }

        public void MuteSfx()
        {
            IsSfxMuted = !IsSfxMuted;
            _audioMixerGroup.audioMixer.SetFloat(Audio.SFX, IsSfxMuted ? Audio.MuteValue : 0f);
        }
    }
}