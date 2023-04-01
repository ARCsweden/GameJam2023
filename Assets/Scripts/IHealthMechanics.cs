
public interface IHealthMechanics
{
    float Health { get; set; }

    void DealDamage(float Damage);

    void OnDeath();
}
