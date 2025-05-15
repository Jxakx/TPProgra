using UnityEngine;
using System.Collections;
using System.Linq;
using TMPro;

public class PortalManager : MonoBehaviour
{
    [Header("Configuración Portal")]
    [SerializeField] private GameObject dimensionalPortal;
    [SerializeField] public Inventory playerInventory;
    [SerializeField] private Transform jaulaDestination;
    [SerializeField] private TextMeshProUGUI portalStatusText; 

    public string[] requiredOrbs = { "orbe_azul", "orbe_rojo", "orbe_verde" };

    private void Start()
    {
        StartCoroutine(CheckOrbsCoroutine());
    }

    private IEnumerator CheckOrbsCoroutine()
    {
        while (true)
        {
            bool hasAllOrbs = requiredOrbs.All(orb => playerInventory.HasItemsy(orb));
            dimensionalPortal.SetActive(hasAllOrbs);

            // Tipo anónimo
            var portalUIInfo = new
            {
                IsActive = hasAllOrbs,
                Collected = requiredOrbs.Count(orb => playerInventory.HasItemsy(orb)),
                Missing = requiredOrbs.Where(orb => !playerInventory.HasItemsy(orb)).ToArray()
            };

           
            if (portalStatusText != null)
            {
                //portalStatusText.text = $"Orbes: {portalUIInfo.Collected}/3\n" +
                                      //$"Faltan: {string.Join(", ", portalUIInfo.Missing)}";
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && requiredOrbs.All(orb => playerInventory.HasItemsy(orb)))
        {
            other.transform.SetPositionAndRotation(jaulaDestination.position, jaulaDestination.rotation);
        }
    }
}