using System;
using System.Collections;

namespace LinkedList
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

	}

	public class PersonList
	{
		
		public Person Head;

		public PersonList()
		{
			Head = null;
		}

		public Person Insert(string id, string name, string location)
		{
			Person person = new Person(id, name, location);
			person.Next = Head;

			if (Head != null) 
			{
				Head.Previous = person;
			}

			Head = person;

			return person;
		}

	}

	class PersonEnumerator : IEnumerator{
		
		public PersonList personList;

		public Person currentNode;

		public object Current {
			get
			{
				return currentNode;
			}
		}

		public bool MoveNext ()
		{
			if (personList == null) 
			{
				personList = new PersonList();
				personList.Insert ("1", "A", "X");
				personList.Insert ("2", "B", "Y");
				personList.Insert ("3", "C", "Z");
			}
			if (currentNode == null && personList.Head != null) 
			{
				currentNode = personList.Head;
				return true;
			} 
			if ( currentNode.Next != null) 
			{
				currentNode = currentNode.Next;
				return true;
			} 
			else {
				return false;
			}

		}

		public void Reset ()
		{
			currentNode = personList.Head;
		}
	}

	class PersonEnumerable : IEnumerable{
		public IEnumerator GetEnumerator (){
			return new PersonEnumerator ();
		}
	}

	 
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			PersonEnumerable personEnumerable = new PersonEnumerable();

			foreach (Person person in personEnumerable) 
			{
				Console.WriteLine (person.Id);
			}

		}
	}
}
