using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public int damage;
	
    [SerializeField]
	float damageTick;
	
    float currentTick;
    bool canDamage = true;

    private LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        HandleCooldown();

        if (!canReflect)
        {
            lineRenderer.enabled = false;
        }
    }

    bool canReflect = true;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // retrieve colliding object and bullet component
        GameObject other = collider.gameObject;
        Bullet bullet = collider.GetComponent<Bullet>();

        // check if the collider has a bullet component
        if (bullet == null)
            return;
        
        // initialize a new vector to zero which
        // will be the normal vector of the reflection
        Vector2 n = transform.up;
		
        // generate reflection vector between colliding object and mirror
        Vector2 reflection = Vector2.Reflect(bullet.direction, n);
        // reflection contains a new forward vector now
        // set the forward of the colliding object to reflection
        bullet.direction = reflection;
    }

    public void Reflect(Vector2 inputVector, Vector2 reflectionPoint, float laserLength)
    {
        Debug.Log("I Reflect");

        lineRenderer.SetPosition(0, reflectionPoint);

        // initialize a new vector to zero which
        // will be the normal vector of the reflection
        Vector2 n = transform.up;
		
        // generate reflection vector between colliding object and mirror
        Vector2 reflection = Vector2.Reflect(inputVector, n);
        reflection.Normalize();

        var layerMask = 1 << 12;
        // This would cast rays only against colliders in layer xxx.
        // But instead we want to collide against everything except layer xxx. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit2D hit = Physics2D.Raycast(reflectionPoint, reflection, 100f);
     

        if (!hit)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(1, reflectionPoint + reflection * 20f);
            Debug.Log("I not hit " + reflection + " " + inputVector);
            return;
        };

        float distance = Vector2.Distance(reflectionPoint, hit.point);
        if (laserLength < distance)
        {
            return;
        }

        Debug.Log(hit.transform.gameObject);

        lineRenderer.enabled = true;

        lineRenderer.SetPosition(1, hit.point);
        canReflect = true;
        StartCoroutine(DisableLineRenderer());


        if (hit.collider.gameObject.tag == "Mirror")
        {
            Debug.Log("I Hit Mirror");
            hit.collider.gameObject.GetComponent<Mirror>().Reflect(hit.point - new Vector2(reflectionPoint.x, reflectionPoint.y), hit.point, laserLength - distance);
        }
        //dont do anything, if cooldown isn't over yet.
        if (!canDamage)
            return;

        //otherwise hit enemy
        if (hit.collider.gameObject.tag == "Enemy")
        {
            TriggerDamage(hit.collider.gameObject);
        }

        if (hit.collider.gameObject.tag == "Player")
        {
            TriggerDamage(hit.collider.gameObject);
        }
    }

    IEnumerator DisableLineRenderer()
    {
        yield return new WaitForSeconds(.1f);
        canReflect = false;
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

        receiver.GetComponent<DamageComponent>().OnDamageReceived(info);

        canDamage = false;
    }
}
