using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Sprite zero;
    [SerializeField] private Sprite one;
    [SerializeField] private Sprite two;
    [SerializeField] private Sprite three;

    [SerializeField] private Image img;

    private void Awake()
    {
        PlayerHealth.SetHeslth += SetCount;
    }

    private void OnDisable()
    {
        PlayerHealth.SetHeslth -= SetCount;
    }

    public void SetCount(int count)
    {
        switch (count)
        {
            case 0:
                img.sprite = zero;
                break;
            case 1:
                img.sprite = one;
                break;
            case 2:
                img.sprite = two;
                break;
            case 3:
                img.sprite = three;
                break;
            default:
                img.sprite = zero;
                break;
        }
    }
}
