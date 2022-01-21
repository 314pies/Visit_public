using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPage : MonoBehaviour
{


    public void UIOnLoginPressed()
    {
        Debug.Log("Logging in...");
        StartCoroutine(OnLoginPressed());
    }
    public GameObject LoginButton;
    public GameObject LoginLoading;
    public Animation loginAnim;
    public IEnumerator OnLoginPressed()
    {
        Debug.Log("User Logged in. UserName: Leo3255");
        LoginButton.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        LoginLoading.SetActive(true);
        yield return new WaitForSeconds(Random.Range(1.5f,4.5f));
        LoginLoading.SetActive(false);
        loginAnim.Play("UISlide-out-down");
    }
}
