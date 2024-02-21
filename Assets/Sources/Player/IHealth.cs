namespace Sources.Player
{
    public interface IHealth
    {
        public void ApplyDamage(int damage);
        public void Heal(int amount);
    }
}