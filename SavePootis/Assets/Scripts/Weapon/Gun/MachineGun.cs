using System.Collections;
using UnityEngine;

public class MachineGun : MonoBehaviour, IWeapon
{
    [Header("Combat")]
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _timeBtwShot;

    [Header("Ammo")]
    [SerializeField] private Projectile _bullet;
    [SerializeField] private int _bulletsCount;
    [SerializeField] private float _reloadTime;
    private int _currentBulletsCount;
    private bool _isReloading = false;
    
    [Header("SFX")]
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private AudioClip _reloadSound;

    private void Start()
    {
        _currentBulletsCount = _bulletsCount;
        _fireRate = 1 / _fireRate * 60;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _timeBtwShot -= Time.deltaTime;
    }

    public void PerformAttack()
    {
        if (_timeBtwShot > 0 || _isReloading)
            return;

        Instantiate(_bullet, transform.position, transform.rotation);
        _bullet.Damage = _damage;
        _currentBulletsCount--;
        _timeBtwShot = _fireRate;
        _audioSource.PlayOneShot(_fireSound);
        if (_currentBulletsCount <= 0)
            StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        _isReloading = true;
        _audioSource.PlayOneShot(_reloadSound);
        yield return new WaitForSeconds(_reloadTime);
        _currentBulletsCount = _bulletsCount;
        _isReloading = false;
    }
}
