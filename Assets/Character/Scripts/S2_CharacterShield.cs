using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CharacterShield : MonoBehaviour
{
    [SerializeField] GameObject shieldForm = null;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnShield()
    {
        if (!shieldForm) return;
        shieldForm.SetActive(true);
        float _size = 5;
        shieldForm.transform.localScale = new Vector3(_size, _size, _size);
        shieldForm.SetActive(false);

    }
}
