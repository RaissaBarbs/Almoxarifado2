using Almoxarifado_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado_Teste
{
    [TestClass]
    public class TesteFuncionarios
    {
        List<Funcionarios> funcionarios;
        List<Departamentos> departamentos;
        public TesteFuncionarios() 
        {
            departamentos = new List<Departamentos>
            {
                new Departamentos
                {
                    idDep = 1,
                    Descricao = "RH"
                }

            };
            funcionarios = new List<Funcionarios>();
        } 
        [TestMethod]
        public void ErroDepartamentoObrigatorio()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var funcionario = new Funcionarios
                {
                    FuncNome = "Gabriela"
                };
                funcionario.VerificarSeTemDepartamento();
                funcionarios.Add(funcionario);
            });
        }
        [TestMethod]
        public void ErroDepartamentoNaoExistente()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var funcionario = new Funcionarios
                {
                    FuncNome = "Felipe"
                };
                funcionario.VerificarSeDepartamentoExiste(departamentos);
                funcionarios.Add(funcionario);
            });
        }
        [TestMethod]
        public void FuncionarioInserido()
        {
            var funcionario = new Funcionarios
            {
                FuncNome = "Mateus",
                idDepartamento= 1
            };
            funcionario.VerificarSeTemDepartamento();
            funcionario.VerificarSeDepartamentoExiste(departamentos);
            funcionarios.Add(funcionario);

        }
    }
}
