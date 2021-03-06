





using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>
    ///     Enumerates from @this to toCharacter.
    /// </summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="toCharacter">to character.</param>
    /// <returns>An enumerator that allows foreach to be used to process @this to toCharacter.</returns>
    public static IEnumerable<char> To(this char @this, char toCharacter)
    {
        bool reverseRequired = (@this > toCharacter);

        char first = reverseRequired ? toCharacter : @this;
        char last = reverseRequired ? @this : toCharacter;

        IEnumerable<char> result = Enumerable.Range(first, last - first + 1).Select(charCode => (char) charCode);

        if (reverseRequired)
        {
            result = result.Reverse();
        }


        return result;
    }
}