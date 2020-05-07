using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataValueController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void Configure(string _value)
    {
        text.text = _value;
    }
}
