using System.Collections;
using UnityEngine;

namespace Common.Coroutines
{
    public abstract class SegmentBehaviour : MonoBehaviour, ISegment
    {
        public abstract IEnumerator CoExecute();

        public virtual void OnAdded()
        {
        }

#if UNITY_EDITOR
        public virtual void OnValidate()
        {
        }
#endif
    }
}