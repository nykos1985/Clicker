namespace Main
{
    public class Enemy : EnemyBase
    {
        public void Damage()
        {
            if (Hp > 1)
            {
                Hp--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}