using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _steps;
    [SerializeField] private float _timeStep = 0.5f;
    [SerializeField, Min(0)] private float _value = 0f;

    private Coroutine _coroutine;

    public bool IsActive { get; private set; } = false;
    public float Value => _value;

    public event Action StateChanged;
    public event Action ValueChanged;

    private void OnEnable()
    {
        _button.onClick.AddListener(Switching);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Switching);
    }

    public void Switching()
    {
        if (_coroutine == null)
        {
            Enable();
        }
        else
        {
            Disable();
        }
    }

    private void Enable()
    {
        IsActive = true;

        _coroutine = StartCoroutine(Go());

        StateChanged?.Invoke();
    }

    private void Disable()
    {
        IsActive = false;

        StopCoroutine(_coroutine);

        _coroutine = null;

        StateChanged?.Invoke();
    }

    private IEnumerator Go()
    {
        while (IsActive)
        {
            _value += _steps;
            ValueChanged?.Invoke();

            yield return new WaitForSecondsRealtime(_timeStep);
        }
    }
}
