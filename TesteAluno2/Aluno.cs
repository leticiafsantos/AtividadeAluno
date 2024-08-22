using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAluno
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string RM { get; set; } // RM agora é uma string
        public DateTime DataNascimento { get; set; }
        public List<float> Notas { get; private set; } // Lista de notas

        // Construtor para inicializar o aluno
        public Aluno(string nome, string rm, DateTime dataNascimento)
        {
            Nome = nome;
            RM = rm;
            DataNascimento = dataNascimento;
            Notas = new List<float>(); // Inicializa a lista de notas
        }

        // Calcula a idade do aluno
        public int CalcularIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;

            return idade;
        }

        // Valida o RM
        public static bool ValidarRM(string rm)
        {
            return rm.Length == 6;
        }

        // Adiciona uma nota à lista de notas
        public void AdicionarNota(float nota)
        {
            if (nota >= 0 && nota <= 10)
            {
                Notas.Add(nota);
            }
            else
            {
                Console.WriteLine("Nota inválida. A nota deve estar entre 0 e 10.");
            }
        }

        // Calcula a média das notas
        public float CalcularMedia()
        {
            if (Notas.Count == 0) return 0;
            float soma = 0;
            foreach (float nota in Notas)
            {
                soma += nota;
            }
            return soma / Notas.Count;
        }
    }
}
