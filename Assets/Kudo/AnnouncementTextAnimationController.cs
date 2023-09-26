using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementTextAnimationController : MonoBehaviour
{
    Animator _anim;
    [SerializeField, Header("éOÇ¬ÇÃâwñº")] string[] _nextStationName;
    Text _announcementText;
    int _nextStationIndex = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _announcementText = GetComponent<Text>();
    }
    void AnimationPlay()
    {
        _announcementText.text = $"éüÇÕ{_nextStationName[_nextStationIndex]}Å`";
        _anim.SetTrigger("IsSideMove");
        _nextStationIndex++;
    }
}
