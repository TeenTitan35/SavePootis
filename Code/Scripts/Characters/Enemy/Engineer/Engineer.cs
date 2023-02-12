using UnityEngine;

public class Engineer : MonoBehaviour
{
    [SerializeField] private EnemyHealth _turret;

    [Header("Audio")]
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _laughs;
    [SerializeField] private AudioClip _sentryDown;
    [SerializeField] private AudioClip[] _curses;

    private LaughBehaviour _laugh;
    private CurseBehaviour _curse;

    private void Start()
    {
        InitBehaviours();    
    }

    private void OnEnable()
    {
        _turret.OnUnitDown += Curse;       
    }

    private void OnDisable()
    {
        _turret.OnUnitDown -= Curse;
        _curse.StopCursing();
    }

    private void InitBehaviours()
    {
        _laugh = new LaughBehaviour(_source, _laughs);
        _curse = new CurseBehaviour(_source, _sentryDown, _curses);
    }

    private void Laugh() => _laugh.Speak();
    private void Curse() => _curse.Speak();
    
}
