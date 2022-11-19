﻿using System;
using System.Collections;
using UnityEngine;

namespace Common.Coroutines
{
    public static class AudioSourceExtensions
    {
        public static Func<IEnumerator> CoPitch(this AudioSource self, float target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetPitch, self.SetPitch, target, duration, easer);

        public static Func<IEnumerator> CoVolume(this AudioSource self, float target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetVolume, self.SetVolume, target, duration, easer);
    }

    internal static class InternalAudioSourceExtensions
    {
        #region Pitch
        public static float GetPitch(this AudioSource self)
            => self.pitch;

        public static void SetPitch(this AudioSource self, float value)
            => self.pitch = value;
        #endregion

        #region Volume
        public static float GetVolume(this AudioSource self)
            => self.volume;

        public static void SetVolume(this AudioSource self, float value)
            => self.volume = value;
        #endregion
    }
}
