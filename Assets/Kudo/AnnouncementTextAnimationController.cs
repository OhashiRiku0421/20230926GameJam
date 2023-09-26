using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementTextAnimationController : MonoBehaviour
{
    Animator _anim;
    [SerializeField, Header("三つの駅名")] string[] _nextStationName;
    Text _announcementText;
    int _nextStationIndex = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _announcementText = GetComponent<Text>();
    }
    void AnimationPlay()
    {
        _announcementText.text = $"次は{_nextStationName[_nextStationIndex]}〜";
        _anim.SetTrigger("IsSideMove");
        _nextStationIndex++;
    }
}
