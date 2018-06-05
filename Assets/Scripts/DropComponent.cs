using System.Collections.Generic;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private List<GameObject> drops;
    [SerializeField]
    private float dropHeight;

    [SerializeField]
    private float manualDropHeight;

    private float lastX;
    
    private float fieldSize;
    [SerializeField]
    private float spacingSize;

    [SerializeField]
    bool randomSpawnHeight;

    [SerializeField]
    float randomSpawnHeightMin;
    [SerializeField]
    float randomSpawnHeightMax;

    void Start()
    {
        // save the drop height
        manualDropHeight = dropHeight;

        // retrieve the size of the drop element
        fieldSize = prefab.GetComponent<SpriteRenderer>().sprite.rect.width;

        // set the position of the first element off by half it's size
        lastX = this.transform.position.x + (fieldSize / 2);
        // now offset the position to the start of the row
        lastX -= ((drops.Count * fieldSize / 2) + ((drops.Count - 1) * spacingSize / 2));

        // iterate over all elements
        for (int i = 0; i < drops.Count; i++)
        {
            if (randomSpawnHeight)
            {
                dropHeight = Random.Range(randomSpawnHeightMin, randomSpawnHeightMax);
            }
            else
            {
                dropHeight = manualDropHeight;
            }

            // instantiate the element at the last calculated X position
            // with it's predefined height
            var drop = Instantiate(prefab, new Vector3(
                lastX,
                this.transform.position.y + this.dropHeight,
                this.transform.position.z),
                Quaternion.identity
            );

            // let it face downwards (drop)
            drop.transform.up = -drop.transform.up;

            // add it to the list of items
            drops[i] = drop;

            // set the X position for the next element
            lastX += spacingSize + fieldSize;
        }
    }

    private void Update()
    {
        
    }
}