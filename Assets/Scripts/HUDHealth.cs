using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealth : MonoBehaviour
{
    public Sprite[] spritesTuercas;
    public Image TuercaUI;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.curRepair <= playerController.maxRepair)
        {
            TuercaUI.sprite = spritesTuercas[playerController.curRepair];
        }
    }
}
