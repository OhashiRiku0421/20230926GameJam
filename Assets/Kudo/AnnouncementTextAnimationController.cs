using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnnouncementTextAnimationController : MonoBehaviour
{
    Animator _anim;
    AudioSource _audioSource;
    Text _announcementText;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _announcementText = GetComponent<Text>();
    }
    /// <summary>アナウンスTextのアニメーションをPlayするメソッド</summary>
    /// <param name="anaText">アナウンスのText</param>
    public void AnimationPlay(string anaText)
    {
        _audioSource.Play();
        _announcementText.text = $"次は{anaText}";
        _anim.SetTrigger("SideMove");
    }
}
