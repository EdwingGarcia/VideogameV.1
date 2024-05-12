using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
  
    public static GameManager Instance {  get; private set; }
    public int gunAmmo = 30;
    public int gunDamage = 0;

    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text=gunAmmo.ToString();
    }
}
