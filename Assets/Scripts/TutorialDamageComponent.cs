using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDamageComponent : DamageComponent
{

    public GameObject objectToActivate;

    private void Update()
    {
        if (health <= 0f)
        {
            objectToActivate.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
