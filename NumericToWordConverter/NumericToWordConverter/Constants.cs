namespace NumericToWord
{
    public class Constants
    {
        #region Error Messages
        public const string NumberRangeValidationError = "Number range is between -999999999999999.99 to 999999999999999.99";
        public const string NumberRequiredValidationError = "Please enter the Number";
        public const string NameRequiredValidationError = "Please enter the Name";
        public const string GenericErrorMessage = "Oops! Something went wrong. Please try again";
        #endregion
        #region Number 
        public const decimal MaxLimit = (decimal)999999999999999.99;
        public const decimal MinLimit = (decimal)-999999999999999.99;
        #endregion
    }
}