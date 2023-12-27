using System;
using System.Collections;
using UnityEngine;

namespace Common.Coroutines
{
    [Serializable]
    public abstract class TrailRendererSegment<T> : TimedSegment
    {
        [SerializeField] protected TrailRenderer _renderer;
        [SerializeField] protected T _target;
    }
    
    [SegmentMenu(nameof(TrailRenderer), "StartColor")]
    public sealed class TrailRendererStartColorSegment : TrailRendererSegment<Color>
    {
        public override IEnumerator CoExecute()
            => _renderer.CoStartColor(_target, _duration, _easer.Evaluate);
    }

    [SegmentMenu(nameof(TrailRenderer), "StartFade")]
    public sealed class TrailRendererStartFadeSegment : TrailRendererSegment<float>
    {
        public override void OnValidate()
            => _target = Mathf.Clamp(_target, 0.0f, 1.0f);

        public override IEnumerator CoExecute()
            => _renderer.CoStartFade(_target, _duration, _easer.Evaluate);
    }

    [SegmentMenu(nameof(TrailRenderer), "EndColor")]
    public sealed class TrailRendererEndColorSegment : TrailRendererSegment<Color>
    {
        public override IEnumerator CoExecute()
            => _renderer.CoEndColor(_target, _duration, _easer.Evaluate);
    }

    [SegmentMenu(nameof(TrailRenderer), "EndFade")]
    public sealed class TrailRendererEndFadeSegment : TrailRendererSegment<float>
    {
        public override void OnValidate()
            => _target = Mathf.Clamp(_target, 0.0f, 1.0f);

        public override IEnumerator CoExecute()
            => _renderer.CoEndFade(_target, _duration, _easer.Evaluate);
    }

    [SegmentMenu(nameof(TrailRenderer), "Time")]
    public sealed class TrailRendererTimeSegment : TrailRendererSegment<float>
    {
        public override IEnumerator CoExecute()
            => _renderer.CoTime(_target, _duration, _easer.Evaluate);
    }
    
    [SegmentMenu(nameof(TrailRenderer), "StartWidth")]
    public sealed class TrailRendererStartWidthSegment : TrailRendererSegment<float>
    {
        public override IEnumerator CoExecute()
            => _renderer.CoStartWidth(_target, _duration, _easer.Evaluate);
    }
    
    [SegmentMenu(nameof(TrailRenderer), "EndWidth")]
    public sealed class TrailRendererEndWidthSegment : TrailRendererSegment<float>
    {
        public override IEnumerator CoExecute()
            => _renderer.CoEndWidth(_target, _duration, _easer.Evaluate);
    }
}