namespace CeramicaCSharp.Utils
{
    using System;

    public class CpfValidator
    {
        public static bool ValidateCPF(string cpf)
        {
            cpf = new string(cpf.ToCharArray().Where(c => char.IsDigit(c)).ToArray());

            if (cpf.Length != 11)
            {
                return false;
            }

            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int digitoVerificador1 = (resto < 2) ? 0 : 11 - resto;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int digitoVerificador2 = (resto < 2) ? 0 : 11 - resto;

            return (digitoVerificador1 == int.Parse(cpf[9].ToString()) && digitoVerificador2 == int.Parse(cpf[10].ToString()));
        }
    }
}
