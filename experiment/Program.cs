// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using experiment.Classes;

// constant pattern
Console.WriteLine("____________________ Constant pattern_________________________");
string message1 = "Welcome back!";
if (message1 is null)
{
    Console.WriteLine("Message is null");
}

// relational pattern
Console.WriteLine("____________________ Relational pattern_________________________");
string message = "Welcome back!";
if(message is not null && message.Length is not < 20)
    Console.WriteLine(message);
else Console.WriteLine("Welcome back to FC 24!");

var person1 = new Person(17, "ram bahadur", DateTime.Parse("2004-01-01"));
Console.WriteLine(person1.ToString());

// property pattern
Console.WriteLine("____________________ Property pattern_________________________");
if (person1 is { Age: < 21 }) 
    Console.WriteLine($"{person1.Name} is not eligible to drink beer. Try milk.");
else Console.WriteLine("Here is your beer. Drink responsibly.");

bool isBornInMarch(DateTime dob)
{
    if (dob is { Month: 3 })
        return true;
    else return false;
}
Console.WriteLine($"{person1.Name} is born is march? {isBornInMarch(person1.DateofBirth)}.");


// type pattern
Console.WriteLine("____________________ Type pattern_________________________");
void isNameOrAge(object data)
{
    if (data is string name)
        Console.WriteLine($"{name} is a name.");
    else if (data is int age)
        Console.WriteLine($"{age} ia an age.");
    else Console.WriteLine("Invalid");
}
isNameOrAge("ram bahadur");
isNameOrAge(21);


void isGreaterThan21(object age)
{
    if (age is int ageIntValue || (age is string ageStringValue && int.TryParse(ageStringValue, out ageIntValue) && ageIntValue is < 21))
        Console.WriteLine($"Age is {ageIntValue}. You cannot play this game.");
    else
        Console.WriteLine($"You can play this game.");
}
isGreaterThan21("42");
isGreaterThan21(15);

//switch expression
Console.WriteLine("____________________ Switch expression _________________________");
int discountPercent = 0;
switch (discountPercent)
{
    case 10:
        Console.WriteLine("10% percent discount.");
        break;
    case 20:
        Console.WriteLine("20% percent discount.");
        break;
    case 30:
        Console.WriteLine("30% percent discount.");
        break;
    default:
        Console.WriteLine("No discount!");
        break;
}

var switch_eg = new SwitchExpression();
switch_eg.GetFruitInfo_SwitchStatement("grapes");

Console.WriteLine(switch_eg.GetFruitInfo_SwitchExpression("strawberry")); 


Fruit fruit = new Fruit(name: "apple", costInUSD: 0.75m, producedIn: "Nepal");
Fruit fruit1 = new Fruit(name: "apple", costInUSD: 4.5m, null);

Console.WriteLine(switch_eg.GetFruitInfo_SwitchExpression(fruit)); 
Console.WriteLine(switch_eg.GetFruitInfo_SwitchExpression(fruit1));


// using discard pattern
Console.WriteLine("____________________ discard pattern_________________________");
string someVal = "44";
if (int.TryParse(someVal, out _))
    Console.WriteLine("someVal is a int.");

// deconstruct example
Console.WriteLine("____________________ deconstruct object _________________________");
var recommendations = new List<LaptopRecommendation>
{
    new LaptopRecommendation(1200, "acer"),
    new LaptopRecommendation(600, "dell")
};

var acerRecommendations = recommendations
                        .Where(recommendation =>
                        {
                            (decimal budget, string brand) = recommendation;
                            return brand is "acer" && budget < 1300;
                        })
                        .ToList();

Console.WriteLine(string.Join(", ", acerRecommendations.Select(x => x.brand)));


//positional pattern
Console.WriteLine("____________________ positional pattern_________________________");
var laptop1 = new LaptopRecommendation(1200, "acer"); 
var laptop2 = new LaptopRecommendation(600, "dell");
var laptop3 = new LaptopRecommendation(4000, "any");
var laptop4 = new LaptopRecommendation(2500, "any");

string getLaptopDetail(LaptopRecommendation info) => info switch
{
    ( <= 1000 and > 500, "acer") => "You should get a Acer Aspire 5.",
    ( <= 1400 and > 1000, "acer") => "You should get a Acer Nitro.",
    ( <= 1500 and > 1000, "acer") => "You should get a Acer Predator.",
    ( <= 1000 and > 500, "dell") => "You should get a Dell Inspiron.",
    ( <= 1400 and > 1000, "dell") => "You should get a Dell G series PC.",
    ( <= 1500 and > 1000, "dell") => "You should get a Dell Alienware.",
    ( >= 3000, object) => "You should either get a Mac Pro M2 Series or a beefy razer series laptop. (I would get a beefy razer laptop)",
    _ => "I recommend you get any laptop from Lenovo Legion series.",
};

Console.WriteLine(getLaptopDetail(laptop1));
Console.WriteLine(getLaptopDetail(laptop2));
Console.WriteLine(getLaptopDetail(laptop3));
Console.WriteLine(getLaptopDetail(laptop4));



// var pattern
Console.WriteLine("____________________ var pattern_________________________");
var listOfAnimal = new List<string>() { "dog", "cat", "rhino"};
var listOfRandomItems = new List<object>() { "Ram", "hari", "John", 421, "bijay", "macafee", "apple", "dog", "cat" };
bool containsAnimal(List<object> randomStuff)
{
    return randomStuff.Intersect(listOfAnimal) is var animalCount && animalCount.Count() > 2;
}
Console.WriteLine($"listOfRandomItems contains animal? : {containsAnimal(listOfRandomItems)}");

string someData = null;
string someDataBak = "N/A";
string returnData = someData ?? someDataBak;
Console.WriteLine(returnData);


// list pattern 
Console.WriteLine("____________________List pattern_________________________");
var simpleListOfName = new List<string> { "Blueskie", "Jon", "Jonsky", "Angel", "Bret" };
if(simpleListOfName is ["Blueskie", _, _, _, _])
    Console.WriteLine("First name is Blueskie.");

if(simpleListOfName is [_, _, "Kumar", ..])
    Console.WriteLine("Third name is Kumar.");
else Console.WriteLine("Third name is not kumar.");

if (simpleListOfName is [.., "Bret"])
    Console.WriteLine("Last name is Bret.");

var listOfNumbers = new List<int> { 765, 2, 34, 5, 2, 3, 33, 66 };
var firstAndFourth = listOfNumbers is [int firstVal, _, _, int fourthVal, ..] ? $"First num is:{firstVal}, fourth num is: {fourthVal}" : "N/A";
Console.WriteLine(firstAndFourth);

var numResult = listOfNumbers switch
{
    [_, int second, ..] => $"Second num is: {second}",
    [.., int last] => $"Last num is: {last}",
    _ => "I dont care",
};
Console.WriteLine(numResult);


using var emp = new StreamReader("../../../email.csv");

while (!emp.EndOfStream)
{
    string[]? empInfo = emp.ReadLine()?.Split(',');

    var checkVerifiedEmployee = empInfo switch
    {
    [string email, ..] => email.Split("@").Contains("example.com") ? $"{email} is Verified Example worker." : $"{email} is Unverified user.",
        _ => "Nothing matched."
    };

    Console.WriteLine(checkVerifiedEmployee);
}


while (!emp.EndOfStream)
{
    string[]? empInfo = emp.ReadLine()?.Split(',');

    var greetAccordingly = empInfo switch
    {
        [_, _, _, string lastName, "manager"] => $"Good Evening, Manager {lastName}.",
        [_, string id, _, ..] => int.TryParse(id, out int empId) && (empId > 2 && empId < 10) ? "You are top 10 employee to join da Company." : "You joined the company after 10 people joined.",
        [_, string id, ..] => int.TryParse(id, out int empId) && empId is 1 ? "Hello Mr CEO." : "Well, Hello there :-) ",
        _ => "Nothing matched."
    };

    Console.WriteLine(greetAccordingly);
}


// ternary operator
int age = 17;
string consoleMessage = age > 18 ? "Eliglble to vote." : "Not eligible to vote";
Console.WriteLine(consoleMessage); 


/// <summary>
/// Data structure to recommend laptop.
/// </summary>
/// <param name="_budget"></param>
/// <param name="_brand"></param>
public struct LaptopRecommendation(decimal _budget, string _brand)
{
    public decimal budget = _budget;
    public string brand = _brand;

    public void Deconstruct(out decimal LaptopBudget, out string LaptopBrand) => (LaptopBudget, LaptopBrand) = (budget, brand);
}



/// <summary>
/// Person object as an example.
/// </summary>
/// <param name="_age"></param>
/// <param name="_name"></param>
/// <param name="_dob"></param>
public class Person(int _age, string _name, DateTime _dob)
{
    public int Age { get; set; } = _age;
    public string Name { get; set; } = _name;
    public DateTime DateofBirth { get; set; } = _dob;

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Date of birth: {DateofBirth}";
    }

    public void Deconstruct(out int personAge, out string personName, out DateTime personDateofBirth) => (personAge, personName, personDateofBirth) = (Age, Name, DateofBirth);
}

