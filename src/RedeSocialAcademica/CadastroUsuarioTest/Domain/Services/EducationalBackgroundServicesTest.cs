using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Domain.Services
{
    [TestClass]
    public class EducationalBackgroundServicesTest
    {
        private readonly IEducationalBackgroundServices _services;
        public EducationalBackgroundServicesTest()
        {
            _services = new EducationalBackgroundServices();
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("Course-Dates")]
        public void BeginDateLargerThanEndDate()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "Ciência da Computação",
                EducationalDegree = "Ensino Superior",
                Status = "Concluído",
                Institution = "Universidade de São Paulo",
                CourseBegin = DateTime.Now,
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "A data de Início do Curso deve ser menor que a data de Finalização.");
        }

        /// <summary>
        /// Case of test whenever the status of the course is "Concluído", but the date is minor than 
        /// <seealso cref="DateTime.Today"/>
        /// </summary>
        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("Course-Dates")]
        public void StatusConcludedButDateMinorThanDateTimeDotToday()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "Ciência da Computação",
                EducationalDegree = "Ensino Superior",
                Status = "Concluído",
                Institution = "Universidade de São Paulo",
                CourseBegin = new DateTime(2020, 1, 1),
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "Para um Curso Estar Concluído, ele precisa que a data final seja menor que a data de hoje.");
        }

        /// <summary>
        /// Checks whether the course name is invalid or it don't exists.
        /// </summary>
        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("CourseName")]
        public void InvalidCourseName()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "",
                EducationalDegree = "Ensino Superior",
                Status = "Concluído",
                Institution = "Universidade de São Paulo",
                CourseBegin = new DateTime(2020, 1, 1),
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "Nome de Curso Inválido!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("EducationalBackground")]
        public void InvalidEducationalBackground()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "Ciência da Computação",
                EducationalDegree = "Curso Livre",
                Status = "Concluído",
                Institution = "Universidade de São Paulo",
                CourseBegin = new DateTime(2020, 1, 1),
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "Escolha uma das Opções de Formação!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("Institutions")]
        public void InvalidInstitution()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "Ciência da Computação",
                EducationalDegree = "Ensino Superior",
                Status = "Concluído",
                Institution = "",
                CourseBegin = new DateTime(2020, 1, 1),
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "Nome de Instituição Inválido");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("Status")]
        public void InvalidCourseStatus()
        {
            EducationalBackground background = new EducationalBackground()
            {
                Course = "Ciência da Computação",
                EducationalDegree = "Ensino Superior",
                Status = "Concluded",
                Institution = "Universidade de São Paulo",
                CourseBegin = new DateTime(2020, 1, 1),
                CourseEnd = new DateTime(2024, 1, 1)
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => _services.ValidateOnCreateEducationalBackground(background));
            Assert.AreEqual(ex.Message, "Escolha uma das Opções de Formação!");
        }
    }
}
