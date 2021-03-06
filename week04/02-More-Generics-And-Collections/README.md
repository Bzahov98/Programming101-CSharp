## Linked List

We'll implement [Linked List data structure](https://www.cs.cmu.edu/~adamchik/15-121/lectures/Linked%20Lists/linked%20lists.html). For this purpose create a separate Class Library project LinkedList.

* Create a generic class `LinkedList<T>`
* Inside the class `LinkedList<T>` create a private nested class `Node`. For info on nested classes read [here](https://msdn.microsoft.com/en-us/library/ms173120.aspx) and [here](https://msdn.microsoft.com/en-us/library/s9f3ty7f%28v=vs.71%29.aspx)
  * In `Node` create a property `Value` of type `T`
  * In `Node` create a property `Next` of type `Node` for the next node in the list. Every node will point to the next one, only the last node won't point to anything
* In `LinkedList` create a property Head of type `Node` - it will contain the head of the list
* For the class `LinkedList` implement the operations (see the article above for details):
  * `Add(T value)` - adds element to the end of the list
  * `InsertAfter(T key, T value)` - adds an element after the specified element key
  * `InsertBefore(T key, T value)` - adds an element before the specified element key
  * `InsertAt(int index, T value)` - adds an element at the specified index
  * `Remove(T value)` - deletes the first occurence of the specified element
  * `RemoveAt(int index)` - removes the element at the specified index
  * `Clear()` - clears the elements of the list
  * Property `Count` for the cumber of elements in the list
  * Indexer `T this[int]` - gets or sets the value of the n-th element
* We should be able to iterate the `LinkedList` class with a for-loop. Hint: See [IEnumerable](https://msdn.microsoft.com/en-us/library/system.collections.ienumerable%28v=vs.110%29.aspx) and [foreach](https://msdn.microsoft.com/en-us/library/ttw7t8t6.aspx)

After creating the linked list class library, create a Console Application that demonstrates it with various data types.
For example:

```csharp
var list = new LinkedList<string>();
list.Add("x");
list.Add("g");
list.Add("s");

Console.WriteLine(list.Count); //output: 3

list.InsertAfter("g", "a");
list.InsertAt(10, "z"); //throws an exception - IndexOutOfRangeException
list.InsertAt(2, "z");
list.Remove("z");
list[1] = "m";

foreach(string value in list)
{
 Console.WriteLine(value);
}
//output:
//x
//m
//a
//s
```

## Dynamic Array

Now lets implement [Dynamic Array data structure](https://en.wikipedia.org/wiki/Dynamic_array), also called Vector. It is an array that resizes itself as we add new elements (the .Net class List<> is a dynamic array). Create it in a new Class Library project named DynamicArray.

The dynamic array should contain a generic type.

It will use an array instead of nodes to store information (Use a simple array and not the .Net class List<>)

For the class `DynamicArray<T>` implement the operations:

* Default constructor and a constructor that takes 1 argument for the initial capacity (the size of the internal array)
* Propert `Capacity` that returns the current capacity (the size of the internal array)
* Property `Count` for the cumber of elements in the dynamic array
* `Contains(T value)` - checks if a value is in the array
* `IndexOf(T value)` - returns the index of the first occurence of the given value, -1 if the value is not in the array
* `Add(T value)` - adds element to the end of the array
* `InsertAt(int index, T value)` - adds an element at the specified index
* `Remove(T value)` - deletes the first occurence of the specified element
* `RemoveAt(int index)` - removes the element at the specified index
* `Clear()` - clears the elements of the dynamic array
* Indexer `T this[int]` - gets or sets the value of the n-th element
* `T[] ToArray()` - copies the elements to a new simple array

The rate of growth of the dynamic array /Or how much our internal array will grow if the current is not enough to contain all the information/ should be:
* The array should start with a size of 10 if not set in the constructor.
* the array should double if the curent size is under 2048.
* If the size is above 2048 resize the array with capacity of 256.

When removing elements if the capicity is 1/3 of the total capacity, make the array shorter by half

## Map

Next implement the [map data structure](https://en.wikipedia.org/wiki/Associative_array). A map stores pair of keys and values like the .Net `Dictionary<T, U>` class. In a Class Library project named Map:

* Create a class `Map<T, U>` - T will be the type of the keys, U the type of the values
* In the class keep two collections - one for the keys and one for the values. Don't use the builting .Net types but one of the types you created above - `LinkedList` or `DynamicArray`
* Implement the following methods and properties for the Map:
 * Add(T key, U value)
 * ContainsKey(T key) - checks if the specified key is in the Map
 * ContainsValue(U value) - checks if the specified value is in the Map
 * Remove(T key)
 * Clear() - removes all elements
 * Indexer U this[T] - gets or sets the value with the specified key
    * if the element doesn't exist the getter should throw an error
    * if the element doesn't exist the setter should add it to the Map

## Bonus - HashMap

The implementation of the Map above is not optimal for storing key-value pairs. A much better implementation is the HashMap (or HashTable) data structure. In this implementation you'll need to use the `GetHashCode()` method of the keys. You can read more on HashMap [here](https://en.wikipedia.org/wiki/Hash_table)
