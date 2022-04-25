using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour
{
    [SerializeField] private Image borderImage;
    [SerializeField] private Color color;


    public void Awake()
    {
        color = UnityEngine.Random.ColorHSV();
        borderImage.color = color;

    }

}
