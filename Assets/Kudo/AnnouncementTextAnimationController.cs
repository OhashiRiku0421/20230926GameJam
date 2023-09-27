using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementTextAnimationController : MonoBehaviour
{
    Animator _anim;
    Text _announcementText;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _announcementText = GetComponent<Text>();
    }
    /// <summary>�A�i�E���XText�̃A�j���[�V������Play���郁�\�b�h</summary>
    /// <param name="anaText">�A�i�E���X��Text</param>
    public void AnimationPlay(string anaText)
    {
        _announcementText.text = $"����{anaText}";
        _anim.SetTrigger("IsSideMove");
    }
}
