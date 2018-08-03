using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageComponent : DamageComponent
{
    public Color damageColor;
    Color normalColor;

    public SpriteRenderer spriteRenderer;
    public int animationSpeed;
    bool isAnimating = false;

    Chicken chicken;

    void Start()
    {
        spriteRenderer = GameObject.Find("EnemySprite").GetComponent<SpriteRenderer>(); ;
        normalColor = spriteRenderer.color;
        chicken = GetComponentInParent<Chicken>();
    }
    public override void OnDamageReceived(DamageInfo info)
    {
        base.OnDamageReceived(info);

        StartCoroutine(DamageAnimation());

        chicken.health -= info.damage;

        if (PhaseController.instance.health1 != 0)
        PhaseController.instance.health1 -= info.damage;
        
        if (PhaseController.instance.health1 == 0)
        {
            if (PhaseController.instance.health2 != 0)
                PhaseController.instance.health2 -= info.damage;
        }

        if (PhaseController.instance.health1 == 0 && PhaseController.instance.health2 == 0)
        {
            if (PhaseController.instance.health3 != 0)
                PhaseController.instance.health3 -= info.damage;
        }

        if (PhaseController.instance.health1 < 0)
        {
            PhaseController.instance.health1 = 0;
        }
        if (PhaseController.instance.health2 < 0)
        {
            PhaseController.instance.health2 = 0;
        }
        if (PhaseController.instance.health3 < 0)
        {
            PhaseController.instance.health3 = 0;
        }



        SoundManager.instance.PlayBossDamageSound();
        // check if health is below zero
        //if (this.health <= 0)
        //{
        //    // the boss is dead...
        //    isDead = true;
        //    gameObject.SetActive(false);
        //}
    }

    IEnumerator DamageAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            for (int i = 0; i < animationSpeed; i++)
            {
                yield return new WaitForEndOfFrame();
                spriteRenderer.color = Color.Lerp(normalColor, damageColor, .2f * i);
            }
            for (int i = animationSpeed; i > 0; i--)
            {
                yield return new WaitForEndOfFrame();
                spriteRenderer.color = Color.Lerp(damageColor, normalColor, .7f * i);
            }
            spriteRenderer.color = normalColor;
            isAnimating = false;
        }
    }
}
