using Groups.Domain.Interfaces.DomainServices;
using Groups.Domain.Models.SqlServerModels;
using System.Diagnostics.CodeAnalysis;

namespace Groups.Domain.DomainServices
{
    public class ArticleServices : IArticleServices
    {
        public bool ValidateAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Nome de Autor Inválido!");

            return true;
        }

        public bool ValidateOnCreate(Article article)
        {
            ValidateAuthor(article.Writer!);
            ValidateTitle(article.Title!);
            ValidateYearWriting(article.YearWriting);

            return true;
        }

        public bool ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Título de Artigo Inválido");

            return true;
        }

        public bool ValidateYearWriting(int yearWriting)
        {
            int actualYear = DateTime.Now.Year;

            if (actualYear < yearWriting)
                throw new ArgumentException("O ano de Escrita não pode ser maior que o atual.");

            return true;
        }
    }
}
