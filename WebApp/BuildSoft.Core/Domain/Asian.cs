namespace BuildSoft.Core.Domain
{
    public class Asian : Person
    {
        public override float Height
        {
            get
            {
                return (1.7f + ((Age + 2) * 0.23f));
            }
        }

        public override PersonType PersonType
        {
            get
            {
                return PersonType.Asian;
            }
        }
    }
}