using System;

namespace PatternsChsarp.Prototype
{
    public interface Prototype
    {
        public 
    }
    public class Person
    {
        private int _age;
        private DateTime _birthDate;
        private string _name;
        private IdInfo _idInfo;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public IdInfo Id
        {
            get { return _idInfo; }
            set { _idInfo = value; }
        }

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.Id = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(this._name)
        }
    }

    public class IdInfo
    {
        private int _id;
        public int IdNumber
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
