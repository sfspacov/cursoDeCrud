using System;

namespace Crud.Dto
{
    public class UsuarioDto
    {
        public string Name { get; set; }
        public string NewCpf { get; set; }
        public string Cpf { get; set; }
        public int IdUf { get; set; }
        public int IdCity { get; set; }

        public virtual void IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Preencha o nome");
            if (string.IsNullOrEmpty(Cpf))
                throw new ArgumentException("Preencha o cpf");
            if (!ValidCpf(Cpf) || NewCpf != null && !ValidCpf(NewCpf))
                throw new ArgumentException("Cpf inválido");
            if (IdUf == 0)
                throw new ArgumentException("Selecione um UF");
            if (IdCity == 0)
                throw new ArgumentException("Selecione uma cidade");
        }

        private static bool ValidCpf(string vrCPF)
        {
            var valor = vrCPF.Replace(".", "").Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}