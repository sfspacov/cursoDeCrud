using Crud.Controllers;
using Crud.Dto;
using Crud.Interfaces;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Crud.Test
{
    [TestClass]
    public class UnitTest1
    {
        readonly UsuarioController _usuarioContoller;
        readonly IUf _uf;
        readonly ICity _city;
        readonly IUsuario _usuario;

        public UnitTest1()
        {
            _uf = new Uf();
            _city = new City();
            _usuario = new Usuario();
            _usuarioContoller = new UsuarioController(_usuario);
        }



        [TestMethod]
        public void UsuarioSave_Ok()
        {
            var uf = _uf.GetAll().FirstOrDefault();

            if (uf == null)
            {
                CreateUfs();
                CreateCities();
                uf = _uf.GetAll().FirstOrDefault();
            }

            var novoUsuario = new UsuarioDto
            {
                Name = GenerateName(10),
                Cpf = GenerateCpf(),
                IdCity = _city.GetByIdUf(uf.Id).FirstOrDefault().Id,
                IdUf = uf.Id
            };

            var result = _usuarioContoller.Save(novoUsuario);
            var createdResult = result as CreatedResult;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
        }
        private void CreateUfs()
        {
            _uf.Create(new Uf
            {
                Name = "Amazonia",
                Abbreviation = "AM"
            });
            _uf.Create(new Uf
            {
                Name = "Bahia",
                Abbreviation = "BA"
            });
            _uf.Create(new Uf
            {
                Name = "Rio de Janeiro",
                Abbreviation = "RJ"
            });
            _uf.Create(new Uf
            {
                Name = "São Paulo",
                Abbreviation = "SP"
            });
        }

        private void CreateCities()
        {
            var ufs = _uf.GetAll();
            _city.Create(new City
            {
                Capital = true,
                IdUf = ufs.First(x => x.Abbreviation == "AM").Id,
                Name = "Manaus"
            });
            _city.Create(new City
            {
                Capital = true,
                IdUf = ufs.First(x => x.Abbreviation == "BA").Id,
                Name = "Salvador"
            });
            _city.Create(new City
            {
                Capital = true,
                IdUf = ufs.First(x => x.Abbreviation == "BA").Id,
                Name = "Ilhéus"
            });
            _city.Create(new City
            {
                IdUf = ufs.First(x => x.Abbreviation == "RJ").Id,
                Name = "Niterói",
            });
            _city.Create(new City
            {
                Capital = true,
                IdUf = ufs.First(x => x.Abbreviation == "RJ").Id,
                Name = "Rio de Janeiro",
            });
            _city.Create(new City
            {
                IdUf = ufs.First(x => x.Abbreviation == "SP").Id,
                Name = "Ubatuba"
            });
            _city.Create(new City
            {
                IdUf = ufs.First(x => x.Abbreviation == "SP").Id,
                Name = "São Paulo"
            });
        }
        private static string GenerateName(int len)
        {
            Random r = new();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z" };
            string[] vowels = { "a", "e", "i", "o", "u", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
        private static string GenerateCpf()
        {
            int soma = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente += resto;
            semente = semente.Insert(3,".").Insert(7,".").Insert(11,"-");

            return semente;
        }
    }
}
