namespace BuildSoft.Core.Domain
{
    public class Saxon : Person
    {
        public override float Height
        {
            get
            {
                return (1.5f + (Age * 0.45f));
            }
        }

        public override PersonType PersonType
        {
            get
            {
                return PersonType.Saxon;
            }
        }
    }
}
