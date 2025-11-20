using System.Collections.Generic;

public class ManualBookData
{
    private List<(string customer, string reply)> dialoguePairs = new List<(string, string)>
    {
        ("hello", "hello what would you like to order?"),
        ("i would like to order 2 food", "okay it is coming right up"),
        ("...", "so how was your day?"),
        ("today's weather is great", "yes, it is i hope you have a wonderful day"),
        ("thankyou", "you are very welcomed")
    };

    private int currentIndex = 0;

    public (string customer, string reply) GetCurrentDialogue() => dialoguePairs[currentIndex];

    public string GetCurrentCustomerLine() => dialoguePairs[currentIndex].customer;
    public string GetCurrentCorrectReply() => dialoguePairs[currentIndex].reply;

    public void NextDialogue()
    {
        currentIndex++;
        if (currentIndex >= dialoguePairs.Count)
            currentIndex = 0;
    }
}
