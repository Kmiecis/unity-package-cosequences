﻿using System;
using System.Collections;
using UnityEngine;

namespace Common.Coroutines
{
    public static class LineRendererExtensions
    {
        public static Func<IEnumerator> CoStartColor(this LineRenderer self, Color target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetStartColor, self.SetStartColor, target, duration, easer);

        public static Func<IEnumerator> CoEndColor(this LineRenderer self, Color target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetEndColor, self.SetEndColor, target, duration, easer);

        public static Func<IEnumerator> CoStartWidth(this LineRenderer self, float target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetStartWidth, self.SetStartWidth, target, duration, easer);

        public static Func<IEnumerator> CoEndWidth(this LineRenderer self, float target, float duration, Func<float, float> easer = null)
            => () => UCoroutine.YieldValueTo(self.GetEndWidth, self.SetEndWidth, target, duration, easer);
    }

    internal static class InternalLineRendererExtensions
    {
        #region Color
        public static Color GetStartColor(this LineRenderer self)
            => self.startColor;

        public static void SetStartColor(this LineRenderer self, Color value)
            => self.startColor = value;

        public static Color GetEndColor(this LineRenderer self)
            => self.endColor;

        public static void SetEndColor(this LineRenderer self, Color value)
            => self.endColor = value;
        #endregion

        #region Width
        public static float GetStartWidth(this LineRenderer self)
            => self.startWidth;

        public static void SetStartWidth(this LineRenderer self, float value)
            => self.startWidth = value;

        public static float GetEndWidth(this LineRenderer self)
            => self.endWidth;

        public static void SetEndWidth(this LineRenderer self, float value)
            => self.endWidth = value;
        #endregion
    }
}
