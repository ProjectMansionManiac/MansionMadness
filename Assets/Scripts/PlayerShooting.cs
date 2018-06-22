using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public float laserLength;
    public float CooldownTimeWhenLaserIsEmpty;

    public int damage;
    [SerializeField]
    float damageTick = 0.1f;
    float currentTick;
    bool canDamage = true;

    [SerializeField]
    float maxAmmo;
    [SerializeField]
    float currentAmmo;
    [SerializeField]
    float refillTick;
    [SerializeField]
    float refillAmount;
    float currentrefillTick;
    bool canShoot = true;

    bool shootPressed = false;

    LineRenderer lineRenderer;
    public Transform shootingOrigin;

    public Image AmmoBar;

    public Animator ammoBarBlink;

    Animator animator;

    PlayerMovement playerMovement;

    private void Start()
    {
        ammoBarBlink = GameObject.Find("AmmoBarBG").GetComponent<Animator>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, shootingOrigin.position);
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleShooting();
        HandleCooldown();
        HandleRefill();
        HandleAmmoBar();
    }

    void HandleAmmoBar()
    {
        AmmoBar.fillAmount = currentAmmo / maxAmmo;
    }

    void HandleRefill()
    {
        if (inCooldown)
            return;

        currentrefillTick += Time.deltaTime;

        if (currentrefillTick >= refillTick)
        {
            currentrefillTick = 0f;
            currentAmmo+= Time.deltaTime * refillAmount;
            if (currentAmmo > maxAmmo)
            {
                currentAmmo = maxAmmo;
            }
            //Allow shooting
            if(currentAmmo > 1)
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
                shootPressed = false;
                if (!inCooldown)
                AmmoEmpty();
            }
        }
        
    }

    private void HandleCooldown()
    {
        currentTick += Time.deltaTime;
        
        if (currentTick >= damageTick)
        {
            currentTick = 0f;

            //Allow damaging
            canDamage = true;
        }
    }

    private void TriggerDamage(GameObject receiver)
    {

        //trigger damage at the Enemy GameObject
        DamageComponent.DamageInfo info = new DamageComponent.DamageInfo();
        info.sender = this.gameObject;
        info.damage = this.damage;

        receiver.GetComponent<BossDamageComponent>().OnDamageReceived(info);

        canDamage = false;
    }

    private void AmmoEmpty()
    {
        StartCoroutine(DisableShooting());
    }

    bool inCooldown = false;

    IEnumerator DisableShooting()
    {
        currentAmmo = 0f;
        inCooldown = true;
        ammoBarBlink.enabled = true;
        yield return new WaitForSeconds(CooldownTimeWhenLaserIsEmpty);
        ammoBarBlink.enabled = false;
        inCooldown = false;
        currentAmmo = 1.1f;
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootPressed = true;
        }

        if (!canShoot)
        {
            lineRenderer.enabled = false;
            return;
        }

        if (inCooldown)
        {
            lineRenderer.enabled = false;
            return;
        }
        if (!shootPressed)
        {
            lineRenderer.enabled = false;
            return;
        }

        if (Input.GetButton("Fire1") && !playerMovement.ducking)
        {
            animator.Play("Shoot");
            currentAmmo--;
            Debug.Log("I Shoot");
            lineRenderer.SetPosition(0, shootingOrigin.position);

            Vector3 inputDirection = Vector3.zero;

            inputDirection.x = Mathf.Round(Input.GetAxis("HorizontalShoot"));
            inputDirection.y = Mathf.Round(Input.GetAxis("VerticalShoot"));

            inputDirection.Normalize();

            inputDirection.x = Mathf.Round(inputDirection.x);
            inputDirection.y = Mathf.Round(inputDirection.y);

            var layerMask = 1 << 10;
            // This would cast rays only against colliders in layer xxx.
            // But instead we want to collide against everything except layer xxx. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)shootingOrigin.position, inputDirection, 100f, layerMask);

            if (!hit)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(1, shootingOrigin.position + inputDirection * 20f);
                return;
            };
            float distance = Vector2.Distance(shootingOrigin.position, hit.point);
            if (laserLength < distance)
            {
                return;
            }



            lineRenderer.enabled = true;

            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.tag == "Mirror")
            {
                Debug.Log("I Hit Mirror");
                hit.collider.gameObject.GetComponent<Mirror>().Reflect(hit.point - new Vector2(shootingOrigin.position.x, shootingOrigin.position.y), hit.point, laserLength - distance);
            }
            //dont do anything, if cooldown isn't over yet.
            if (!canDamage)
                return;

            //otherwise hit enemy
            if (hit.collider.gameObject.tag == "Enemy")
            {
                TriggerDamage(hit.collider.gameObject);
            }


        } else
        {
            lineRenderer.enabled = false;
        }

    }
}
