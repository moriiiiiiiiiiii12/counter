using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _countSteps;
    [SerializeField] private float _timeStep = 0.5f;
    [SerializeField, Min(0)] private float _count = 0f;

    private Coroutine _countCoroutine;

    public bool IsCounting { get; private set; } = false;
    public float Count => _count;

    public event UnityAction CountingChanged;
    public event UnityAction CountChanged;

    public void Switching()
    {
        if (_countCoroutine == null) 
        {
            Debug.Log("Полетело");
            IsCounting = true;

            _countCoroutine = StartCoroutine(StartCount());

            CountingChanged?.Invoke();
        }
        else 
        {
            Debug.Log("Остановка");
            IsCounting = false;

            StopCoroutine(_countCoroutine);
            
            _countCoroutine = null;

            CountingChanged?.Invoke();
        }
    }

    private IEnumerator StartCount()
    {
        while (IsCounting)
        {
            _count += _countSteps;
            CountChanged?.Invoke();
            
            Debug.Log(_count.ToString());

            yield return new WaitForSecondsRealtime(_timeStep);
        }
    }
}
