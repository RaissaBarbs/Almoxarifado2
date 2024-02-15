using Almoxarifado_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado_Teste
{
    [TestClass]

    public class TesteDepartamentos
    {
        [TestMethod]
        public void ErroBuscarFuncionario()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var departamento = new Departamentos
                {
                    Descricao = "RH",
                    Funcionarios = new List<Funcionarios>
                    {
                        new Funcionarios
                        {
                            FuncNome = "Pedrinho"
                        }, 
                        new Funcionarios
                        {
                            FuncNome = "Ana Julia"
                        }
                    }
                };

                var funcionario = departamento.BuscarFuncionario("Pedro Afonso");
            });
        }
        
        [TestMethod]
        public void BuscarFuncionario()
        {
            var departamento = new Departamentos
            {
                Descricao = "RH",
                Funcionarios = new List<Funcionarios> 
                { 
                    new Funcionarios
                    {
                        FuncNome = "Pedrinho"
                    } 
                }
            };

            var funcionario = departamento.BuscarFuncionario("Pedrinho");
        }

        [TestMethod]
        public void ErroBuscarCargoFuncionario()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                var esperado = "professora";
                var departamento = new Departamentos
                {
                    Descricao = "RH",
                    Funcionarios = new List<Funcionarios>
                    {
                        new Funcionarios
                        {
                            FuncNome = "Pedrinho",
                            Cargo = new Cargos
                            {
                                CargosNome = "marceneiro"
                            }
                        },

                        new Funcionarios
                        {
                            FuncNome = "Ana Julia",
                             Cargo = new Cargos
                             {
                                CargosNome = "professora"
                             }
                        }
                    }
                };

                var funcionario = departamento.BuscarFuncionario("Pedro Afonso");
                Assert.AreEqual(esperado, funcionario.PegarCargo());
            });
        }
        [TestMethod]
        public void BuscarCargoFuncionario()
        {
            var esperado = "professora";
            var departamento = new Departamentos
            {
                Descricao = "RH",
                Funcionarios = new List<Funcionarios>
                    {
                        new Funcionarios
                        {
                            FuncNome = "Pedrinho",
                            Cargo = new Cargos
                            {
                                CargosNome = "marceneiro"
                            }
                        },

                        new Funcionarios
                        {
                            FuncNome = "Ana Julia",
                             Cargo = new Cargos
                             {
                                CargosNome = "professora"
                             }
                        }
                    }
            };

            var funcionario = departamento.BuscarFuncionario("Ana Julia");
            Assert.AreEqual(esperado, funcionario.PegarCargo());
        }
    }
}
