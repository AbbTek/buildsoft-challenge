namespace BuildSoft.Core.Domain
{
    public class Jute : Person
    {
        public override float Height
        {
            get
            {
                return ((Age * 1.6f) / 2);
            }
        }

        public override PersonType PersonType
        {
            get
            {
                return PersonType.Jute;
            }
        }
    }
}
