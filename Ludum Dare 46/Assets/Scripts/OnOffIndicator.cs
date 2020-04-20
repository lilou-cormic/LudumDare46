using PurpleCable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OnOffIndicator : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer = null;

    [SerializeField] Sprite OnSprite = null;

    [SerializeField] Sprite OffSprite = null;

    private bool _isOn = false;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetState(bool isOn)
    {
        _isOn = isOn;

        if (_isOn)
            SpriteRenderer.sprite = OnSprite;
        else
            SpriteRenderer.sprite = OffSprite;

        gameObject.StartAnimations();
    }
}
