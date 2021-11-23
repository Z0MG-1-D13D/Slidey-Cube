using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFirstButton : MonoBehaviour
{

    public Button firstButton;

    private void OnEnable()
    {
        firstButton.Select();
    }
}
