using UnityEngine;
using UnityEngine.Events;

public class FireHazard : MonoBehaviour
{
    public event UnityAction<FireEnteredEventArgs> onCharacterEnteredAction;
    
    [HideInInspector] public FireHazardScriptableObject fireHazardData;

    [SerializeField]
    private UnityEvent<FireEnteredEventArgs> onCharacterEntered = new UnityEvent<FireEnteredEventArgs>();

    [SerializeField] private GameObject player;
    private PlayerCharacterController targetCharacterController;

    const string playerTag = "PlayerCharacter";// Added a const string to hold the player tag.

    // public void SetScriptableData(FireHazardScriptableObject fireHazardScriptableObject)
    // {
    //     fireHazardData = fireHazardScriptableObject;
    // }
    private void Start()
    { 
        targetCharacterController = player.GetComponent<PlayerCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Player entered this hazard");
            FireEnteredEventArgs fireEnteredEventArgs = new FireEnteredEventArgs
            {
                damageDealt = fireHazardData.GetRandomFireDamage(),
                targetCharacterController = this.targetCharacterController
            };
            onCharacterEntered?.Invoke(fireEnteredEventArgs);
            onCharacterEnteredAction.Invoke(fireEnteredEventArgs);
        }
    }
}

public class FireEnteredEventArgs
{
    public int damageDealt;
    public PlayerCharacterController targetCharacterController;
}