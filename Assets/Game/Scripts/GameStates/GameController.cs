using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI StateStatus;
    [SerializeField]
    public TextMeshProUGUI GameEnding;
    [SerializeField]
    public GameObject Cannon;
    [SerializeField]
    public LineRenderer Line;
    [SerializeField]
    public PlayerController _playerController;
    [SerializeField]
    public AudioSource _WinnerSound;
    [SerializeField]
    public AudioSource _LoserSound;
    [SerializeField]
    public List<GameObject> tiles;
    [SerializeField]
    public List<GameObject> submarines;
    [SerializeField]
    public SubmarineSpawner subSpawner;
    [SerializeField]
    public int ShotsLeft;
    [SerializeField]
    public int SubsLeft;
    [SerializeField]
    public TextMeshProUGUI NumofSubs;
    [SerializeField]
    public TextMeshProUGUI NumofShots;


    private void Awake()
    {
        SubsLeft = submarines.Count;
    }

    private void Update()
    {
        NumofShots.text = ": " + ShotsLeft;
        NumofSubs.text = ": " + SubsLeft;
    }
}
