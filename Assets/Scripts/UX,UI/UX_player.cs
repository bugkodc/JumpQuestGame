using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.Rendering.VirtualTexturing;

public class UX_player : MonoBehaviour
{
    [SerializeField] public Animator _UxPlayer;
    [SerializeField] public Animator _Uxenemy;
    public void ClickPlayer()
    {
        _UxPlayer.SetTrigger("hit");
    }
    public void Clickenemy()
    {
        _Uxenemy.SetTrigger("hit");
    }
}
