namespace experiment.Classes
{
    public class SwitchExpression
    {

        /// <summary>
        /// Good old switch statement.
        /// </summary>
        public void GetFruitInfo_SwitchStatement(string fruitName)
        {
            switch (fruitName.ToLower())
            {
                case "apple":
                    Console.WriteLine("An apple a day keeps the doctor away!");
                    break;
                case "banana":
                    Console.WriteLine("Banana is good for potassium.");
                    break;
                case "orange":
                    Console.WriteLine("Oranges are a great source of Vitamin C.");
                    break;
                case "mango":
                    Console.WriteLine("Mangoes are delicious and refreshing.");
                    break;
                case "grapes":
                    Console.WriteLine("Grapes come in many varieties, red, green, and purple!");
                    break;
                case "strawberry":
                    Console.WriteLine("Strawberries are perfect for adding a sweet touch to desserts.");
                    break;
                default:
                    Console.WriteLine("Not a fruit.");
                    break;
            }
        }

        /// <summary>
        /// Switch expression implementation
        /// </summary>
        /// <param name="fruitName"></param>
        public string GetFruitInfo_SwitchExpression(string fruitName) => fruitName.ToLower() switch
        {
            "apple" => "An apple a day keeps the doctor away!",
            "banana" => "Banana is good for potassium.",
            "orange" => "Oranges are a great source of Vitamin C.",
            "mango" => "Mangoes are delicious and refreshing.",
            "grapes" => "Grapes come in many varieties, red, green, and purple!",
            "strawberry" => "Strawberries are perfect for adding a sweet touch to desserts.",
            _ => "Not a fruit."
        };

        public string GetFruitInfo_SwitchExpression(Fruit fruit) => fruit switch
        {
            { name: "apple", costInUSD: < 0.5m, producedIn: "Nepal"} => "An apple from Nepal which is cost efficient.",
            { name: "apple", costInUSD: > 2, producedIn: not "Nepal"} => "An apple which is not from Nepal and is expensive.",
            { name: "apple", costInUSD: < 1,  producedIn: _ } => "A juicy apple.",
            { name: "apple", costInUSD: _, producedIn: _ } => "An apple.",
            _ => "Not an apple."
        };

        public void DiscardExample(string? value, int? numberValue)
        {
            Console.WriteLine($"value: {value ?? "N/A"}, numberValue: {numberValue ?? 0}");
        }
    }

    public record Fruit(string name, decimal costInUSD, string? producedIn);
}
