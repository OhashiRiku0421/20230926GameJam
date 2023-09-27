using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDistanceText : MonoBehaviour
{
    [SerializeField]
    private Text _distanceText;
    [SerializeField]
    private PlayerController _player;
    private void Update()
    {
        _distanceText.text = _player.Distance().ToString("F2") + "m";
    }
}
