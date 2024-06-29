using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofres : MonoBehaviour
{
    [SerializeField] private bool _isInTrunk;
    private Inventory _myInventory;
    public GameObject orbe;
    public Transform instancePoint;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip noAccessSound;
    private bool onlyOneTime;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (_isInTrunk)
            {
                if (_myInventory.HasItemsy("llavecabra") && !onlyOneTime)
                {
                    audioSource.PlayOneShot(openSound);
                    onlyOneTime = true;
                    animator.SetTrigger("isOpen");
                } else
                {
                    audioSource.PlayOneShot(noAccessSound);
                }
            } 
        }
    }

    public void InstanciarOrbe()
    {
        Instantiate(orbe, instancePoint.position, this.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        _myInventory = other.GetComponent<Inventory>();
        if (_myInventory != null)
        {
            _isInTrunk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isInTrunk = false;
    }
}
