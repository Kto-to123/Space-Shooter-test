using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public static UnityAction GameWin;
    public static bool win;

    public float distance = 20f;

    float way;
    Slider slider;

    void Start()
    {
        win = false;
        slider = GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        if (!win)
        {
            way += Time.deltaTime / distance;
            if (way < 1) slider.value = way;
            else if (way >= 1)
            {
                win = true;
                GameWin?.Invoke();
            }
        }
    }
}
