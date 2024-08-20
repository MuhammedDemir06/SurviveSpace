using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAccountUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject createOrLoginUI;
    [SerializeField] private GameObject loginAccountUI;
    [SerializeField] private GameObject createAccountUI;
    [Header("Texts")]
    [SerializeField] private GameObject wrongLoginText;
    [SerializeField] private GameObject nameTakenText;
    [SerializeField] private GameObject accountCreatedText;
    private void OnEnable()
    {
        LoginAccount.WrongLogin += WrongLogin;
        CreateAccount.NameTaken += NameTaken;
        CreateAccount.AccountCreated += AccountCreated;
    }
    private void OnDisable()
    {
        LoginAccount.WrongLogin -= WrongLogin;
        CreateAccount.NameTaken -= NameTaken;
        CreateAccount.AccountCreated -= AccountCreated;
    }
   
    private void Start()
    {
        createOrLoginUI.SetActive(true);
        loginAccountUI.SetActive(false);
        createAccountUI.SetActive(false);
    }
    private void AccountCreated()
    {
        accountCreatedText.SetActive(true);
        createAccountUI.SetActive(false);
        createOrLoginUI.SetActive(true);
    }
    private void NameTaken()
    {
        StartCoroutine(NameTakenTimer());
    }
    private IEnumerator NameTakenTimer()
    {
        nameTakenText.SetActive(true);
        yield return new WaitForSeconds(3f);
        nameTakenText.SetActive(false);
    }
    private void WrongLogin()
    {
        StartCoroutine(WrongLoginTimer());
    }
    private IEnumerator WrongLoginTimer()
    {
        wrongLoginText.SetActive(true);
        yield return new WaitForSeconds(3f);
        wrongLoginText.SetActive(false);
    }
    //Buttons
    public void LoginAccountButton()
    {
        createOrLoginUI.SetActive(false);
        loginAccountUI.SetActive(true);
        createAccountUI.SetActive(false);
        accountCreatedText.SetActive(false);
    }
    public void CreateAccountButton()
    {
        createOrLoginUI.SetActive(false);
        loginAccountUI.SetActive(false);
        createAccountUI.SetActive(true);
    }
    public void BackButton()
    {
        createOrLoginUI.SetActive(true);
        loginAccountUI.SetActive(false);
        createAccountUI.SetActive(false);
    }
}
