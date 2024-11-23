using System;
using System.Text.RegularExpressions;

namespace BuscaPersonalApi.Utils
{
    public class ValidarUtils
    {
        public bool ValidarId(int id)
        {
            return id > 0;
        }

        public bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            // Lógica para validar os dígitos verificadores do CPF (opcional)

            return true;
        }

        public bool ValidarCREF(string cref)
        {
            if (string.IsNullOrEmpty(cref))
            {
                return false;
            }

            string pattern = @"^\d{1,6}-[A-Za-z]/[A-Za-z]{2}$";
            return Regex.IsMatch(cref, pattern);
        }

        public bool ValidarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // Regex para validar email
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public bool ValidarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
            {
                return false;
            }

            // Exemplo: pelo menos 6 caracteres e 1 caractere especial
            return senha.Length >= 6 && Regex.IsMatch(senha, @"[!@#$%^&*(),.?""{}|<>]");
        }

        public bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                return false;
            }

            // Regex para validar telefone no formato brasileiro
            return Regex.IsMatch(telefone, @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$");
        }

        public bool ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return false;
            }

            // Exemplo: Nome não deve conter números ou caracteres especiais
            return Regex.IsMatch(nome, @"^[a-zA-ZÀ-ÿ0-9\s]+$");
        }

        public bool ValidarDataNascimento(DateOnly dataNascimento)
        {
            DateOnly dataAtual = DateOnly.FromDateTime(DateTime.Now);

            // Exemplo: A pessoa deve ter pelo menos 18 anos
            if (dataNascimento.AddYears(18) > dataAtual)
            {
                return false;
            }

            return true;
        }

        public bool ValidarEspecialidade(string especialidade)
        {
            if (string.IsNullOrEmpty(especialidade))
            {
                return false;
            }

            // Exemplo: Especialidade deve ter no máximo 50 caracteres
            return especialidade.Length <= 50;
        }
    }
}
