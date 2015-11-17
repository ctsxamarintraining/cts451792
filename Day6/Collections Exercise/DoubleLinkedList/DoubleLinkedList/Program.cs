using System;
using System.Collections;

namespace DoubleLinkedList
{

	public class Person
	{
		public string Id;
		public string Name;
		public string Location;

		public Person Next;
		public Person Previous;

		public Person(string id, string name, string location)
		{
			Id = id;
			Name = name;
			Location = location;
		}

		public Person()
		{
			Id = null;
			Name = null;
			Location = null;
		}

	}

	public class PersonList : IEnumerable
	{

		public Person Head;
		public Person Current;

		public PersonList()
		{
			Head = null;
			Current = null;
		}

		public void Insert(string id, string name, string location)
		{
			Person person = new Person(id, name, location);

			if (Head == null) 
			{
				Head = new Person();
				Head.Next = person;
				person.Previous = Head;
				Current = person;
			}
			else 
			{
				Current.Next = person;
				person.Previous = Current;
				Current = person;
			}

		}
			
		public IEnumerator GetEnumerator ()
		{
			return new PersonEnumerator (Head);
		}

	}

	class PersonEnumerator : IEnumerator{

		public PersonList personList = new PersonList();

		public Person currentNode;

		public PersonEnumerator(Person head){
			currentNode = head;
		}

		public object Current {
			get
			{
				return currentNode;
			}
		}

		public bool MoveNext ()
		{
			if (currentNode == null && personList.Head != null) {
				currentNode = personList.Head;
				return true;
			}
			if ( currentNode.Next != null) 
			{
				currentNode = currentNode.Next;
				return true;
			} 
			else 
			{
				return false;
			}

		}

		public void Reset ()
		{
			currentNode = personList.Head;
		}
	}


	class MainClass
	{
		public static void Main (string[] args)
		{

			PersonList personList = new PersonList();
			personList.Insert ("1", "A", "X");
			personList.Insert ("2", "B", "Y");
			personList.Insert ("3", "C", "Z");

			foreach (Person person in personList) 
			{
				Console.WriteLine (person.Id);
			}

		}
	}
}
