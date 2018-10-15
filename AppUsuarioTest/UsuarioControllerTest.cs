using AppUsuario.Controllers;
using AppUsuario.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppUsuarioTest
{
    public class UsuarioControllerTest
    {
        private Mock<IDbUsuarioRepository> _usuRepMock;
        UsuarioController _controller;

        public UsuarioControllerTest()
        {
            _usuRepMock = new Mock<IDbUsuarioRepository>();
            _controller = new UsuarioController(_usuRepMock.Object);

        }

        [Fact]
        public void GetTest_RetornaTipoListaUsuarios_QuandoListaTodosUsuarios()
        {

            IEnumerable<Usuario> mockList = new List<Usuario>() { };
             
             var result = _usuRepMock.Setup(r => r.FindAll())
                                      .Returns(mockList);           
            Assert.IsType<ActionResult<IEnumerable<Usuario>>>(result);

        }

        [Fact]
        public void GetTest_RetornaTipoaUsuarios_QuandoUsuario()
        {
            Usuario mock = new Usuario();
            var result = _usuRepMock.Setup(r => r.Find(1))
                                     .Returns(mock);
            Assert.IsType<ActionResult<Usuario>>(result);

        }
    }
}
