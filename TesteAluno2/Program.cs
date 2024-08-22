using System;
using TesteAluno2;

namespace TesteAluno
{
    class Program
    {
        static void Main()
        {
            // Solicita ao usuário que insira seu nome
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            // Solicita ao usuário que insira seu RM
            string rm;
            while (true)
            {
                Console.Write("Digite seu RM (6 dígitos): ");
                rm = Console.ReadLine();
                if (Aluno.ValidarRM(rm))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("RM inválido. O RM deve ter 6 dígitos.");
                }
            }

            // Solicita ao usuário que insira sua data de nascimento
            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Digite sua data de nascimento (formato: dd/MM/yyyy): ");
                string inputDataNascimento = Console.ReadLine();
                if (DateTime.TryParseExact(inputDataNascimento, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
                {
                    DateTime dataMinima = new DateTime(1907, 1, 1); // Define o ano mínimo permitido
                    if (dataNascimento > DateTime.Today)
                    {
                        Console.WriteLine("Data inválida. A data de nascimento não pode ser uma data futura.");
                    }
                    else if (dataNascimento < dataMinima)
                    {
                        Console.WriteLine("Data inválida. A data de nascimento não pode ser anterior a 01/01/1907.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Data inválida. Por favor, use o formato dd/MM/yyyy.");
                }
            }

            // Cria um novo objeto Aluno
            Aluno aluno = new Aluno(nome, rm, dataNascimento);

            // Adiciona notas
            while (true)
            {
                Console.Write("Digite a nota (ou 'fim' para terminar): ");
                string inputNota = Console.ReadLine();
                if (inputNota.ToLower() == "fim")
                    break;

                if (float.TryParse(inputNota, out float nota))
                {
                    aluno.AdicionarNota(nota);
                }
                else
                {
                    Console.WriteLine("Nota inválida. Por favor, digite um número.");
                }
            }

            // Calcula a idade
            int idade = aluno.CalcularIdade();

            // Calcula a média
            float media = aluno.CalcularMedia();

            // Exibe as informações
            Console.WriteLine($"Nome: {aluno.Nome}");
            Console.WriteLine($"RM: {aluno.RM}");
            Console.WriteLine($"Data de Nascimento: {aluno.DataNascimento.ToShortDateString()}");
            Console.WriteLine($"Sua idade é: {idade} anos.");
            Console.WriteLine($"Média das notas: {media:F2}");
        }
    }
}
