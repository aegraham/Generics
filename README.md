# Generics
T standards for temple. You pass the object you wish to use into the class.

For example, instead of having a concreate class for a FilmList like below, we could use could create a GenericList and pass an object T in.
```sh
public void Add(Film film)
{
    throw new NotImplementedException();
}
```
```sh
public Film this[int index]
{
    get
    {
        throw new NotImplementedException();
    }
}
```
```sh
public class GenericList<T>
{
    public void Add(T value)
    {

    }

    public T this[int index]
    {
        get { throw new NotImplementedException();}
    }
}
```
The above generic list would allow us to use this list for multiple things.
```sh    
var numnbers = new GenericList<int>();
numnbers.Add(1);
```
```sh
var films = new GenericList<Film>();
films.Add(film);
```
Creating a generic list is more performant as its created at run time and ther eis no casting or boxing. It is also a create use of reusing code.

In practical terms you will be using generics instead of creating them, For example List<string>().
You can go to System.Collections.Generic to see also of the out of the box generics available in .NET.

# Dictionary

You need to set a key and value. Make sure you use correct naming. Prefix them with T and give them a correct name that describes it. For code readability.
```sh
public class GenericDictionary<TKey, TValue>
{
    public void Add(TKey key, TValue value)
    {

    }
}
```
Then to us this, we can set the TKey type and the TValue type and pass them in.
var dictionary = new GenericDictionary<int, Film>();
            dictionary.Add(123,new Film());
Constraints
Currently in the above code we can add what ever type of objects to our list or dictionary. There are no constraints, in this instance we probable would not what to do this.
Below is an of a function which will return the Max value
```sh
public class Utilities
{
    public int Max(int a, int b)
    {
        return a > b ? a : b;
    }
}
```
If we where to use generics it would be the following
```sh
public T Max<T>(T a, T b)
{
    return a > b ? a : b;
}
```
However this won’t work, as the complier doesn’t know the type of T. So it can’t compare the two objects. As they are both objects. We need to assume both A and B implement the IComparable interface. Which is an example of a constraint. 
```sh
public T Max<T>(T a, T b)  where T : IComparable
{
    return a.CompareTo(b) > 0 ? a : b;
}
```
Also the generic function is in a none generic class. The class doesn’t have to be generic. You can also change this to class level.
```sh  
public class Utilities<T> where T : IComparable
{
    public int Max(int a, int b) 
    {
        return a > b ? a : b;
    }

    public T Max(T a, T b)  
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}
```
# Other comparables.
Where T : IComparable – As implying a constraint to an interface.
Where T : Product – Imply a constraint to a class, in this example we are saying if T is a Product or any of its children or sub classes. 
Where T : struct – We can say T is a value type
Where T: class – It has to be a reference type
Where T: new() – Is an object that has a default constructor.
# Constraint to a class
```sh
public class Product
{
    public string Title { get; set; }

    public float Price { get; set; }
}
```
```sh
public class DiscountCalculator<TProduct> where TProduct : Product
{
    public float CalulateDiscount(TProduct product)
    {
        return product.Price;
    }
}
```
As the discount calculator is constraint to the Product class, we have access to all of its properties and can return the product price or do a discount calculation.

Constraint to Value Type
In C# value types can’t be null, we can create a nullable class to allow our value types to be null.
```sh
public class Nullable<T> where T : struct
{
    private object _value;

    public Nullable()
    {
    }

    public Nullable(T value)
    {
        _value = value;
    }

    public bool HasValue
    {
        get{ return _value != null; }
    }

    public T GetValueOrDefault()
    {
        if (HasValue)
        {
            return (T)_value;
        }

        return default(T);
    }
}
```
In the above class we can check if the object has a value. If it does it returns true otherwise it returns false. We also have a method call GetValueOrDefault(). If we where to pass a int, which has been set it till return that number, otherwise it will return 0.

The code below will return 1, as we have passed 1 in.
```sh
var number = new Nullable<int>(1);
Console.WriteLine("Has Value ?" + number.HasValue);
Console.WriteLine("Value = " + number.GetValueOrDefault());
```            
If we don’t pass a number in, it will return 0.
```sh
var number = new Nullable<int>();
Console.WriteLine("Has Value ?" + number.HasValue);
Console.WriteLine("Value = " + number.GetValueOrDefault());
```
We don’t’ need to create this in .NET as it already exists.  
 

# Constraint new()
The below code won’t work unless we create a constraint as it the compler doesn’t know what type of object it is.
```sh
public void DoSomething(T value)
{
    var obj = new T();
}
```
You can add multiple constraints to a class, so we can also add that it needs a empty constructure.
```sh
public class Utilities<T> where T : IComparable, new()
```
The above is now valid.

References

<a href="https://www.youtube.com/watch?v=gyal6TbgmSU">Programming with Mosh</a>
