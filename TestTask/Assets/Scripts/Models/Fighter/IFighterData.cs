namespace Models.Fighter
{
    public interface IFighterData
    {
        Stat[] Stats { get; }
        Buff[] Buffs { get; }
        
        IFighterData ToDamage();

        void TakeDamage(IFighterData fighterData);
    }
}