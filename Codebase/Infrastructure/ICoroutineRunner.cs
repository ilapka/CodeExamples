using System.Collections;
using UnityEngine;

namespace Codebase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
        bool IsAlive();
    }
}