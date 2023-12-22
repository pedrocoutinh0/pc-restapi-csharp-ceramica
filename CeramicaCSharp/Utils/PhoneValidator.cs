using PhoneNumbers;

namespace CeramicaCSharp.Utils
{
    public class PhoneValidator
    {
        public static bool VerifyPhoneNumber(string telefone)
        {
            try
            {
                telefone = "+" + telefone;

                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber numero = phoneUtil.Parse(telefone, "BR");

                return phoneUtil.IsValidNumber(numero);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
