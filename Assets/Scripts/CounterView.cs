using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _textButton;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _text.text = _counter.Value.ToString();

        DisplayStatusButton();

    }

    private void OnEnable()
    {
        _counter.ValueChanged += Display;
        _counter.StateChanged += DisplayStatusButton;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= Display;
        _counter.StateChanged -= DisplayStatusButton;
    }

    private void Display()
    {
        _text.text = _counter.Value.ToString();
    }

    private void DisplayStatusButton()
    {
        if (_counter.IsActive == false)
        {
            _textButton.text = "Включить";
        }
        else
        {
            _textButton.text = "Выключить";
        }
    }
}
