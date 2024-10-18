using CadastroUsuario.Domain.Interfaces.Services;
using CadastroUsuario.Domain.Models;
using CadastroUsuario.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Domain.Services
{
    [TestClass]
    public class UserServicesTest
    {
        private readonly IUserServices services;
        public UserServicesTest()
        {
            services = new UserServices();
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Course")]
        public void InvalidCourseTest()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello39@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Nome do Curso Inválido!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-BirthDate")]
        public void InvalidBirthDate()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello39@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(2012, 10, 10),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "É necessário ser maior de 13 anos para se cadastrar!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-EducationalDegree")]
        public void InvalidEducationalDegree()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello39@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Livre",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Escolha uma das Opções de Formação!");
        }

        /// <summary>
        /// Test Case without e-mail
        /// </summary>
        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Email")]
        public void InvalidEmptyEmail()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "E-Mail Inválido!");
        }

        /// <summary>
        /// Testing an E-Mail Without At.
        /// </summary>
        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Email")]
        public void InvalidEmailWithoutAt()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcellogmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "E-Mail Inválido!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-FullName")]
        public void EmptyFullName()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Nome Completo Inválido!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-FullName")]
        public void FullNameWithoutSpaces()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "MarcelloMuller",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Nome Completo Inválido!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("ContainsAllCharacterTypes")]
        public void PasswordWithoutLowerLetters()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "V0V&EO&3B9&O7!W&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Senha Inválida! Faltam Letras Minúsculas!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("ContainsAllCharacterTypes")]
        public void PasswordWithoutUpperLetters()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "kaxc0bvc&q&fl3xpbe9&s7n!l&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Senha Inválida! Faltam Letras Maiúsculas!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("ContainsAllCharacterTypes")]
        public void PasswordWithoutNumbers()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "VkaxcbvVc&qEO&flxBpbe&sOn!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Senha Inválida! Faltam Números!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("ContainsAllCharacterTypes")]
        public void PasswordWithoutSymbols()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bvVcqEOfl3xBpbe9sO7nWlGKLM",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Senha Inválida! Faltam Letras Maiúsculas!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("PasswordWithLessThan16Characters")]
        public void PasswordWithLessThanSixteenCharacters()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bv!",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Crie uma Senha de ao Menos 16 Caracteres!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-Password")]
        [TestCategory("ContainsMaximumFiveCharactersOfTheSameTypeInASequence")]
        public void TestContainsMoreThanFiveCharactersOfTheSameTypeInASequence()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "marcelloMULLER640157@#$%¨¨",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (69) 3787-0248",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Crie uma Senha que Não Tenha mais de 5 Caracteres do Mesmo Tipo em Sequência!");
        }

        [TestMethod]
        [TestCategory("Failed")]
        [TestCategory("ApplicationUser-PhoneNumber")]
        public void TestWithNullPhoneNumber()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => services.ValidateUserOnCreate(user));
            Assert.AreEqual(ex.Message, "Número de Telefone Inválido!");
        }

        [TestMethod]
        [TestCategory("Success")]
        [TestCategory("ApplicationUser-Course")]
        [TestCategory("ApplicationUser-BirthDate")]
        [TestCategory("ApplicationUser-EducationalDegree")]
        [TestCategory("ApplicationUser-Email")]
        [TestCategory("ApplicationUser-FullName")]
        [TestCategory("ApplicationUser-Password")]
        public void TestSuccess()
        {
            ApplicationUser user = new ApplicationUser
            {
                FullName = "Marcello Muller",
                EMail = "mullermarcello@gmail.com",
                Password = "Vkaxc0bvVc&qEO&fl3xBpbe9&sO7n!Wl&",
                BirthDate = new DateTime(1991, 03, 15),
                Phone = "+55 (11) 98174-6450",
                EducationalDegree = "Mestrado",
                ActualCourse = "Ciências da Computação",
                Curriculum = "Desenvolvedor de Sistemas",
                Institution = "Etec",
                PasswordErrors = 0
            };

            bool resp = services.ValidateUserOnCreate(user);
            Assert.AreEqual(true, resp);
        }
    }
}
