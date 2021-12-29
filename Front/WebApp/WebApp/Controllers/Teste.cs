/*
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC01.Presentation.Models;
using ProjetoMVC01.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoMVC01.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model,
            [FromServices] UsuarioRepository usuarioRepository)
        {
            //verificar se os campos da model passaram nas regras de validação..
            if (ModelState.IsValid)
            {
                try
                {
                    //buscar o usuario no banco de dados atraves do email e senha..
                    var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);

                    //verificando se o usuario não possui perfil definido
                    usuario.Perfil = usuario.Perfil != null ? usuario.Perfil : string.Empty;

                    //verificar se o usuario foi encontrado..
                    if (usuario != null)
                    {
                        //Criando a identificação do usuario..
                        var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, usuario.Email), //email do usuário autenticado
                            new Claim(ClaimTypes.Role, usuario.Perfil) //perfil do usuário autenticado
                        },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        //Gravando a identificação do usuario em um Cookie!
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        //gravando os dados do usuario autenticado em sessão..
                        HttpContext.Session.SetString("nome_usuario", usuario.Nome);
                        HttpContext.Session.SetString("email_usuario", usuario.Email);
                        HttpContext.Session.SetString("perfil_usuario", usuario.Perfil);

                        //redirecionar para a página /Home/Index..
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Acesso negado. Email e senha inválidos.";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            //destruir o cookie que contem a autorização do usuario..
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //apagar os valores gravados em sessão
            HttpContext.Session.Remove("nome_usuario");
            HttpContext.Session.Remove("email_usuario");
            HttpContext.Session.Remove("perfil_usuario");

            //redirecionar de volta para a página de login..
            return RedirectToAction("Login", "Account");
        }
    }
}
*/