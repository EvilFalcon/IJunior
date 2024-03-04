using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;

    private string _replacedText = "Изменили";
    private string _additionalText = " Добавили";
    private string _hackedText = "Взломан";
    private float _duration = 2f;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append( _text.DOText(_replacedText, _duration));
        sequence.Append(_text.DOText(_additionalText, _duration).SetRelative());
        sequence.Append(_text.DOText(_hackedText, _duration, true, ScrambleMode.All));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
