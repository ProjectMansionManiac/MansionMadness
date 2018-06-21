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
        spriteRenderer = GameObject.Find("Enemy").GetComponent<SpriteRenderer>(); ;
        normalColor = spriteRenderer.color;
        chicken = GetComponentInParent<Chicken>();
    }
    public override void OnDamageReceived(DamageInfo info)
    {
        base.OnDamageReceived(info);

        StartCoroutine(DamageAnimation());

        chicken.health -= info.damage;
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
            Debug.Log("Hey Man");
            isAnimating = true;
            for (int i = 0; i < animationSpeed; i++)
            {
                yield return new WaitForSeconds(0.01f);
                spriteRenderer.color = Color.Lerp(normalColor, damageColor, .2f * i);
            }
            for (int i = animationSpeed; i > 0; i--)
            {
                yield return new WaitForSeconds(0.01f);
                spriteRenderer.color = Color.Lerp(damageColor, normalColor, .7f * i);
            }
            spriteRenderer.color = normalColor;
            isAnimating = false;
        }
    }
}
