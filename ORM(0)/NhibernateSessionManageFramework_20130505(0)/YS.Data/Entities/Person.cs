namespace YS.Data.Entities
{
    public class Person
    {
        public virtual  string ID { get; set; }

        public virtual string Name { get; set; }

        public virtual string Sex { get; set; }

        public Person(string id,string name,string sex )
        {
            ID = id;
            Name = name;
            Sex = sex;
        }

        public Person()
        {
        }

    }
}
