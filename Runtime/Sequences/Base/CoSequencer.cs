using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Coroutines
{
    [AddComponentMenu(nameof(Common) + "/" + nameof(Coroutines) + "/" + nameof(CoSequencer))]
    public class CoSequencer : SegmentBehaviour
    {
        [SerializeReference]
        protected List<ISegment> _segments;

        private Coroutine _coroutine;

        public CoSequencer()
        {
            _segments = new List<ISegment>();
        }

        public IEnumerable<ISegment> GetSegments()
        {
            return _segments;
        }

        public override IEnumerator Build()
        {
            var prev = (ILink)_segments[0];
            for (int i = 1; i < _segments.Count; ++i)
            {
                var next = _segments[i];
                if (next is IDecorator decorator)
                {
                    prev = new DecoratorLink(prev, decorator);
                }
                else
                {
                    prev = new ThenLink(prev, next);
                }
            }
            return prev.Build();
        }

        public Coroutine Play(MonoBehaviour target)
        {
            return Build().Start(target);
        }

        public void Play()
        {
            _coroutine = Play(this);
        }

        public void Stop()
        {
            UCoroutine.SafeStop(ref _coroutine, this);
        }

        private void OnEnable()
        {
            Play();
        }

        private void OnDisable()
        {
            Stop();
        }

        public override void OnValidate()
        {
            foreach (var segment in GetSegments())
            {
                if (segment != null)
                {
                    segment.OnValidate();
                }
            }
        }

        private void Reset()
        {
            enabled = false;
        }
    }

    public static class CoSequenceExtensions
    {
        public static IEnumerable<T> GetSegments<T>(this CoSequencer self)
            where T : ISegment
        {
            foreach (var segment in self.GetSegments())
            {
                if (segment is T item)
                {
                    yield return item;
                }
            }
        }
    }
}