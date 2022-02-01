using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDD.Events;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] public bool HasBeenCollected { get; set; }

    public virtual void Collected()
    {
        EventManager.Instance.Raise(new CollectItemEvent() { item = this });
        HasBeenCollected = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collected();
            Destroy(this.gameObject);
        }
    }
}
