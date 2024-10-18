using CadastroUsuario.Infra.BCryptServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuarioTest.Infra.BCryptServices
{
    [TestClass]
    public class PasswordHashingTest
    {
        [TestMethod]
        [TestCategory("TestFuncionality")]
        public void TestHashPassword()
        {
            string hash = PasswordHashing.HashPassword("Gustavo", "$2a$18$zmTN22SudHIRVk9Vg0RXTO");

            Assert.IsInstanceOfType(hash, typeof(string));
        }

        [TestMethod]
        [TestCategory("TestFuncionality")]
        public void TestGenerateSalt()
        {
            string salt = PasswordHashing.GenerateSalt(18);

            Assert.IsInstanceOfType(salt, typeof(string));
        }
    }
}
