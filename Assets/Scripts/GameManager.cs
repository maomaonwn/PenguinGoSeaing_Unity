using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Animator loadingAnim;

    private int FadeInBool = Animator.StringToHash("FadeIn");
    private int FadeOutBool = Animator.StringToHash("FadeOut");
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);

        loadingAnim = GetComponent<Animator>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
        StartCoroutine(LoadSceneAnimation());
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Application.Exit();
#endif
    }

/// <summary>
/// �����ĵ��붯��
/// </summary>
/// <returns></returns>
    IEnumerator LoadSceneAnimation()
    {
        //�������ض���
        loadingAnim.SetBool(FadeInBool, true);
        loadingAnim.SetBool(FadeOutBool, false);
        //�ȴ�һ���ӣ�����ʱ����
        yield return new WaitForSeconds(1);

        //�رռ��ض���
        loadingAnim.SetBool(FadeInBool, false);
        loadingAnim.SetBool(FadeOutBool, true);
    }
}
