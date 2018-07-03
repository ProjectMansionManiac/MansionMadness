using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageComponent : DamageComponent
{
    public Image healthBar;
    public GameObject gameOverScreen;

    public Color damageColor;
    Color normalColor;

    public SpriteRenderer spriteRenderer;
    public int animationSpeed;
    bool isAnimating = false;

    bool isInvincible = false;
    public float invincibilityTime = 1f;

    private void Start()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        normalColor = spriteRenderer.color;
        healthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        //gameOverScreen = GameObject.Find("GameOverScreen");
    }

    private bool damageZoneActive = false;
    [SerializeField] private float contactDamage = 10.0f;
    [SerializeField] private float damageZoneCooldownTime = 5.0f;

    public override void OnDamageReceived(DamageInfo info)
    {
        base.OnDamageReceived(info);

        healthBar.fillAmount = this.health / 100f;
        StartCoroutine(DamageAnimation());
        // check if health is below zero
        if (this.health == 0f)
        {
            // the player is dead...
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    private IEnumerator DamageTick()
    {
        yield return new WaitForSeconds(damageZoneCooldownTime);
        this.damageZoneActive = false;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvincible)
            return;

        StartCoroutine(Invincibility());

        var other = collision.gameObject;

        Debug.Log("Hit " + other.name);

        if (other.tag == "EnemyBullet")
        {
            var knockbackComp = other.GetComponent<KnockBackComponent>();

            DamageComponent.DamageInfo info = new DamageComponent.DamageInfo();
            info.damage = collision.gameObject.GetComponent<Bullet>().damage;
            info.sender = collision.gameObject;

            this.OnDamageReceived(info);

            knockbackComp.Execute(gameObject.transform.parent.gameObject);

            Destroy(collision.gameObject);
        }
        if (other.tag == "Spike")
        {
            var knockbackComp = other.GetComponent<KnockBackComponent>();

            DamageComponent.DamageInfo info = new DamageComponent.DamageInfo();
            info.damage = collision.gameObject.GetComponent<Spike>().damage;
            info.sender = collision.gameObject;
            this.OnDamageReceived(info);

            //collision.gameObject.GetComponent<KnockBackComponent>().canKnockback = false;

            knockbackComp.Execute(gameObject.transform.parent.gameObject);

            Destroy(collision.gameObject);
        }
        if ((other.name == "HitboxHead" || other.name == "HitboxBody" || other.name == "HitboxTorso") && damageZoneActive == false)
        {
            var knockbackComp = other.GetComponent<KnockBackComponent>();

            Debug.Log(other.gameObject);

            var damageComponent = other.GetComponent<DamageComponent>();
            if (damageComponent != null)
            {
                DamageInfo info = new DamageInfo();
                info.damage = contactDamage;
                info.sender = this.gameObject;

                OnDamageReceived(info);
                this.damageZoneActive = true;

                StartCoroutine(DamageTick());
            }

            knockbackComp.Execute(gameObject.transform.parent.gameObject);
        }
    }

    public void Respawn()
    {
        this.health = 100.0f;
        this.transform.parent.position = GameManager.GetInstance().currentState.currentCheckPoint;
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
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
