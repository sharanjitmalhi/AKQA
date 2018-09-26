using NumericToWord.Entities;

namespace NumericToWord.Repository.Contracts
{
    public interface IConverterRepository
    {
        OutputModel ConvertToWord(InputModel input);
        string ConvertNumberToWord(string number);
    }
}
