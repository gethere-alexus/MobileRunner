namespace Sources.Services
{
    public interface IHealth
    {
        public void ApplyDamage(int damage);
        public void Heal(int amount);
    }
}