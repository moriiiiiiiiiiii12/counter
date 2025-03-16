using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = _counter.Count.ToString();

        DisplayStatusButton();

    }

    private void OnEnable()
    {
        _counter.CountChanged += DisplayCount;
        _counter.CountingChanged += DisplayStatusButton;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayCount;
        _counter.CountingChanged -= DisplayStatusButton;
    }

    private void DisplayCount()
    {
        _text.text = _counter.Count.ToString();
    }

    private void DisplayStatusButton()
    {
        if (_counter.IsCounting == false)
        {
            _textButton.text = "Включить";
        }
        else
        {
            _textButton.text = "Выключить";
        }
    }
}
