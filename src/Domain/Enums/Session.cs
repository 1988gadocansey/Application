using Ardalis.SmartEnum;
namespace ApplicantPortal.Domain.Enums;

/*
public class Session(string name, int value) : SmartEnum<Session>(name, value)
{
    public static readonly Session Regular = new RegularType();
    public static readonly Session Evening = new EveningType();
    public static readonly Session Sandwich = new SandwichType();
    public static readonly Session Distance = new DistanceType();
    private class RegularType : Session
    {
        public RegularType() : base(nameof(Regular), 1)
        {
        }
    }
    private class EveningType : Session
    {
        public EveningType() : base(nameof(Evening), 2)
        {
        }
    }
    private class SandwichType : Session
    {
        public SandwichType() : base(nameof(Sandwich), 3)
        {
        }
    }
    private class DistanceType : Session
    {
        public DistanceType() : base(nameof(Distance), 4)
        {
        }
    }
}*/

public enum Session
{ 
 Regular  ,
  Evening  ,
  Sandwich ,
 Session 
    
}
