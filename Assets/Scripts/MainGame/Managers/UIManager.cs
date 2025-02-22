using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    
    [SerializeField] private PlayerCharacterController bobby;
    [SerializeField] private GameObject skillsHolder;
    private GameObject[] skillsButtonsUI;
    
    public void RefreshHPText(int newHP)
    {
        hpText.text = newHP.ToString();
    }

    private void Awake()
    {
        bobby.onTakeDamageEventAction += RefreshHPText;
    }

    private void Start()
    {
        hpText.text = bobby.Hp.ToString();
        skillsButtonsUI = skillsHolder.GetComponentsInChildren<GameObject>();
        for (int i = 0; i < skillsButtonsUI.Length; i++)
        {
            skillsButtonsUI[i].GetComponent<SkillButtonUI>().skillIcon.sprite =  skillsButtonsUI[i].GetComponent<SkillButtonUI>().skillIcons[i];
            skillsButtonsUI[i].GetComponent<SkillButtonUI>().skillNameText.text = "Skill " + (i + 1);
        }
       
    }

   
}